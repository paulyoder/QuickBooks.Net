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
    public class ReportRowsTest
    {
        [Test]
        public void All()
        {
            Assert.AreEqual(4, new ReportRows(RowsXML(), null).All.Count());
        }

        [Test]
        public void Data()
        {
            var rows = new ReportRows(RowsXML(), null);
            Assert.AreEqual(1, rows.Data.Count());
            Assert.AreEqual("DataRow", rows.Data.First().Type);
        }

        [Test]
        public void Subtotal()
        {
            var rows = new ReportRows(RowsXML(), null);
            Assert.AreEqual(1, rows.Subtotal.Count());
            Assert.AreEqual("SubtotalRow", rows.Subtotal.First().Type);
        }

        [Test]
        public void Total()
        {
            var rows = new ReportRows(RowsXML(), null);
            Assert.AreEqual(1, rows.Total.Count());
            Assert.AreEqual("TotalRow", rows.Total.First().Type);
        }

        [Test]
        public void Text()
        {
            var rows = new ReportRows(RowsXML(), null);
            Assert.AreEqual(1, rows.Text.Count());
            Assert.AreEqual("TextRow", rows.Text.First().Type);
        }

        protected XElement RowsXML()
        {
            return new XElement("ReportData",
                new XElement("DataRow",
                    new XElement("RowData",
                        new XAttribute("rowType", "account"),
                        new XAttribute("value", "1.5")),
                    new XElement("ColData",
                        new XAttribute("colID", "1"),
                        new XAttribute("value", "55"),
                        new XAttribute("dataType", "int")),
                    new XElement("ColData",
                        new XAttribute("colID", "2"),
                        new XAttribute("value", "Yoder, Paul"),
                        new XAttribute("dataType", "int")),
                    new XElement("ColData",
                        new XAttribute("colID", "3"),
                        new XAttribute("value", "Deposit"),
                        new XAttribute("dataType", "int"))),
                new XElement("TextRow",
                    new XAttribute("rowNumber", "2"),
                    new XAttribute("value", "This is a report")),
                new XElement("SubtotalRow",
                    new XElement("RowData",
                        new XAttribute("rowType", "class"),
                        new XAttribute("value", "88")),
                    new XElement("ColData",
                        new XAttribute("colID", "2"),
                        new XAttribute("value", "33"),
                        new XAttribute("dataType", "string"))),
                new XElement("TotalRow",
                    new XElement("RowData",
                        new XAttribute("rowType", "customer"),
                        new XAttribute("value", "67")),
                    new XElement("ColData",
                        new XAttribute("colID", "3"),
                        new XAttribute("value", "44"),
                        new XAttribute("dataType", "amount"))));
        }
    }
}
