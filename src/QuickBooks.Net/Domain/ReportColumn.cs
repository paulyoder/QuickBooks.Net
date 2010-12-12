using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net.Domain
{
    public class ReportColumn
    {
        public ReportColumn(XElement xml)
        {
            if (xml.Name != "ColData")
                throw new ArgumentException(
                    string.Format("{0} is an invalid XElement Name. 'ColData' is the expected XElement Name", xml.Name));

            Id = Convert.ToInt32(xml.Attribute("colID").Value);
            Value = xml.Attribute("value").Value;
            if (xml.Attribute("dataType") != null)
                DataType = xml.Attribute("dataType").Value;
        }

        public virtual int Id { get; set; }
        public virtual string Value { get; set; }
        public virtual string DataType { get; set; }
    }
}
