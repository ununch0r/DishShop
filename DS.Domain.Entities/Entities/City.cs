using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class City
    {
        public City()
        {
            Providers = new HashSet<Provider>();
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
