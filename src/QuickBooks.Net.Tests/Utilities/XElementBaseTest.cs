using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using QuickBooks.Net.Utilities;
using System.Xml.Linq;

namespace QuickBooks.Net.Tests.Utilities
{
    [TestFixture]
    public class XElementBaseTest : XmlTestUtilities
    {
        private XElementBase _xmlBase;

        [SetUp]
        public void s()
        {
            _xmlBase = new XElementBase("Root");
        }

        [Test]
        public void Constructor_sets_root_element_name_on_Xml_property()
        {
            Assert.AreEqual("Root", _xmlBase.Xml.Name.ToString());
        }

        [Test]
        public void AddUpdateXElement_adds_one_level_xml_element()
        {
            _xmlBase.AddUpdateXElement(new XElement("Age", 22));
            var expected = new XElement("Root",
                new XElement("Age", 22));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_adds_two_level_xml_element()
        {
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Brother", "Paul")));
            var expected = new XElement("Root",
                new XElement("Family",
                    new XElement("Brother", "Paul")));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_doesnt_erase_first_level_when_2_two_level_xml_elements_are_added()
        {
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Brother", "Paul")));
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Sister", "Sara")));
            var expected = new XElement("Root",
                new XElement("Family",
                    new XElement("Brother", "Paul"),
                    new XElement("Sister", "Sara")));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_updates_one_level_xml_element()
        {
            _xmlBase.AddUpdateXElement(new XElement("Age", 22));
            _xmlBase.AddUpdateXElement(new XElement("Age", 31));
            var expected = new XElement("Root",
                new XElement("Age", 31));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_updates_two_level_xml_element()
        {
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Brother", "Paul")));
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Brother", "Andy")));
            var expected = new XElement("Root",
                new XElement("Family",
                    new XElement("Brother", "Andy")));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_orders_first_level_xml_elements_middle_is_last()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("Sister");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Brother");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Spouse");

            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"));
            _xmlBase.AddUpdateXElement(new XElement("Spouse", "?"));
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andy"));

            var expected = new XElement("Root",
                new XElement("Sister", "Sara"),
                new XElement("Brother", "Andy"),
                new XElement("Spouse", "?"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_allow_duplicates_orders_same_child_names()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("Sister");

            _xmlBase.AddUpdateXElement(new XElement("Sister", "Cami"), true);
            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"), true);

            var expected = new XElement("Root",
                new XElement("Sister", "Cami"),
                new XElement("Sister", "Sara"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_orders_first_level_xml_elements_first_is_last()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("Sister");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Brother");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Spouse");

            _xmlBase.AddUpdateXElement(new XElement("Spouse", "?"));
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andy"));
            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"));

            var expected = new XElement("Root",
                new XElement("Sister", "Sara"),
                new XElement("Brother", "Andy"),
                new XElement("Spouse", "?"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_allow_duplicates_orders_first_level_xml_elements_middle_is_last()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("Sister");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Brother");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Spouse");

            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"), true);
            _xmlBase.AddUpdateXElement(new XElement("Spouse", "?"), true);
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andy"), true);
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Ben"), true);

            var expected = new XElement("Root",
                new XElement("Sister", "Sara"),
                new XElement("Brother", "Ben"),
                new XElement("Brother", "Andy"),
                new XElement("Spouse", "?"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_allow_duplicates_orders_first_level_xml_elements_first_is_last()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("Sister");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Brother");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Spouse");

            _xmlBase.AddUpdateXElement(new XElement("Spouse", "?"), true);
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andy"), true);
            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"), true);
            _xmlBase.AddUpdateXElement(new XElement("Sister", "Cami"), true);

            var expected = new XElement("Root",
                new XElement("Sister", "Sara"),
                new XElement("Sister", "Cami"),
                new XElement("Brother", "Andy"),
                new XElement("Spouse", "?"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_orders_second_level_xml_elements_first_is_last()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add(new ElementPosition("Sister", "Name", "Age", "City"));
            _xmlBase.ElementOrder.ChildrenOrder.Add("Brother");
            _xmlBase.ElementOrder.ChildrenOrder.Add("Spouse");

            _xmlBase.AddUpdateXElement(new XElement("Spouse", "?"));
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andy"));
            _xmlBase.AddUpdateXElement(new XElement("Sister",
                new XElement("Age", "24")));
            _xmlBase.AddUpdateXElement(new XElement("Sister",
                new XElement("City", "Nappanee")));
            _xmlBase.AddUpdateXElement(new XElement("Sister",
                new XElement("Name", "Sara")));

            var expected = new XElement("Root",
                new XElement("Sister", 
                    new XElement("Name","Sara"),
                    new XElement("Age","24"),
                    new XElement("City","Nappanee")),
                new XElement("Brother", "Andy"),
                new XElement("Spouse", "?"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_orders_by_first_come_if_not_in_ElementOrder()
        {
            _xmlBase.AddUpdateXElement(new XElement("Brother", "Andrew"));
            _xmlBase.AddUpdateXElement(new XElement("Sister", "Sara"));

            var expected = new XElement("Root",
                new XElement("Brother", "Andrew"),
                new XElement("Sister", "Sara"));
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void ResetXml_clears_the_Xml_property_down_to_the_root_element()
        {
            _xmlBase.AddUpdateXElement(new XElement("Family",
                new XElement("Brother", "Paul")));
            _xmlBase.ResetXml();

            var expected = new XElement("Root");
            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddUpdateXElement_AllowDuplicates_one_descedant_allows_duplicates()
        {
            _xmlBase.AddUpdateXElement(new XElement("Name", "Paul"), true);
            _xmlBase.AddUpdateXElement(new XElement("Name", "Andy"), true);

            var expected = new XElement("Root",
                new XElement("Name", "Paul"),
                new XElement("Name", "Andy"));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void AddXElementAllowDuplicates_two_descedants_allows_duplicates()
        {
            _xmlBase.AddUpdateXElement(new XElement("Family", new XElement("Name", "Paul")), true);
            _xmlBase.AddUpdateXElement(new XElement("Family", new XElement("Name", "Andy")), true);

            var expected = new XElement("Root",
                new XElement("Family",
                    new XElement("Name", "Paul"),
                    new XElement("Name", "Andy")));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }

        [Test]
        public void InsertXElement_inserts_in_order()
        {
            _xmlBase.ElementOrder.ChildrenOrder.Add("City");
            _xmlBase.ElementOrder.ChildrenOrder.Add(new ElementPosition("Family", "Brother", "Sister"));
            _xmlBase.ElementOrder.ChildrenOrder.Add("State");

            _xmlBase.InsertXElement(_xmlBase.Xml, new XElement("Family",
                new XElement("Brother", "Paul")), _xmlBase.ElementOrder);
            _xmlBase.InsertXElement(_xmlBase.Xml, new XElement("Family",
                new XElement("Sister", "Sara")), _xmlBase.ElementOrder);
            _xmlBase.AddUpdateXElement(new XElement("City", "Omaha"));
            _xmlBase.AddUpdateXElement(new XElement("State", "Nebraska"));
            var expected = new XElement("Root",
                new XElement("City", "Omaha"),
                new XElement("Family",
                    new XElement("Brother", "Paul")),
                new XElement("Family",
                    new XElement("Sister", "Sara")),
                new XElement("State", "Nebraska"));

            AssertXmlAreEqual(expected, _xmlBase.Xml);
        }
    }
}
