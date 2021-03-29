using DS.Services.DTO.DTOs.PositionDTOs;
using DS.Services.DTO.DTOs.ShopDTOs;

namespace DS.Services.DTO.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public PositionDTO Position { get; set; }
        public ShopDTO Shop { get; set; }
    }
}
