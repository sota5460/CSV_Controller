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

        /// <summary>
        /// ファイル読み込みボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_fileselect_micos_Click(object sender, EventArgs e)
        {
            read_CurrentMicosData_fromFileOpen();
            read_database_CurrentMicosZaiko();

            Create_DiplayTable_fromOriginalTable(Current_Micos_Zaiko_Table,Current_Micos_Display_Table,0);

            dataGridView_CurrentMicos.DataSource = Current_Micos_Display_Table;

        }

        private void button_fileselect_zaiko_Click(object sender, EventArgs e)
        {
            read_ActualZaikoData_fromFileOpen();
            read_database_ActualZaiko();

            Create_DiplayTable_fromOriginalTable(Current_Actual_Zaiko_Table,Current_Actual_Zaiko_Display_Table,1);

            dataGridView_ActualZaiko.DataSource = Current_Actual_Zaiko_Display_Table;
        }

        private void button_create_diffrencetable_Click(object sender, EventArgs e)
        {
            create_difference_table();
        }

        /// <summary>
        /// ダイアログボックスからファイルを読んでデータﾃｰﾌﾞﾙを作成する関数
        /// </summary>
        public void read_CurrentMicosData_fromFileOpen()
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Current_Micos_Zaiko_Table = new DataTable("Micos現在在庫データ");
                foreach (string filename_currentmicos_icb in openFileDialog1.FileNames)
                {


                    TextFieldParser parser = new TextFieldParser(filename_currentmicos_icb, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
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
                    textBox_filepath_micos.AppendText(filename_currentmicos_icb + "\n");
                }
                first_file_flag = true;
            }
        }
        public void read_ActualZaikoData_fromFileOpen()
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Current_Actual_Zaiko_Table = new DataTable("実際の在庫データ");
                foreach (string filename_currentmicos_icb in openFileDialog1.FileNames)
                {


                    TextFieldParser parser = new TextFieldParser(filename_currentmicos_icb, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
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
                                Current_Actual_Zaiko_Table.Columns.Add(column[i], typeof(float)); //現在在庫数だけint型
                            }
                            else
                            {
                                Current_Actual_Zaiko_Table.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                            }
                        }

                        first_file_flag = false;
                    }


                    while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                    {
                        string[] column_data = parser.ReadFields();

                        row = Current_Actual_Zaiko_Table.NewRow();
                        for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                        {
                            row[i] = column_data[i];
                        }
                        Current_Actual_Zaiko_Table.Rows.Add(row);
                    }
                    textBox_filepath_zaiko.AppendText(filename_currentmicos_icb + "\n");
                }

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
            //for(int i = 0; i < Current_Micos_Display_Table.Columns.Count;i++)
            //{
            //    if(Current_Micos_Display_Table.Columns[i].ColumnName == "現在在庫数")
            //    {
            //        Difference_Table.Columns.Add(Current_Micos_Display_Table.Columns[i].ColumnName, typeof(float));
            //    }
            //    else
            //    {
            //        Difference_Table.Columns.Add(Current_Micos_Display_Table.Columns[i].ColumnName, typeof(string));
            //    }

            //}

            Difference_Table = new DataTable();

            foreach(DataColumn column in Current_Micos_Display_Table.Columns)
            {
                Difference_Table.Columns.Add(column.ColumnName, column.DataType);
            }

            //var zaiko_dic = Current_Micos_Display_Table.AsEnumerable().ToDictionary(row => new Tuple<string,string>(row[],row[]), row => row["現在在庫数"]);

            //var dic = new Dictionary<Tuple<string, string>, float>();
            //foreach(DataRow row in Current_Micos_Display_Table.Rows)
            //{
            //    float f_value = (float)row["現在在庫数"];
            //    dic.Add(new Tuple<string, string>(row["品目ＣＤ"].ToString(), row["品名"].ToString()), f_value);
                
            //}




            DataRow row_difference;
            foreach (DataRow row_micos in Current_Micos_Display_Table.Rows)
            {
                foreach (DataRow row_actualZaiko in Current_Actual_Zaiko_Display_Table.Rows)
                {
                    if (row_micos["品目ＣＤ"].ToString() == row_actualZaiko["品目ＣＤ"].ToString())
                    {
                        float row_micos_zaiko = (float)row_micos["現在在庫数"]; //なぜか一回フロート型の変数に明示的に型指定して、取り出さないと計算できなかった。
                        float row_actual_zaiko = (float)row_actualZaiko["現在在庫数"];

                        row_difference = Difference_Table.NewRow();　//この時点でカラムは追加されてる。
                        row_difference["品目ＣＤ"] = row_micos["品目ＣＤ"];
                        row_difference["現在在庫数"] = row_micos_zaiko - row_actual_zaiko;

                        Difference_Table.Rows.Add(row_difference);
                    }
                }
            }

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
            //var Difference_var = Current_Micos_Display_Table.AsEnumerable().Except(Current_Actual_Zaiko_Display_Table.AsEnumerable(), DataRowComparer.Default);

            //if (Difference_var.Any())
            //{
            //    Difference_Table = Difference_var.CopyToDataTable();
            //}


            dataGridView_Difference_Table.DataSource = Difference_Table;

        }

        public void Create_DiplayTable_fromOriginalTable(DataTable original_table, DataTable display_table, int mode) //diplay用に列数を減らす。コンパクトにする。 0: Micos, 1:Zaiko
        {
            display_table = new DataTable(); //display_tableの初期化

            DataTable display_table_temp = new DataTable();　//一時オリジナルﾃｰﾌﾞﾙ保存用ﾃｰﾌﾞﾙ宣言

            display_table_temp = original_table;　//オリジナルデータを一時ﾃｰﾌﾞﾙにコピー
            var column_list = new List<string>();

            foreach(DataColumn column in display_table_temp.Columns)　// カラム名のリストを作成
            {
                column_list.Add(column.ColumnName);
            }
            
            foreach(string column in column_list)
            {
                if(column != "品目ＣＤ" && column != "品名" && column != "現在在庫数"){　//displayする列のみ残す。
                    display_table_temp.Columns.Remove(column);
                }
            }

            switch (mode)
            {
                case (0):
                    Current_Micos_Display_Table = display_table_temp;
                    break;
                case (1):
                    Current_Actual_Zaiko_Display_Table = display_table_temp;
                    break;
            }
        }


    }
}
