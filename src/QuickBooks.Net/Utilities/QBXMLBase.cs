using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using QuickBooks.Net.Utilities.ConversionExtensions;
using log4net;
using System.Reflection;

namespace QuickBooks.Net.Utilities
{
    public class QBXMLBase<TReturn>
    {
        private ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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

            SetElementOrder();
        }

        /// <summary>
        /// Called at instantiation to set the element order on the QBXML message
        /// Override this method on inherited classes to set the element order
        /// </summary>
        protected virtual void SetElementOrder()
        { }

        protected void AddElementOrder(params ElementPosition[] elementOrder)
        {
            foreach (var element in elementOrder)
                _xmlBase.ElementOrder.ChildrenOrder.Add(element);
        }

        /// <summary>
        /// Adds or updates a qbxml message
        /// </summary>
        /// <param name="message">Message to add</param>
        protected virtual void AddUpdateMessage(params object[] message)
        {
            _xmlBase.AddUpdateXElement(ConvertObjectArrayToXElement(message.ToList()));
        }

        /// <summary>
        /// Adds a qbxml message and allows duplicate messages
        /// </summary>
        /// <param name="message">Message to add</param>
        protected virtual void AddMessageAllowDuplicates(params object[] message)
        {
            _xmlBase.AddUpdateXElement(ConvertObjectArrayToXElement(message.ToList()), true);
        }

        /// <summary>
        /// Converts ("DateFilter","FromDate","2/8/2008")
        /// to
        /// new XElement("DateFilter",
        ///   new XElement("FromDate", "2/8/2008"));
        /// </summary>
        protected virtual XElement ConvertObjectArrayToXElement(IList<object> messageList)
        {
            if (messageList.Count == 2)
            {
                var elementName = messageList[0].ToString();
                //Convert DateTime to xml date time version, else just get the ToString value
                string value = messageList[1].ToString();
                //DateTime needs to be converted to xml version of DateTime
                if (messageList[1].GetType() == typeof(DateTime))
                    value = messageList[1].As<DateTime>().ToXMLDateString();
                //bool values need to be all lowercase (ToString() returns capitalized word)
                else if (messageList[1].GetType() == typeof(bool))
                    value = (messageList[1].As<bool>()) ?
                        "true" : "false";
                return new XElement(elementName, value);
            }
            else
                return new XElement(messageList[0].ToString(), ConvertObjectArrayToXElement(messageList.Skip(1).ToList()));
        }

        /// <summary>
        /// Throws a QBException if there is an error message in the response
        /// </summary>
        /// <param name="response">
        /// QBXML response. 
        /// Response root element is return name element (e.g. ClassQueryRs). It is NOT the QBXML element
        /// </param>
        /// <exception cref="QBException" />
        protected virtual void CheckForErrorMessageInResponse(XElement response)
        {
            var statusCode = response.Attribute("statusCode").Value;
            var statusMessage = response.Attribute("statusMessage").Value;
            if (statusCode != "0" && statusCode != "1")
            {
                _log.ErrorFormat("Error in qbxml response. StatusCode: {0}, StatusMessage: {1} \nQBXML Request:\n{2}",
                    statusCode,
                    statusMessage, 
                    _xmlBase.Xml.ToString());
                throw new QBException(statusMessage, statusCode);
            }
        }

        /// <summary>
        /// Converts an XElement response into a list of the corresponding C# objects
        /// </summary>
        /// <param name="response">QBXML response</param>
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
