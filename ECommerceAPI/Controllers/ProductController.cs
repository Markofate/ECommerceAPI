﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace ECommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productsService)
        {
            _productService = productsService;
        }
        
        [HttpGet]
        [Route("/products/")]
        public IActionResult GetProducts()
        {
            var content = _productService.GetProducts();
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
            
            
        }
        [HttpGet]
        [Route("/product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var content = _productService.GetProductById(id);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
            
        }
    }
}
