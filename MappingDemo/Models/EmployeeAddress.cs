namespace MappingDemo.Models
{
    public class EmployeeAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
