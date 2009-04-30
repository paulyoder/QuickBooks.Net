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

        public ICustomDetailReport SummarizeRowsBy(string summarizeBy)
        {
            AddUpdateMessage("SummarizeRowsBy", summarizeBy);
            return this;
        }

        public ICustomDetailReport IncludeColumn(params string[] columns)
        {
            foreach (var column in columns)
                AddMessageAllowDuplicates("IncludeColumn", column);
            return this;
        }

        public ICustomDetailReport IncludeAccounts(string accounts)
        {
            AddUpdateMessage("IncludeAccounts", accounts);
            return this;
        }

        public ICustomDetailReport ReportOpenBalanceAsOf(string asOf)
        {
            AddUpdateMessage("ReportOpenBalanceAsOf", asOf);
            return this;
        }

        public ICustomDetailReport ReportBasis(string reportBasis)
        {
            AddUpdateMessage("ReportBasis", reportBasis);
            return this;
        }
    }
}
