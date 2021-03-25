using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;

namespace DS.API.ViewModels.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<CreateProductCharacteristicViewModel> ProductsCharacteristics { get; set; }
    }
}
