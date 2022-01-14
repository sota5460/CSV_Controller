using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MicosController
{
    public partial class Tanaoroshi : Form
    {
        /// <summary>
        /// 生データのデータﾃｰﾌﾞﾙ
        /// </summary>
        public DataTable Current_Micos_Zaiko_Table { get; set; }
        public DataTable Current_Actual_Zaiko_Table { get; set; }
       
        /// <summary>
        /// 表示されてるデータのﾃｰﾌﾞﾙ。DateGridに渡すデータ。
        /// </summary>
        public DataTable Current_Micos_Display_Table { get; set; }
        public DataTable Current_Actual_Zaiko_Display_Table { get; set; }
        public DataTable Difference_Table { get; set; }


        public string Filepath_Current_Micos{get;set;}
        public string Filepath_Current_Actual_Zaiko { get; set; }

        bool first_file_flag = true;
       

        public Tanaoroshi()
        {
            InitializeComponent();
        }

        public void add_columns_datatable()
        {

        }

        public void read_CurrentMicosData_fromFileOpen()
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename_icb in openFileDialog1.FileNames)
                {


                    TextFieldParser parser = new TextFieldParser(filename_icb, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");// ","区切り


                    string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。行のカーソルは呼び出す度にインクリメント。
                    DataRow row;

                    if (first_file_flag) //一つ目のファイルのときだけ列の名前を取得する。
                    {
                        for (int i = 0; i < column.Length; i++)  //列の名前を追加する。
                        {

                            if (i == 10) // 10列目：現在在庫数
                            {
                               Current_Micos_Zaiko_Table.Columns.Add(column[i], typeof(float)); //現在在庫数だけint型
                            }
                            else
                            {
                               Current_Micos_Zaiko_Table.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                            }
                        }

                        first_file_flag = false;
                    }


                    while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                    {
                        string[] column_data = parser.ReadFields();

                        row =Current_Micos_Zaiko_Table.NewRow();
                        for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                        {
                            row[i] = column_data[i];
                        }
                       Current_Micos_Zaiko_Table.Rows.Add(row);
                    }
                    //textBox_selected_ICB.AppendText(filename_icb + " , ");
                }
               // DS.Tables.Add(Component_Table_ICB);
                first_file_flag = true;
            }
        }
        /// <summary>
        /// チェックボックスに項目を自動追加する関数
        /// </summary>
        public void read_database_CurrentMicosZaiko() //Current_Micos_Zaiko_Tableの経費の種類をチェックボックスに追加する。
        {
            DataTable notDoublicated_CurrentMicos;
            DataView dtView_CurrentMicos = new DataView(Current_Micos_Zaiko_Table);

            notDoublicated_CurrentMicos = dtView_CurrentMicos.ToTable(true, "経費"); //"経費"列の重複を取り除く

            foreach (DataRow row in notDoublicated_CurrentMicos.Rows)
            {
                checkedListBox_CurrentMicos_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
            }
            
        }

        public void read_database_ActualZaiko() //Current_Actual_Zaiko_Tableの経費の種類をチェックボックスに追加する。
        {
            DataTable notDoublicated_ActualZaiko;
            DataView dtView_ActualZaiko = new DataView(Current_Actual_Zaiko_Table);

            notDoublicated_ActualZaiko = dtView_ActualZaiko.ToTable(true, "経費"); //"経費"列の重複を取り除く

            foreach (DataRow row in notDoublicated_ActualZaiko.Rows)
            {
                checkedListBox_ActualZaiko_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
            }
        }

        public void create_difference_table() //在庫を比較して差を求めて、ﾃｰﾌﾞﾙを作る。
        {

            ///Difference Tableの列名を追加する。
            for(int i = 0; i < Current_Micos_Display_Table.Columns.Count;i++)
            {
                if(Current_Micos_Display_Table.Columns[i].ColumnName == "現在在庫数")
                {
                    Difference_Table.Columns.Add(Current_Micos_Display_Table.Columns[i].ColumnName, typeof(float));
                }
                else
                {
                    Difference_Table.Columns.Add(Current_Micos_Display_Table.Columns[i].ColumnName, typeof(string));
                }
               
            }
            


            //DataRow row_difference;
            //foreach(DataRow row_micos in Current_Micos_Display_Table.Rows)
            //{
            //    foreach(DataRow row_actualZaiko in Current_Actual_Zaiko_Display_Table.Rows)
            //    {
            //        if (row_micos["品目ＣＤ"].ToString() == row_actualZaiko["品目ＣＤ"].ToString())
            //        {
            //            row_difference = Difference_Table.NewRow();
            //            row_difference["品目ＣＤ"] = row_micos["品目ＣＤ"];
            //            row_difference["現在在庫数"] = row_actualZaiko["現在在庫数"] - row_micos["現在在庫数"];

            //        }
            //    }
            //}

            ////表示されているﾃｰﾌﾞﾙ二つを合体
            //Difference_Table.Merge(Current_Actual_Zaiko_Display_Table);
            //Difference_Table.Merge(Current_Micos_Display_Table);

            ////品目ＣＤでgroupbyして、現在在庫数の合計値を足し合わせる。
            //Difference_Table = Difference_Table.AsEnumerable()
            //    .GroupBy(x => x.Field<float>("品目ＣＤ"))
            //    .Select(x => { DataRow row = Difference_Table.NewRow();
            //        row["品目ＣＤ"] = x.Key;
            //        row["現在在庫数"] = x.Sum(y => y.Field<float>("現在在庫数"));
            //        return row;
            //    })
            //    .CopyToDataTable();


            //　 Current_Micos_Display_Table　と　Current_Actual_Zaiko_Display_Table の差を抽出して、Difference_Tableに格納する。
            var Difference_var = Current_Micos_Display_Table.AsEnumerable().Except(Current_Actual_Zaiko_Display_Table.AsEnumerable(), DataRowComparer.Default);

            if (Difference_var.Any())
            {
                Difference_Table = Difference_var.CopyToDataTable();
            }


            dataGridView_Difference_Table.DataSource = Difference_Table;

        }
        

        
    }
}
