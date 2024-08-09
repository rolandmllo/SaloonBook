using AutoMapper;
using BLL.DTO;
using Public.DTO.v1;
using Appointment = App.Domain.Appointment;
using Category = App.Domain.Category;
using Salon = BLL.DTO.Salon;
using Service = App.Domain.Service;

namespace BLL.App;

public class AutoMapperConfig : Profile

{
    public AutoMapperConfig()

    {
        //domain->bll
        CreateMap<Appointment, BLL.DTO.Appointment>().ReverseMap();
        CreateMap<BLL.DTO.Category, Category>().ReverseMap();
        CreateMap<BLL.DTO.Service, Service>().ReverseMap();
        CreateMap<Salon, global::App.Domain.Salon>().ReverseMap();
        CreateMap<City, global::App.Domain.City>().ReverseMap();
        CreateMap<AppointmentServices, global::App.Domain.AppointmentServices>().ReverseMap();
        
        AllowNullDestinationValues = true;
        
        
        // CreateMap<BLL.DTO.Appointment, Appointment>().ForMember(
        //     dest => dest.Employee.FirstName,
        //     options =>
        //         options.MapFrom(src => src.EmployeeFirstName)
        // )
        //     .ForMember(dest => dest.Employee.LastName,
        //     options => 
        //         options.MapFrom(src => src.EmployeeLastName)
        //     );
        //
    }
}