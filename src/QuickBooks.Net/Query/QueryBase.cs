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
    public abstract class QueryBase<TReturn> : QBXMLBase<TReturn>, IQueryBase<TReturn>, IQueryBaseNoIteration<TReturn>
    {
        public int IteratorRemainingCount { get; protected set; }

        protected QueryBase(IQBSessionInternal session, string requestName, string responseName)
            : base(session, requestName, responseName)
        { }

        public virtual IList<TReturn> List()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
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

            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();

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
    }
}
