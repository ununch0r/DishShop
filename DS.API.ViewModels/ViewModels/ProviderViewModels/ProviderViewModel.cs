using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.CityViewModels;
using DS.API.ViewModels.ViewModels.ContractViewModels;

namespace DS.API.ViewModels.ViewModels.ProviderViewModels
{
    public class ProviderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CityViewModel City { get; set; }
        public IEnumerable<ContractNestedInProviderViewModel> Contracts { get; set; }
    }
}
