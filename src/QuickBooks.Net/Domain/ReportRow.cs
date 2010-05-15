using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net.Domain
{
    public class ReportRow
    {
        protected IEnumerable<ReportColumnDescription> _columnDescriptions;

        public ReportRow(XElement xml)
            : this(xml, new List<ReportColumnDescription>())
        { }

        public ReportRow(XElement xml, IEnumerable<ReportColumnDescription> columnDescriptions)
        {
            _columnDescriptions = columnDescriptions;
            Type = xml.Name.ToString();
            RowType = "";
            RowValue = "";
            if (xml.Name == "TextRow")
            {
                if (xml.Attribute("value") != null)
                    RowValue = xml.Attribute("value").Value;
                Columns = new List<ReportColumn>();
            }
            else
            {
                var rowData = xml.Descendants("RowData").FirstOrDefault();
                if (rowData != null)
                {
                    RowType = rowData.Attribute("rowType").Value;
                    RowValue = rowData.Attribute("value").Value;
                }
                
                var columns = new List<ReportColumn>();
                foreach (var columnXML in xml.Descendants("ColData"))
                    columns.Add(new ReportColumn(columnXML));
                Columns = columns;
            }
        }

        public virtual string Type { get; protected set; }
        public virtual string RowType { get; protected set; }
        public virtual string RowValue { get; protected set; }
        public virtual IEnumerable<ReportColumn> Columns { get; protected set; }
        
        /// <summary>
        /// Returns the column value on this row
        /// </summary>
        public virtual string this[string columnType]
        {
            get
            {
                var column = _columnDescriptions.Where(x => x.ColumnType == columnType).FirstOrDefault();
                if (column == null)
                    throw new ArgumentException(string.Format("'{0}' ColumnType does not exist", columnType));
                else
                {
                    var rowColumn = Columns.Where(x => x.Id == column.Id).FirstOrDefault();
                    if (rowColumn == null)
                        return "";
                    else
                        return rowColumn.Value ?? "";
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var column in Columns)
                sb.AppendFormat("{0}: {1},", _columnDescriptions.Where(x => x.Id == column.Id).Single().ColumnType, column.Value);

            return sb.ToString();
        }
    }
}
