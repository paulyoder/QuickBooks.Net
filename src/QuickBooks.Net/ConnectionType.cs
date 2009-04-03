using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net
{
    public enum ConnectionType
    {
        Unknown = 0,
        LocalQBD = 1,
        RemoteQBD = 2,
        LocalQBDLaunchUI = 3,
        RemoteQBOE = 4,
    }
}
