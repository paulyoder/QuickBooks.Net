using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class CustomSummaryReport : ReportBase<ICustomSummaryReport>, ICustomSummaryReport
    {
        public CustomSummaryReport(IQBSessionInternal session)
            : base(session, "CustomSummaryReportQueryRq", "CustomSummaryReportQueryRs")
        {
            _returnReport = this;
        }

        public ICustomSummaryReport CustomSummaryReportType(string reportType)
        {
            AddUpdateMessage("CustomSummaryReportType", reportType);
            return this;
        }

        protected override void OnNewReport()
        {
            base.OnNewReport();
            CustomSummaryReportType("CustomSummary");
        }
    }
}
