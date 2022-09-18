using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Presentation.Controllers.EmployeeTypes;

[Authorize(AuthenticationSchemes = "JWT_OR_COOKIE")]
[Area("EmployeeType")]
public class EmployeeTypeBase : ControllerBase
{
}