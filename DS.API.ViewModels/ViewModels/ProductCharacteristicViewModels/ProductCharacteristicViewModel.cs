using DS.API.ViewModels.ViewModels.CharacteristicViewModels;

namespace DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels
{
    public class ProductCharacteristicViewModel
    {
        public CharacteristicViewModel Characteristic { get; set; }
        public decimal? Value { get; set; }
    }
}
