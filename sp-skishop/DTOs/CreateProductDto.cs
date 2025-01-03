using System.ComponentModel.DataAnnotations;

namespace sp_skishop.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public  string Name { get; set; } = string.Empty;
        [Required]
        public  string Description { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public  string PictureUrl { get; set; } = string.Empty;
        [Required]
        public  string Type { get; set; }
        [Required]
        public  string Brand { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int QuantityInStock { get; set; }
    }
}
