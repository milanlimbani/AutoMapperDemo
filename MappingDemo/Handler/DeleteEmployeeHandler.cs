using MappingDemo.Command;
using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class DeleteEmployeeHandler:IRequestHandler<DeleteEmployeeCommand,int>
    {
        private readonly EmployeeRepository _employeeRepository;
        public DeleteEmployeeHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetById(request.Id);
            if (employee == null) return default;
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
