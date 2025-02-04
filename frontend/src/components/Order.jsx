import {
    Modal, ModalOverlay, ModalContent, ModalHeader,
    ModalFooter, ModalBody, ModalCloseButton} from '@chakra-ui/react'
import { useState, useEffect } from "react";
import axios from "axios";

export default function Order({isOpen, onClose, orderId}) {

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [order, setOrder] = useState(null);

    useEffect(() => {
        const fetchOrder = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`http://localhost:5000/api/v1/orders/${orderId}`);
                setOrder(response.data);
            } catch (error) {
                setError("Could not fetch data");
                console.error(error);
            } finally {
                setLoading(false);
            }
        };

        if (orderId) {
            fetchOrder();
        }
    }, [orderId]);

    return (
        <>
            <Modal isOpen={isOpen} onClose={onClose} isCentered>
                <ModalOverlay />
                <ModalContent>
                    <ModalHeader>Детали заказа</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        {loading ? (
                            <p>Загрузка...</p>
                        ) : error ? (
                            <p>{error}</p>
                        ) : order ? (
                            <div>
                                <p>Номер заказа: {order.id}</p>
                                <p>Город отправителя: {order.origin_city}</p>
                                <p>Адрес отправителя: {order.origin_address}</p>
                                <p>Город получателя: {order.destination_city}</p>
                                <p>Адрес получателя: {order.destination_address}</p>
                                <p>Вес груза: {order.weight}</p>
                                <p>Дата забора груза: {new Date(order.accepted_at).toLocaleDateString()}</p>
                            </div>
                        ) : (
                            <p>Ошибка</p>
                        )}
                    </ModalBody>
                    <ModalFooter justifyContent='center'>
                        <button onClick={onClose}>Закрыть</button>
                    </ModalFooter>
                </ModalContent>
            </Modal>
        </>
    )
}