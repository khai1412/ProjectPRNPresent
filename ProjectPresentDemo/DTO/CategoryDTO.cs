
using ProjectPresentDemo.Models;

namespace ProjectPresentDemo.DTO
{
    public class CategoryDTO : BaseDTO<Category>
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public CategoryDTO(Category category) {
            this.CategoryId = category.CategoryId;
            this.CategoryName = category?.CategoryName;
        }
        public override Category GetEntity()
        {
            return new Category { CategoryId = this.CategoryId, CategoryName = this.CategoryName };
        }

        public override void UpdateEntity(Category entity)
        {
            entity.CategoryId = this.CategoryId;
            entity.CategoryName = this.CategoryName;
        }
    }
}
