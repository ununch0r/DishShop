using DS.API.ViewModels.ViewModels.ContractViewModels;
using DS.API.ViewModels.ViewModels.SupplyContentViewModels;
using DS.API.ViewModels.ViewModels.SupplyStatusViewModels;
using System;
using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.EmployeeViewModels;
using DS.API.ViewModels.ViewModels.ShopViewModels;

namespace DS.API.ViewModels.ViewModels.SupplyViewModels
{
    public class SupplyViewModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }

        public ContractViewModel Contract { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public ShopViewModel Shop { get; set; }
        public SupplyStatusViewModel Status { get; set; }
        public IEnumerable<SupplyContentViewModel> SuppliesContents { get; set; }
    }
}
