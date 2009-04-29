using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using System.Xml.Linq;
using QuickBooks.Net.Tests;

namespace QuickBooks.Net.Net.Tests.Utilities
{
    [TestFixture]
    public class QBXMLBaseTest : XmlTestUtilities
    {
        protected class QBXMLBaseChild : QBXMLBase<QBClass>
        {
            internal QBXMLBaseChild()
                : base(null, "ClassQueryRq", "ClassQueryRs")
            { }

            public new void AddUpdateMessage(params string[] message)
            {
                base.AddUpdateMessage(message);
            }

            public new void AddMessageAllowDuplicates(params string[] message)
            {
                base.AddMessageAllowDuplicates(message);
            }

            public new XElement ConvertStringArrayToXElement(IList<string> messageList)
            {
                return base.ConvertStringArrayToXElement(messageList);
            }

            public new void CheckForErrorMessageInResponse(XElement response)
            {
                base.CheckForErrorMessageInResponse(response);
            }

            public new IList<QBClass> XMLtoPOCOList(XElement response)
            {
                return base.XMLtoPOCOList(response);
            }

            public XElement Xml
            {
                get { return _xmlBase.Xml; }
            }
        }

        [Test]
        public void AddUpdateMessage_adds_new_message()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddUpdateMessage("MaxReturned", "20");
            
            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "20"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void AddUpdateMessage_updates_old_message()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddUpdateMessage("MaxReturned", "20");
            qbxmlBase.AddUpdateMessage("MaxReturned", "40");

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "40"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void AddMessageAllowDuplicates_adds_new_message()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", "20");

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "20"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void AddMessageAllowDuplicates_adds_duplicate_message()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", "20");
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", "40");

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "20"),
                new XElement("MaxReturned", "40"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void ConvertStringArrayToXElement_two_elements()
        {
            var expected = new XElement("MaxReturned", "20");
            var actual = new QBXMLBaseChild()
                .ConvertStringArrayToXElement(
                    new List<string>() { "MaxReturned", "20" });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ConvertStringArrayToXElement_four_elements()
        {
            var expected = new XElement("ClassQueryRq",
                new XElement("AccountFilter",
                    new XElement("AccountFullName", "Yoder, Paul")));
            var actual = new QBXMLBaseChild()
                .ConvertStringArrayToXElement(
                    new List<string>() { "ClassQueryRq", "AccountFilter", "AccountFullName", "Yoder, Paul" });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void CheckForErrorMessageInResponse_does_not_throw_exception_if_status_code_equals_0()
        {
            var response = new XElement("ClassQueryRs",
                new XAttribute("statusCode", "0"),
                new XAttribute("statusMessage", "Status OK"));
            new QBXMLBaseChild().CheckForErrorMessageInResponse(response);
        }

        [Test]
        public void CheckForErrorMessageInResponse_does_not_throw_exception_if_status_code_equals_1()
        {
            var response = new XElement("ClassQueryRs",
                new XAttribute("statusCode", "1"),
                new XAttribute("statusMessage", "No Results Returned"));
            new QBXMLBaseChild().CheckForErrorMessageInResponse(response);
        }

        [Test]
        [ExpectedException(typeof(QBException), "Bad Error")]
        public void CheckForErrorMessageInResponse_throws_QBException_on_error()
        {
            var response = new XElement("ClassQueryRs",
                new XAttribute("statusCode", "500"),
                new XAttribute("statusMessage", "Bad Error"));
            new QBXMLBaseChild().CheckForErrorMessageInResponse(response);
        }

        [Test]
        public void XMLtoPOCOList()
        {
            var xml = new XElement("ClassQueryRs",
                new XElement("ClassRet",
                    new XElement("ListID", "123"),
                    new XElement("Name", "Yoder, Paul")),
                new XElement("ClassRet",
                    new XElement("ListID", "456"),
                    new XElement("Name", "Buffett, Warren")));

            var pocoList = new QBXMLBaseChild().XMLtoPOCOList(xml);
            Assert.AreEqual(2, pocoList.Count, "Count");
            Assert.AreEqual("123", pocoList[0].ListID, "ListID");
            Assert.AreEqual("Buffett, Warren", pocoList[1].Name, "Name");
        }
    }


}
