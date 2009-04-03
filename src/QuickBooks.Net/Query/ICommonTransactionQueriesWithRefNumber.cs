using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public interface ICommonTransactionQueriesWithRefNumber<IReturnQuery, TReturn> : 
        ICommonTransactionQueries<IReturnQuery, TReturn>
    {
        IReturnQuery RefNumber(params string[] refNumbers);
        IReturnQuery RefNumberCaseSensitive(params string[] refNumbers);
        IReturnQuery RefNumberFilter(string matchCriterion, string refNumber);
        IReturnQuery RefNumberRangeFilter(string fromRefNumber, string toRefNumber);
    }
}
