import React, { useState } from 'react';
import axios from 'axios';
import './static/createorder.css';
import { Link, redirect } from 'react-router-dom';
import Swal from 'sweetalert2';

const CreateOrder = () => {
  const [address, setAddress] = useState('');
  const [cardNumber, setCardNumber] = useState('');
  const [cardExpiry, setCardExpiry] = useState('');
  const [cardCVC, setCardCVC] = useState('');
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);
  const email = localStorage.getItem('email');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
        const response = await axios.post(`https://localhost:7227/AddProductsToOrder/${email}/${address}`);
        console.log('Order created:', response.data);
        Swal.fire(
            "Order Created",
            "Order Created Successfully",
            "success"
          ).then(()=>window.location = "/products");
          redirect("/products")
      } catch (err) {
        Swal.fire(
            "Couldn't Create Order",
            "Failed To Create Order",
            "error"
            
          );
        setError('Failed to create order');
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

  return (
    <div className="create-order-container">
      <h1>Create Order</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="address">Address:</label>
          <input
            type="text"
            id="address"
            value={address}
            onChange={(e) => setAddress(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="cardNumber">Card Number:</label>
          <input
            type="text"
            id="cardNumber"
            value={cardNumber}
            onChange={(e) => setCardNumber(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="cardExpiry">Card Expiry:</label>
          <input
            type="text"
            id="cardExpiry"
            value={cardExpiry}
            onChange={(e) => setCardExpiry(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="cardCVC">Card CVC:</label>
          <input
            type="text"
            id="cardCVC"
            value={cardCVC}
            onChange={(e) => setCardCVC(e.target.value)}
            required
          />
        </div>
            <button type="submit" className="btn btn-dark" disabled={loading} >
            {loading ? 'Creating Order...' : 'Create Order'}
            </button>
        {error && <p className="error">{error}</p>}
      </form>
    </div>
  );
};

export default CreateOrder;
