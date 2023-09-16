using MediatR;

namespace MappingDemo.Command
{
    public class DeleteEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; } 
    }
}
