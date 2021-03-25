using System;
using System.ComponentModel.DataAnnotations;

namespace DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels
{
    public class CreateProductCharacteristicViewModel
    {
        [Range(0,int.MaxValue)]
        public int CharacteristicId { get; set; }
        public decimal? Value { get; set; }
    }
}
