using AutoMapper;
using MappingDemo.Models;

namespace MappingDemo.MapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDTO,Employee>();
            CreateMap<EmployeeAddressDTO,EmployeeAddress>();
            CreateMap<EmployeeDetailsDTO,EmployeeDetails>();
        }
    }
}
