using System.ComponentModel.DataAnnotations;
namespace RecordShop.Web.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Maximum Title length must be less than 50"), MinLength(3, ErrorMessage = "Minimum Title length must be 3")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Artist is required")]
        [StringLength(50, ErrorMessage = "Maximum Artist length must be less than 50"), MinLength(3, ErrorMessage = "Minimum Artist length must be 3")]
        public string Artist { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Maximum Genre length must be less than 50"), MinLength(3, ErrorMessage = "Minimum Genre length must be 3")]
        public string Genre { get; set; } = string.Empty;

        [Range(1930, 2026, ErrorMessage = "Release year must be between 1930 and 2026")]
        public int ReleaseYear { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price range must be between £0.01 and £10,000")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Stock range must be between 0 and 100")]
        public int StockQuantity { get; set; }
    }
}
