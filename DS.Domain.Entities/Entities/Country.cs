using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Producer> Producers { get; set; }
    }
}
