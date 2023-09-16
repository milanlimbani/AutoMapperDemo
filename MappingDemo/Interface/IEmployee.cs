using MappingDemo.Models;

namespace MappingDemo.Interface
{
    public interface IEmployee
    {
        public Task<List<Employee>> GetAll();
        public Task<Employee> GetById(int Id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
