using DS.API.ViewModels.ViewModels.CountryViewModels;

namespace DS.API.ViewModels.ViewModels.CityViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
