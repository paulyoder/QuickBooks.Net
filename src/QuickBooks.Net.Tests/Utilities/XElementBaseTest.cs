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
    public class XmlElementBaseTest : XmlTestUtilities
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
    }
}
