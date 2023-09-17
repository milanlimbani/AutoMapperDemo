using AutoMapper;
using MappingDemo.Command;
using MappingDemo.Interface;
using MappingDemo.Models;
using MappingDemo.Repository;
using MediatR;

namespace MappingDemo.Handler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(EmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeDTO employee = request.Employee; // Access the EmployeeDTO directly from the command
            EmployeeDTO addedEmployee = await _employeeRepository.AddEmployeeAsync(employee);
            return addedEmployee; // No need to map again, since it's already an EmployeeDTO
        }
    }
}
