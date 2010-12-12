using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public interface ICommonTransactionQueries<IReturnQuery, TReturn> : 
        IQueryBase<TReturn>
    {
        IReturnQuery TxnID(params string[] txnIDs);
        IReturnQuery MaxReturned(int maxReturned);
        IReturnQuery DateModifiedFrom(DateTime fromDate);
        IReturnQuery DateModifiedTo(DateTime toDate);
        IReturnQuery DateFrom(DateTime fromDate);
        IReturnQuery DateTo(DateTime toDate);
        IReturnQuery DateMacro(string dateMacro);
        IReturnQuery EntityListID(params string[] entityListIDs);
        IReturnQuery EntityListIDWithChildren(string entityListID);
        IReturnQuery EntityFullName(params string[] entityFullNames);
        IReturnQuery EntityFullNameWithChildren(string entityFullName);
        IReturnQuery AccountListID(params string[] accountListIDs);
        IReturnQuery AccountListIDWithChildren(string accountListID);
        IReturnQuery AccountFullName(params string[] accountFullNames);
        IReturnQuery AccountFullNameWithChildren(string accountFullName);
        IReturnQuery IncludeLineItems();
        IReturnQuery IncludeRetElement(params string[] retElements);
        IReturnQuery OwnerID(params string[] ownerID);
    }
}
