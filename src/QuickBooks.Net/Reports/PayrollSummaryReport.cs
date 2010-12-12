using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;

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

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "PayrollSummaryReportType",
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
                "IncludeSubcolumns",
                "ReportCalendar",
                "ReturnRows",
                "ReturnColumns");
        }
    }
}
