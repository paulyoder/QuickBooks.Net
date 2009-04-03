using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public interface IClassQuery : IQueryBaseNoIteration<QBClass>
    {
        IClassQuery ListID(params string[] listIDs);
        IClassQuery FullName(params string[] fullNames);
        IClassQuery MaxReturned(int maxReturned);
        IClassQuery ActiveStatus(string activeStatus);
        IClassQuery DateModifiedFrom(DateTime fromDate);
        IClassQuery DateModifiedTo(DateTime toDate);
        IClassQuery NameFilter(string matchCriterion, string name);
        IClassQuery NameRangeFilter(string fromName, string toName);
        IClassQuery IncludeRetElement(params string[] retElements);
    }
}
