using AutoMapper;
using Timesheets.Domain.Dto;
using Timesheets.Domain.Entities;
using Timesheets.Presentation.Models.Employee;
using Timesheets.Presentation.Models.EmployeeType;
using Timesheets.Presentation.Models.Report;
using Timesheets.Presentation.Models.TimeSheet;

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
        
        CreateMap<ReportDto, ReportRequestModel>().ReverseMap();
        
        CreateMap<ReportDto, ReportResponseModel>().ReverseMap();
    }
}