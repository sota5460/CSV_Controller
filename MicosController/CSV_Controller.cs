using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;

namespace MicosController
{
   /// <summary>
   /// csv file path(文字列配列) ⇒　データﾃｰﾌﾞﾙ
   /// </summary>
    class CSV_Controller
    {

        private DataTable Read_CSV_Table { get; set; }
        public DataTable Out_DataTable { get; set; }

        private DataTable Temp_DataTable { get; set; }

        //private DataTable before_Table { get; set; }
        //private DataTable after_Table { get; set; }
        /// <summary>
        /// csvファイルを読み込んで、Read_CSV_Tableを作成する。csvのフォーマットは一行目が列名でカンマ区切り。
        /// </summary>
        /// <param name="csv_file_path"></param>
        public void Read_CSV_to_Table(List<string> csv_file_path)
        {

        }
        /// <summary>
        /// 列col_nameの中で値が"value"のものを抽出する。
        /// </summary>
        /// <param name="col_name"></param>
        /// <param name="value"></param>
        public void ExtractByRowValue(string col_name, string value)
        {

            if (Read_CSV_Table.AsEnumerable().Where(x => x[col_name].ToString() == value).Any())
            {
                Out_DataTable =  Read_CSV_Table.AsEnumerable().Where(x => x[col_name].ToString() == value).CopyToDataTable();
            }
            else
            {
                MessageBox.Show("対象の行が見つかりません。");
            }
        }

        public void Organize_ColNum(int[] delete_col)
        {
            Out_DataTable = Read_CSV_Table.Copy();
            foreach(int col in delete_col)
            {
                Out_DataTable.Columns.RemoveAt(col);
            }
        }

    }
}
