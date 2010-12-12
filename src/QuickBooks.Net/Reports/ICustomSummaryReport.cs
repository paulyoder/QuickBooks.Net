using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface ICustomSummaryReport : IReportBase<ICustomSummaryReport>
    {
        ICustomSummaryReport CustomSummaryReportType(string reportType);
        ICustomSummaryReport SummarizeColumnsBy(string summarizeBy);
        ICustomSummaryReport SummarizeRowsBy(string summarizeBy);
        ICustomSummaryReport IncludeSubcolumns();
        ICustomSummaryReport ReportCalendar(string reportCalendar);
        ICustomSummaryReport ReturnRows(string returnRows);
        ICustomSummaryReport ReturnColumns(string returnColumns);
        ICustomSummaryReport ReportBasis(string reportBasis);
    }
}
