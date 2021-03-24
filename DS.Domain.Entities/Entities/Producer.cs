using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public IEnumerable<ContractContent> ContractContents { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
