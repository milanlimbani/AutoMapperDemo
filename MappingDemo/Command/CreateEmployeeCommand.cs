using MappingDemo.Models;
using MediatR;

public class CreateEmployeeCommand : IRequest<EmployeeDTO>
{
    public CreateEmployeeCommand(EmployeeDTO employee)
    {
        Employee = employee;
    }

    public EmployeeDTO Employee { get; set; }
}
