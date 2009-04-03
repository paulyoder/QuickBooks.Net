using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net
{
    public interface IQBSessionFactory : IDisposable
    {
        IQBSession OpenSession();
    }
}
