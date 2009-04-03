using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Query;

namespace QuickBooks.Net
{
    public interface IQBSession : IDisposable
    {
        IQueries Queries { get; }
        void Close();
    }
}
