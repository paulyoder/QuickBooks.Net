using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using System.Xml.Linq;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using System.IO;
using NPOI.HSSF.Util;

namespace QuickBooks.Net.Utilities
{
    public class ReportService
    {
        HSSFWorkbook _workbook;
        HSSFFont _boldFont;
        HSSFCellStyle _boldAllBorders;

        public void AddReport(Report r, string sheetName)
        {
            var sheet = _workbook.CreateSheet(sheetName);
            CreateReportHeader(sheet, r);
            CreateReportData(sheet, r);
        }

        public void Save(string fileName)
        {
            var file = new FileStream(fileName, System.IO.FileMode.Create);
            _workbook.Write(file);
            file.Close();
        }

        public void Save(Stream stream)
        {
            _workbook.Write(stream);
        }

        private void CreateReportData(HSSFSheet sheet, Report r)
        {
            var amountStyle = _workbook.CreateCellStyle();
            amountStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            var boldTopBorder = _workbook.CreateCellStyle();
            boldTopBorder.BorderTop = HSSFCellStyle.BORDER_THIN;
            boldTopBorder.TopBorderColor= HSSFColor.BLACK.index;
            boldTopBorder.SetFont(_boldFont);
            var bold = _workbook.CreateCellStyle();
            bold.SetFont(_boldFont);
            var currentRowIndex = 0;
            foreach (var reportRow in r.Rows.All)
            {
                currentRowIndex++;
                var sheetRow = sheet.CreateRow(currentRowIndex);
                foreach (var col in reportRow.Columns)
                {
                    var cell = sheetRow.CreateCell(col.Id - 1);
                    cell.SetCellValue(col.Value);
                    if (r.ColumnDescriptions.First(x => x.Id == col.Id).DataType == "AMTTYPE")
                    {
                        cell.CellStyle = (reportRow.Type == "SubtotalRow" || reportRow.Type == "TotalRow") ?
                            boldTopBorder :
                            amountStyle;
                    }
                    else if (col.Id == 1)
                    {
                        cell.CellStyle = bold;
                    }
                }
                if (reportRow.Type == "TextRow")
                    sheetRow.CreateCell(0).SetCellValue(reportRow.RowValue);
                if (reportRow.Type == "SubtotalRow")
                {
                    currentRowIndex++;
                    sheet.CreateRow(currentRowIndex);
                }
            }
        }

        private void CreateReportHeader(HSSFSheet sheet, Report r)
        {
            var row = sheet.CreateRow(0);
            for (int i = 0; i < r.ColumnDescriptions.Count(); i++)
            {
                var column = r.ColumnDescriptions.First(x => x.Id == i + 1);
                var value = (column.Titles.Count() == 0) ?
                    "" :
                    column.Titles.First();
                var cell = row.CreateCell(i);
                cell.SetCellValue(value);
                cell.CellStyle = _boldAllBorders;
            }
        }

        protected void OnNewWorkbook()
        {
            _boldFont = _workbook.CreateFont();
            _boldFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;

            _boldAllBorders = _workbook.CreateCellStyle();
            _boldAllBorders.BorderTop = HSSFCellStyle.BORDER_THIN;
            _boldAllBorders.TopBorderColor = HSSFColor.BLACK.index;
            _boldAllBorders.BorderBottom = HSSFCellStyle.BORDER_THIN;
            _boldAllBorders.BorderLeft = HSSFCellStyle.BORDER_THIN;
            _boldAllBorders.BorderRight = HSSFCellStyle.BORDER_THIN;
            _boldAllBorders.BottomBorderColor = HSSFColor.BLACK.index;
            _boldAllBorders.LeftBorderColor = HSSFColor.BLACK.index;
            _boldAllBorders.RightBorderColor = HSSFColor.BLACK.index;
            _boldAllBorders.SetFont(_boldFont);
        }

        public void OpenWorkbook(string fileName)
        {
            using (var file = new FileStream(fileName, System.IO.FileMode.Open, FileAccess.Read))
            {
                _workbook = new HSSFWorkbook(file);
            }
            OnNewWorkbook();
        }

        public void NewWorkbook()
        {
            _workbook = new HSSFWorkbook();

            ////create a entry of DocumentSummaryInformation
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "QuickBooks.NET";
            _workbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            var si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "QuickBooks.NET";
            _workbook.SummaryInformation = si;

            OnNewWorkbook();
        }
    }
}
