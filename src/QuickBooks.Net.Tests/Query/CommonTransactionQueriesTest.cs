using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Tests.Utilities;
using QuickBooks.Net.Query;
using Rhino.Mocks;
using System.Xml.Linq;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Tests.Query
{
    [TestFixture]
    public class CommonTransactionQueriesTest : QueryResponses
    {
        protected IQBSessionInternal _session;
        /// <summary>
        /// DepositQuery is used since it directly inherits from CommonTransactionQueries
        /// DepositQuery is not meant to be used in the API. Instead, the IDepositQuery should
        /// be used which limits the filter queries that are accessible.
        /// </summary>
        protected DepositQuery _depositQuery;

        [SetUp]
        public void s()
        {
            _session = MockRepository.GenerateStub<IQBSessionInternal>();
            _session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForDepositQueries());
            _depositQuery = new DepositQuery(_session);
        }

        [Test]
        public void TxnID_single()
        {
            _depositQuery.TxnID("1").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("TxnID", "1"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void TxnID_multiple()
        {
            _depositQuery.TxnID("1", "2", "3").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("TxnID", "1"),
                new XElement("TxnID", "2"),
                new XElement("TxnID", "3"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateModifiedFrom()
        {
            var theDate = new DateTime(2008, 1, 1);
            _depositQuery.DateModifiedFrom(theDate).List();

            var expected = new XElement("DepositQueryRq",
                new XElement("ModifiedDateRangeFilter",
                    new XElement("FromModifiedDate", theDate.ToXMLDateString())));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateModifiedTo()
        {
            var theDate = new DateTime(2008, 1, 1);
            _depositQuery.DateModifiedTo(theDate).List();

            var expected = new XElement("DepositQueryRq",
                new XElement("ModifiedDateRangeFilter",
                    new XElement("ToModifiedDate", theDate.ToXMLDateString())));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateFrom()
        {
            var theDate = new DateTime(2008, 1, 1);
            _depositQuery.DateFrom(theDate).List();

            var expected = new XElement("DepositQueryRq",
                new XElement("TxnDateRangeFilter",
                    new XElement("FromTxnDate", theDate.ToXMLDateString())));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateTo()
        {
            var theDate = new DateTime(2008, 1, 1);
            _depositQuery.DateTo(theDate).List();

            var expected = new XElement("DepositQueryRq",
                new XElement("TxnDateRangeFilter",
                    new XElement("ToTxnDate", theDate.ToXMLDateString())));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateMacro()
        {
            _depositQuery.DateMacro("Today").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("TxnDateRangeFilter",
                    new XElement("DateMacro", "Today")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void EntityListID()
        {
            _depositQuery.EntityListID("1", "2").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("EntityFilter",
                    new XElement("ListID", "1"),
                    new XElement("ListID", "2")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void EntityListIDWithChildren()
        {
            _depositQuery.EntityListIDWithChildren("1").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("EntityFilter",
                    new XElement("ListIDWithChildren", "1")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void EntityFullName()
        {
            _depositQuery.EntityFullName("Paul Yoder", "Darth Vader").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("EntityFilter",
                    new XElement("FullName", "Paul Yoder"),
                    new XElement("FullName", "Darth Vader")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void EntityFullNameWithChildren()
        {
            _depositQuery.EntityFullNameWithChildren("Paul Yoder").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("EntityFilter",
                    new XElement("FullNameWithChildren", "Paul Yoder")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void AccountListID()
        {
            _depositQuery.AccountListID("1", "2").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("AccountFilter",
                    new XElement("ListID", "1"),
                    new XElement("ListID", "2")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void AccountListIDWithChildren()
        {
            _depositQuery.AccountListIDWithChildren("1").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("AccountFilter",
                    new XElement("ListIDWithChildren", "1")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void AccountFullName()
        {
            _depositQuery.AccountFullName("Bank1", "Bank2").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("AccountFilter",
                    new XElement("FullName", "Bank1"),
                    new XElement("FullName", "Bank2")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void AccountFullNameWithChildren()
        {
            _depositQuery.AccountFullNameWithChildren("Bank1").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("AccountFilter",
                    new XElement("FullNameWithChildren", "Bank1")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void IncludeLineItems()
        {
            _depositQuery.IncludeLineItems().List();

            var expected = new XElement("DepositQueryRq",
                new XElement("IncludeLineItems", true));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void OwnerID()
        {
            _depositQuery.OwnerID("1", "2").List();

            var expected = new XElement("DepositQueryRq",
                new XElement("OwnerID", "1"),
                new XElement("OwnerID", "2"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }
    }
}
