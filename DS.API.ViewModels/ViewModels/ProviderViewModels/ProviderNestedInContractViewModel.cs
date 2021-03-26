using DS.API.ViewModels.ViewModels.CityViewModels;

namespace DS.API.ViewModels.ViewModels.ProviderViewModels
{
    public class ProviderNestedInContractViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CityViewModel City { get; set; }
    }
}
