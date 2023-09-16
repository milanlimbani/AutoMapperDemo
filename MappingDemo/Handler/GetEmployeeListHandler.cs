using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class GetEmployeeListHandler:IRequestHandler<GetEmployeeListQuery,List<Employee>>
    {
        private readonly EmployeeRepository _employeeRepository;
        public GetEmployeeListHandler(EmployeeRepository employeeRepository)
        {
               _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request,CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAll();
        }
    }
}
