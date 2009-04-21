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
    public class ReportRowTest
    {
        private XElement ReportDataXML()
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

        private XElement DataRowXML()
        {
            return new XElement("DataRow",
                new XElement("RowData",
                    new XAttribute("rowType", "account"),
                    new XAttribute("value", "1.5")),
                new XElement("ColData",
                    new XAttribute("colID", "1"),
                    new XAttribute("value", "55"),
                    new XAttribute("dataType", "int")),
                new XElement("ColData",
                    new XAttribute("colID", "2"),
                    new XAttribute("value", "88"),
                    new XAttribute("dataType", "int")));
        }

        private XElement TextRowXML()
        {
            return new XElement("TextRow",
                new XAttribute("rowNumber", "2"),
                new XAttribute("value", "This is a report"));
        }

        private XElement SubtotalRowXML()
        {
            return new XElement("SubtotalRow",
                new XElement("RowData",
                    new XAttribute("rowType", "class"),
                    new XAttribute("value", "88")),
                new XElement("ColData",
                    new XAttribute("colID", "1"),
                    new XAttribute("value", "33"),
                    new XAttribute("dataType", "string")),
                new XElement("ColData",
                    new XAttribute("colID", "2"),
                    new XAttribute("value", "54"),
                    new XAttribute("dataType", "int")),
                new XElement("ColData",
                    new XAttribute("colID", "3"),
                    new XAttribute("value", "Yoder, Paul"),
                    new XAttribute("dataType", "int"))); ;
        }

        private XElement TotalRowXML()
        {
            return new XElement("TotalRow",
                new XElement("RowData",
                    new XAttribute("rowType", "customer"),
                    new XAttribute("value", "67")),
                new XElement("ColData",
                    new XAttribute("colID", "1"),
                    new XAttribute("value", "44"),
                    new XAttribute("dataType", "amount")),
                new XElement("ColData",
                    new XAttribute("colID", "2"),
                    new XAttribute("value", "67"),
                    new XAttribute("dataType", "int")));
        }

        [Test]
        public void DataRow_Type()
        {
            Assert.AreEqual("DataRow", new ReportRow(DataRowXML()).Type);
        }

        [Test]
        public void DataRow_RowType()
        {
            Assert.AreEqual("account", new ReportRow(DataRowXML()).RowType);
        }

        [Test]
        public void DataRow_RowValue()
        {
            Assert.AreEqual("1.5", new ReportRow(DataRowXML()).RowValue);
        }

        [Test]
        public void DataRow_ColumnCount()
        {
            Assert.AreEqual(2, new ReportRow(DataRowXML()).Columns.Count());
        }

        [Test]
        public void TextRow_Type()
        {
            Assert.AreEqual("TextRow", new ReportRow(TextRowXML()).Type);
        }

        [Test]
        public void TextRow_Value()
        {
            Assert.AreEqual("This is a report", new ReportRow(TextRowXML()).RowValue);
        }

        [Test]
        public void TextRow_ColumnsCount()
        {
            Assert.AreEqual(0, new ReportRow(TextRowXML()).Columns.Count());
        }

        [Test]
        public void SubtotalRow_Type()
        {
            Assert.AreEqual("SubtotalRow", new ReportRow(SubtotalRowXML()).Type);
        }

        [Test]
        public void SubtotalRow_RowType()
        {
            Assert.AreEqual("class", new ReportRow(SubtotalRowXML()).RowType);
        }

        [Test]
        public void SubtotalRow_RowValue()
        {
            Assert.AreEqual("88", new ReportRow(SubtotalRowXML()).RowValue);
        }

        [Test]
        public void SubtotalRow_ColumnCount()
        {
            Assert.AreEqual(3, new ReportRow(SubtotalRowXML()).Columns.Count());
        }

        [Test]
        public void TotalRow_Type()
        {
            Assert.AreEqual("TotalRow", new ReportRow(TotalRowXML()).Type);
        }

        [Test]
        public void TotalRow_RowType()
        {
            Assert.AreEqual("customer", new ReportRow(TotalRowXML()).RowType);
        }

        [Test]
        public void TotalRow_RowValue()
        {
            Assert.AreEqual("67", new ReportRow(TotalRowXML()).RowValue);
        }

        [Test]
        public void TotalRow_ColumnCount()
        {
            Assert.AreEqual(2, new ReportRow(TotalRowXML()).Columns.Count());
        }

        [Test]
        public void Indexer_ReturnsColumnValue()
        {

        }

        [Test]
        public void Indexer_ReturnsBlankWhenColumnNameDoesntExistOnRow()
        {

        }
    }
}
