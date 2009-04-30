using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Reports
{
    public interface ICustomDetailReport : IReportBase<ICustomDetailReport>
    {
        ICustomDetailReport CustomDetailReportType(string reportType);
        ICustomDetailReport SummarizeRowsBy(string summarizeBy);
        ICustomDetailReport IncludeColumn(params string[] columns);
        ICustomDetailReport IncludeAccounts(string accounts);
        ICustomDetailReport ReportOpenBalanceAsOf(string asOf);
        ICustomDetailReport ReportBasis(string reportBasis);
    }
}
