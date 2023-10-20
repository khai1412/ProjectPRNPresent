using ProjectPresentDemo.Models;

namespace ProjectPresentDemo.DTO
{
    public class ProductDTO : BaseDTO<Product>
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public string? Image { get; set; }

        public int? CategoryId { get; set; }
        public ProductDTO(Product product) {
            this.ProductId = product.ProductId;
            this.ProductName = product?.ProductName;
            this.UnitPrice = product?.UnitPrice;
            this.UnitsInStock = product?.UnitsInStock;
            this.Image = product?.Image;
            this.CategoryId = product?.CategoryId;
        }
        public ProductDTO()
        {

        }
        public override Product GetEntity()
        {
            return new Product { ProductName = this.ProductName, UnitPrice = this.UnitPrice,UnitsInStock = this.UnitsInStock,Image = this.Image,CategoryId = this.CategoryId };
        }

        public override void UpdateEntity(Product entity)
        {
            entity.ProductName = this.ProductName;
            entity.UnitPrice = this.UnitPrice;
            entity.UnitsInStock = this.UnitsInStock;
            entity.Image = this.Image;
            entity.CategoryId = this.CategoryId;
        }
    }
}
