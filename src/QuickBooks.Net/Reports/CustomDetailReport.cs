using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities.ConversionExtensions;
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

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "CustomDetailReportType",
                "DisplayReport",
                new ElementPosition("ReportPeriod",
                    "FromReportDate",
                    "ToReportDate"),
                "ReportDateMacro",
                new ElementPosition("ReportAccountFilter",
                    "AccountTypeFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                new ElementPosition("ReportEntityFilter",
                    "EntityTypeFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                new ElementPosition("ReportItemFilter",
                    "ItemTypeFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                new ElementPosition("ReportClassFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                new ElementPosition("ReportTxnTypeFilter",
                    "TxnTypeFilter"),
                new ElementPosition("ReportModifiedDateRangeFilter",
                    "FromReportModifiedDate",
                    "ToReportModifiedDate"),
                "ReportModifiedDateRangeMacro",
                "ReportDetailLevelFilter",
                "ReportPostingStatusFilter",
                "SummarizeRowsBy",
                "IncludeColumn",
                "IncludeAccounts",
                "ReportOpenBalanceAsOf",
                "ReportBasis");
        }
    }
}
