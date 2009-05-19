using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Net.Tests.Utilities
{
    [TestFixture]
    public class ElementPositionTest
    {
        [Test]
        public void Explicit_from_string_conversion()
        {
            Assert.AreEqual("MaxReturned", ((ElementPosition)"MaxReturned").Name);
        }

        [Test]
        public void Constructor_with_string_array_children()
        { 
            var element = new ElementPosition("ParentRef", "ListID", "FullName");
            Assert.AreEqual(2, element.ChildrenOrder.Count, "Count");
            Assert.AreEqual("ListID", element.ChildrenOrder[0].Name);
        }

        [Test]
        public void Constructor_with_ElementPosition_array_children()
        {
            var element = new ElementPosition("ParentRef", new ElementPosition("ListID"), new ElementPosition("FullName"));
            Assert.AreEqual(2, element.ChildrenOrder.Count, "Count");
            Assert.AreEqual("ListID", element.ChildrenOrder[0].Name);
        }

        [Test]
        public void Constructor_with_mixed_string_and_ElementPosition_array_children()
        {
            var element = new ElementPosition("ParentRef", new ElementPosition("ListID"), "FullName");
            Assert.AreEqual(2, element.ChildrenOrder.Count, "Count");
            Assert.AreEqual("ListID", element.ChildrenOrder[0].Name);
            Assert.AreEqual("FullName", element.ChildrenOrder[1].Name);
        }

        [Test]
        public void HasChildren_returns_true_when_there_are_children()
        {
            Assert.IsTrue(new ElementPosition("", "firstChild").HasChildren);
        }

        [Test]
        public void HasChildren_returns_false_when_no_children()
        {
            Assert.IsFalse(new ElementPosition("").HasChildren);
        }
    }
}
