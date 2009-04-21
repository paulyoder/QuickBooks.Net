using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net.Domain
{
    public class ReportColumnDescription
    {
        public ReportColumnDescription(XElement xml)
        {
            if (xml.Name != "ColDesc")
                throw new ArgumentException(
                    string.Format("{0} is an invalid XElement Name. 'ColDesc' is the expected XElement Name", xml.Name));

            Id = Convert.ToInt32(xml.Attribute("colID").Value);
            DataType = xml.Attribute("dataType").Value;
            ColumnType = xml.Descendants("ColType").First().Value;
            
            var titles = new List<string>();
            foreach (var title in xml.Descendants("ColTitle"))
            {
                if (title.Attribute("value") != null)
                    titles.Add(title.Attribute("value").Value);
            }
            Titles = titles;
        }

        public virtual int Id { get; protected set; }
        public virtual string DataType { get; protected set; }
        public virtual IEnumerable<string> Titles { get; protected set; }
        public virtual string ColumnType { get; protected set; }
    }
}
