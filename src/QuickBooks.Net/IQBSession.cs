using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Query;
using QuickBooks.Net.Reports;
using QuickBooks.Net.Add;

namespace QuickBooks.Net
{
    public interface IQBSession : IDisposable
    {
        bool IsOpen { get; }
        IQueries Query { get; }
        IReports Report { get; }
        IAdditions Add { get; }
        void Close();
    }
}
