using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class PayrollDetailReport : ReportBase<IPayrollDetailReport>, IPayrollDetailReport
    {
        public PayrollDetailReport(IQBSessionInternal session)
            : base(session, "PayrollDetailReportQueryRq", "PayrollDetailReportQueryRs")
        {
            _returnReport = this;
        }

        public IPayrollDetailReport PayrollDetailReportType(string reportType)
        {
            AddUpdateMessage("PayrollDetailReportType", reportType);
            return this;
        }
    }
}
