using DS.API.ViewModels.ViewModels.ValueTypeViewModels;

namespace DS.API.ViewModels.ViewModels.CharacteristicViewModels
{
    public class CharacteristicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ValueTypeViewModel ValueType { get; set; }
    }
}
