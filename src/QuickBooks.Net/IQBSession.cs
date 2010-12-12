using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Query;
using QuickBooks.Net.Reports;
using QuickBooks.Net.Add;
using QuickBooks.Net.Modify;

namespace QuickBooks.Net
{
    public interface IQBSession : IDisposable
    {
        bool IsOpen { get; }
        IQueries Query { get; }
        IReports Report { get; }
        IAdditions Add { get; }
        IModifications Modify { get; }
        void Close();
    }
}
