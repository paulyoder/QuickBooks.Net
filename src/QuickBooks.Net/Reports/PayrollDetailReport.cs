using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;

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

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "PayrollDetailReportType",
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
                "ReportOpenBalanceAsOf");
        }
    }
}
