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