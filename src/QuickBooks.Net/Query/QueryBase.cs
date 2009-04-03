using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace QuickBooks.Net.Query
{
    /// <typeparam name="TReturns">Expected return type</typeparam>
    public abstract class QueryBase<TReturn> : IQueryBase<TReturn>, IQueryBaseNoIteration<TReturn>
    {
        protected IQBSessionInternal _session;
        protected string _requestName;
        protected string _responseName;
        protected string _returnTypeElementName;
        protected XElementBase _xmlBase;
        public int IteratorRemainingCount { get; protected set; }

        protected QueryBase(IQBSessionInternal session, string requestName, string responseName)
        {
            _session = session;
            _requestName = requestName;
            _responseName = responseName;
            _returnTypeElementName = ((XmlRootAttribute)typeof(TReturn)
                .GetCustomAttributes(typeof(XmlRootAttribute), false)[0])
                .ElementName;
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

        public virtual IList<TReturn> List()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml);
            CheckForErrorMessageInResponse(response);
            var responseList = XMLtoPOCOList(response);
            _xmlBase.ResetXml();
            return responseList;
        }

        public virtual TReturn Single()
        {
            return List().FirstOrDefault();
        }

        public virtual IList<TReturn> Iterate()
        {
            if (_xmlBase.Xml.Descendants("MaxReturned").Count() == 0)
                throw new QBException("MaxReturned property must be set to use the Iterate function");

            SetIteratorAttribute();

            var response = _session.ProcessRequest(_xmlBase.Xml);

            CheckForErrorMessageInResponse(response);

            SetIteratorID(response);

            IteratorRemainingCount = Convert.ToInt32(response.Attribute("iteratorRemainingCount").Value);

            if (IteratorRemainingCount == 0)
                _xmlBase.ResetXml();

            return XMLtoPOCOList(response);
        }

        public virtual void StopIteration()
        {
            if (_xmlBase.Xml.Attribute("iterator") == null)
                _xmlBase.Xml.Add(new XAttribute("iterator", "Stop"));
            else
                _xmlBase.Xml.Attribute("iterator").SetValue("Stop");

            _session.ProcessRequest(_xmlBase.Xml);
        }

        /// <summary>
        /// Gets the iteratorID from the response and sets it on the request if the
        /// request doesn't already have it set
        /// </summary>
        private void SetIteratorID(XElement response)
        {
            if (_xmlBase.Xml.Attribute("iteratorID") == null)
                _xmlBase.Xml.Add(new XAttribute("iteratorID",
                    response.Attributes()
                        .Where(x => x.Name == "iteratorID")
                        .First()
                        .Value));
        }

        private void SetIteratorAttribute()
        {
            if (_xmlBase.Xml.Attribute("iterator") == null)
                _xmlBase.Xml.Add(new XAttribute("iterator", "Start"));
            else
                _xmlBase.Xml.Attribute("iterator").SetValue("Continue");
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
