using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface IGeneralDetailReport : IReportBase<IGeneralDetailReport>
    {
        IGeneralDetailReport GeneralDetailReportType(string reportType);
        IGeneralDetailReport SummarizeRowsBy(string summarizeBy);
        IGeneralDetailReport IncludeColumn(params string[] columns);
        IGeneralDetailReport IncludeAccounts(string accounts);
        IGeneralDetailReport OpenBalanceAsOf(string openBalance);
        IGeneralDetailReport ReportBasis(string basis);
    }
}
