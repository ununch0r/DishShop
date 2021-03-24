using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string StreetIdentifier { get; set; }
        public int CityId { get; set; }


        public City City { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<ShopAvailability> ShopAvailabilities { get; set; }
        public IEnumerable<Supply> Supplies { get; set; }
    }
}
