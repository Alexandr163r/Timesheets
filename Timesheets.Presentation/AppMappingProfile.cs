using AutoMapper;
using Timesheets.DAL.Entity;
using Timesheets.Domain.Entities;
using Timesheets.Presentation.Models.Employee;
using Timesheets.Presentation.Models.EmployeeType;
using Timesheets.Presentation.Models.ReportCard;
using Timesheets.Presentation.Models.TimeSheet;
using Timesheets.Presentation.Models.User;

namespace Timesheets.Presentation;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<EmployeeType, EmployeeTypeRequestModel>().ReverseMap();
        
        CreateMap<EmployeeType, EmployeeTypeResponseModel>().ReverseMap();
        
        CreateMap<Employee, EmployeeRequestModel>().ReverseMap();
        
        CreateMap<Employee, EmployeeResponseModel>().ReverseMap();
        
        CreateMap<TimeSheet, TimeSheetRequestModel>().ReverseMap();
        
        CreateMap<TimeSheet, TimeSheetResponseModel>().ReverseMap();
        
        CreateMap<ReportCard, ReportCardRequestModel>().ReverseMap();
        
        CreateMap<ReportCard, ReportCardResponseModel>().ReverseMap();

        CreateMap<ApplicationUser, UserRegistrationModel>().ReverseMap();
        
        CreateMap<ApplicationUser, UserLoginModel>().ReverseMap();
    }
}