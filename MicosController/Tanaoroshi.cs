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
        public DataTable Current_Micos_Display_Table { get; set; } //一番初めに表示されるMicosﾃｰﾌﾞﾙ。保持する用。
        public DataTable Micos_Display_Extracted_Table { get; set; }　//抽出したときに表示する用ﾃｰﾌﾞﾙ。
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
            //read_database_CurrentMicosZaiko();
            read_database_CurrentMicosZaiko_addCheckbox("経費", 0);
            read_database_CurrentMicosZaiko_addCheckbox("保管場所", 1);
            read_database_CurrentMicosZaiko_addCheckbox("工程", 2);

            Create_DiplayTable_fromOriginalTable(Current_Micos_Zaiko_Table,Current_Micos_Display_Table,0);

            dataGridView_CurrentMicos.DataSource = Current_Micos_Display_Table;
            Micos_Display_Extracted_Table = Current_Micos_Display_Table;

        }

        private void button_fileselect_zaiko_Click(object sender, EventArgs e)
        {
            read_ActualZaikoData_fromFileOpen();
            read_database_ActualZaiko();

            Create_DiplayTable_fromOriginalTable(Current_Actual_Zaiko_Table,Current_Actual_Zaiko_Display_Table,1);

            dataGridView_ActualZaiko.DataSource = Current_Actual_Zaiko_Display_Table;
        }

        /// <summary>
        /// フィルタをかけるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_filter_Micos_Click(object sender, EventArgs e)
        {
            button_filter_Micos.Enabled = false;

            extract_by_keihi_koutei_hokan_kai(0);

            button_filter_Micos.Enabled = true;

        }
        /// <summary>
        /// クエリを入力してフィルタをかけるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_extract_queeryStatement_Click(object sender, EventArgs e)
        {
            string queery = textBox_queeryStatement.Text;

            Micos_Display_Extracted_Table = Current_Micos_Display_Table.Select(queery).CopyToDataTable();


            dataGridView_CurrentMicos.DataSource = Micos_Display_Extracted_Table;

        }
        /// <summary>
        /// 差ﾃｰﾌﾞﾙを表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_diffrencetable_Click(object sender, EventArgs e)
        {
            create_difference_table();
        }
        /// <summary>
        /// 在庫データ書くとき用のテンプレートcsvファイル出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_csv_templateOut_Click(object sender, EventArgs e)
        {
            save_templete_csv_file();
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

                            if (column[i] == "現在在庫数") // 10列目：現在在庫数
                            {
                                Current_Actual_Zaiko_Table.Columns.Add(column[i], typeof(float)); //現在在庫数だけfloat型
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
        /// チェックボックスに項目を自動追加する関数 0経費 1保管場所 2工程
        /// </summary>
        public void read_database_CurrentMicosZaiko_addCheckbox(string column_name, int mode) //Current_Micos_Zaiko_Tableの経費の種類をチェックボックスに追加する。第一引数：カラム名　第二引数：mode 0 経費; 1 保管場所; 2 工程
        {
            DataTable notDoublicated_CurrentMicos;
            DataView dtView_CurrentMicos = new DataView(Current_Micos_Zaiko_Table);

            notDoublicated_CurrentMicos = dtView_CurrentMicos.ToTable(true,column_name); //列の重複を取り除く

            switch (mode)
            {
                case (0):
                    foreach (DataRow row in notDoublicated_CurrentMicos.Rows)
                    {
                        checkedListBox_CurrentMicos_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
                    }

                    for (int i = 0; i < checkedListBox_CurrentMicos_keihi.Items.Count; i++) //すべての項目をチェックする。
                    {
                        checkedListBox_CurrentMicos_keihi.SetItemChecked(i, true);
                    }

                    break;
                case (1):
                    foreach (DataRow row in notDoublicated_CurrentMicos.Rows)
                    {
                        checkedListBox_currentMicos_hokan.Items.Add(row["保管場所"]); //"保管場所"列の重複してないものをチェックボックスに追加する。
                    }

                    for (int i = 0; i < checkedListBox_currentMicos_hokan.Items.Count; i++) //すべての項目をチェックする。
                    {
                        checkedListBox_currentMicos_hokan.SetItemChecked(i, true);
                    }

                    break;
                case (2):
                    foreach (DataRow row in notDoublicated_CurrentMicos.Rows)
                    {
                        checkedListBox_currentMicos_koutei.Items.Add(row["工程"]); //"工程"列の重複してないものをチェックボックスに追加する。
                    }

                    for (int i = 0; i < checkedListBox_currentMicos_koutei.Items.Count; i++) //すべての項目をチェックする。
                    {
                        checkedListBox_currentMicos_koutei.SetItemChecked(i, true);
                    }

                    break;
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
        /// <summary>
        /// ﾃｰﾌﾞﾙ比較して差を求めたﾃｰﾌﾞﾙを作成する。
        /// </summary>
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

            Difference_Table = new DataTable();　//差ﾃｰﾌﾞﾙの初期化

            foreach(DataColumn column in Current_Micos_Display_Table.Columns)　//Micosﾃｰﾌﾞﾙと同じ列を追加する。
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


            ///Micosﾃｰﾌﾞﾙ、在庫ﾃｰﾌﾞﾙで同じ品目ＣＤが二つ存在してはいけない。（EEC3928のデータが二つとか存在するとダメ。ユニークにしないといけない。）


            DataRow row_difference;
            int zaiko_data_num_cnt = 0;
            foreach (DataRow row_micos in Micos_Display_Extracted_Table.Rows)
            {
                zaiko_data_num_cnt = 0;
                foreach (DataRow row_actualZaiko in Current_Actual_Zaiko_Display_Table.Rows)
                {
                    if (row_micos["品目ＣＤ"].ToString() == row_actualZaiko["品目ＣＤ"].ToString())　//&& row_micos["保管場所"].ToString() == row_actualZaiko["保管場所"] で保管場所も条件に入れられる。
                    {
                        float row_micos_zaiko = (float)row_micos["現在在庫数"]; //なぜか一回フロート型の変数に明示的に型指定して、取り出さないと計算できなかった。
                        float row_actual_zaiko = (float)row_actualZaiko["現在在庫数"];

                        row_difference = Difference_Table.NewRow();　//この時点でカラムは追加されてる。
                        row_difference["品目ＣＤ"] = row_micos["品目ＣＤ"];
                        row_difference["現在在庫数"] = row_micos_zaiko - row_actual_zaiko;

                        row_difference["工程"] = row_micos["工程"];
                        row_difference["経費"] = row_micos["経費"];


                        Difference_Table.Rows.Add(row_difference);
                        break;
                    }

                    zaiko_data_num_cnt++;

                    if (zaiko_data_num_cnt == Current_Actual_Zaiko_Display_Table.Rows.Count)
                    {
                        row_difference = Difference_Table.NewRow();　//この時点でカラムは追加されてる。
                        row_difference["品目ＣＤ"] = row_micos["品目ＣＤ"];
                        row_difference["現在在庫数"] = (float) 0;　//在庫データに存在しないので、Micosをゼロにする。

                        row_difference["工程"] = row_micos["工程"];
                        row_difference["経費"] = row_micos["経費"];


                        Difference_Table.Rows.Add(row_difference);

                        Console.WriteLine("{0}は在庫データに存在しません。", row_micos["品目ＣＤ"]);　
                    }

                   

                }
            }


            int micos_data_num_cnt = 0;

            foreach(DataRow row_actualZaiko in Current_Actual_Zaiko_Display_Table.Rows)
            {
                micos_data_num_cnt = 0;
                foreach(DataRow row_micos in Micos_Display_Extracted_Table.Rows)
                {
                    if (row_actualZaiko["品目ＣＤ"].ToString()== row_micos["品目ＣＤ"].ToString())
                    {
                        break;
                    }

                    micos_data_num_cnt++;

                    if (micos_data_num_cnt == Micos_Display_Extracted_Table.Rows.Count)
                    {
                        row_difference = Difference_Table.NewRow();　//この時点でカラムは追加されてる。
                        row_difference["品目ＣＤ"] = row_actualZaiko["品目ＣＤ"];
                        row_difference["現在在庫数"] = row_actualZaiko["現在在庫数"];

                        row_difference["工程"] = row_actualZaiko["工程"];
                        row_difference["経費"] = row_actualZaiko["経費"];


                        Difference_Table.Rows.Add(row_difference);


                        Console.WriteLine("{0}はMicosデータに存在しません。", row_actualZaiko["品目ＣＤ"]);
                    }

                    
                }
            }

            Difference_Table.Columns["現在在庫数"].ColumnName = "実在庫との差";  //列名変更

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
        /// <summary>
        /// ﾃｰﾌﾞﾙ操作関連関数
        /// </summary>
        /// <param name="original_table"></param>
        /// <param name="display_table"></param>
        /// <param name="mode"></param>
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
                if(column != "品目ＣＤ" && column != "品名" && column != "現在在庫数"　&& column!="保管場所" && column != "工程"　&& column !="経費"){　//displayする列のみ残す。
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

        public void extract_by_keihi_koutei_hokan(int mode)
        {

            Micos_Display_Extracted_Table = new DataTable();


            int i = 0;
            string temp_querry = "";

            switch (mode)
            {
                case (0):
                    foreach (string selected_keihi in checkedListBox_CurrentMicos_keihi.CheckedItems)
                    {
                        if (i == 0)
                        {
                            temp_querry = querry_maker_fullmatch(0, "経費", selected_keihi, "");
                        }
                        else
                        {
                            temp_querry = querry_maker_fullmatch(2, "経費", selected_keihi, temp_querry);
                        }
                        i++;
                    }
                    break;
                case (1):
                    foreach (string selected_keihi in checkedListBox_currentMicos_hokan.CheckedItems)
                    {
                        if (i == 0)
                        {
                            temp_querry = querry_maker_fullmatch(0, "保管場所", selected_keihi, "");
                        }
                        else
                        {
                            temp_querry = querry_maker_fullmatch(2, "保管場所", selected_keihi, temp_querry);
                        }
                        i++;
                    }
                    break;
                case (2):
                    foreach (string selected_keihi in checkedListBox_currentMicos_koutei.CheckedItems)
                    {
                        if (i == 0)
                        {
                            temp_querry = querry_maker_fullmatch(0, "工程", selected_keihi, "");
                        }
                        else
                        {
                            temp_querry = querry_maker_fullmatch(2, "工程", selected_keihi, temp_querry);
                        }
                        i++;
                    }
                    break;
            }

            if (temp_querry != "")
            {
                Micos_Display_Extracted_Table =Current_Micos_Display_Table.Select(temp_querry).CopyToDataTable();
               // Current_Micos_Display_Table.Merge(temp_Datatable.Select(temp_querry).CopyToDataTable());
            }
            else
            {
                dataGridView_CurrentMicos.DataSource = null;
                return;

            }

            dataGridView_CurrentMicos.DataSource = Micos_Display_Extracted_Table;

        }

        public void extract_by_keihi_koutei_hokan_kai(int mode) //チェックボックス抽出処理最終版。チェックボックス３つを監視して、チェックあるやつだけグリッドに表示する。
        {

            Micos_Display_Extracted_Table = new DataTable();


            int i = 0;

            string temp_querry_keihi = "";
            string temp_querry_hokan = "";
            string temp_querry_koutei = "";


            foreach (string selected_keihi in checkedListBox_CurrentMicos_keihi.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_keihi = querry_maker_fullmatch(0, "経費", selected_keihi, "");
                }
                else
                {
                    temp_querry_keihi = querry_maker_fullmatch(2, "経費", selected_keihi, temp_querry_keihi);
                }
                i++;
            }

            if (temp_querry_keihi == "")
            {
                dataGridView_CurrentMicos.DataSource = null;
                return;
            }

            Micos_Display_Extracted_Table = Current_Micos_Display_Table.Select(temp_querry_keihi).CopyToDataTable();

            i = 0;

            foreach (string selected_keihi in checkedListBox_currentMicos_hokan.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_hokan = querry_maker_fullmatch(0, "保管場所", selected_keihi, "");
                }
                else
                {
                    temp_querry_hokan = querry_maker_fullmatch(2, "保管場所", selected_keihi, temp_querry_hokan);
                }
                i++;
            }

            if (temp_querry_hokan == "")
            {
                dataGridView_CurrentMicos.DataSource = null;
                return;
            }

            Micos_Display_Extracted_Table = Micos_Display_Extracted_Table.Select(temp_querry_keihi).CopyToDataTable();

            i = 0;

            foreach (string selected_keihi in checkedListBox_currentMicos_koutei.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_koutei = querry_maker_fullmatch(0, "工程", selected_keihi, "");
                }
                else
                {
                    temp_querry_koutei = querry_maker_fullmatch(2, "工程", selected_keihi, temp_querry_koutei);
                }
                i++;
            }

            if (temp_querry_koutei == "")
            {
                dataGridView_CurrentMicos.DataSource = null;
                return;
            }

            Micos_Display_Extracted_Table = Micos_Display_Extracted_Table.Select(temp_querry_koutei).CopyToDataTable();


            dataGridView_CurrentMicos.DataSource = Micos_Display_Extracted_Table;

        }

        public string querry_maker_fullmatch(int and_or, string column_name, string target, string combine_querry) //querry作成関数。 第一引数 0: 結合なし　1: ANDで結合 2:ORで結合
        {
            string Querry = "";
            switch (and_or)
            {
                case (0):
                    Querry = column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
                case (1):
                    Querry = combine_querry + " " + "AND" + " " + column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
                case (2):
                    Querry = combine_querry + " " + "OR" + " " + column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
            }
            return Querry;
        }
        /// <summary>
        ///実在庫記入用の csvテンプレートファイルを出力する。
        /// </summary>
        public void save_templete_csv_file()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csvファイル(*.csv)|*.csv";
            sfd.Title = "保存先のファイル名を指定してください";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                foreach(DataColumn column in Micos_Display_Extracted_Table.Columns)
                {
                    file.Write(column.ColumnName + ",");
                }

                file.Close();
            }
        }




    }
}
