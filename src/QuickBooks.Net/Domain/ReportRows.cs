using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net.Domain
{
    public class ReportRows
    {
        public ReportRows(XElement xml, IEnumerable<ReportColumnDescription> columnDescriptions)
        {
            var rows = new List<ReportRow>();
            foreach (var rowXML in xml.Elements())
                rows.Add(new ReportRow(rowXML, columnDescriptions));
            All = rows;
        }

        /// <summary>
        /// Returns all Rows
        /// </summary>
        public virtual IEnumerable<ReportRow> All { get; protected set; }
        
        /// <summary>
        /// Returns all DataRows
        /// </summary>
        public virtual IEnumerable<ReportRow> Data
        {
            get { return All.Where(x => x.Type == "DataRow"); }
        }

        /// <summary>
        /// Returns all SubtotalRows
        /// </summary>
        public virtual IEnumerable<ReportRow> Subtotal
        {
            get { return All.Where(x => x.Type == "SubtotalRow"); }
        }

        /// <summary>
        /// Return all TotalRows
        /// </summary>
        public virtual IEnumerable<ReportRow> Total
        {
            get { return All.Where(x => x.Type == "TotalRow"); }
        }

        /// <summary>
        /// Returns all TextRows
        /// </summary>
        public virtual IEnumerable<ReportRow> Text
        {
            get { return All.Where(x => x.Type == "TextRow"); }
        }
    }
}
