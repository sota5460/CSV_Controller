using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace MicosController
{
    class ExcellController
    {

        public string excell_file_path { get; set; }//テンプレートファイル
        //public string excell_sheet_name { get; set; }//テンプレートファイルの中の編集したいシート名

        public string word_file_path { get; set; }

        public DataTable Table_forLabelZaiko { get; set; } //必要な列4つ。PMT名、材料名、材料コード、使用数量

        public void Fill_Ecellsheet_template()
        {

            try
            {
                //var file = new FileStream(excell_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                IWorkbook workbook = WorkbookFactory.Create(excell_file_path);

                var sheet = workbook.GetSheetAt(0);

                //WriteCell(sheet, 2, 2, 20);

                //var book = WorkbookFactory.Create(excell_file_path);  //ブック読み込み

                //var sheet = workbook?.GetSheet(excell_sheet_name); //シート名からシート取得

                int row_cnt = 1; //0行目は列名が書いてあるから1からカウント
                foreach (DataRow row in Table_forLabelZaiko.Rows)
                {
                    WriteCell_String(sheet, 0, row_cnt, row["PMT"].ToString());
                    WriteCell_String(sheet, 1, row_cnt, row["品名"].ToString());
                    WriteCell_String(sheet, 2, row_cnt, row["品目ＣＤ"].ToString());
                    //WriteCell_Float(sheet, 3,row_cnt, float.Parse( row["合計使用数"].ToString()));
                    //WriteCell_Float(sheet, 3, row_cnt, Math.Round(double.Parse(row["合計使用数"].ToString()), 2));
                    //Math.Round(double.Parse(row["合計使用数"].ToString()), 2);
                    WriteCell_String(sheet, 3,row_cnt,row["合計使用数"].ToString());

                    row_cnt++;
                }

                //workbook.CreateSheet();

                using (var fs = new FileStream(excell_file_path, FileMode.Create)) //ファイルを上書き保存。
                {
                    workbook.Write(fs);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static void WriteCell_String(ISheet sheet, int columnIndex, int rowIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        //セル設定(数値用)
        public static void WriteCell_Float(ISheet sheet, int columnIndex, int rowIndex, double value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        ////セル設定(日付用)
        //public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, DateTime value)
        //{
        //    var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
        //    var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

        //    cell.SetCellValue(value);
        //}

        ////書式変更
        //public static void WriteStyle(ISheet sheet, int columnIndex, int rowIndex, ICellStyle style)
        //{
        //    var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
        //    var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

        //    cell.CellStyle = style;
        //}

        public void Open_LabelWordFile()
        {
            Process pt = new Process();
            //ps.StartInfo.FileName = @"C:\Users\e33230-user3\OneDrive - hqhamamatsu.onmicrosoft.com\デスクトップ\PCPPC.hod";
            pt.StartInfo.FileName = word_file_path;
            pt.Start();
        }
    }
}
