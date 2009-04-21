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
    public class ReportTest
    {
        [Test]
        public void Title()
        {
            Assert.AreEqual("Main Report", new Report(ReportXML()).Title);
        }

        [Test]
        public void Subtitle()
        {
            Assert.AreEqual("Report Sub Title", new Report(ReportXML()).Subtitle);
        }

        [Test]
        public void ReportBasis()
        {
            Assert.AreEqual("The Basis", new Report(ReportXML()).ReportBasis);
        }

        [Test]
        public void NumRows()
        {
            Assert.AreEqual(22, new Report(ReportXML()).NumRows);
        }

        [Test]
        public void NumColumns()
        {
            Assert.AreEqual(3, new Report(ReportXML()).NumColumns);
        }

        [Test]
        public void NumColTitleRows()
        {
            Assert.AreEqual(2, new Report(ReportXML()).NumColTitleRows);
        }

        [Test]
        public void ColumnDescriptions_Count()
        {
            Assert.AreEqual(2, new Report(ReportXML()).ColumnDescriptions.Count());
        }

        [Test]
        public void Rows_Count()
        {
            Assert.AreEqual(4, new Report(ReportXML()).Rows.All.Count());
        }

        private XElement ReportXML()
        {
            return new XElement("ReportRet",
                new XElement("ReportTitle", "Main Report"),
                new XElement("ReportSubtitle", "Report Sub Title"),
                new XElement("ReportBasis", "The Basis"),
                new XElement("NumRows", 22),
                new XElement("NumColumns", 3),
                new XElement("NumColTitleRows", 2),
                new XElement("ColDesc",
                    new XAttribute("colID", "1"),
                    new XAttribute("dataType", "string"),
                    new XElement("ColTitle",
                        new XAttribute("titleRow", "1"),
                        new XAttribute("value", "The First Title")),
                    new XElement("ColTitle",
                        new XAttribute("titleRow", "2"),
                        new XAttribute("value", "The Second Title")),
                    new XElement("ColType", "Account")),
                new XElement("ColDesc",
                    new XAttribute("colID", "1"),
                    new XAttribute("dataType", "string"),
                    new XElement("ColTitle",
                        new XAttribute("titleRow", "1"),
                        new XAttribute("value", "The First Title")),
                    new XElement("ColTitle",
                        new XAttribute("titleRow", "2"),
                        new XAttribute("value", "The Second Title")),
                    new XElement("ColType", "Account")),
                new XElement("ReportData",
                    new XElement("DataRow",
                        new XElement("RowData",
                            new XAttribute("rowType", "account"),
                            new XAttribute("value", "1.5")),
                        new XElement("ColData",
                            new XAttribute("colID", "1"),
                            new XAttribute("value", "55"),
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
                            new XAttribute("dataType", "amount")))));
        }
    }
}
