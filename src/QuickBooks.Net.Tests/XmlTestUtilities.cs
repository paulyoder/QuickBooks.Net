using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MbUnit.Framework;

namespace QuickBooks.Net.Tests
{
    public class XmlTestUtilities
    {
        protected void AssertXmlAreEqual(XElement expected, XElement actual)
        {
            Assert.AreEqual(
                expected.ToString(SaveOptions.DisableFormatting),
                actual.ToString(SaveOptions.DisableFormatting));
        }
    }
}
