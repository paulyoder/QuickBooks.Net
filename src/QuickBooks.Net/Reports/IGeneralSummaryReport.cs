using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface IGeneralSummaryReport : IReportBase<IGeneralSummaryReport>
    {
        IGeneralSummaryReport GeneralSummaryReportType(string reportType);
        IGeneralSummaryReport SummarizeColumnsBy(string summarizeBy);
        IGeneralSummaryReport IncludeSubcolumns();
        IGeneralSummaryReport ReportCalendar(string reportCalendar);
        IGeneralSummaryReport ReturnRows(string returnRows);
        IGeneralSummaryReport ReturnColumns(string returnColumns);
        IGeneralSummaryReport ReportBasis(string reportBasis);
    }
}
