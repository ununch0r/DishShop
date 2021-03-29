using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PositionId { get; set; }
        public int ShopId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
