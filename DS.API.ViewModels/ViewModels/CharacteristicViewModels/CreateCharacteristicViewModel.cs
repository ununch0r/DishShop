using System;
using System.ComponentModel.DataAnnotations;

namespace DS.API.ViewModels.ViewModels.CharacteristicViewModels
{
    public class CreateCharacteristicViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Range(0,int.MaxValue)]
        public int? ValueTypeId { get; set; }
    }
}
