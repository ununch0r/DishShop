using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.CategoryViewModels;
using DS.API.ViewModels.ViewModels.ProducerViewModels;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;

namespace DS.API.ViewModels.ViewModels.ProductViewModels
{
    public class CatalogProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }

        public CategoryViewModel Category { get; set; }
        public ProducerViewModel Producer { get; set; }
        public IEnumerable<ProductCharacteristicViewModel> ProductsCharacteristics { get; set; }
    }
}
