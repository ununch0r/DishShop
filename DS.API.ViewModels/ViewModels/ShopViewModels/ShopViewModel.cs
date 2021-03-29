using DS.API.ViewModels.ViewModels.CityViewModels;

namespace DS.API.ViewModels.ViewModels.ShopViewModels
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetIdentifier { get; set; }
        public string StreetName { get; set; }

        public CityViewModel City { get; set; }
    }
}
