using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public interface IQueryBaseNoIteration<TReturn>
    {
        IList<TReturn> List();
        TReturn Single();
    }
}
