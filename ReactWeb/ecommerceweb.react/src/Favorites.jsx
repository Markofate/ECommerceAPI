import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './static/favorites.css';
import Swal from 'sweetalert2';

const Favorites = () => {
  const [favorites, setFavorites] = useState([]);
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const email = localStorage.getItem('email');

  useEffect(() => {
    const fetchProductsAndFavorites = async () => {
      try {
        setLoading(true);
        // Fetch all products
        const productResponse = await axios.get('https://localhost:7227/products');
        const filteredProducts = productResponse.data.filter(product => product.stock > 0);
        setProducts(filteredProducts);

        
        const favoriteResponse = await axios.get(`https://localhost:7227/UserFavorites/${email}`); // 1 UserId dir loginle paslanmalıdır
        if (favoriteResponse.data.length === 0) {
          setFavorites([]);
          setLoading(false);
          return;
        }

        const favoriteProductIds = favoriteResponse.data.map(fav => fav.productId);
        const favoriteProducts = filteredProducts.filter(product => favoriteProductIds.includes(product.productId));
        setFavorites(favoriteProducts);
        
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProductsAndFavorites();
  }, []);

  const handleRemoveFromFavorites = async (productId) => {
    try {
      const result = await Swal.fire({
        title: "Are you sure?",
        text: "Do you want to remove the product?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, remove it!"
      });
      if (result.isConfirmed) {
        await axios.delete(`https://localhost:7227/RemoveFromFavorite/${email}/${productId}`);
        Swal.fire({
          title: "Removed!",
           text:"The product has been removed from favorites.",
            icon:"success"
          }).then(()=>location.reload());
      }
    } catch (err) {
      Swal.fire({
        title: "Failed To Remove From Favorites",
        text: err.message,
        icon: "error"
      });
      console.error('Failed to remove product from favorites', err);
    }
  }

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className='favorites-container'>
      <h1>Favorites</h1>
      {favorites.length === 0 && !loading && <p>No favorite products available</p>}
      <div className='favorites-grid'>
        {favorites.map(product => (
          <div className='favorites-item' key={product.productId}>
            <Link to={`/product/${product.productId}`}>
              <img className='favorites-image' src={product.photos} alt={product.product} />
            </Link>
            <div className='favorites-info'>
              <Link to={`/product/${product.productId}`}>
                <h3>{product.product}</h3>
              </Link>
              <p>Price: {product.price} {product.currency}</p>
              <button className='remove-button' onClick={() => handleRemoveFromFavorites(product.productId)}>
                Remove from Favorites
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Favorites;
