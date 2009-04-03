using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities.DateTimeExtensions;

namespace QuickBooks.Net.Query
{
    /// <summary>Contains common DAO filters</summary>
    /// <typeparam name="IReturnDAO">Query interface to return</typeparam>
    /// <typeparam name="TReturn">Expected return type</typeparam>
    public class CommonQueries<IReturnQuery, TReturn> : QueryBase<TReturn>
    {
        protected IReturnQuery _returnQuery;
        protected string[] _modifiedDateFromElement;
        protected string[] _modifiedDateToElement;

        public CommonQueries(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        {
            _modifiedDateFromElement = new string[] { "FromModifiedDate" };
            _modifiedDateToElement = new string[] { "ToModifiedDate" };
        }

        public virtual IReturnQuery ListID(params string[] listIDs)
        {
            foreach (var listID in listIDs)
                AddMessageAllowDuplicates("ListID", listID);
            return _returnQuery;
        }

        public virtual IReturnQuery FullName(params string[] fullNames)
        {
            foreach (var name in fullNames)
                AddMessageAllowDuplicates("FullName", name);
            return _returnQuery;
        }

        public virtual IReturnQuery MaxReturned(int maxReturned)
        {
            AddUpdateMessage("MaxReturned", maxReturned.ToString());
            return _returnQuery;
        }

        public virtual IReturnQuery ActiveStatus(string activeStatus)
        {
            AddUpdateMessage("ActiveStatus", activeStatus);
            return _returnQuery;
        }

        public virtual IReturnQuery DateModifiedFrom(DateTime fromDate)
        {
            var message = new List<string>();
            message.AddRange(_modifiedDateFromElement);
            message.Add(fromDate.ToXMLDateString());
            AddUpdateMessage(message.ToArray());
            return _returnQuery;
        }

        public virtual IReturnQuery DateModifiedTo(DateTime toDate)
        {
            var message = new List<string>();
            message.AddRange(_modifiedDateToElement);
            message.Add(toDate.ToXMLDateString());
            AddUpdateMessage(message.ToArray());
            return _returnQuery;
        }

        public virtual IReturnQuery NameFilter(string matchCriterion, string name)
        {
            AddUpdateMessage("NameFilter", "MatchCriterion", matchCriterion);
            AddUpdateMessage("NameFilter", "Name", name);
            return _returnQuery;
        }

        public virtual IReturnQuery NameRangeFilter(string fromName, string toName)
        {
            AddUpdateMessage("NameRangeFilter", "FromName", fromName);
            AddUpdateMessage("NameRangeFilter", "ToName", toName);
            return _returnQuery;
        }

        public virtual IReturnQuery IncludeRetElement(params string[] retElements)
        {
            foreach (var retElement in retElements)
                AddMessageAllowDuplicates("IncludeRetElement", retElement);
            return _returnQuery;
        }
    }
}
