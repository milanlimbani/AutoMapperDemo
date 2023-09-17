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
            var result = await _dataContext.Employees.Include(e => e.EmployeeDetails).Include(e => e.employeeAddresses).FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                _dataContext.EmployeesAddress.RemoveRange(result.employeeAddresses);
                _dataContext.EmployeesDetails.RemoveRange(result.EmployeeDetails);
                _dataContext.Employees.Remove(result);
                return await _dataContext.SaveChangesAsync();

            }
            return 0;
        }

        public async Task<List<Employee>> GetAll()
        {
            var filterdata = await _dataContext.Employees.Include(e => e.employeeAddresses).Include(e => e.EmployeeDetails).ToListAsync();
            return filterdata;
        }

        public async Task<Employee> GetById(int Id)
        {
            var filterdata = await _dataContext.Employees.Include(e => e.employeeAddresses).Include(e => e.EmployeeDetails).Where(x => x.Id == Id).FirstOrDefaultAsync();
            return filterdata;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _dataContext.Employees
                .Include(e => e.EmployeeDetails)
                .Include(e => e.employeeAddresses)
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (existingEmployee != null)
            {

                existingEmployee.Name = employee.Name;
                existingEmployee.Age = employee.Age;
                existingEmployee.Address = employee.Address;
                existingEmployee.MobileNumber = employee.MobileNumber;

                // Update EmployeeDetails
                if (employee.EmployeeDetails != null)
                {
                    foreach (var detail in employee.EmployeeDetails)
                    {
                        var existingDetail = existingEmployee.EmployeeDetails.FirstOrDefault(ed => ed.Id == detail.Id);
                        if (existingDetail != null)
                        {
                            existingDetail.Name = detail.Name;
                            existingDetail.Age = detail.Age;
                            existingDetail.Address = detail.Address;
                            existingDetail.MobileNumber = detail.MobileNumber;
                        }
                        else
                        {
                            // If the detail is not found, consider adding a new detail logic here.
                        }
                    }
                }
                if (employee.employeeAddresses != null)
                {

                    // Update EmployeeAddresses
                    foreach (var address in employee.employeeAddresses)
                    {
                        var existingAddress = existingEmployee.employeeAddresses.FirstOrDefault(ea => ea.Id == address.Id);
                        if (existingAddress != null)
                        {
                            existingAddress.Name = address.Name;
                            existingAddress.Age = address.Age;
                            existingAddress.Address = address.Address;
                            existingAddress.MobileNumber = address.MobileNumber;

                        }
                        else
                        {
                            // If the address is not found, consider adding a new address logic here.
                        }
                    }
                }

                _dataContext.Employees.Update(existingEmployee);
                return await _dataContext.SaveChangesAsync();
            }

            return 0; // Employee with specified Id not found
        }
    }
}
