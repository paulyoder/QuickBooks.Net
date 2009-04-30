using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities.DateTimeExtensions;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Reports
{
    public class CustomDetailReport : ReportBase<ICustomDetailReport>, ICustomDetailReport
    {
        public CustomDetailReport(IQBSessionInternal session)
            : base(session, "CustomDetailReportQueryRq", "CustomDetailReportQueryRs")
        {
            _returnReport = this;
        }

        protected override void OnNewReport()
        {
            base.OnNewReport();
            //CustomDetailReportType is required and 'CustomTxnDetail' is the only valid value
            CustomDetailReportType("CustomTxnDetail");
        }

        public ICustomDetailReport CustomDetailReportType(string reportType)
        {
            AddUpdateMessage("CustomDetailReportType", reportType);
            return this;
        }
    }
}
