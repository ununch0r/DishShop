using DS.API.ViewModels.ViewModels.ContractContentViewModels;
using DS.API.ViewModels.ViewModels.ProviderViewModels;
using System;
using System.Collections.Generic;

namespace DS.API.ViewModels.ViewModels.ContractViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ProviderNestedInContractViewModel Provider { get; set; }
        public IEnumerable<ContractContentViewModel> ContractsContents { get; set; }
    }
}
