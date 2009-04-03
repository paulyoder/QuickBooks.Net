using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net
{
    public interface IQBSessionInternal
    {
        XElement ProcessRequest(XElement XmlQuery);
    }
}
