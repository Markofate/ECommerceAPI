import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';

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

  const handleClick = (id) => {
    navigate(`/product/${id}`);
  };

  if (loading) return <p id='loading'>Loading...</p>;
  if (error) return <p id='error'>Error: {error}</p>;

  return (
    <>
      <div className='row mt-4'>
        {products.length === 0 && !loading && <p>No products available</p>}
        {products.map(product => (
          <div className="col-2 mb-2 d-flex align-items-stretch" key={product.productId}>
            <Link to={`/product/${product.productId}`}>
            <div className='card'>
              <div id='imageWrapper'>
                  {product.photos && <img className="card-img-top mb-2" id='productPhoto' src={product.photos} alt={product.product}></img>}
              </div>
              <div className="card-body d-flex flex-column">
                  <h3 className='card-title'>{product.product}</h3>
                <p className='card-text'>Description: {product.description}</p>
                <p>Stock: {product.stock}</p>
                <p>Price: {product.price} {product.currency}</p>
              </div>
            </div>
            </Link>
          </div>
        ))}
      </div>
    </>
  );
};

export default React.memo(Products);