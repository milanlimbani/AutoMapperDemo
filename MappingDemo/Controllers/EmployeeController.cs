using AutoMapper;
using MappingDemo.Command;
using MappingDemo.Handler;
using MappingDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MappingDemo.Controllers
{
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public EmployeeController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator; 
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employeelist =await _mediator.Send(new GetEmployeeListQuery());
            return employeelist;
        }
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeIdQuery() { Id=id});
            return employee;
        }
        [HttpPost]
        [Route("AddEmployees")]
        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            var createEmployeeCommand = new CreateEmployeeCommand(employee); // Pass the employee directly to the constructor
            var employeeReturn = await _mediator.Send(createEmployeeCommand);
            return _mapper.Map<EmployeeDTO>(employeeReturn);
        }

        [HttpPost]
        [Route("UpdateEmployees")]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new UpdateEmployeeCommand(employee.Id,employee.Name, employee.Age,
                employee.Address, employee.MobileNumber, employee.EmployeeDetails.ToList(), employee.employeeAddresses.ToList()));
            return employeeReturn;
        }
        [HttpPost]
        [Route("DeleteEmployees")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id=id});
        }
    }
}
