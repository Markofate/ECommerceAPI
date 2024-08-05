import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import 'primeicons/primeicons.css';
import "./static/products.css";

const Products = () => {
  const [products, setProducts] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [favorites, setFavorites] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const email = localStorage.getItem('email');

  useEffect(() => {
    const fetchProductsAndFavorites = async () => {
      try {
        setLoading(true);
        const productResponse = await axios.get('https://localhost:7227/products');
        const filteredProducts = productResponse.data.filter(product => product.stock > 0);
        setProducts(filteredProducts);
        setFilteredProducts(filteredProducts); // Başlangıçta tüm ürünleri göster

        const categoryResponse = await axios.get('https://localhost:7227/categories');
        setCategories(categoryResponse.data);

        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
      try {
        if (!email) {
          return;
        }
        const favoriteResponse = await axios.get(`https://localhost:7227/UserFavorites/${email}`); 
        if (favoriteResponse.data.length === 0) {return}
        const favoriteProductIds = favoriteResponse.data.map(fav => fav.productId);
        setFavorites(favoriteProductIds);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      } finally {
        setLoading(false);
      }
    };

    fetchProductsAndFavorites();
  }, []);

  const handleCategorySelect = (categoryId) => {
    setSelectedCategory(categoryId);
    if (categoryId === 0) {
      setFilteredProducts(products);
    } else {
      const filtered = products.filter(product => product.categoryId === categoryId);
      setFilteredProducts(filtered);
    }
  };

  const handleFavoriteToggle = async (productId) => {
    try {
      if (!email) {
        return;
      }
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
    <div className='products-page'>
      <div className='category-menu'>
        <h3>Categories</h3>
        <ul>
          <li onClick={() => handleCategorySelect(0)} className={!selectedCategory ? 'selected' : ''}>All</li>
          {categories.map(category => (
            <li 
              key={category.categoryId} 
              onClick={() => handleCategorySelect(category.categoryId)}
              className={selectedCategory === category.categoryId ? 'selected' : ''}
            >
              {category.name}
            </li>
          ))}
        </ul>
      </div>
      <div className='products-container'>
        <div className='row mt-4'>
          {filteredProducts.length === 0 && !loading && <p>No products available</p>}
          {filteredProducts.map(product => (
            <div className="col-2 mb-2 d-flex align-items-stretch" key={product.productId}>
              <div className='card'>
                <Link to={`/product/${product.productId}`}>
                  <div id='imageWrapper'>
                    {product.photos && <img className="card-img-top mb-2" id='productPhoto' src={product.photos} alt={product.product}></img>}
                  </div>
                </Link>
                <i 
                  className={`pi favorite-icon mr-3 ${favorites.includes(product.productId) ? 'pi-heart-fill' : 'pi-heart'}`} 
                  style={{ cursor:'pointer',backgroundColor: 'transparent', color: favorites.includes(product.productId) ? 'red' : 'black' }}
                  onClick={() => handleFavoriteToggle(product.productId)}
                ></i>
                <div className="card-body d-flex flex-column">
                  <Link to={`/product/${product.productId}`}>
                    <h3 className='card-title '>{product.product}</h3>
                  </Link>
                  <p> {product.price} {product.currency}</p>
                  <p className='card-text'> {product.description}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default React.memo(Products);
