using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CartProductService: ICartProductService
    {
        private ICartProductRepository _cartProductRepository;
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;

        public CartProductService(ICartProductRepository cartProductRepository, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartProductRepository = cartProductRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public void AddCartProduct(CartProducts product)
        {
            _cartProductRepository.Add(product);
        }
        public void UpdateCartProduct(CartProducts product)
        {
            _cartProductRepository.Update(product);
        }
        public void DeleteCartProduct(CartProducts product)
        {
            _cartProductRepository.Delete(product);
        }
        public List<CartProducts> GetCartProducts()
        {
            return _cartProductRepository.GetAll();
        }

        public CartProducts GetCartProductById(int id)
        {
            return _cartProductRepository.Get(cp => cp.CartProductId == id);
        }

        public List<CartProducts> GetCartProductsByCartId(int cartId)
        {
            return _cartProductRepository.GetAll(cp => cp.CartId == cartId);
        }

        public void AddProductToCart(int productId, int cartId, int quantity)
        {
            CartService tempCartService = new CartService(_cartRepository);
            ProductService tempProductService = new ProductService(_productRepository);
            var cart = tempCartService.GetCartById(cartId);
            var product = tempProductService.GetProductById(productId);

            if (cart != null)
            {
                CartProducts cartProduct = new CartProducts()
                {
                    CartId = cartId, ProductId = productId, Quantity = quantity,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now,
                    CreatedBy = cart.CreatedBy, UpdatedBy = cart.UpdatedBy
                };
                AddCartProduct(cartProduct);

                cart.TotalAmount += quantity * product.Price;
            }
            else
            {
                throw new Exception("No Basket Found");
            }
        }

    }
}
