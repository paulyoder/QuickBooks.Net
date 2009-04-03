using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public class Queries : QuickBooks.Net.Query.IQueries
    {
        protected IQBSessionInternal _session;

        public Queries(IQBSessionInternal session)
        {
            _session = session;
        }

        protected IClassQuery _class;
        public IClassQuery Class
        {
            get
            {
                if (_class == null)
                    _class = new ClassQuery(_session);
                return _class;
            }
        }

        protected IDepositQuery _deposit;
        public IDepositQuery Deposit
        {
            get
            {
                if (_deposit == null)
                    _deposit = new DepositQuery(_session);
                return _deposit;
            }
        }

        protected ICreditCardChargeQuery _creditCardCharge;
        public ICreditCardChargeQuery CreditCardCharge
        {
            get
            {
                if (_creditCardCharge == null)
                    _creditCardCharge = new CreditCardChargeQuery(_session);
                return _creditCardCharge;
            }
        }
    }
}
