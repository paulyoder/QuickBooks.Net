using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Query
{
    public class Queries : IQueries
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

        protected IEntityQuery _entity;
        public IEntityQuery Entity
        {
            get
            {
                if (_entity == null)
                    _entity = new EntityQuery(_session);
                return _entity;
            }
        }

        protected ICustomerQuery _customer;
        public ICustomerQuery Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerQuery(_session);
                return _customer;
            }
        }

        protected IEmployeeQuery _employee;
        public IEmployeeQuery Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new EmployeeQuery(_session);
                return _employee;
            }
        }

        protected IOtherNameQuery _otherName;
        public IOtherNameQuery OtherName
        {
            get
            {
                if (_otherName == null)
                    _otherName = new OtherNameQuery(_session);
                return _otherName;
            }
        }

        protected IVendorQuery _vendor;
        public IVendorQuery Vendor
        {
            get
            {
                if (_vendor == null)
                    _vendor = new VendorQuery(_session);
                return _vendor;
            }
        }
    }
}
