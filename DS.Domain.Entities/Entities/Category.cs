﻿using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Characteristic> Characteristics { get; set; }
    }
}
