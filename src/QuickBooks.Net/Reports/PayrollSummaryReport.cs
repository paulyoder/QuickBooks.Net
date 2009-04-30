using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class PayrollSummaryReport : ReportBase<IPayrollSummaryReport>, IPayrollSummaryReport
    {
        public PayrollSummaryReport(IQBSessionInternal session)
            : base(session, "PayrollSummaryReportQueryRq", "PayrollSummaryReportQueryRs")
        {
            _returnReport = this;
        }

        public IPayrollSummaryReport PayrollSummaryReportType(string reportType)
        {
            AddUpdateMessage("PayrollSummaryReportType", reportType);
            return this;
        }
    }
}
