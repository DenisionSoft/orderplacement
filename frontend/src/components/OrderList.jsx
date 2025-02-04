import { useState, useEffect } from "react";
import axios from "axios";
import ListItem from "./ListItem.jsx";

const ITEMS_PER_PAGE = 2;

export default function OrderList({ onOrderOpen }) {
    const [orders, setOrders] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [loading, setLoading] = useState(false);
    const [totalItems, setTotalItems] = useState(0);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchOrders = async () => {
            setLoading(true);
            const offset = (currentPage - 1) * ITEMS_PER_PAGE;
            try {
                const response = await axios.get(`http://localhost:5000/api/v1/orders?offset=${offset}&limit=${ITEMS_PER_PAGE}`);
                setOrders(response.data.items);
                setTotalItems(response.data.total);
            } catch (error) {
                setError("Could not fetch data");
                console.error(error);
            } finally {
                setLoading(false);
            }
        };

        fetchOrders();
    }, [currentPage]);

    const totalPages = Math.ceil(totalItems / ITEMS_PER_PAGE);

    const handlePageChange = (newPage) => {
        setCurrentPage(newPage);
    };

    const renderPaginationButtons = () => {
        const pageButtons = [];
        for (let i = 1; i <= totalPages; i++) {
            pageButtons.push(
                <button key={i} onClick={() => handlePageChange(i)} disabled={i === currentPage}>
                    {i}
                </button>
            );
        }
        return pageButtons;
    };

    if (loading) return <p className="loading">Загрузка...</p>;
    if (error) return <p className="error">{error}</p>;

    return (
        <div className="order-list-container">
            <h2>Список заказов</h2>
            {orders.length > 0 ? (
                orders.map((order) => (
                    <ListItem key={order.id} order={order} onOrderOpen={onOrderOpen} />
                ))
            ) : (
                <p>Заказов нет</p>
            )}
            <div className="pagination-buttons">
                {renderPaginationButtons()}
            </div>
        </div>
    );
}
