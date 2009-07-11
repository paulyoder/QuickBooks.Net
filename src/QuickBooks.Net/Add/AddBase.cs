using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Add
{
    public class AddBase<IReturnAdd, TReturn> : 
        QBXMLBase<TReturn>
    {
        protected IReturnAdd _returnAdd;
        private string _addElementName;

        public AddBase(IQBSessionInternal session, string requestName, string responseName, string addElementName)
            : base(session, requestName, responseName)
        {
            _addElementName = addElementName;
        }

        protected override void AddUpdateMessage(params object[] message)
        {
            base.AddUpdateMessage(
                new List<object>().Ad(_addElementName).AdRange(message).ToArray());
        }

        protected override void AddMessageAllowDuplicates(params object[] message)
        {
            base.AddMessageAllowDuplicates(
                new List<object>().Ad(_addElementName).AdRange(message).ToArray());
        }

        public virtual IReturnAdd IncludeRetElement(params string[] retElements)
        {
            foreach (var retElement in retElements)
                AddMessageAllowDuplicates("IncludeRetElement", retElement);
            return _returnAdd;
        }

        public virtual TReturn Add()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            _xmlBase.ResetXml();
            return XMLtoPOCOList(response).First();
        }
    }
}
