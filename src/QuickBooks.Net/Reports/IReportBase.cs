using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Reports
{
    /// <typeparam name="IReturnReport">Report Interface to return</typeparam>
    public interface IReportBase<IReturnReport>
    {
        IReturnReport DisplayReport();
        IReturnReport ReportPeriodFrom(DateTime dateFrom);
        IReturnReport ReportPeriodTo(DateTime dateTo);
        IReturnReport ReportPeriodDateMacro(string dateMacro);
        IReturnReport AccountType(string type);
        IReturnReport AccountListID(params string[] listIDs);
        IReturnReport AccountFullName(params string[] fullNames);
        IReturnReport AccountListIDWithChildren(string listID);
        IReturnReport AccountFullNameWithChildren(string fullName);
        IReturnReport EntityType(string type);
        IReturnReport EntityListID(params string[] listIDs);
        IReturnReport EntityFullName(params string[] fullNames);
        IReturnReport EntityListIDWithChildren(string listID);
        IReturnReport EntityFullNameWithChildren(string fullName);
        IReturnReport ItemType(string type);
        IReturnReport ItemListID(params string[] listIDs);
        IReturnReport ItemFullName(params string[] fullNames);
        IReturnReport ItemListIDWithChildren(string listID);
        IReturnReport ItemFullNameWithChildren(string fullName);
        IReturnReport ClassListID(params string[] listIDs);
        IReturnReport ClassFullName(params string[] fullNames);
        IReturnReport ClassListIDWithChildren(string listID);
        IReturnReport ClassFullNameWithChildren(string fullName);
        IReturnReport TxnType(params string[] txnTypes);
        IReturnReport ReportModifiedFrom(DateTime dateFrom);
        IReturnReport ReportModifiedTo(DateTime dateTo);
        IReturnReport ReportModifiedDateMacro(string dateMacro);
        IReturnReport DetailLevel(string detailLevel);
        IReturnReport PostingStatus(string postingStatus);
        Report RunReport();
    }
}
