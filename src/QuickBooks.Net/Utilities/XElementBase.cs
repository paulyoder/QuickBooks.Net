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

        /// <summary>
        /// Adds or updates a child XElement to the <paramref name="Xml"/> property
        /// If the child XElement already exists, it overwrites the old child XElement
        /// </summary>
        /// <param name="newXElement">Child XElement to add or update</param>
        public virtual void AddUpdateXElement(XElement newXElement)
        {
            AddUpdateXElement(newXElement, false);
        }

        /// <summary>
        /// Adds or updates a child XElement to the <paramref name="Xml"/> property
        /// </summary>
        /// <example allowDuplicates="true">
        /// Xml Before = (ClassFullName)Paul(/ClassFullName)
        /// AddUpdateXElement(XElement("ClassFullName", "Sara"), true)
        /// Xml After = (ClassFullName)Paul(/ClassFullName)(ClassFullName)Sara(/ClassFullName)
        /// </example>
        /// <example allowDuplicates="false">
        /// Xml Before = (ClassFullName)Paul(/ClassFullName)
        /// AddUpdateXElement(XElement("ClassFullName", "Sara"), false)
        /// Xml After = (ClassFullName)Sara(/ClassFullName)
        /// </example>
        /// <param name="newXElement">Child XElement to add or update</param>
        /// <param name="allowDuplicates">If true, old child XElements are not overwritten</param>
        public virtual void AddUpdateXElement(XElement newXElement, bool allowDuplicates)
        {
            AddUpdateXElement(newXElement, Xml, allowDuplicates);
        }

        /// <summary>
        /// Adds or updates a child XElement to the parent XElement argument
        /// </summary>
        /// <param name="newXElement">Child XElement to add/update</param>
        /// <param name="parent">XElement to add the newXElement to</param>
        /// <param name="allowDuplicates">If true, old child XElements are not overwritten</param>
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

        /// <summary>
        /// Deletes all child elements from the <paramref name="Xml"/> property
        /// </summary>
        public virtual void ResetXml()
        {
            Xml = new XElement(_xmlRootElementName);
        }
    }
}
