using System.ComponentModel.DataAnnotations;
using ShopApp.Entities;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        //[StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün ismi minimum 10 karakter ve maksimum 60 karakter olmalıdır.")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [StringLength(100, MinimumLength = 20, ErrorMessage = "Ürün açıklaması minimum 20 karakter ve maksimum 100 karakter olmalıdır.")]
        public string Description { get; set; }

        [Range(1, 10000)]
        public decimal? Price { get; set; }
        public List<Category>? SelectedCategories { get; set; }
    }
}
