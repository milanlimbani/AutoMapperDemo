using AutoMapper;
using MappingDemo.Data;
using MappingDemo.Interface;
using MappingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MappingDemo.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly IMapper _mappers;
        public EmployeeRepository(ApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _dataContext = applicationDbContext;
            _mappers = mapper;
        }
        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            //Employee employee = _mappers.Map<EmployeeDTO, Employee>(employeeDto);
            //var result = _dataContext.Employees.Add(employee);
            //await _dataContext.SaveChangesAsync();
            //Employee addedEmployee = result.Entity;
            //return _mappers.Map<Employee, EmployeeDTO>(addedEmployee);
            Employee employee = _mappers.Map<EmployeeDTO, Employee>(employeeDto);

            // Handle null or empty EmployeeDetails
            if (employeeDto.employeeDetailsDTOs != null && employeeDto.employeeDetailsDTOs.Any())
            {
                foreach (var detailsDto in employeeDto.employeeDetailsDTOs)
                {
                    var details = _mappers.Map<EmployeeDetailsDTO, EmployeeDetails>(detailsDto);
                    employee.EmployeeDetails.Add(details);
                }
            }

            // Handle null or empty EmployeeAddress
            if (employeeDto.employeeAddressDTOs != null && employeeDto.employeeAddressDTOs.Any())
            {
                foreach (var addressDto in employeeDto.employeeAddressDTOs)
                {
                    var address = _mappers.Map<EmployeeAddressDTO, EmployeeAddress>(addressDto);
                    employee.employeeAddresses.Add(address);
                }
            }

            var result = _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            //  Employee addedEmployee = result.Entity;
            EmployeeDTO addedEmployeeDto = _mappers.Map<Employee, EmployeeDTO>(result.Entity);
            addedEmployeeDto.employeeDetailsDTOs = employeeDto.employeeDetailsDTOs;
            addedEmployeeDto.employeeAddressDTOs = employeeDto.employeeAddressDTOs;

            return addedEmployeeDto;

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

        public async Task<List<EmployeeDTO>> GetAll()
        {
            var employees = await _dataContext.Employees
       .Include(e => e.employeeAddresses)
       .Include(e => e.EmployeeDetails)
       .ToListAsync();

            var employeeDTOs = _mappers.Map<List<Employee>, List<EmployeeDTO>>(employees);
            return employeeDTOs;
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
