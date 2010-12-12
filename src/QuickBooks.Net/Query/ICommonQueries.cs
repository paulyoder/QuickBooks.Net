using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public interface ICommonQueries<IReturnQuery>
    {
        IReturnQuery ListID(params string[] listIDs);
        IReturnQuery FullName(params string[] fullNames);
        IReturnQuery MaxReturned(int maxReturned);
        IReturnQuery ActiveStatus(string activeStatus);
        IReturnQuery DateModifiedFrom(DateTime fromDate);
        IReturnQuery DateModifiedTo(DateTime toDate);
        IReturnQuery NameFilter(string matchCriterion, string name);
        IReturnQuery NameRangeFilter(string fromName, string toName);
        IReturnQuery IncludeRetElement(params string[] retElements);
    }
}
