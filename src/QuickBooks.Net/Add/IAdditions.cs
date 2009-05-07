using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Add
{
    public interface IAdditions
    {
        ICustomerAdd Customer { get; }
    }
}
