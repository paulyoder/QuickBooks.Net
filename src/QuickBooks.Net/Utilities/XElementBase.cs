using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net.Utilities
{
    public class XElementBase
    {
        public virtual XElement Xml { get; protected set; }
        protected string _xmlRootElementName;

        public XElementBase(string xmlRootElementName)
        {
            _xmlRootElementName = xmlRootElementName;
            ResetXml();
        }

        public virtual void AddUpdateXElement(XElement newXElement)
        {
            AddUpdateXElement(newXElement, false);
        }

        public virtual void AddUpdateXElement(XElement newXElement, bool allowDuplicates)
        {
            AddUpdateXElement(newXElement, Xml, allowDuplicates);
        }

        protected virtual void AddUpdateXElement(XElement newXElement, XElement parent, bool allowDuplicates)
        {
            var firstGeneration = from child in parent.Descendants()
                                  where child.Parent.Name == parent.Name
                                  select child;

            var match = (from child in firstGeneration
                         where child.Name == newXElement.Name
                         select child).FirstOrDefault();

            if (match == null)
                parent.Add(newXElement);
            else
                if (newXElement.Descendants().Count() == 0)
                    if (allowDuplicates)
                        parent.Add(newXElement);
                    else
                        match.SetValue(newXElement.Value);
                else
                    AddUpdateXElement(newXElement.Descendants().First(), match, allowDuplicates);
        }

        public void ResetXml()
        {
            Xml = new XElement(_xmlRootElementName);
        }
    }
}
