import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './navbar.css';

const Navbar = () => {
    const [itemCount, setItemCount] = useState(0);
    const email = "kemal@gmail.com"; // Email bilgisi

    useEffect(() => {
        const fetchCartItemCount = async () => {
            try {
                // Email bilgisi URL yoluna ekleniyor
                const response = await axios.get(`https://localhost:7227/CartProducts/${email}`);
                // Eğer dönen veri içinde itemCount varsa
                setItemCount(response.data.length); // response.data içerisindeki ürünlerin sayısını kullanın
            } catch (error) {
                console.error('Error fetching cart item count:', error);
            }
        };

        fetchCartItemCount();
    }, [email]);

    return (
        <header>
            <div className="navbar navbar-expand-sm">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">ECommerce</a>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav mr-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link" aria-current="page" href="/products">Products</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/Favorites">Favorites</a>
                            </li>
                        </ul>
                        <div className="d-flex align-items-center ml-auto">
                            <a className="nav-link" href="/cart">
                                <i className="pi pi-shopping-cart cart-icon"></i>
                                {itemCount > 0 && <span className="cart-item-count">({itemCount})</span>}
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    );
};

export default Navbar;
