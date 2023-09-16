using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class GetEmployeeHandler:IRequestHandler<GetEmployeeIdQuery,Employee>
    {
        private readonly EmployeeRepository _employeeRepository;
        public GetEmployeeHandler(EmployeeRepository employeeRepository)
        {
                _employeeRepository= employeeRepository;
        }
        public async Task<Employee> Handle(GetEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetById(request.Id);
        }
    }
}
