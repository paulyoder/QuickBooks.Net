using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Utilities
{
    public class ElementPosition
    {
        public virtual string Name { get; protected set; }
        public virtual IList<ElementPosition> ChildrenOrder { get; protected set; }
        public virtual bool HasChildren
        {
            get { return (ChildrenOrder.Count > 0); }
        }

        public ElementPosition(string name)
            : this(name, new ElementPosition[0])
        { }

        public ElementPosition(string name, params ElementPosition[] childrenOrder)
        {
            Name = name;
            ChildrenOrder = new List<ElementPosition>();
            foreach (var child in childrenOrder)
                ChildrenOrder.Add(child);
        }

        public static implicit operator ElementPosition(string elementName)
        {
            return new ElementPosition(elementName);
        }

        public static ElementPosition Ref(string refName)
        {
            return new ElementPosition(refName,
                "ListID",
                "FullName");
        }
    }
}
