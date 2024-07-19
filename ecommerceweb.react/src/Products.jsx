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
        <div>
            <h1>Products</h1>
            <ul>
                {products.map(product => (
                    <li key={product.productId}>
                        <h2>{product.product}</h2>
                        <p>Description: {product.description}</p>
                        <p>Price: {product.price} {product.currency}</p>
                        <p>Stock: {product.stock}</p>
                        <p>Sales: {product.sales}</p>
                        <p>Category ID: {product.categoryId}</p>
                        {product.photos && <img id='productPhoto' src={product.photos} alt={product.product} />}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Products;
