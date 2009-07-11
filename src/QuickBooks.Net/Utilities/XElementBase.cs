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
        public virtual ElementPosition ElementOrder { get; protected set; }
        protected string _xmlRootElementName;

        public XElementBase(string xmlRootElementName)
        {
            _xmlRootElementName = xmlRootElementName;
            ElementOrder = new ElementPosition(_xmlRootElementName);
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
            AddUpdateXElement(newXElement, Xml, allowDuplicates, ElementOrder);
        }

        /// <summary>
        /// Adds or updates a child XElement to the parent XElement argument
        /// </summary>
        /// <param name="newXElement">Child XElement to add/update</param>
        /// <param name="parent">XElement to add the newXElement to</param>
        /// <param name="allowDuplicates">If true, old child XElements are not overwritten</param>
        public virtual void AddUpdateXElement(XElement newXElement, XElement parent, bool allowDuplicates, ElementPosition parentElementPosition)
        {
            var firstGeneration = from child in parent.Descendants()
                                  where child.Parent.Name == parent.Name
                                  select child;

            var match = (from child in firstGeneration
                         where child.Name == newXElement.Name
                         select child).FirstOrDefault();

            if (match == null)
                InsertAndOrderChild(parent, newXElement, parentElementPosition);
            else
                if (newXElement.Descendants().Count() == 0)
                    if (allowDuplicates)
                        InsertAndOrderChild(parent, newXElement, parentElementPosition);
                    else
                        match.SetValue(newXElement.Value);
                else
                    AddUpdateXElement(newXElement.Descendants().First(), 
                        match, 
                        allowDuplicates, 
                        parentElementPosition.ChildrenOrder.FirstOrDefault(x => x.Name == newXElement.Name));
        }

        public virtual void InsertXElement(XElement parent, XElement newXElement, ElementPosition parentPosition)
        {
            InsertAndOrderChild(parent, newXElement, parentPosition);
        }

        protected virtual void InsertAndOrderChild(XElement parent, XElement child, ElementPosition parentPosition)
        {
            if (parentPosition == null ||
                parent.Descendants().Count() == 0)
            {
                parent.Add(child);
                return;
            }

            var childPosition = parentPosition.ChildrenOrder.IndexOf(
                parentPosition.ChildrenOrder.FirstOrDefault(x => x.Name == child.Name));

            if (childPosition == -1)
            {
                parent.Add(child);
                return;
            }

            var insertAfter = FindSiblingToInsertAfter(parent, parentPosition, childPosition);

            if (insertAfter == null)
                AddSameChildrenInOrder(parent, child);
            else
                insertAfter.AddAfterSelf(child);
        }

        private void AddSameChildrenInOrder(XElement parent, XElement child)
        {
            if (parent.Descendants(child.Name).Count() == 0)
                parent.Descendants().First().AddBeforeSelf(child);
            else
                parent.Descendants(child.Name).Last().AddAfterSelf(child);
        }

        private XElement FindSiblingToInsertAfter(XElement parent, ElementPosition parentPosition, int childPosition)
        {
            for (int i = childPosition - 1; i >= 0; i--)
            {
                if (parent.Element(parentPosition.ChildrenOrder[i].Name) != null)
                    return parent.Elements(parentPosition.ChildrenOrder[i].Name).Last();
            }
            return null;
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
