using DS.API.ViewModels.ViewModels.ProductViewModels;

namespace DS.API.ViewModels.ViewModels.ShopAvailabilityViewModels
{
    public class ShopAvailabilityViewModel
    {
        public int Amount { get; set; }

        public CatalogProductViewModel Product { get; set; }
    }
}
