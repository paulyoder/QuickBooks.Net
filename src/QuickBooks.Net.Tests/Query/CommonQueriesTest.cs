using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using System.Xml.Linq;
using QuickBooks.Net.Query;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities.DateTimeExtensions;
using QuickBooks.Net.Tests.Query;
using QuickBooks.Net.Tests.Utilities;

namespace QuickBooks.Net.Tests.Query
{
    [TestFixture]
    public class CommonQueriesTest : QueryResponses
    {
        protected IQBSessionInternal _session;
        /// <summary>
        /// ClassQuery is used since it directly inherits from CommonQueries
        /// ClassQuery is not meant to be used in the API. Instead, the IClassQuery should
        /// be used which limits the filter queries that are accessible.
        /// </summary>
        protected ClassQuery _classQuery;

        [SetUp]
        public void s()
        {
            _session = MockRepository.GenerateStub<IQBSessionInternal>();
            _session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries());
            _classQuery = new ClassQuery(_session); 
        }

        [Test]
        public void ListID_single()
        {
            _classQuery.ListID("123").Single();

            var expected = new XElement("ClassQueryRq",
                new XElement("ListID", "123"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ListID_multiple()
        {
            _classQuery.ListID("123", "456", "789").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("ListID", "123"),
                new XElement("ListID", "456"),
                new XElement("ListID", "789"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void FullName_single()
        {
            _classQuery.FullName("Paul Yoder").Single();

            var expected = new XElement("ClassQueryRq",
                new XElement("FullName", "Paul Yoder"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void FullName_multiple()
        {
            _classQuery.FullName("Paul Yoder", "Abe Lincoln", "Joe Schmoe").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("FullName", "Paul Yoder"),
                new XElement("FullName", "Abe Lincoln"),
                new XElement("FullName", "Joe Schmoe"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void MaxReturned()
        {
            _classQuery.MaxReturned(20).List();

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", 20));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ActiveStatus()
        {
            _classQuery.ActiveStatus("All").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("ActiveStatus", "All"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateModifiedFrom()
        {
            _classQuery.DateModifiedFrom(new DateTime(2008, 1, 1)).List();

            var expected = new XElement("ClassQueryRq",
                new XElement("FromModifiedDate", new DateTime(2008, 1, 1).ToXMLDateString()));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void DateModifiedTo()
        {
            _classQuery.DateModifiedTo(new DateTime(2009, 9, 1)).List();

            var expected = new XElement("ClassQueryRq",
                new XElement("ToModifiedDate", new DateTime(2009, 9, 1).ToXMLDateString()));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void NameFilter()
        {
            _classQuery.NameFilter("StartsWith", "Paul").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("NameFilter",
                    new XElement("MatchCriterion", "StartsWith"),
                    new XElement("Name", "Paul")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void NameRangeFilter()
        {
            _classQuery.NameRangeFilter("Paul", "Sara").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("NameRangeFilter",
                    new XElement("FromName", "Paul"),
                    new XElement("ToName", "Sara")));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void IncludeRetElement_single()
        {
            _classQuery.IncludeRetElement("ListID").Single();

            var expected = new XElement("ClassQueryRq",
                new XElement("IncludeRetElement", "ListID"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void IncludeRetElement_multiple()
        {
            _classQuery.IncludeRetElement("ListID", "EditSequence", "IsActive").List();

            var expected = new XElement("ClassQueryRq",
                new XElement("IncludeRetElement", "ListID"),
                new XElement("IncludeRetElement", "EditSequence"),
                new XElement("IncludeRetElement", "IsActive"));
            var actual = _session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[0][0] as XElement;

            AssertXmlAreEqual(expected, actual);
        }
    }
}
