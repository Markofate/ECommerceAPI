import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import "./static/productDetail.css";
import { Button } from 'primereact/button';
import Swal from 'sweetalert2';


const ProductDetail = () => {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [quantity, setQuantity] = useState(1);
  const email = "kemal@gmail.com";//user emaili veya userIdsi gerek
  useEffect(() => {
    const fetchProduct = async () => {
      try {
        setLoading(true);
        const response = await axios.get(`https://localhost:7227/product/${id}`);
        setProduct(response.data);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProduct();
  }, [id]);

  const handleAddToCart = async () => {
    try {
      await axios.post(`https://localhost:7227/AddProductToCart/${id}/${email}/${quantity}`);
        Swal.fire(
          "Added To Cart",
          "Product Added to Cart Successfully",
          "success"
        ).then(function() {
          window.location = "/cart";
      });
    } catch (err) {
      Swal.fire(
        "Failed To Add To Cart",
        err.response.data.message,
        "error"
      );
    }
  };

  const handleQuantityChange = (e) => {
    setQuantity(e.target.value);
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className='product-detail'>
      {product && (
        <div className="product-card">
          <div className="product-image-wrapper">
            {product.photos && <img className="product-image" src={product.photos} alt={product.product} />}
          </div>
          <div className="product-info">
            <h2 className="product-title">{product.product}</h2>
            <p className="product-price">${product.price}</p>
            <p className="product-text">{product.description}</p>
            <div className="product-options">
              <label className="product-label">Quantity</label>
              <select className="product-select" value={quantity} onChange={handleQuantityChange}>
                {[...Array(product.stock).keys()].map(n => (
                  <option key={n + 1} value={n + 1}>{n + 1}</option>
                ))}
              </select>
            </div>
            <Button className="product-button" label='Add To Cart' onClick={handleAddToCart}/>
            <i className="pi pi-shopping-cart cart-icon"></i>
            <div className="product-faq">
              <h4 className="faq-title">Title</h4>
              <p className="faq-text">Answer the frequently asked question in a simple sentence, a longish paragraph, or even in a list.</p>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ProductDetail;
