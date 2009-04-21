using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("ReportRet")]
    public class Report
    {
        public Report(XElement xml)
        {
            Title = xml.Descendants("ReportTitle").First().Value;
            Subtitle = xml.Descendants("ReportSubtitle").First().Value;
            var reportBasis = xml.Descendants("ReportBasis").FirstOrDefault();
            if (reportBasis != null)
                ReportBasis = reportBasis.Value;
            NumRows = Convert.ToInt32(xml.Descendants("NumRows").First().Value);
            NumColumns = Convert.ToInt32(xml.Descendants("NumColumns").First().Value);
            NumColTitleRows = Convert.ToInt32(xml.Descendants("NumColTitleRows").First().Value);
            
            var columnDescriptions = new List<ReportColumnDescription>();
            foreach (var columnDescriptionXML in xml.Descendants("ColDesc"))
                columnDescriptions.Add(new ReportColumnDescription(columnDescriptionXML));
            ColumnDescriptions = columnDescriptions;
            
            var rows = new List<ReportRow>();
            var reportData = xml.Descendants("ReportData").FirstOrDefault();
            Rows = new ReportRows(reportData, ColumnDescriptions);
        }

        public virtual string Title { get; protected set; }
        public virtual string Subtitle { get; protected set; }
        public virtual string ReportBasis { get; protected set; }
        public virtual int NumRows { get; protected set; }
        public virtual int NumColumns { get; protected set; }
        public virtual int NumColTitleRows { get; protected set; }
        public virtual IEnumerable<ReportColumnDescription> ColumnDescriptions { get; protected set; }
        public virtual ReportRows Rows { get; protected set; }
    }
}
