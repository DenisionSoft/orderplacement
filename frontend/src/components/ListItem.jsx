export default function ListItem({ order, onOrderOpen }) {
    return (
        <div className="order-item" onClick={() => onOrderOpen(order.id)}>
            <p>№ {order.id}</p>
            <p>{order.origin_city}, {order.origin_address} ➡ {order.destination_city}, {order.destination_address}</p>
            <p>{order.weight} кг</p>
            <p>📅 {new Date(order.accepted_at).toLocaleDateString()}</p>
        </div>
    );
}

