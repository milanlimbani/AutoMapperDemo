namespace MappingDemo.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public List<EmployeeAddressDTO> employeeAddressDTOs { get; set; }
        public List<EmployeeDetailsDTO> employeeDetailsDTOs { get; set; }
    }
}
