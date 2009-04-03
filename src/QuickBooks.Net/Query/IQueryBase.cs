using System;
using System.Collections.Generic;
namespace QuickBooks.Net.Query
{
    public interface IQueryBase<TReturn>
    {
        IList<TReturn> List();
        TReturn Single();
        IList<TReturn> Iterate();
        int IteratorRemainingCount { get; }
        void StopIteration();
    }
}
