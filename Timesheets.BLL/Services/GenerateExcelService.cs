using ClosedXML.Excel;
using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;

namespace Timesheets.BLL.Services;

public class GenerateExcelService : IGenerateExcelService
{
    public async Task<MemoryStream> ConvertToExcelAsync(List<ReportCard> reportCards)
    {
        using (var reportWorkbook = new XLWorkbook())
        {
            var worksheet = reportWorkbook.Worksheets.Add("Отчет");
            var currentRow = 1;

            #region Header

            worksheet.Cell(currentRow, 1).Value = "Должность";
            worksheet.Cell(currentRow, 2).Value = "Имя";
            worksheet.Cell(currentRow, 3).Value = "Фамилия";
            worksheet.Cell(currentRow, 4).Value = "Начало работы";
            worksheet.Cell(currentRow, 5).Value = "Конец работы";
            worksheet.Cell(currentRow, 6).Value = "Часов отработано";
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();

            #endregion

            #region Body

            foreach (var report in reportCards)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = report.Title;
                worksheet.Cell(currentRow, 2).Value = report.Name;
                worksheet.Cell(currentRow, 3).Value = report.Surname;
                worksheet.Cell(currentRow, 4).Value = report.StartOfWorkDay;
                worksheet.Cell(currentRow, 5).Value = report.EndOfWorkDay;
                worksheet.Cell(currentRow, 6).Value = report.WorkTime;
                worksheet.Columns().AdjustToContents();
                worksheet.Rows().AdjustToContents();
            }

            #endregion

            using (var stream = new MemoryStream())
            {
                reportWorkbook.SaveAs(stream);

                return stream;
            }
        }
    }
}