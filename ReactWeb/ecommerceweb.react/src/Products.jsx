import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Products = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
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

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <>
        <div className='col-sm' >
            <h1>Products</h1>
                {products.map(product => (
                    <div className='card' key={product.productId}>
                        {product.photos && <img className="card-img-top" id='productPhoto' src={product.photos} alt={product.product}></img>}
                        <h2>{product.product}</h2>
                        <div className="card-body">
                        <p>Description: {product.description}</p>
                        <p>Stock: {product.stock}</p>
                        <p>Price: {product.price} {product.currency}</p>
                        </div>
                    </div>
                ))}
        </div>
        </>
    );
};

export default Products;
