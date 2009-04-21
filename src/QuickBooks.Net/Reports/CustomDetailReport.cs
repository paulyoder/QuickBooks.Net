using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities.DateTimeExtensions;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Reports
{
    public class CustomDetailReport : QBXMLBase<Report>, ICustomDetailReport
    {
        public CustomDetailReport(IQBSessionInternal session)
            : base(session, "CustomDetailReportQueryRq", "CustomDetailReportQueryRs")
        { }

        public ICustomDetailReport CustomDetailReportType(string reportType)
        {
            AddUpdateMessage("CustomDetailReportType", reportType);
            return this;
        }

        public ICustomDetailReport DisplayReport()
        {
            AddUpdateMessage("DisplayReport", "true");
            return this;
        }

        public ICustomDetailReport ReportPeriodFrom(DateTime dateFrom)
        {
            AddUpdateMessage("ReportPeriod", "FromReportDate", dateFrom.ToXMLDateString());
            return this;
        }

        public ICustomDetailReport ReportPeriodTo(DateTime dateTo)
        {
            AddUpdateMessage("ReportPeriod", "ToReportDate", dateTo.ToXMLDateString());
            return this;
        }

        public ICustomDetailReport ReportPeriodDateMacro(string dateMacro)
        {
            AddUpdateMessage("ReportPeriod", "ReportDateMacro", dateMacro);
            return this;
        }

        public ICustomDetailReport AccountType(string type)
        {
            AddUpdateMessage("ReportAccountFilter", "AccountTypeFilter", type);
            return this;
        }

        public ICustomDetailReport AccountListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportAccountFilter", "ListID", listID);
            return this;
        }

        public ICustomDetailReport AccountFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportAccountFilter", "FullName", fullName);
            return this;
        }

        public ICustomDetailReport AccountListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportAccountFilter", "ListIDWithChildren", listID);
            return this;
        }

        public ICustomDetailReport AccountFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportAccountFilter", "FullNameWithChildren", fullName);
            return this;
        }

        public ICustomDetailReport EntityType(string type)
        {
            AddUpdateMessage("ReportEntityFilter", "EntityTypeFilter", type);
            return this;
        }

        public ICustomDetailReport EntityListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportEntityFilter", "ListID", listID);
            return this;
        }

        public ICustomDetailReport EntityFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportEntityFilter", "FullName", fullName);
            return this;
        }

        public ICustomDetailReport EntityListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportEntityFilter", "ListIDWithChildren", listID);
            return this;
        }

        public ICustomDetailReport EntityFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportEntityFilter", "FullNameWithChildren", fullName);
            return this;
        }

        public ICustomDetailReport ItemType(string type)
        {
            AddUpdateMessage("ReportItemFilter", "ItemTypeFilter", type);
            return this;
        }

        public ICustomDetailReport ItemListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportItemFilter", "ListID", listID);
            return this;
        }

        public ICustomDetailReport ItemFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportItemFilter", "FullName", fullName);
            return this;
        }

        public ICustomDetailReport ItemListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportItemFilter", "ListIDWithChildren", listID);
            return this;
        }

        public ICustomDetailReport ItemFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportItemFilter", "FullNameWithChildren", fullName);
            return this;
        }

        public ICustomDetailReport ClassListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportClassFilter", "ListID", listID);
            return this;
        }

        public ICustomDetailReport ClassFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportClassFilter", "FullName", fullName);
            return this;
        }

        public ICustomDetailReport ClassListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportClassFilter", "ListIDWithChildren", listID);
            return this;
        }

        public ICustomDetailReport ClassFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportClassFilter", "FullNameWithChildren", fullName);
            return this;
        }

        public ICustomDetailReport TxnType(params string[] txnTypes)
        {
            foreach (var txnType in txnTypes)
                AddMessageAllowDuplicates("ReportTxnTypeFilter", "TxnTypeFilter", txnType);
            return this;
        }

        public ICustomDetailReport ReportModifiedFrom(DateTime dateFrom)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "FromReportModifiedDate", dateFrom.ToXMLDateString());
            return this;
        }

        public ICustomDetailReport ReportModifiedTo(DateTime dateTo)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "ToReportModifiedDate", dateTo.ToXMLDateString());
            return this;
        }

        public ICustomDetailReport ReportModifiedDateMacro(string dateMacro)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "ReportModifiedDateRangeMacro", dateMacro);
            return this;
        }

        public ICustomDetailReport DetailLevel(string detailLevel)
        {
            AddUpdateMessage("ReportDetailLevelFilter", detailLevel);
            return this;
        }

        public ICustomDetailReport PostingStatus(string postingStatus)
        {
            AddUpdateMessage("ReportPostingStatusFilter", postingStatus);
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

        public Report RunReport()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            return new Report(response.Element("ReportRet"));
        }
    }
}
