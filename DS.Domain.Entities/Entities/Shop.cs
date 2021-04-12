using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Shop
    {
        public Shop()
        {
            Employees = new HashSet<Employee>();
            ShopsAvailabilities = new HashSet<ShopsAvailability>();
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public string StreetIdentifier { get; set; }
        public string StreetName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<ShopsAvailability> ShopsAvailabilities { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
