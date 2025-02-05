import {
    Modal, ModalOverlay, ModalContent, ModalHeader,
    ModalFooter, ModalBody, ModalCloseButton
} from '@chakra-ui/react';
import { useState } from 'react';
import PropTypes from 'prop-types';

export default function NewOrderForm({ isOpen, onClose }) {

    const [formData, setFormData] = useState({
        origin_city: '',
        origin_address: '',
        destination_city: '',
        destination_address: '',
        weight: 0,
        accepted_at: ''
    });

    const onAddHandler = (event) => {
        const { name, value, type } = event.target;

        if (type === "date") {
            const date = new Date(value);
            const isoDate = date.toISOString();
            setFormData((prevData) => ({
                ...prevData,
                [name]: isoDate,
            }));
            return;
        }

        setFormData((prevData) => ({
            ...prevData,
            [name]: type === "number" ? parseFloat(value) || 0 : value,
        }));
    };

    const onSubmitCreate = (e) => {
        e.preventDefault();

        fetch('http://localhost:5000/api/v1/orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        })
            .then((response) => response.json())
            .then((data) => {
                console.log('Success:', data);
                setFormData({
                    origin_city: '',
                    origin_address: '',
                    destination_city: '',
                    destination_address: '',
                    weight: 0,
                    accepted_at: ''
                });
                onClose();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    };

    return (
        <>
            <Modal isOpen={isOpen} onClose={onClose} isCentered>
                <ModalOverlay />
                <ModalContent>
                    <ModalHeader>Новый заказ</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        <form onSubmit={onSubmitCreate} className="form-container">
                            <label htmlFor="origin_city">Город отправителя</label>
                            <input type="text" id="origin_city" name="origin_city" className="textInput" onChange={onAddHandler} required />

                            <label htmlFor="origin_address">Адрес отправителя</label>
                            <input type="text" id="origin_address" name="origin_address" className="textInput" onChange={onAddHandler} required />

                            <label htmlFor="destination_city">Город получателя</label>
                            <input type="text" id="destination_city" name="destination_city" className="textInput" onChange={onAddHandler} required />

                            <label htmlFor="destination_address">Адрес получателя</label>
                            <input type="text" id="destination_address" name="destination_address" className="textInput" onChange={onAddHandler} required />

                            <label htmlFor="weight">Вес груза</label>
                            <input type="number" id="weight" name="weight" className="textInput" step="0.0001" min="0" onChange={onAddHandler} required />

                            <label htmlFor="accepted_at">Дата забора груза</label>
                            <input type="date" id="accepted_at" name="accepted_at" className="dataInput" onChange={onAddHandler} required />

                            <button type="submit" className="submit-button">Создать заказ</button>
                        </form>
                    </ModalBody>
                    <ModalFooter justifyContent='center'>
                    </ModalFooter>
                </ModalContent>
            </Modal>
        </>
    );
}

NewOrderForm.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
};