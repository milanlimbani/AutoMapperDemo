using MappingDemo.Command;
using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class UpdateEmployeeCommandHandler:IRequestHandler<UpdateEmployeeCommand,int>
    {
        private readonly EmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetById(request.Id);
            if(employee == null) return default;
            employee.Name = request.Name;
            employee.Age= request.Age;
            employee.Address = request.Address;
            employee.MobileNumber = request.MobileNumber;
            employee.EmployeeDetails = request.EmployeeDetails;
            employee.employeeAddresses = request.EmployeeAddress;
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
