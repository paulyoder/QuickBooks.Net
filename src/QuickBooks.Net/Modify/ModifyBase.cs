using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Modify
{
    public class ModifyBase<IReturnMod, TReturn> : QBXMLBase<TReturn>
    {
        protected IReturnMod _returnMod;
        private string _modElementName;

        public ModifyBase(IQBSessionInternal session, string requestName, string responseName, string modElementName)
            : base(session, requestName, responseName)
        {
            _modElementName = modElementName;
        }

        protected override void AddUpdateMessage(params object[] message)
        {
            base.AddUpdateMessage(
                new List<object>().Ad(_modElementName).AdRange(message).ToArray());
        }

        protected override void AddMessageAllowDuplicates(params object[] message)
        {
            base.AddMessageAllowDuplicates(
                new List<object>().Ad(_modElementName).AdRange(message).ToArray());
        }

        public virtual IReturnMod IncludeRetElement(params string[] retElements)
        {
            foreach (var retElement in retElements)
                AddMessageAllowDuplicates("IncludeRetElement", retElement);
            return _returnMod;
        }

        public virtual TReturn Modify()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            _xmlBase.ResetXml();
            return XMLtoPOCOList(response).First();
        }
    }
}
