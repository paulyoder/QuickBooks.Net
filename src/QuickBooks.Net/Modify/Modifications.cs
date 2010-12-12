using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Modify
{
    public class Modifications : IModifications
    {
        protected IQBSessionInternal _session;

        public Modifications(IQBSessionInternal session)
        {
            _session = session;
        }

        protected IJournalEntryMod _journalMod;
        public IJournalEntryMod JournalEntry
        {
            get
            {
                if (_journalMod == null)
                    _journalMod = new JournalEntryMod(_session);
                return _journalMod;
            }
        }

        protected ICustomerMod _customerMod;
        public ICustomerMod Customer
        {
            get
            {
                if (_customerMod == null)
                    _customerMod = new CustomerMod(_session);
                return _customerMod;
            }
        }
    }
}
