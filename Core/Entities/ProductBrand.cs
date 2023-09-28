using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductBrand
    {
        [Key]
        public int ProductBrandId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}