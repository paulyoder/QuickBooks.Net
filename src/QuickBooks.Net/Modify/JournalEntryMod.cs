using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using System.Xml.Linq;

namespace QuickBooks.Net.Modify
{
    public class JournalEntryMod : 
        ModifyBase<IJournalEntryMod, JournalEntry>,
        IJournalEntryMod
    {
        public JournalEntryMod(IQBSessionInternal session)
            : base(session, "JournalEntryModRq","JournalEntryModRs","JournalEntryMod")
        {
            _returnMod = this;
        }

        public IJournalEntryMod TxnID(string txnID)
        {
            AddUpdateMessage("TxnID", txnID);
            return this;
        }

        public IJournalEntryMod EditSequence(string editSequence)
        {
            AddUpdateMessage("EditSequence", editSequence);
            return this;
        }

        public IJournalEntryMod TxnDate(DateTime date)
        {
            AddUpdateMessage("TxnDate", date);
            return this;
        }

        public IJournalEntryMod RefNumber(string refNumber)
        {
            AddUpdateMessage("RefNumber", refNumber);
            return this;
        }

        public IJournalEntryMod IsAdjustment()
        {
            AddUpdateMessage("IsAdjustment", true);
            return this;
        }

        public IJournalEntryMod JournalLines(params JournalLine[] lines)
        {
            var order = _xmlBase.ElementOrder.ChildrenOrder[0].ChildrenOrder
                .Where(x => x.Name == "JournalLineMod")
                .Single();

            foreach (var line in lines)
            {
                var lineXML = new XElement("JournalLineMod");
                AddUpdateMessage(lineXML, order, "TxnLineID", line.TxnLineID);
                AddUpdateMessage(lineXML, order, "JournalLineType", line.Type);
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

                _xmlBase.InsertXElement(_xmlBase.Xml.Element("JournalEntryMod"), lineXML, _xmlBase.ElementOrder.ChildrenOrder[0]);
            }

            return this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                new ElementPosition("JournalEntryMod",
                    "TxnID",
                    "EditSequence",
                    "TxnDate",
                    "RefNumber",
                    "IsAdjustment",
                    new ElementPosition("JournalLineMod",
                        "TxnLineID",
                        "JournalLineType",
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
