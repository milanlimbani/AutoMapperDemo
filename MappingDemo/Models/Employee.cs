namespace MappingDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<EmployeeDetails> EmployeeDetails { get; set; } 
        public ICollection<EmployeeAddress> employeeAddresses { get; set; } 
    }
}
