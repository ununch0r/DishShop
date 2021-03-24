using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public IEnumerable<Shop> Shops { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
    }
}
