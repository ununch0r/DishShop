using DS.Services.DTO.DTOs.PositionDTOs;

namespace DS.Services.DTO.DTOs.EmployeeDTOs
{
    public class ShopNestedEmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public PositionDTO Position { get; set; }
    }
}
