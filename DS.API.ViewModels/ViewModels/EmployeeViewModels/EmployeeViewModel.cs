using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.PositionViewModels;
using DS.API.ViewModels.ViewModels.ShopViewModels;
using DS.API.ViewModels.ViewModels.SupplyViewModels;

namespace DS.API.ViewModels.ViewModels.EmployeeViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public PositionViewModel Position { get; set; }
        public ShopViewModel Shop { get; set; }
    }
}
