import logoImage from '../assets/versta-logo.png'
import { GoPlus } from "react-icons/go";

export default function NavBar({onOpen}) {

    return (
        <>
            <div className="container">
                <img
                    className="logo"
                    src={logoImage}
                    alt="logo"
                />
                <button className="button" onClick={onOpen}> {<GoPlus />} Создать заказ</button>

            </div>
        </>
    );
}