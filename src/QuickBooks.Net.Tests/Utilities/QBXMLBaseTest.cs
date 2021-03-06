﻿using System;
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

            public new void AddUpdateMessage(params object[] message)
            {
                base.AddUpdateMessage(message);
            }

            public new void AddUpdateMessage(XElement parent, ElementPosition parentElementPosition, params object[] message)
            {
                base.AddUpdateMessage(parent, parentElementPosition, message);
            }

            public new void AddMessageAllowDuplicates(params object[] message)
            {
                base.AddMessageAllowDuplicates(message);
            }

            public new XElement ConvertObjectArrayToXElement(IList<object> messageList)
            {
                return base.ConvertObjectArrayToXElement(messageList);
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
        public void AddUpdateMessage_doesnt_add_message_if_last_value_is_null()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddUpdateMessage("MaxReturned", "20");
            qbxmlBase.AddUpdateMessage("ListID", null);

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "20"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void AddUpdateMessage_parentXML_doesnt_add_message_if_last_value_is_null()
        {
            var qbxmlBase = new QBXMLBaseChild();
            var xml = new XElement("ClassQueryRq");
            var order = new ElementPosition("ClassQueryRq",
                "MaxReturned",
                "ListID");

            qbxmlBase.AddUpdateMessage(xml, order, "MaxReturned", null);
            qbxmlBase.AddUpdateMessage(xml, order, "ListID", 22);

            var expected = new XElement("ClassQueryRq",
                new XElement("ListID", "22"));
            AssertXmlAreEqual(expected, xml);
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
        public void AddMessageAllowDuplicates_doesnt_add_message_if_last_value_is_null()
        {
            var qbxmlBase = new QBXMLBaseChild();
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", "20");
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", "40");
            qbxmlBase.AddMessageAllowDuplicates("MaxReturned", null);

            var expected = new XElement("ClassQueryRq",
                new XElement("MaxReturned", "20"),
                new XElement("MaxReturned", "40"));
            AssertXmlAreEqual(expected, qbxmlBase.Xml);
        }

        [Test]
        public void ConvertObjectArrayToXElement_two_elements()
        {
            var expected = new XElement("MaxReturned", "20");
            var actual = new QBXMLBaseChild()
                .ConvertObjectArrayToXElement(
                    new List<object>() { "MaxReturned", "20" });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ConvertObjectArrayToXElement_four_elements()
        {
            var expected = new XElement("ClassQueryRq",
                new XElement("AccountFilter",
                    new XElement("AccountFullName", "Yoder, Paul")));
            var actual = new QBXMLBaseChild()
                .ConvertObjectArrayToXElement(
                    new List<object>() { "ClassQueryRq", "AccountFilter", "AccountFullName", "Yoder, Paul" });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ConvertObjectArrayToXElement_converts_decimal_to_string()
        {
            var expected = new XElement("ClassQueryRq",
                new XElement("AccountFilter",
                    new XElement("AccountBalance", "20.22")));
            var actual = new QBXMLBaseChild()
                .ConvertObjectArrayToXElement(
                    new List<object>() { "ClassQueryRq", "AccountFilter", "AccountBalance", (decimal)20.22 });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ConvertObjectArrayToXElement_converts_bool_to_string()
        {
            var expected = new XElement("ClassQueryRq",
                new XElement("IsActive", "true"));
            var actual = new QBXMLBaseChild()
                .ConvertObjectArrayToXElement(
                    new List<object>() { "ClassQueryRq", "IsActive", true });
            AssertXmlAreEqual(expected, actual);
        }

        [Test]
        public void ConvertObjectArrayToXElement_converts_DateTime_to_XMLVersionOfDateTime()
        {
            var expected = new XElement("ClassQueryRq",
                new XElement("AccountFilter",
                    new XElement("AccountOpenDate", "2009-01-01")));
            var actual = new QBXMLBaseChild()
                .ConvertObjectArrayToXElement(
                    new List<object>() { "ClassQueryRq", "AccountFilter", "AccountOpenDate", new DateTime(2009, 1, 1) });
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
