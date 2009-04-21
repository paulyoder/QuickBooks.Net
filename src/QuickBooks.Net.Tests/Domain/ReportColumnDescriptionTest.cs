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
    public class ReportColumnDescriptionTest
    {
        private XElement ColDescXML()
        {
            return new XElement("ColDesc",
                new XAttribute("colID","1"),
                new XAttribute("dataType","string"),
                new XElement("ColTitle",
                    new XAttribute("titleRow","1"),
                    new XAttribute("value","The First Title")),
                new XElement("ColTitle",
                    new XAttribute("titleRow", "2"),
                    new XAttribute("value", "The Second Title")),
                new XElement("ColType","Account"));
        }

        [Test]
        public void Id()
        {
            var col = new ReportColumnDescription(ColDescXML());
            Assert.AreEqual(1, col.Id);
        }

        [Test]
        public void DataType()
        {
            var col = new ReportColumnDescription(ColDescXML());
            Assert.AreEqual("string", col.DataType);
        }

        [Test]
        public void Titles()
        {
            var col = new ReportColumnDescription(ColDescXML());
            Assert.AreEqual("The Second Title", col.Titles.ElementAt(1));
        }

        [Test]
        public void ColumnType()
        {
            var col = new ReportColumnDescription(ColDescXML());
            Assert.AreEqual("Account", col.ColumnType);
        }

        [Test]
        [ExpectedArgumentException("RowData is an invalid XElement Name. 'ColDesc' is the expected XElement Name")]
        public void Constructor_throws_InvalidArgumentException_when_element_name_is_not_ColData()
        {
            var xml = ColDescXML();
            xml.Name = "RowData";
            var column = new ReportColumnDescription(xml);
        }
    }
}
