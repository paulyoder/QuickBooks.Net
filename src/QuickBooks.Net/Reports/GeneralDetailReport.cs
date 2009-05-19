using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;

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

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "GeneralDetailReportType",
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
