using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Query;
using QuickBooks.Net.Utilities;
using Rhino.Mocks;
using System.Xml.Linq;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities.DateTimeExtensions;
using QuickBooks.Net.Tests.Utilities;

namespace QuickBooks.Net.Tests.Query
{
    [TestFixture]
    public class QueryBaseTest : QueryResponses
    {
        [Test]
        public void List_sends_qbxml_message_to_session()
        {
            var expectedMessage = new XElement("ClassQueryRq",
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries());

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).List();
            
            var actualMessage = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null)).First()[0] as XElement;
            AssertXmlAreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void List_clears_xml_message_afterwards()
        {
            var expectedMessage = new XElement("ClassQueryRq");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).List();
            daoChild.List();

            var actualMessage = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void List_deserializes_xml_response_into_TReturns_type()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries());

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var classes = daoChild.List();

            Assert.AreEqual(2, classes.Count, "Count");
            Assert.AreEqual("22", classes[0].ListID, "First ListID");
            Assert.AreEqual(4, classes[1].Sublevel, "Second Sublevel");
        }

        [Test]
        [ExpectedException(typeof(QBException), "There was an error in the query")]
        public void List_throws_QBException_when_error_message_in_qb_response()
        {
            var response = ValidSessionResponseForClassQueries();
            response.Descendants("ClassQueryRs").First().Attribute("statusCode").SetValue("500");
            response.Descendants("ClassQueryRs").First().Attribute("statusMessage").SetValue("There was an error in the query");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(response);

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var classes = daoChild.List();
        }

        [Test]
        public void Single_clears_xml_message_afterwards()
        {
            var expectedMessage = new XElement("ClassQueryRq");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Single();
            daoChild.Single();

            var actualMessage = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void Single_deserializes_xml_response_into_TReturn_type()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForClassQueries());

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var @class = daoChild.Single();

            Assert.AreEqual("22", @class.ListID, "ListID");
        }

        [Test]
        public void Single_returns_null_when_nothing_returns()
        {
            var noReturnedClasses = ValidSessionResponseForClassQueries();
            noReturnedClasses.Descendants("ClassQueryRs").First().RemoveNodes();

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(noReturnedClasses);

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");

            Assert.IsNull(daoChild.Single());
        }

        [Test]
        [ExpectedException(typeof(QBException), "There was an error in the query")]
        public void Single_throws_QBException_when_error_message_in_qb_response()
        {
            var response = ValidSessionResponseForClassQueries();
            response.Descendants("ClassQueryRs").First().Attribute("statusCode").SetValue("500");
            response.Descendants("ClassQueryRs").First().Attribute("statusMessage").SetValue("There was an error in the query");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(response);

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var classes = daoChild.Single();
        }

        [Test]
        [ExpectedException(typeof(QBException), "MaxReturned property must be set to use the Iterate function")]
        public void Iterate_throws_exception_if_MaxReturned_not_set()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.Iterate();
        }

        [Test]
        public void Iterate_sets_iterator_attribute_to_Start_on_first_request()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Start"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null)).First()[0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void Iterate_sets_iterator_attribute_to_Continue_on_second_request()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Continue"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();
            daoChild.MaxReturned(20).Iterate();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void Iterate_gets_iteratorID_from_response_and_sets_it_on_the_request()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Continue"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();
            daoChild.MaxReturned(20).Iterate();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void Iterate_sets_IteratorRemainingCount()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();

            Assert.AreEqual(2000, daoChild.IteratorRemainingCount);
        }

        [Test]
        public void Iterate_deserializes_xml_response_into_TReturn_type()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var classes = daoChild.MaxReturned(20).Iterate();

            Assert.AreEqual(2, classes.Count, "Count");
            Assert.AreEqual("22", classes[0].ListID, "First ListID");
            Assert.AreEqual(4, classes[1].Sublevel, "Second Sublevel");
        }

        [Test]
        public void Iterate_does_not_clear_xml_message_when_there_are_still_iterations_left()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Continue"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();
            //This should still have the MaxReturned XElement set since we are not
            //at the end of the iteration
            daoChild.Iterate();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void Iterate_clears_xml_message_when_iteration_is_complete()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Start"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));
            var response = ValidSessionResponseForIteratedClassQueries();
            response.Descendants("ClassQueryRs").First().Attribute("iteratorRemainingCount").SetValue("0");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(response)
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).AccountListID("55").Iterate();
            daoChild.MaxReturned(20).Iterate();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(QBException), "There was an error in the query")]
        public void Iterate_throws_QBException_when_error_message_in_qb_response()
        {
            var response = ValidSessionResponseForIteratedClassQueries();
            response.Descendants("ClassQueryRs").First().Attribute("statusCode").SetValue("500");
            response.Descendants("ClassQueryRs").First().Attribute("statusMessage").SetValue("There was an error in the query");

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(response);

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            var classes = daoChild.MaxReturned(20).Iterate();
        }

        [Test]
        public void StopIteration_sets_iterator_attribute_to_Stop()
        {
            var expected = new XElement("ClassQueryRq",
                new XAttribute("iterator", "Stop"),
                new XAttribute("iteratorID", 123),
                new XElement("MaxReturned", 20));

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Stub(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ValidSessionResponseForIteratedClassQueries())
                .Repeat.Any();

            var daoChild = new QueryBaseChild(session, "ClassQueryRq", "ClassQueryRs");
            daoChild.MaxReturned(20).Iterate();
            daoChild.StopIteration();

            var actual = session.GetArgumentsForCallsMadeOn(x => x.ProcessRequest(null))[1][0] as XElement;
            AssertXmlAreEqual(expected, actual);
        }
    }

    public class QueryBaseChild : QueryBase<QBClass>
    {
        public QueryBaseChild(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        { }

        public QueryBaseChild MaxReturned(int maxReturned)
        {
            AddUpdateMessage("MaxReturned", maxReturned.ToString());
            return this;
        }

        public QueryBaseChild AccountListID(string accountListID)
        {
            AddUpdateMessage("AccountListID", accountListID);
            return this;
        }
    }
}
