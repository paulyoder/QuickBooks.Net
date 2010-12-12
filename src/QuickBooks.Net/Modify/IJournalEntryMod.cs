using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Modify
{
    public interface IJournalEntryMod
    {
        IJournalEntryMod TxnID(string txnID);
        IJournalEntryMod EditSequence(string editSequence);
        IJournalEntryMod TxnDate(DateTime date);
        IJournalEntryMod RefNumber(string refNumber);
        IJournalEntryMod IsAdjustment();
        IJournalEntryMod JournalLines(params JournalLine[] lines);
        IJournalEntryMod IncludeRetElement(params string[] retElements);
        JournalEntry Modify();
    }
}
