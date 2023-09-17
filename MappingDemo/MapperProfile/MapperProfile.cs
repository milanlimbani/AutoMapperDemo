using AutoMapper;
using MappingDemo.Command;
using MappingDemo.Models;

namespace MappingDemo.MapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.employeeDetailsDTOs, opt => opt.MapFrom(src => src.EmployeeDetails))
            .ForMember(dest => dest.employeeAddressDTOs, opt => opt.MapFrom(src => src.employeeAddresses));

            CreateMap<EmployeeDetailsDTO, EmployeeDetails>();
            CreateMap<EmployeeDetails, EmployeeDetailsDTO>();

            CreateMap<EmployeeAddressDTO, EmployeeAddress>();
            CreateMap<EmployeeAddress, EmployeeAddressDTO>();
        }
    }
}
