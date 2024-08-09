using App.Domain.Identity;
using AutoMapper;
using BLL.DTO;
using Public.DTO.v1;
using Appointment = BLL.DTO.Appointment;
using BasicUserInfo = BLL.DTO.BasicUserInfo;
using Category = BLL.DTO.Category;
using Salon = BLL.DTO.Salon;
using Service = BLL.DTO.Service;

namespace Public.DTO;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<BLL.DTO.AppointmentSchedule, Public.DTO.v1.AppointmentScheduleByEmployeeName>();

        CreateMap<Appointment, Public.DTO.v1.AppointmentBooking>().ReverseMap();
        CreateMap<Category, Public.DTO.v1.Category>().ReverseMap();
        CreateMap<Service, Public.DTO.v1.ServiceList>().ReverseMap();
        
        CreateMap<Public.DTO.v1.Salon, Salon>().ReverseMap();
        CreateMap<Public.DTO.v1.Salon, global::App.Domain.Salon>().ReverseMap();
        CreateMap<SalonsByCityName, SalonsByCityNames>().ReverseMap();
        CreateMap<AppUser, BasicUserInfo>().ReverseMap();
        CreateMap<Public.DTO.v1.BasicUserInfo, AppUser>().ReverseMap();
        
        CreateMap<AppointmentServices, App.Domain.AppointmentServices>().ReverseMap();
        CreateMap<AppointmentBooking, Appointment>().ReverseMap();
        CreateMap<App.Domain.Appointment, Appointment>().ReverseMap();
        
        
        AllowNullDestinationValues = true;
    }
}