using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class GeneralSummaryReport : ReportBase<IGeneralSummaryReport>, IGeneralSummaryReport
    {
        public GeneralSummaryReport(IQBSessionInternal session)
            : base(session, "GeneralSummaryReportQueryRq", "GeneralSummaryReportQueryRs")
        {
            _returnReport = this;
        }

        public IGeneralSummaryReport GeneralSummaryReportType(string reportType)
        {
            AddUpdateMessage("GeneralSummaryReportType", reportType);
            return this;
        }
    }
}
