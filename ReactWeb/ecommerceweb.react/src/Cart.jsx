import React, { useEffect, useState } from 'react';
import axios from 'axios';
import "./static/cart.css";

const Cart = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [subtotal, setSubtotal] = useState(0);
  const shipping = 3.99;
  const tax = 2.00;

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        setLoading(true);

        // İlk API çağrısı: ürün bilgileri
        const productResponse = await axios.get('https://localhost:7227/User/1/Cart/Products');
        const products = productResponse.data;

        // İkinci API çağrısı: sepet bilgileri
        const cartResponse = await axios.get('https://localhost:7227/cartproducts');//buraya userId eklenmeli büyük bir database de tüm ürünelri kontrol etmek sıkıntı çıkarırı
        const cartProducts = cartResponse.data;

        // Ürün bilgileri ile sepet bilgilerini birleştir
        const mergedProducts = products.map(product => {
          const cartProduct = cartProducts.find(cp => cp.productId === product.productId);
          return {
            ...product,
            quantity: cartProduct ? cartProduct.quantity : 0,
          };
        });

        setProducts(mergedProducts);

        // Subtotal hesaplaması
        const calculatedSubtotal = mergedProducts.reduce((total, product) => {
          const price = parseFloat(product.price);
          const quantity = parseInt(product.quantity, 10);
          return total + (isNaN(price) || isNaN(quantity) ? 0 : price * quantity);
        }, 0);
        setSubtotal(calculatedSubtotal);

        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProducts();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  const total = subtotal + shipping + tax;

  return (
    <div className='cart-container'>
      <div className='cart-products'>
        <h1>Basket</h1>
        <p>{products.length} items</p>
        {products.length === 0 && !loading && <p>No products available</p>}
        {products.map(product => (
          <div className="cart-product" key={product.productId}>
            <div className='cart-product-image'>
              {product.photos && <img src={product.photos} alt={product.product}></img>}
            </div>
            <div className="cart-product-info">
              <h3>{product.product}</h3>
              <p>{product.description}</p>
              <p>Price: {product.price} {product.currency}</p>
              <p>Quantity: {product.quantity}</p>
            </div>
          </div>
        ))}
      </div>
      <div className='cart-summary'>
        <h2>Order summary</h2>
        <p>Subtotal: ${subtotal.toFixed(2)}</p>
        <p>Shipping: ${shipping.toFixed(2)}</p>
        <p>Tax: ${tax.toFixed(2)}</p>
        <h3>Total: ${total.toFixed(2)}</h3>
        <button className="btn btn-success">Create Order</button>
      </div>
    </div>
  );
};

export default React.memo(Cart);
