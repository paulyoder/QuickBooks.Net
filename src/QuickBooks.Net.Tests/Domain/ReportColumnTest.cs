using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Xml.Linq;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Net.Tests.Domain
{
    [TestFixture]
    public class ReportColumnTest
    {
        private XElement ColDataXML()
        {
            return new XElement("ColData",
                new XAttribute("colID", "2"),
                new XAttribute("value", "your mom"),
                new XAttribute("dataType", "string"));
        }

        [Test]
        public void Constructor_sets_Id()
        {
            var column = new ReportColumn(ColDataXML());
            Assert.AreEqual(2, column.Id);
        }

        [Test]
        public void Constructor_sets_Value()
        {
            var column = new ReportColumn(ColDataXML());
            Assert.AreEqual("your mom", column.Value);
        }

        [Test]
        public void Constructor_sets_DataType()
        {
            var column = new ReportColumn(ColDataXML());
            Assert.AreEqual("string", column.DataType);
        }

        [Test]
        [ExpectedArgumentException("RowData is an invalid XElement Name. 'ColData' is the expected XElement Name")]
        public void Constructor_throws_InvalidArgumentException_when_element_name_is_not_ColData()
        {
            var xml = ColDataXML();
            xml.Name = "RowData";
            var column = new ReportColumn(xml);
        }
    }
}
