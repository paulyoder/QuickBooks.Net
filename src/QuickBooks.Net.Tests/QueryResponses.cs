using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using QuickBooks.Net.Utilities.DateTimeExtensions;

namespace QuickBooks.Net.Tests.Utilities
{
    public class QueryResponses : XmlTestUtilities
    {
        protected XElement ValidSessionResponseForClassQueries()
        {
            return new XElement("ClassQueryRs",
                new XAttribute("statusCode", 0),
                new XAttribute("statusMessage", "Status OK"),
                new XAttribute("retCount", 1),
                new XElement("ClassRet",
                    new XElement("ListID", "22"),
                    new XElement("TimeCreated", new DateTime(2008, 1, 1).ToXMLDateString()),
                    new XElement("TimeModified", new DateTime(2008, 2, 2).ToXMLDateString()),
                    new XElement("EditSequence", "1"),
                    new XElement("Name", "Paul"),
                    new XElement("FullName", "Paul Yoder"),
                    new XElement("Sublevel", 1)),
                new XElement("ClassRet",
                    new XElement("ListID", "54"),
                    new XElement("TimeCreated", new DateTime(2007, 1, 1).ToXMLDateString()),
                    new XElement("TimeModified", new DateTime(2007, 2, 2).ToXMLDateString()),
                    new XElement("EditSequence", "3"),
                    new XElement("Name", "Sara"),
                    new XElement("FullName", "Sara Yoder"),
                    new XElement("Sublevel", 4)));
        }

        /// <summary>
        /// A Valid Class Query cannot be iterated, but it is used in this case
        /// just for testing
        /// </summary>
        protected XElement ValidSessionResponseForIteratedClassQueries()
        {
            var response = ValidSessionResponseForClassQueries();
            response.Add(new XAttribute("iteratorID", 123));
            response.Add(new XAttribute("iteratorRemainingCount", 2000));
            return response;

        }

        protected XElement ValidSessionResponseForCreditCardQueries()
        {
            return new XElement("CreditCardChargeQueryRs",
                new XAttribute("statusCode", 0),
                new XAttribute("statusMessage", "Status OK"),
                new XAttribute("retCount", 1),
                new XElement("CreditCardChargeRet",
                    new XElement("TxnID", "12345"),
                    new XElement("TimeCreated", new DateTime(2008, 1, 1).ToXMLDateString()),
                    new XElement("TimeModified", new DateTime(2009, 2, 2).ToXMLDateString()),
                    new XElement("EditSequence", "09876"),
                    new XElement("TxnNumber", "999"),
                    new XElement("TxnDate", new DateTime(2008, 1, 2).ToXMLDateString()),
                    new XElement("Memo", "hello mom"),
                    new XElement("DepositTotal", 100)));
        }

        protected XElement ValidSessionResponseForDepositQueries()
        {
            return new XElement("DepositQueryRs",
                new XAttribute("statusCode", 0),
                new XAttribute("statusMessage", "Status OK"),
                new XAttribute("retCount", 1),
                new XElement("DepositRet",
                    new XElement("TxnID", "12345"),
                    new XElement("TimeCreated", new DateTime(2008, 1, 1).ToXMLDateString()),
                    new XElement("TimeModified", new DateTime(2009, 2, 2).ToXMLDateString()),
                    new XElement("EditSequence", "09876"),
                    new XElement("TxnNumber", "999"),
                    new XElement("TxnDate", new DateTime(2008, 1, 2).ToXMLDateString()),
                    new XElement("Memo", "hello mom"),
                    new XElement("DepositTotal", 100)));
        }
    }
}
