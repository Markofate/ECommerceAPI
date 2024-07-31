import React, { useEffect, useState } from 'react';
import axios from 'axios';
import "./static/cart.css";
import Swal from 'sweetalert2';
import 'primeicons/primeicons.css';

const Cart = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [subtotal, setSubtotal] = useState(0);
  const email = localStorage.getItem('email');
  const shipping = 3.99;
  const tax = 2.00;

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        setLoading(true);

        const productResponse = await axios.get(`https://localhost:7227/User/${email}/Cart/Products`);
        const products = productResponse.data;

        const cartResponse = await axios.get(`https://localhost:7227/cartproducts/${email}`);
        const cartProducts = cartResponse.data;

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

  const handleClick = () =>{
    if(products.length === 0){
      Swal.fire({
        title: 'No Products At Cart!',
        text: 'Add Some Products Before You Create An Order.',
        icon: 'error'
      });
      return;
    }
    window.location.replace(`/create-order`);
  }

  const removeProductFromCart = async (productId) => {
    try {
      Swal.fire({
        title: "Are you sure?",
        text: "Do you want to remove the product?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, remove it!"
      }).then((result) => {
        if (result.isConfirmed) {
          axios.delete(`https://localhost:7227/RemoveProductFromCart/${productId}/${email}`);
          setProducts(products.filter(product => product.productId !== productId));
          location.reload();
        }
      });
    } catch (error) {
        console.error('Error removing product from cart:', error);
    }
  };

  if (loading) return <p>Loading...</p>;
  if (error === "Request failed with status code 400") return <p>No Products To Show</p>;
  if (error) return <p>Error: {error}</p>;

  let total = subtotal + shipping + tax;
  if (products.length === 0) {
    total = 0;
  }

  return (
    <div className='cart-container'>
      <div className='cart-products'>
        <h1 className="pi pi-shopping-cart cart-icon"> Cart</h1>
        <p>{products.length} items</p>
        {products.length === 0 && !loading && <p>No products available</p>}
        {products.map(product => (
          <div className="cart-product" key={product.productId}>
            <div className='cart-product-image'>
              {product.photos && <img src={product.photos} alt={product.product} />}
            </div>
            <div className="cart-product-info">
              <h3>{product.product}</h3>
              <p>{product.description}</p>
              <p>Price: {product.price} {product.currency}</p>
              <p>Quantity: {product.quantity}</p>
            </div>
            <div className="cart-product-remove">
              <i
                className='pi pi-trash'
                onClick={() => removeProductFromCart(product.productId)}
                style={{ cursor: 'pointer'}}
              />
            </div>
          </div>
        ))}
      </div>
      <div className='cart-summary'>
        <h2>Order summary</h2>
        <p>Subtotal: {subtotal.toFixed(2)}</p>
        <p>Shipping: {shipping.toFixed(2)}</p>
        <p>Tax: {tax.toFixed(2)}</p>
        <h3>Total: ${total.toFixed(2)}</h3>
        <button className="btn btn-success" onClick={handleClick}>Continue To Payment</button>
      </div>
    </div>
  );
};

export default React.memo(Cart);
