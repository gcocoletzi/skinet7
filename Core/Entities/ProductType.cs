using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}