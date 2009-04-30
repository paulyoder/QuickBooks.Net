using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class GeneralDetailReport : ReportBase<IGeneralDetailReport>, IGeneralDetailReport
    {
        public GeneralDetailReport(IQBSessionInternal session)
            : base(session, "CustomSummaryReportQueryRq", "CustomSummaryReportQueryRs")
        {
            _returnReport = this;
        }

        public IGeneralDetailReport GeneralDetailReportType(string reportType)
        {
            AddUpdateMessage("GeneralDetailReportType", reportType);
            return this;
        }
    }
}
