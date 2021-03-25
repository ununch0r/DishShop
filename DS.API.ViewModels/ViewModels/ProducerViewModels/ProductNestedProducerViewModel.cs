using DS.API.ViewModels.ViewModels.CountryViewModels;

namespace DS.API.ViewModels.ViewModels.ProducerViewModels
{
    public class ProductNestedProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
