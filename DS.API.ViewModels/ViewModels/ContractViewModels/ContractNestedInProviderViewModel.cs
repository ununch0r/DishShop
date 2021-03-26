using DS.API.ViewModels.ViewModels.ContractContentViewModels;
using System;
using System.Collections.Generic;

namespace DS.API.ViewModels.ViewModels.ContractViewModels
{
    public class ContractNestedInProviderViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<ContractContentViewModel> ContractsContents { get; set; }
    }
}
