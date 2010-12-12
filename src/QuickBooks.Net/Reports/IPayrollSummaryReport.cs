using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface IPayrollSummaryReport : IReportBase<IPayrollSummaryReport>
    {
        IPayrollSummaryReport PayrollSummaryReportType(string reportType);
        IPayrollSummaryReport SummarizeColumnsBy(string summarizeBy);
        IPayrollSummaryReport IncludeSubcolumns();
        IPayrollSummaryReport ReportCalendar(string reportCalendar);
        IPayrollSummaryReport ReturnRows(string returnRows);
        IPayrollSummaryReport ReturnColumns(string returnColumns);
    }
}
