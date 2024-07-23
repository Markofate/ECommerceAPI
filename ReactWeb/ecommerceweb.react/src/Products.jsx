import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';
import 'primeicons/primeicons.css';


const Products = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        setLoading(true);
        const response = await axios.get('https://localhost:7227/products');
        setProducts(response.data);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProducts();
  }, []);



  if (loading) return <p id='loading'>Loading...</p>;
  if (error) return <p id='error'>Error: {error}</p>;

  return (
    <>
      <div className='row mt-4'>
        {products.length === 0 && !loading && <p>No products available</p>}
        {products.map(product => (
          <div className="col-2 mb-2 d-flex align-items-stretch" key={product.productId}>
            <div className='card'>
            <Link to={`/product/${product.productId}`}>
              <div id='imageWrapper'>
                  {product.photos && <img className="card-img-top mb-2" id='productPhoto' src={product.photos} alt={product.product}></img>}
              </div>
            </Link>
              <i className="pi pi-heart favorite-icon mr-3"></i>
              <div className="card-body d-flex flex-column">
               
              <Link to={`/product/${product.productId}`}>
                  <h3 className='card-title '>{product.product}</h3>
              </Link>   
                <p>Price: {product.price} {product.currency}</p> 
                <p className='card-text'>Description: {product.description}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
};

export default React.memo(Products);