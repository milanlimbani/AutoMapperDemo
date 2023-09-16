using MappingDemo.Models;
using MediatR;

namespace MappingDemo.Handler
{
    public class GetEmployeeIdQuery:IRequest<Employee>
    {
        public int Id { get; set; } 
    }
}
