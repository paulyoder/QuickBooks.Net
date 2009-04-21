using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Reports
{
    public interface ICustomDetailReport
    {
        ICustomDetailReport CustomDetailReportType(string reportType);
        ICustomDetailReport DisplayReport();
        ICustomDetailReport ReportPeriodFrom(DateTime dateFrom);
        ICustomDetailReport ReportPeriodTo(DateTime dateTo);
        ICustomDetailReport ReportPeriodDateMacro(string dateMacro);
        ICustomDetailReport AccountType(string type);
        ICustomDetailReport AccountListID(params string[] listIDs);
        ICustomDetailReport AccountFullName(params string[] fullNames);
        ICustomDetailReport AccountListIDWithChildren(string listID);
        ICustomDetailReport AccountFullNameWithChildren(string fullName);
        ICustomDetailReport EntityType(string type);
        ICustomDetailReport EntityListID(params string[] listIDs);
        ICustomDetailReport EntityFullName(params string[] fullNames);
        ICustomDetailReport EntityListIDWithChildren(string listID);
        ICustomDetailReport EntityFullNameWithChildren(string fullName);
        ICustomDetailReport ItemType(string type);
        ICustomDetailReport ItemListID(params string[] listIDs);
        ICustomDetailReport ItemFullName(params string[] fullNames);
        ICustomDetailReport ItemListIDWithChildren(string listID);
        ICustomDetailReport ItemFullNameWithChildren(string fullName);
        ICustomDetailReport ClassListID(params string[] listIDs);
        ICustomDetailReport ClassFullName(params string[] fullNames);
        ICustomDetailReport ClassListIDWithChildren(string listID);
        ICustomDetailReport ClassFullNameWithChildren(string fullName);
        ICustomDetailReport TxnType(params string[] txnTypes);
        ICustomDetailReport ReportModifiedFrom(DateTime dateFrom);
        ICustomDetailReport ReportModifiedTo(DateTime dateTo);
        ICustomDetailReport ReportModifiedDateMacro(string dateMacro);
        ICustomDetailReport DetailLevel(string detailLevel);
        ICustomDetailReport PostingStatus(string postingStatus);
        ICustomDetailReport SummarizeRowsBy(string summarizeBy);
        ICustomDetailReport IncludeColumn(params string[] columns);
        ICustomDetailReport IncludeAccounts(string accounts);
        ICustomDetailReport ReportOpenBalanceAsOf(string asOf);
        ICustomDetailReport ReportBasis(string reportBasis);
        Report RunReport();
    }
}
