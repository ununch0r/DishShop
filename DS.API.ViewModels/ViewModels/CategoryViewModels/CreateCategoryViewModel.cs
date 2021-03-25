using System.ComponentModel.DataAnnotations;

namespace DS.API.ViewModels.ViewModels.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
