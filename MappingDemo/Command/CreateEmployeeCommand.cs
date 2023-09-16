using MappingDemo.Models;
using MediatR;

namespace MappingDemo.Command
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
       
        public CreateEmployeeCommand(string name, int age, string address, string mobileno,List<EmployeeAddress> employeeAddresses,List<EmployeeDetails> employeeDetails)
        {
            Name = name;
            Age = age;
            Address = address;
            MobileNumber = mobileno;
            EmployeeDetails = employeeDetails;
            EmployeeAddress = employeeAddresses;
        }

        public CreateEmployeeCommand(string name, int age, string address, string mobileNumber, List<EmployeeDetails> employeeDetails, List<EmployeeAddress> employeeAddresses)
        {
            Name = name;
            Age = age;
            Address = address;
            MobileNumber = mobileNumber;
            EmployeeDetails = employeeDetails;
            EmployeeAddress = employeeAddresses;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public List<EmployeeAddress> EmployeeAddress { get;private set; }
        public List<EmployeeDetails> EmployeeDetails { get;private set; }
       
    }
}

