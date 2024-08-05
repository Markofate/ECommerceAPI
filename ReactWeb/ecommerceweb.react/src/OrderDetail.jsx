import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import "./static/orderdetail.css";

const OrderDetail = () => {
  const { orderId } = useParams();
  const [order, setOrder] = useState(null);
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchOrderDetails = async () => {
      try {
        const orderResponse = await axios.get(`https://localhost:7227/order/${orderId}`);
        setOrder(orderResponse.data);

        const orderProductsResponse = await axios.get(`https://localhost:7227/OrderProducts/${orderId}`);
        const productIds = orderProductsResponse.data.map(op => op.productId);

        const productRequests = productIds.map(productId => axios.get(`https://localhost:7227/product/${productId}`));
        const productResponses = await Promise.all(productRequests);

        const fetchedProducts = productResponses.map(response => response.data);
        const mergedProducts = orderProductsResponse.data.map(orderProduct => {
          const product = fetchedProducts.find(p => p.productId === orderProduct.productId);
          return {
            ...product,
            quantity: orderProduct.quantity,
          };
        });

        setProducts(mergedProducts);
      } catch (err) {
        console.log(err);
        setError('Error fetching order details.');
      } finally {
        setLoading(false);
      }
    };

    fetchOrderDetails();
  }, [orderId]);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div className="order-detail-container">
      {order && (
        <div className="order-summary">
          <h2>Order Details</h2>
          <p><strong>Order ID:</strong> {order.orderId}</p>
          <p><strong>Date:</strong> {new Date(order.date).toLocaleDateString()}</p>
          <p><strong>Status:</strong> {order.status}</p>
          <p><strong>Total Amount:</strong> {order.totalAmount} <i className='pi pi-turkish-lira' style={{fontSize:'1em'}}></i></p>
          <p><strong>Address:</strong> {order.address}</p>
        </div>
      )}
      <div className="order-products">
        <h3>Products</h3>
        {products.length === 0 ? (
          <p>No products found for this order.</p>
        ) : (
          <ul className="product-list">
            {products.map(product => (
              <li key={product.productId} className="product-item">
                <img src={product.photos} alt={product.product} className="product-image" />
                <div className="product-details">
                  <p><strong>Product:</strong> {product.product}</p>
                  <p><strong>Description:</strong> {product.description}</p>
                  <p><strong>Price:</strong> {product.price} {product.currency}</p>
                  <p><strong>Quantity:</strong> {product.quantity}</p>
                </div>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
};

export default OrderDetail;
