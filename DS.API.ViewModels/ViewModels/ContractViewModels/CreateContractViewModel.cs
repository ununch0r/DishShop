using System;
using System.Collections.Generic;
using DS.API.ViewModels.ViewModels.ContractContentViewModels;

namespace DS.API.ViewModels.ViewModels.ContractViewModels
{
    public class CreateContractViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProviderId { get; set; }

        public IEnumerable<CreateContractContentViewModel> ContractsContents { get; set; }
    }
}
