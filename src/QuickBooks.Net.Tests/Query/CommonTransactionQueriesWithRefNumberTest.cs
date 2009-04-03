using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Query;
using Rhino.Mocks;
using QuickBooks.Net.Tests.Utilities;
using System.Xml.Linq;

namespace QuickBooks.Net.Tests.Query
{
    [TestFixture]
    public class CommonTransactionQueriesWithRefNumberTest : QueryResponses
    {
        protected IQBSessionInternal _session;
        /// <summary>
        /// CreditCardChargeQuery is used since it directly inherits from CommonTransactionQueriesWithRefNumber
        /// CreditCardChargeQuery is not meant to be used in the API. Instead, the ICreditCardChargeQuery should
        /// be used which limits the filter queries that are accessible.
        /// </summary>
        protected CreditCardChargeQuery _ccQuery;

        [SetUp]
        public void s()
        {
            _session = MockRepository.GenerateStub<IQBSessionInternal>();
            _session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForCreditCardQueries());
            _ccQuery = new CreditCardChargeQuery(_session);
        }

        [Test]
        public void RefNumber_single()
        {
            _ccQuery.RefNumber("1").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumber", "1"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void RefNumber_multiple()
        {
            _ccQuery.RefNumber("1", "2").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumber", "1"),
                new XElement("RefNumber", "2"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void RefNumberCaseSensitive_single()
        {
            _ccQuery.RefNumberCaseSensitive("1").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumberCaseSensitive", "1"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void RefNumberCaseSensitive_multiple()
        {
            _ccQuery.RefNumberCaseSensitive("1", "2").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumberCaseSensitive", "1"),
                new XElement("RefNumberCaseSensitive", "2"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void RefNumberFilter()
        {
            _ccQuery.RefNumberFilter("StartsWith", "Hi").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumberFilter",
                    new XElement("MatchCriterion", "StartsWith"),
                    new XElement("RefNumber", "Hi")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void RefNumberRangeFilter()
        {
            _ccQuery.RefNumberRangeFilter("low", "hi").List();

            var expected = new XElement("CreditCardChargeQueryRq",
                new XElement("RefNumberRangeFilter",
                    new XElement("FromRefNumber", "low"),
                    new XElement("ToRefNumber", "hi")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }
    }
}
