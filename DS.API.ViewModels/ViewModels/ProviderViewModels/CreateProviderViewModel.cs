using System.ComponentModel.DataAnnotations;

namespace DS.API.ViewModels.ViewModels.ProviderViewModels
{
    public class CreateProviderViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int CityId { get; set; }
    }
}
