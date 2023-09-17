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
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator; 
        }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IEnumerable<Employee>> GetEmployees()
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
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new CreateEmployeeCommand(employee.Name,employee.Age,employee.Address,employee.MobileNumber,employee.EmployeeDetails.ToList(),employee.employeeAddresses.ToList()));
            return employeeReturn;
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
