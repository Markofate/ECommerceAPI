import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './navbar.css';
import logo from "/src/assets/logo.png";

const Navbar = () => {
    const [itemCount, setItemCount] = useState(0);
    const email = localStorage.getItem('email'); // Email bilgisi

    useEffect(() => {
        const fetchCartItemCount = async () => {
            if (!email) {
                return; // Eğer email yoksa, axios isteği yapılmaz
            }
            try {
                const response = await axios.get(`https://localhost:7227/CartProducts/${email}`);
                setItemCount(response.data.length); // response.data içerisindeki ürünlerin sayısını kullanın
            } catch (error) {
                console.error('Error fetching cart item count:', error);
            }
        };

        fetchCartItemCount();
    }, [email]);

    const handleLogout = () => {
        localStorage.removeItem('email');
        window.location.replace("/login");
    };
    const handleLogin = () => {
        window.location.replace('/login');
    };
    const handleRegister = () =>{
        window.location.replace('/register');
    }

    return (
        <header>
            <div className="navbar navbar-expand-sm">
                <div className="container-fluid">
                    <img src={logo} style={{ height: 40, width: 40 }} alt="logo" />
                    <a className="navbar-brand" href="/">ECommerce</a>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav mr-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link" aria-current="page" href="/products">Products</a>
                            </li>
                            {email && (
                                <>
                                    <li className="nav-item">
                                        <a className="nav-link" href="/Favorites">Favorites</a>
                                    </li>
                                </>
                            )}
                        </ul>
                        {email && (
                            <div className="d-flex align-items-center ml-auto">
                                <a className="nav-link" href="/cart">
                                    <i className="pi pi-shopping-cart cart-icon"></i>
                                    {itemCount > 0 && <span className="cart-item-count">({itemCount})</span>}
                                </a>
                            </div>
                        )}
                        {email
                        ? <></>
                        : <button className='btn btn-secondary ml-3' onClick={handleRegister}>Register</button>
                         }
                        {email
                        ? <button className='btn btn-secondary ml-3' onClick={handleLogout}>Logout</button>
                        : <button className='btn btn-secondary ml-3' onClick={handleLogin}>Login</button>
                         }

                            
                    </div>
                </div>
            </div>
        </header>
    );
};

export default Navbar;
