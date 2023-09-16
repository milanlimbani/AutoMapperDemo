using MappingDemo.Data;
using MappingDemo.Interface;
using MappingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MappingDemo.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _dataContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
                _dataContext = applicationDbContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            var result = _dataContext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            _dataContext.Employees.Remove(result);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            var filterdata = await _dataContext.Employees.ToListAsync();
            return filterdata;
        }

        public async Task<Employee> GetById(int Id)
        {
            var filterdata = await _dataContext.Employees.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return filterdata;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _dataContext.Employees.Update(employee);
            return await _dataContext.SaveChangesAsync();
        }
    }
}
