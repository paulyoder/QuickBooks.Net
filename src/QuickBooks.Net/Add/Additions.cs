using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Add
{
    public class Additions : IAdditions
    {
        protected IQBSessionInternal _session;

        public Additions(IQBSessionInternal session)
        {
            _session = session;
        }

        protected ICustomerAdd _customerAdd;
        public ICustomerAdd Customer
        {
            get 
            {
                if (_customerAdd == null)
                    _customerAdd = new CustomerAdd(_session);
                return _customerAdd;
            }
        }

        protected IVendorAdd _vendorAdd;
        public IVendorAdd Vendor
        {
            get
            {
                if (_vendorAdd == null)
                    _vendorAdd = new VendorAdd(_session);
                return _vendorAdd;
            }
        }

        protected IJournalEntryAdd _journalAdd;
        public IJournalEntryAdd JournalEntry
        {
            get
            {
                if (_journalAdd == null)
                    _journalAdd = new JournalEntryAdd(_session);
                return _journalAdd;
            }
        }
    }
}
