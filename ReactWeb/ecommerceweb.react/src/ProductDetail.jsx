import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const ProductDetail = () => {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

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

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className='ProductDetail'>
      {product && (
        <>
          <h2>{product.product}</h2>
          <p>Description: {product.description}</p>
          <p>Stock: {product.stock}</p>
          <p>Price: {product.price} {product.currency}</p>
          {product.photos && <img src={product.photos} alt={product.product} />}
        </>
      )}
    </div>
  );
};

export default ProductDetail;
