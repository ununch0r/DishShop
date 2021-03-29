using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.SupplyContentViewModels;

namespace DS.API.ViewModels.ViewModels.SupplyViewModels
{
    public class CreateSupplyViewModel
    {
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }
        public int StatusId { get; set; }

        public IEnumerable<CreateSupplyContentViewModel> SuppliesContents { get; set; }
    }
}
