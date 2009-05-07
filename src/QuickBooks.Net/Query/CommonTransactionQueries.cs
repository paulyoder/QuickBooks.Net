using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Query
{
    public class CommonTransactionQueries<IReturnQuery, TReturn> :
        CommonQueries<IReturnQuery, TReturn>, ICommonTransactionQueries<IReturnQuery, TReturn>
    {
        public CommonTransactionQueries(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        {
            _modifiedDateFromElement = new string[] { "ModifiedDateRangeFilter", "FromModifiedDate" };
            _modifiedDateToElement = new string[] { "ModifiedDateRangeFilter", "ToModifiedDate" };
        }

        public virtual IReturnQuery TxnID(params string[] txnIDs)
        {
            foreach (var txnID in txnIDs)
                AddMessageAllowDuplicates("TxnID", txnID);
            return _returnQuery;
        }

        public virtual IReturnQuery DateFrom(DateTime fromDate)
        {
            AddUpdateMessage("TxnDateRangeFilter", "FromTxnDate", fromDate);
            return _returnQuery;
        }

        public virtual IReturnQuery DateTo(DateTime toDate)
        {
            AddUpdateMessage("TxnDateRangeFilter", "ToTxnDate", toDate);
            return _returnQuery;
        }

        public virtual IReturnQuery DateMacro(string dateMacro)
        {
            AddUpdateMessage("TxnDateRangeFilter", "DateMacro", dateMacro);
            return _returnQuery;
        }

        public virtual IReturnQuery EntityListID(params string[] entityListIDs)
        {
            foreach (var entityListID in entityListIDs)
                AddMessageAllowDuplicates("EntityFilter", "ListID", entityListID);
            return _returnQuery;
        }

        public virtual IReturnQuery EntityListIDWithChildren(string entityListID)
        {
            AddUpdateMessage("EntityFilter", "ListIDWithChildren", entityListID);
            return _returnQuery;
        }

        public virtual IReturnQuery EntityFullName(params string[] entityFullNames)
        {
            foreach (var entityFullName in entityFullNames)
                AddMessageAllowDuplicates("EntityFilter", "FullName", entityFullName);
            return _returnQuery;
        }

        public virtual IReturnQuery EntityFullNameWithChildren(string entityFullName)
        {
            AddUpdateMessage("EntityFilter", "FullNameWithChildren", entityFullName);
            return _returnQuery;
        }

        public virtual IReturnQuery AccountListID(params string[] accountListIDs)
        {
            foreach (var accountListID in accountListIDs)
                AddMessageAllowDuplicates("AccountFilter", "ListID", accountListID);
            return _returnQuery;
        }

        public virtual IReturnQuery AccountListIDWithChildren(string accountListID)
        {
            AddUpdateMessage("AccountFilter", "ListIDWithChildren", accountListID);
            return _returnQuery;
        }

        public virtual IReturnQuery AccountFullName(params string[] accountFullNames)
        {
            foreach (var accountFullName in accountFullNames)
                AddMessageAllowDuplicates("AccountFilter", "FullName", accountFullName);
            return _returnQuery;
        }

        public virtual IReturnQuery AccountFullNameWithChildren(string accountFullName)
        {
            AddUpdateMessage("AccountFilter", "FullNameWithChildren", accountFullName);
            return _returnQuery;
        }

        public virtual IReturnQuery IncludeLineItems()
        {
            AddUpdateMessage("IncludeLineItems", "true");
            return _returnQuery;
        }

        public virtual IReturnQuery OwnerID(params string[] ownerIDs)
        {
            foreach (var ownerID in ownerIDs)
                AddMessageAllowDuplicates("OwnerID", ownerID);
            return _returnQuery;
        }
    }
}
