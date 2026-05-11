using Api1.Data;
using Api1.Dtos.Products;
using Api1.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(AppDbContext appDbContext, IMapper mapper) : ControllerBase
    {
        //add crud operations here
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = appDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var productReturnDto = mapper.Map<ProductReturnDto>(product);
            return Ok(productReturnDto);
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products =appDbContext.Products
                .Include(p => p.Category)
                .ToList();  
            var productsReturnDtos = mapper.Map<List<ProductReturnDto>>(products);
            return Ok(productsReturnDtos);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductCreateDto productCreateDto)
        {
            var category = appDbContext.Categories.Find(productCreateDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid category id");
            }
            var product = mapper.Map<Product>(productCreateDto);
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var existingProduct = appDbContext.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.CategoryId = updatedProduct.CategoryId;
            appDbContext.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = appDbContext.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            appDbContext.Products.Remove(existingProduct);
            appDbContext.SaveChanges();
            return NoContent();
        }
    }
}