using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Presentation.Controllers.Employees;

[Authorize(AuthenticationSchemes = "JWT_OR_COOKIE")]
[Area("Employee")]
public class EmployeeBase : ControllerBase
{
}