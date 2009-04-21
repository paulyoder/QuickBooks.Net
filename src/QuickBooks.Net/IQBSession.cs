using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Query;
using QuickBooks.Net.Reports;

namespace QuickBooks.Net
{
    public interface IQBSession : IDisposable
    {
        bool IsOpen { get; }
        IQueries Queries { get; }
        IReports Reports { get; }
        void Close();
    }
}
