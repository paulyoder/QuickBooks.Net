using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface IPayrollDetailReport : IReportBase<IPayrollDetailReport>
    {
        IPayrollDetailReport PayrollDetailReportType(string reportType);
        IPayrollDetailReport SummarizeRowsBy(string summarizeBy);
        IPayrollDetailReport IncludeColumn(params string[] columns);
        IPayrollDetailReport IncludeAccounts(string accounts);
        IPayrollDetailReport OpenBalanceAsOf(string balanceAsOf);
    }
}
