using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.DateTimeExtensions;

namespace QuickBooks.Net.Reports
{
    public class ReportBase<IReturnReport> : QBXMLBase<Report>, IReportBase<IReturnReport>
    {
        protected IReturnReport _returnReport;

        public ReportBase(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        {
            OnNewReport();
        }

        public virtual IReturnReport DisplayReport()
        {
            AddUpdateMessage("DisplayReport", "true");
            return _returnReport;
        }

        public virtual IReturnReport ReportPeriodFrom(DateTime dateFrom)
        {
            AddUpdateMessage("ReportPeriod", "FromReportDate", dateFrom.ToXMLDateString());
            return _returnReport;
        }

        public virtual IReturnReport ReportPeriodTo(DateTime dateTo)
        {
            AddUpdateMessage("ReportPeriod", "ToReportDate", dateTo.ToXMLDateString());
            return _returnReport;
        }

        public virtual IReturnReport ReportPeriodDateMacro(string dateMacro)
        {
            AddUpdateMessage("ReportPeriod", "ReportDateMacro", dateMacro);
            return _returnReport;
        }

        public virtual IReturnReport AccountType(string type)
        {
            AddUpdateMessage("ReportAccountFilter", "AccountTypeFilter", type);
            return _returnReport;
        }

        public virtual IReturnReport AccountListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportAccountFilter", "ListID", listID);
            return _returnReport;
        }

        public virtual IReturnReport AccountFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportAccountFilter", "FullName", fullName);
            return _returnReport;
        }

        public virtual IReturnReport AccountListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportAccountFilter", "ListIDWithChildren", listID);
            return _returnReport;
        }

        public virtual IReturnReport AccountFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportAccountFilter", "FullNameWithChildren", fullName);
            return _returnReport;
        }

        public virtual IReturnReport EntityType(string type)
        {
            AddUpdateMessage("ReportEntityFilter", "EntityTypeFilter", type);
            return _returnReport;
        }

        public virtual IReturnReport EntityListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportEntityFilter", "ListID", listID);
            return _returnReport;
        }

        public virtual IReturnReport EntityFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportEntityFilter", "FullName", fullName);
            return _returnReport;
        }

        public virtual IReturnReport EntityListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportEntityFilter", "ListIDWithChildren", listID);
            return _returnReport;
        }

        public virtual IReturnReport EntityFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportEntityFilter", "FullNameWithChildren", fullName);
            return _returnReport;
        }

        public virtual IReturnReport ItemType(string type)
        {
            AddUpdateMessage("ReportItemFilter", "ItemTypeFilter", type);
            return _returnReport;
        }

        public virtual IReturnReport ItemListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportItemFilter", "ListID", listID);
            return _returnReport;
        }

        public virtual IReturnReport ItemFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportItemFilter", "FullName", fullName);
            return _returnReport;
        }

        public virtual IReturnReport ItemListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportItemFilter", "ListIDWithChildren", listID);
            return _returnReport;
        }

        public virtual IReturnReport ItemFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportItemFilter", "FullNameWithChildren", fullName);
            return _returnReport;
        }

        public virtual IReturnReport ClassListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ReportClassFilter", "ListID", listID);
            return _returnReport;
        }

        public virtual IReturnReport ClassFullName(params string[] fullNames)
        {
            foreach (var fullName in fullNames)
                AddMessageAllowDuplicates("ReportClassFilter", "FullName", fullName);
            return _returnReport;
        }

        public virtual IReturnReport ClassListIDWithChildren(string listID)
        {
            AddUpdateMessage("ReportClassFilter", "ListIDWithChildren", listID);
            return _returnReport;
        }

        public virtual IReturnReport ClassFullNameWithChildren(string fullName)
        {
            AddUpdateMessage("ReportClassFilter", "FullNameWithChildren", fullName);
            return _returnReport;
        }

        public virtual IReturnReport TxnType(params string[] txnTypes)
        {
            foreach (var txnType in txnTypes)
                AddMessageAllowDuplicates("ReportTxnTypeFilter", "TxnTypeFilter", txnType);
            return _returnReport;
        }

        public virtual IReturnReport ReportModifiedFrom(DateTime dateFrom)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "FromReportModifiedDate", dateFrom.ToXMLDateString());
            return _returnReport;
        }

        public virtual IReturnReport ReportModifiedTo(DateTime dateTo)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "ToReportModifiedDate", dateTo.ToXMLDateString());
            return _returnReport;
        }

        public virtual IReturnReport ReportModifiedDateMacro(string dateMacro)
        {
            AddUpdateMessage("ReportModifiedDateRangeFilter", "ReportModifiedDateRangeMacro", dateMacro);
            return _returnReport;
        }

        public virtual IReturnReport DetailLevel(string detailLevel)
        {
            AddUpdateMessage("ReportDetailLevelFilter", detailLevel);
            return _returnReport;
        }

        public virtual IReturnReport PostingStatus(string postingStatus)
        {
            AddUpdateMessage("ReportPostingStatusFilter", postingStatus);
            return _returnReport;
        }

        public virtual Report RunReport()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            OnNewReport();
            return new Report(response.Element("ReportRet"));
        }

        /// <summary>
        /// Gets called when a new report is created
        /// </summary>
        protected virtual void OnNewReport()
        {
            _xmlBase.ResetXml();
        }
    }
}
