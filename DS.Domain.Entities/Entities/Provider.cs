using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
    }
}
