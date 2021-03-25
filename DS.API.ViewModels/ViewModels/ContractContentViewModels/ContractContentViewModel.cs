using DS.API.ViewModels.ViewModels.ProductViewModels;

namespace DS.API.ViewModels.ViewModels.ContractContentViewModels
{
    public class ContractContentViewModel
    {
        public decimal PricePerUnit { get; set; }

        public CatalogProductViewModel Product { get; set; }
    }
}
