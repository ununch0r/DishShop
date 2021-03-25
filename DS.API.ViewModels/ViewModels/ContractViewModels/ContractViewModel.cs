using System;
using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.ContractContentViewModels;
using DS.API.ViewModels.ViewModels.ProviderViewModels;

namespace DS.API.ViewModels.ViewModels.ContractViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ProviderViewModel Provider { get; set; }
        public virtual IEnumerable<ContractContentViewModel> ContractsContents { get; set; }
    }
}
