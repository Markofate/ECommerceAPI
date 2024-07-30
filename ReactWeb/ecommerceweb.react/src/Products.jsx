import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import 'primeicons/primeicons.css';
import "./static/productDetail.css";
import Draggable from 'react-draggable';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [favorites, setFavorites] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const email = "kemal@gmail.com"; // Kullanıcı emailini buraya ekleyin

  useEffect(() => {
    const fetchProductsAndFavorites = async () => {
      try {
        setLoading(true);
        const productResponse = await axios.get('https://localhost:7227/products');
        const filteredProducts = productResponse.data.filter(product => product.stock > 0);
        setProducts(filteredProducts);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
      try{
        const favoriteResponse = await axios.get(`https://localhost:7227/UserFavorites/1`); 
        if (favoriteResponse.data.length === 0) {return}
        const favoriteProductIds = favoriteResponse.data.map(fav => fav.productId);
        setFavorites(favoriteProductIds);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }finally{
        setLoading(false);
      }
    };

    fetchProductsAndFavorites();
  }, []);

  const handleFavoriteToggle = async (productId) => {
    try {
      let updatedFavorites;
      if (favorites.includes(productId)) {
        await axios.delete(`https://localhost:7227/RemoveFromFavorite/${email}/${productId}`);
        updatedFavorites = favorites.filter(id => id !== productId);
      } else {
        await axios.post(`https://localhost:7227/AddToFavorite/${email}/${productId}`);
        updatedFavorites = [...favorites, productId];
      }
      setFavorites(updatedFavorites);
    } catch (err) {
      console.error("Failed to update favorites", err);
    }
  };

  if (loading) return <p id='loading'>Loading...</p>;
  if (error) return <p id='error'>Error: {error}</p>;

  return (
    <>
      <div className='row mt-4'>
        {products.length === 0 && !loading && <p>No products available</p>}
        {products.map(product => (
          <Draggable defaultPosition={{x: 0, y: 0}} >
              <div className="col-2 mb-2 d-flex align-items-stretch" key={product.productId}>
                <div className='card'>
                  <Link to={`/product/${product.productId}`}>
                    <div id='imageWrapper'>
                      {product.photos && <img className="card-img-top mb-2" id='productPhoto' src={product.photos} alt={product.product}></img>}
                    </div>
                  </Link>
                  <i 
                    className={`pi favorite-icon mr-3 ${favorites.includes(product.productId) ? 'pi-heart-fill' : 'pi-heart'}`} 
                    style={{ color: favorites.includes(product.productId) ? 'red' : 'black' }}
                    onClick={() => handleFavoriteToggle(product.productId)}
                  ></i>
                  <div className="card-body d-flex flex-column">
                    <Link to={`/product/${product.productId}`}>
                      <h3 className='card-title '>{product.product}</h3>
                    </Link>
                    <p>Price: {product.price} {product.currency}</p>
                    <p className='card-text'>Description: {product.description}</p>
                  </div>
                </div>
              </div>
          </Draggable>
        ))}
      </div>
    </>
  );
};

export default React.memo(Products);
