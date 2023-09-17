using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class GetEmployeeListHandler:IRequestHandler<GetEmployeeListQuery,List<EmployeeDTO>>
    {
        private readonly EmployeeRepository _employeeRepository;
        public GetEmployeeListHandler(EmployeeRepository employeeRepository)
        {
               _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDTO>> Handle(GetEmployeeListQuery request,CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAll();
        }
    }
}
