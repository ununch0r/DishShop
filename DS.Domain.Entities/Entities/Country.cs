using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Producers = new HashSet<Producer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
