using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public class CommonTransactionQueriesWithRefNumber<IReturnQuery, TReturn> : 
        CommonTransactionQueries<IReturnQuery,TReturn>,
        ICommonTransactionQueriesWithRefNumber<IReturnQuery, TReturn>
    {
        public CommonTransactionQueriesWithRefNumber(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        { }

        public IReturnQuery RefNumber(params string[] refNumbers)
        {
            foreach (var refNumber in refNumbers)
                AddMessageAllowDuplicates("RefNumber", refNumber);
            return _returnQuery;
        }

        public IReturnQuery RefNumberCaseSensitive(params string[] refNumbers)
        {
            foreach (var refNumber in refNumbers)
                AddMessageAllowDuplicates("RefNumberCaseSensitive", refNumber);
            return _returnQuery;
        }

        public IReturnQuery RefNumberFilter(string matchCriterion, string refNumber)
        {
            AddUpdateMessage("RefNumberFilter", "MatchCriterion", matchCriterion);
            AddUpdateMessage("RefNumberFilter", "RefNumber", refNumber);
            return _returnQuery;
        }

        public IReturnQuery RefNumberRangeFilter(string fromRefNumber, string toRefNumber)
        {
            AddUpdateMessage("RefNumberRangeFilter", "FromRefNumber", fromRefNumber);
            AddUpdateMessage("RefNumberRangeFilter", "ToRefNumber", toRefNumber);
            return _returnQuery;
        }
    }
}
