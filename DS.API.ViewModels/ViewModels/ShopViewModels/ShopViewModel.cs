using DS.API.ViewModels.ViewModels.CityViewModels;
using DS.API.ViewModels.ViewModels.EmployeeViewModels;
using DS.API.ViewModels.ViewModels.ShopAvailabilityViewModels;
using DS.API.ViewModels.ViewModels.SupplyViewModels;
using System.Collections.Generic;

namespace DS.API.ViewModels.ViewModels.ShopViewModels
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetIdentifier { get; set; }
        public string StreetName { get; set; }

        public ShopNestedEmployeeViewModel Manager { get; set; }
        public CityViewModel City { get; set; }

        public IEnumerable<ShopNestedSupplyViewModel> Supplies { get; set; }
        public IEnumerable<ShopAvailabilityViewModel> ShopsAvailabilities { get; set; }
        public IEnumerable<ShopNestedEmployeeViewModel> Employees { get; set; }
    }
}
