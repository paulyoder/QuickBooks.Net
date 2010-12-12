using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;

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

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "CustomSummaryReportType",
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
                "SummarizeColumnsBy",
                "SummarizeRowsBy",
                "IncludeSubcolumns",
                "ReportCalendar",
                "ReturnRows",
                "ReturnColumns",
                "ReportBasis");
        }
    }
}
