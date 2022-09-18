using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Presentation.Controllers.TimeSheets;
[Authorize(AuthenticationSchemes = "JWT_OR_COOKIE")]
[Area("TimeSheet")]
public class TimeSheetBase : ControllerBase
{
}