import Navbar from './components/Navbar';
import OrderList from './components/OrderList';
import { useDisclosure } from "@chakra-ui/react";
import NewOrderForm from "./components/NewOrderForm.jsx";
import Order from "./components/Order.jsx";
import { useState } from 'react';

export default function App() {
    const newOrderModal = useDisclosure();
    const orderModal = useDisclosure();
    const [selectedOrderId, setSelectedOrderId] = useState(null);

    const handleOrderOpen = (orderId) => {
        setSelectedOrderId(orderId);
        orderModal.onOpen();
    };

    return (
        <>
            <Navbar isOpen={newOrderModal.isOpen} onClose={newOrderModal.onClose} onOpen={newOrderModal.onOpen} />
            <NewOrderForm isOpen={newOrderModal.isOpen} onClose={newOrderModal.onClose} />
            <Order isOpen={orderModal.isOpen} onClose={orderModal.onClose} orderId={selectedOrderId} />
            <OrderList onOrderOpen={handleOrderOpen} />
        </>
    );
}