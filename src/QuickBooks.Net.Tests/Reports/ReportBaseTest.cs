using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Xml.Linq;
using Rhino.Mocks;
using QuickBooks.Net.Reports;

namespace QuickBooks.Net.Net.Tests.Reports
{
    [TestFixture]
    public class ReportBaseTest
    {
        [Test]
        public void RunReport_returns_report()
        {
            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(ReportXML());

            var customReport = new CustomDetailReport(session);
            var report = customReport.RunReport();
            Assert.AreEqual("Main Report", report.Title);
        }

        [Test]
        [ExpectedException(typeof(QBException), "Bad Report")]
        public void RunReport_throws_QBException_on_qb_error()
        {
            var responseAll = ReportXML();
            var responseMessage = responseAll.Descendants("CustomDetailReportQueryRs").First();
            responseMessage.Attribute("statusCode").Value = "500";
            responseMessage.Attribute("statusMessage").Value = "Bad Report";

            var session = MockRepository.GenerateStub<IQBSessionInternal>();
            session.Expect(x => x.ProcessRequest(null))
                .IgnoreArguments()
                .Return(responseAll);

            new CustomDetailReport(session).RunReport();
        }

        private XElement ReportXML()
        {
            return new XElement("QBXML",
                new XElement("CustomDetailReportQueryRs",
                    new XAttribute("statusCode", "0"),
                    new XAttribute("statusMessage", "Status OK"),
                    new XElement("ReportRet",
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
                                    new XAttribute("dataType", "amount")))))));
        }
    }
}
