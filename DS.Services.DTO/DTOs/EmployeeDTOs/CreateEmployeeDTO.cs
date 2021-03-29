namespace DS.Services.DTO.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PositionId { get; set; }
        public int ShopId { get; set; }
    }
}
