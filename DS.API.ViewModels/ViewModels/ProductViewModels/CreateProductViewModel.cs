using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;

namespace DS.API.ViewModels.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ScanCode { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProducerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CreateProductCharacteristicViewModel> ProductsCharacteristics { get; set; }
    }
}
