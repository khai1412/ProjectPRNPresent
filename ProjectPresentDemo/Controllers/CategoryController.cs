using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPresentDemo.DTO;
using ProjectPresentDemo.Models;

namespace ProjectPresentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private MySaleDbContext context;
        public CategoryController(MySaleDbContext context) {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            this.context = new MySaleDbContext();
            var x = this.context.Categories;
            var result = this.context.Categories.Select(e=> new CategoryDTO(e)).ToList();
            return Ok(result);
        }
    }
}
