using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using System.Xml.Linq;

namespace QuickBooks.Net.Add
{
    public class JournalEntryAdd : 
        AddBase<IJournalEntryAdd, JournalEntry>, 
        IJournalEntryAdd
    {
        public JournalEntryAdd(IQBSessionInternal session)
            : base(session, "JournalEntryAddRq", "JournalEntryAddRs", "JournalEntryAdd")
        {
            _returnAdd = this;
        }

        public IJournalEntryAdd TxnDate(DateTime date)
        {
            AddUpdateMessage("TxnDate", date);
            return this;
        }

        public IJournalEntryAdd RefNumber(string refNumber)
        {
            AddUpdateMessage("RefNumber", refNumber);
            return this;
        }

        public IJournalEntryAdd IsAdjustment()
        {
            AddUpdateMessage("IsAdjustment", true);
            return this;
        }

        public IJournalEntryAdd DebitLines(params JournalLine[] debitLines)
        {
            foreach (var debitLine in debitLines)
                AddJournalLine("JournalDebitLine", debitLine);
            return this;
        }

        public IJournalEntryAdd CreditLines(params JournalLine[] creditLines)
        {
            foreach (var creditLine in creditLines)
                AddJournalLine("JournalCreditLine", creditLine);
            return this;
        }

        protected void AddJournalLine(string ParentNode, JournalLine line)
        {
            var lineXML = new XElement(ParentNode);
            var order = _xmlBase.ElementOrder.ChildrenOrder[0].ChildrenOrder
                .Where(x => x.Name == ParentNode)
                .Single();
            
            AddUpdateMessage(lineXML, order, "TxnLineID", line.TxnLineID);
            AddUpdateMessage(lineXML, order, "Amount", line.Amount.ToString("0.00"));
            AddUpdateMessage(lineXML, order, "Memo", line.Memo);
            AddUpdateMessage(lineXML, order, "BillableStatus", line.BillableStatus);
            if (line.AccountRef != null)
            {
                AddUpdateMessage(lineXML, order, "AccountRef", "ListID", line.AccountRef.ListID);
                AddUpdateMessage(lineXML, order, "AccountRef", "FullName", line.AccountRef.FullName);
            }
            if (line.EntityRef != null)
            {
                AddUpdateMessage(lineXML, order, "EntityRef", "ListID", line.EntityRef.ListID);
                AddUpdateMessage(lineXML, order, "EntityRef", "FullName", line.EntityRef.FullName);
            }
            if (line.ClassRef != null)
            {
                AddUpdateMessage(lineXML, order, "ClassRef", "ListID", line.ClassRef.ListID);
                AddUpdateMessage(lineXML, order, "ClassRef", "FullName", line.ClassRef.FullName);
            }

            _xmlBase.InsertXElement(_xmlBase.Xml.Element("JournalEntryAdd"), lineXML, _xmlBase.ElementOrder.ChildrenOrder[0]);
        }

        public virtual JournalEntry Add()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            _xmlBase.ResetXml();
            return XMLtoPOCOList(response).First();
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                new ElementPosition("JournalEntryAdd",
                    "TxnDate",
                    "RefNumber",
                    "IsAdjustment",
                    new ElementPosition("JournalDebitLine",
                        "TxnLineID",
                        ElementPosition.Ref("AccountRef"),
                        "Amount",
                        "Memo",
                        ElementPosition.Ref("EntityRef"),
                        ElementPosition.Ref("ClassRef"),
                        "BillableStatus"),
                    new ElementPosition("JournalCreditLine",
                        "TxnLineID",
                        ElementPosition.Ref("AccountRef"),
                        "Amount",
                        "Memo",
                        ElementPosition.Ref("EntityRef"),
                        ElementPosition.Ref("ClassRef"),
                        "BillableStatus"),
                    "IncludeRetElement"));
        }
    }
}
