using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Modify
{
    public interface IModifications
    {
        IJournalEntryMod JournalEntry { get; }
        ICustomerMod Customer { get; }
    }
}
