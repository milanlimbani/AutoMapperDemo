using MappingDemo.Models;
using MediatR;

namespace MappingDemo.Handler
{
    public class GetEmployeeListQuery:IRequest<List<Employee>>
    {
    }
}
