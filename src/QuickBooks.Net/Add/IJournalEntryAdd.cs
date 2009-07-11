using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Add
{
    public interface IJournalEntryAdd
    {
        IJournalEntryAdd TxnDate(DateTime date);
        IJournalEntryAdd RefNumber(string refNumber);
        IJournalEntryAdd IsAdjustment();
        IJournalEntryAdd DebitLines(params JournalLine[] debitLines);
        IJournalEntryAdd CreditLines(params JournalLine[] creditLines);
        IJournalEntryAdd IncludeRetElement(params string[] retElements);
        JournalEntry Add();
    }
}
