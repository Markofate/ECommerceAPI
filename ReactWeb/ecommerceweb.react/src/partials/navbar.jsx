import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './navbar.css';
import logo from "/src/assets/logo.png";
import { Route } from 'react-router-dom';

const Navbar = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
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
    useEffect(() => {
        const fetchUserData = async () => {
          try {
            const response = await axios.get(`https://localhost:7227/User/Profile/${email}`);
            const user = response.data;
            setFirstName(user.firstName);
            setLastName(user.lastName);
          } catch (err) {
            console.error('Error fetching user data:', err);
          }
        };
        fetchUserData();
    })

    const handleLogout = () => {
        localStorage.removeItem('email');
        window.location.replace("/login");
    };
    const handleCart = () => {
        if (Route =='/cart') {
            return;
        }
        
        window.location.replace('/cart');
    }
    const handleLogin = () => {
        window.location.replace('/login');
    };
    const handleRegister = () =>{
        window.location.replace('/register');
    }
    const handleUser = () =>{
        window.location.replace('/Profile');
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
                                    <i className="pi pi-shopping-cart cart-icon" onClick={handleCart}></i>
                                    {itemCount > 0 && <span className="cart-item-count mr-2">({itemCount})</span>}

                            </div>
                        )}
                        {email
                        ?  <> <div className='Username mr-2 ml-2'><strong>{firstName} {lastName}</strong> </div> <i className='pi pi-user' style={{cursor: 'pointer'}} onClick={handleUser} ></i> </>
                        : <></>
                         }
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
