using MappingDemo.Command;
using MappingDemo.Interface;
using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class CreateEmployeeHandler:IRequestHandler<CreateEmployeeCommand,Employee>
    {
        private readonly EmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee()
            {
                Name = request.Name,
                Age = request.Age,
                Address = request.Address,
                MobileNumber = request.MobileNumber,
                EmployeeDetails=request.EmployeeDetails,
                employeeAddresses=request.EmployeeAddress
            };
            return await _employeeRepository.AddEmployeeAsync(employee);
        }
    }
}
