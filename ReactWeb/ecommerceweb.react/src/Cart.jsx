import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import "./static/cart.css";

const Cart = () => {
    const { id } = useParams();
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    useEffect(() => {
        const fetchProducts = async () => {
        try {
            setLoading(true);               //userId gönderip cartProducts çekiyoruz. Idnin nerden alınacağına karar verilecek
            const response = await axios.get('https://localhost:7227/User/${id}/Cart/Products');
            console.log(response);
            setProducts(response.data);
            setLoading(false);
        } catch (err) {
            setError(err.message);
            setLoading(false);
        }
    };

    fetchProducts();
  }, [id]);//[id]

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
    return(
        <>
        <div className='col mt-4'>
          {products.length === 0 && !loading && <p>No products available</p>}
          {products.map(product => (
            <div className="row-2 mb-2 d-flex align-items-stretch" key={product.productId}>
              <div className='card'>
                <div id='imageWrapper'>
                    {product.photos && <img className="card-img-top mb-2" id='productPhoto' src={product.photos} alt={product.product}></img>}
                </div>
                <i className="pi pi-heart mr-3"></i>
                <div className="card-body d-flex flex-column">
                    <h3 className='card-title '>{product.product}</h3>   
                  <p>Price: {product.price} {product.currency}</p> 
                  <p className='card-text'>Description: {product.description}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </>
    );
  };//şualık userıdyi 1 e backend de set ederek çalıştırabildik. login eklendikten sonra tekrar bakmak gerek

 export default React.memo(Cart);