using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PositionId { get; set; }
        public int ShopId { get; set; }

        public Position Position { get; set; }
        public Shop Shop { get; set; }
        public IEnumerable<Supply> Supplies { get; set; }
    }
}
