using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace QuickBooks.Net.Utilities
{
    public class QBXMLBase<TReturn>
    {
        protected IQBSessionInternal _session;
        protected string _requestName;
        protected string _responseName;
        protected string _returnTypeElementName;
        protected XElementBase _xmlBase;

        public QBXMLBase(IQBSessionInternal session, string requestName, string responseName)
        {
            _session = session;
            _requestName = requestName;
            _responseName = responseName;
            try
            {
                _returnTypeElementName = ((XmlRootAttribute)typeof(TReturn)
                    .GetCustomAttributes(typeof(XmlRootAttribute), false)[0])
                    .ElementName;
            }
            catch (IndexOutOfRangeException) { }
            _xmlBase = new XElementBase(requestName);
        }

        protected virtual void AddUpdateMessage(params string[] message)
        {
            _xmlBase.AddUpdateXElement(ConvertStringArrayToXElement(message.ToList()));
        }

        protected virtual void AddMessageAllowDuplicates(params string[] message)
        {
            _xmlBase.AddUpdateXElement(ConvertStringArrayToXElement(message.ToList()), true);
        }

        /// <summary>
        /// Converts ("DateFilter","FromDate","2/8/2008")
        /// to
        /// new XElement("DateFilter",
        ///   new XElement("FromDate", "2/8/2008"));
        /// </summary>
        /// <returns></returns>
        protected virtual XElement ConvertStringArrayToXElement(IList<string> messageList)
        {
            if (messageList.Count == 2)
                return new XElement(messageList[0], messageList[1]);
            else
                return new XElement(messageList[0], ConvertStringArrayToXElement(messageList.Skip(1).ToList()));
        }

        protected virtual void CheckForErrorMessageInResponse(XElement response)
        {
            var statusCode = response.Attribute("statusCode").Value;
            var statusMessage = response.Attribute("statusMessage").Value;
            if (statusCode != "0" && statusCode != "1")
                throw new QBException(statusMessage, statusCode);
        }

        protected virtual IList<TReturn> XMLtoPOCOList(XElement response)
        {
            var list = new List<TReturn>();
            var serializer = new XmlSerializer(typeof(TReturn));
            foreach (var item in response.Descendants(_returnTypeElementName))
                list.Add((TReturn)serializer.Deserialize(new StringReader(item.ToString(SaveOptions.None))));
            return list;
        }
    }
}
