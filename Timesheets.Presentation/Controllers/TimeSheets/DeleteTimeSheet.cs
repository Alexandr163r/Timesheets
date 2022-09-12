using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Presentation.Controllers.TimeSheets;

public class DeleteTimeSheet : TimeSheetBase
{
    private readonly ITimeSheetService _service;

    private readonly ITimeSheetServiceValidator _validator;

    public DeleteTimeSheet(ITimeSheetService service, ITimeSheetServiceValidator validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpDelete("[area]/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isValidId = await _validator.IsValidIdAsync(id);

        if (!isValidId)
        {
            return BadRequest("Записи с таким Id не найдено");
        }
        
        await _service.DeleteAsync(id);

        return Ok();
    }
}