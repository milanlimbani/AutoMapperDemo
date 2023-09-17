using MappingDemo.Models;

namespace MappingDemo.Interface
{
    public interface IEmployee
    {
        public Task<List<EmployeeDTO>> GetAll();
        public Task<Employee> GetById(int Id);
        public Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
