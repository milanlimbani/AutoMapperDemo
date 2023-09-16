using MappingDemo.Models;
using MediatR;

namespace MappingDemo.Command
{
    public class UpdateEmployeeCommand:IRequest<int>
    {
     
        public UpdateEmployeeCommand(int id,string name, int age, string address, string mobileno, List<EmployeeAddress> employeeAddresses, List<EmployeeDetails> employeeDetails)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            MobileNumber = mobileno;
            EmployeeAddress = employeeAddresses;
            EmployeeDetails = employeeDetails;
        }

        public UpdateEmployeeCommand(int id, string name, int age, string address, string mobileNumber, List<EmployeeDetails> employeeDetails, List<EmployeeAddress> employeeAddresses)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            MobileNumber = mobileNumber;
            EmployeeDetails = employeeDetails;
            EmployeeAddress = employeeAddresses;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public List<EmployeeAddress> EmployeeAddress { get; set; }
        public List<EmployeeDetails> EmployeeDetails { get; set; }

    }
}

