using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPresentDemo.DTO;
using ProjectPresentDemo.Models;

namespace ProjectPresentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private MySaleDbContext context;
        public ProductController(MySaleDbContext context) {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var result = this.context.Products.Select(e=> new ProductDTO(e)).ToList();
            return Ok(result);
        }
        [HttpGet("categoryName")]
        public IActionResult GetAllProductByCategory(string? categoryName)
        {
            var result = this.context.Products.Where(e => e.Category.CategoryName.Equals(categoryName)).Select(e => new ProductDTO(e)).ToList();
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductDTO? productDTO) {
            if(productDTO == null) return BadRequest();
            try
            {
                if (this.context.Products.Any(e => e.ProductId.Equals(productDTO.ProductId)) && !this.context.Categories.Any(e => e.CategoryId.Equals(productDTO.CategoryId))) return BadRequest();
                var newProduct = productDTO.GetEntity();
                this.context.Products.Add(newProduct);
                this.context.SaveChanges();
                return Ok(productDTO);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut]
        public IActionResult UpdateProduct(ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();
            if (!this.context.Products.Any(e => e.ProductId.Equals(productDTO.ProductId)) && !this.context.Categories.Any(e => e.CategoryId.Equals(productDTO.CategoryId))) return BadRequest();
            var currentProduct = this.context.Products.FirstOrDefault(e => e.ProductId.Equals(productDTO.ProductId));
            productDTO?.UpdateEntity(currentProduct);
            this.context.Products.Update(currentProduct); 
            this.context.SaveChanges();
            return Ok(currentProduct);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int productId) {
            var currentProduct = this.context.Products.FirstOrDefault(e=>e.ProductId == productId);
            if(currentProduct == null) return BadRequest();
            this.context.Products.Remove(currentProduct);
            this.context.SaveChanges();
            return Ok(currentProduct);
        }
    }
}
