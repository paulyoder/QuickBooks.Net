using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public interface IReports
    {
        ICustomDetailReport CustomDetailReport { get; }
        ICustomSummaryReport CustomSummaryReport { get; }
        IGeneralDetailReport GeneralDetailReport { get; }
        IGeneralSummaryReport GeneralSummaryReport { get; }
        IPayrollDetailReport PayrollDetailReport { get; }
        IPayrollSummaryReport PayrollSummaryReport { get; }
    }
}
