using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO;


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

        private List<string> DENSAN_SEIZOU_TABLE_ColumnName=new List<string>() { "入力日", "出荷製品", "製品コード", "経費", "出庫日", "納入予定日", "使用材料リスト" };
        private List<string> DENSAN_ZAIKO_TABLE_ColumnName = new List<string>() { "材料名", "材料コード", "保管場所", "Micos上の現在在庫","単位", "仕掛使用数", "在庫余裕分", "社内保管場所", "社内在庫","使用製品とその個数辞書"};
        private DataTable BUHIN_LIST_MicosOrigin_Table { get; set; }
        private DataTable ZAIKO_LIST_MicosOrigin_Table { get; set; }
        private List<string> DENSAN_HOKANBASYO = new List<string>() { "G324105", "G324205", "G323105", "G323205", "G323305" };

        public DataTable DENSAN_SEIZOU_TABLE { get; set; }
        public DataTable DENSAN_ZAIKO_TABLE { get; set; }


        /// <summary>
        /// csvファイルを読み込んで、Read_CSV_Tableを作成する。csvのフォーマットは一行目が列名でカンマ区切り。
        /// </summary>
        /// <param name="csv_file_path"></param>
        public void Read_CSV_to_Table(List<string> csv_file_path)
        {
            bool first_file_flag = true;
            Read_CSV_Table = new DataTable();

            foreach (string filename in csv_file_path)
            {

                TextFieldParser parser = new TextFieldParser(filename, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り


                string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。行のカーソルは呼び出す度にインクリメント。
                DataRow row;

                if (first_file_flag) //一つ目のファイルのときだけ列の名前を取得する。
                {
                    for (int i = 0; i < column.Length; i++)  //列の名前を追加する。
                    {
                        if (column[i] == "数量")
                        {
                            Read_CSV_Table.Columns.Add(column[i], typeof(float)); //他にも特定の型で読み込みたいときはIf()分を追加していく。
                        }
                        else
                        {
                            Read_CSV_Table.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                        }


                    }

                    first_file_flag = false;
                }


                while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                {
                    string[] column_data = parser.ReadFields();

                    row = Read_CSV_Table.NewRow();
                    for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                    {
                        row[i] = column_data[i];
                    }
                    Read_CSV_Table.Rows.Add(row);
                }
            }
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
        /// <summary>
        /// 引数で渡した列をﾃｰﾌﾞﾙから削除する。
        /// </summary>
        /// <param name="delete_col"></param>
        public void Organize_ColNum(int[] delete_col)
        {
            Out_DataTable = Read_CSV_Table.Copy();
            foreach(int col in delete_col)
            {
                Out_DataTable.Columns.RemoveAt(col);
            }
        }
        /// <summary>
        /// 電産の製造状況用のデータを入力するためのcsvファイルのテンプレートファイルを作成する。
        /// </summary>
        public void Create_DENSAN_SEIZOU_csv_template()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csvファイル(*.csv)|*.csv";
            sfd.Title = "保存先のファイル名を指定してください";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                try
                {
                    foreach (string col_name in DENSAN_SEIZOU_TABLE_ColumnName )
                    {
                        file.Write(col_name+ ",");
                    }

                }
                catch (NullReferenceException error)
                {
                    MessageBox.Show("テンプレ参照用のMicosデータがロードされていません。");
                }

                file.Close();
            }
        }

        public void Create_DENSAN_ZAIKO_csv_template_withBUHINLIST()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csvファイル(*.csv)|*.csv";
            sfd.Title = "保存先のファイル名を指定してください";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                try
                {
                    foreach (string col_name in DENSAN_ZAIKO_TABLE_ColumnName)
                    {
                        file.Write(col_name + ",");
                    }

                }
                catch (NullReferenceException error)
                {
                    MessageBox.Show("テンプレ参照用のMicosデータがロードされていません。");
                }

                file.Close();
            }

        }
        /// <summary>
        /// 引数で渡したデータﾃｰﾌﾞﾙをcsv出力する。
        /// </summary>
        /// <param name="target_table"></param>
        public void Export_csv_fromDataTable(DataTable target_table)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csvファイル(*.csv)|*.csv";
            sfd.Title = "保存先のファイル名を指定してください";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                try
                {
                    foreach (DataColumn column in target_table.Columns)
                    {
                        file.Write(column + ",");
                    }

                    file.Write("\n"); //改行コード

                    foreach(DataRow row in target_table.Rows)
                    {
                        for(int i =0; i < target_table.Rows.Count; i++)
                        {
                            file.Write(row[i].ToString() + ",");
                        }
                        file.Write("\n"); //一列各毎に改行
                    }

                }
                catch (NullReferenceException error)
                {
                    MessageBox.Show("テンプレ参照用のMicosデータがロードされていません。");
                }

                file.Close();
            }
        }
        /// <summary>
        /// 部品リストのcsvファイルを読み込んで、部品リストﾃｰﾌﾞﾙを作成する。
        /// </summary>
        /// <param name="BUHINcsv_FilePath"></param>
        public void Read_BUHINLISTcsv(List<string> BUHINcsv_FilePath)
        {
            Read_CSV_to_Table(BUHINcsv_FilePath);

            BUHIN_LIST_MicosOrigin_Table = new DataTable();
            BUHIN_LIST_MicosOrigin_Table = Read_CSV_Table.Copy();
        }
        /// <summary>
        /// 在庫リストのcsvファイルを読み込んで在庫リストﾃｰﾌﾞﾙを作成する。
        /// </summary>
        /// <param name="ZAIKOcsv_FilePath"></param>
        public void Read_ZAIKOLISTcsv(List<string> ZAIKOcsv_FilePath)
        {
            Read_CSV_to_Table(ZAIKOcsv_FilePath);

            ZAIKO_LIST_MicosOrigin_Table = new DataTable();
            ZAIKO_LIST_MicosOrigin_Table = Read_CSV_Table.Copy();
        }
        /// <summary>
        ///  ZAIKO_LIST_MicosOrigin_Tableをもとに電産在庫用ﾃｰﾌﾞﾙを作る。関数を使う前にZAIKO_LIST_MicosOrigin_Tableがないといけない。
        /// </summary>
        public void Create_DENSAN_ZAIKO_TABLE_init()
        {
            if(ZAIKO_LIST_MicosOrigin_Table.Rows.Count < 1)
            {
                MessageBox.Show("Micosの在庫データを読み込んで、在庫ﾃｰﾌﾞﾙを作成してください。");
                return;
            }

            DENSAN_ZAIKO_TABLE = new DataTable();

            //関数内で一時的に保持するﾃｰﾌﾞﾙ宣言
            DataTable DensanAndSyanaiZaiko = new DataTable();

            //列の作成
            foreach(string col_name in DENSAN_ZAIKO_TABLE_ColumnName)
            {
                if(
                   col_name == "Micos上の現在在庫" || 
                   col_name == "仕掛使用数" ||
                   col_name == "在庫余裕分" ||
                   col_name == "社内在庫"
                  )
                {
                    DENSAN_ZAIKO_TABLE.Columns.Add(col_name, typeof(float));
                }
                else
                {
                    DENSAN_ZAIKO_TABLE.Columns.Add(col_name, typeof(string));
                }
            }

            bool first_flag = true;
            string querry = "";

            //Micos在庫リストから電産保管場所のものだけを抽出してtemp_Tableに格納する。
            foreach(string densan_hokanbasyo in DENSAN_HOKANBASYO)
            {
                if (first_flag)
                {
                    querry = querry_maker_fullmatch(0,"保管場所",densan_hokanbasyo,"");
                    first_flag = false;
                }
                else
                {
                    querry = querry_maker_fullmatch(2, "保管場所", densan_hokanbasyo, querry);
                }
            }

            //保管場所が電産のものをすべてコピー.　この時点では電産在庫のみが格納⇒ここから社内在庫を足してく。
            DensanAndSyanaiZaiko = ZAIKO_LIST_MicosOrigin_Table.Select(querry).CopyToDataTable();

            List<string> densan_zaiko_list = new List<string>();
            densan_zaiko_list = remove_doublicate_value_fromTable(DensanAndSyanaiZaiko, "保管場所");

            DensanAndSyanaiZaiko = new DataTable();

            bool first_flag_densan_zaiko = true;
            

            foreach (string densan_zaiko_hinmeicd in densan_zaiko_list)
            {
                string querry_densanzaiko = "";
                if (first_flag_densan_zaiko)
                {
                    querry_densanzaiko = querry_maker_fullmatch(0, "品目ＣＤ", densan_zaiko_hinmeicd, "");
                    DensanAndSyanaiZaiko = ZAIKO_LIST_MicosOrigin_Table.Select(querry_densanzaiko).CopyToDataTable();
                }
                else
                {
                    querry_densanzaiko = querry_maker_fullmatch(0, "品目ＣＤ", densan_zaiko_hinmeicd, "");
                    DensanAndSyanaiZaiko.Merge(ZAIKO_LIST_MicosOrigin_Table.Select(querry_densanzaiko).CopyToDataTable());
                }
            }
            //この時点で電産にある在庫とその社内在庫のデータがDensanAndSyanaiZaikoに格納される。


            // 実際にDENSAN_ZAIKO_TABLEに格納していく。
            foreach (DataRow row in DensanAndSyanaiZaiko.Rows)
            {
                string hokanbasyo = row["保管場所"].ToString();
                char initial_hokanbasyo = hokanbasyo[0];

                if(initial_hokanbasyo == 'G')
                {
                    DataRow densan_row = DENSAN_ZAIKO_TABLE.NewRow();
                    densan_row["材料名"] = row["品名"];
                    densan_row["材料コード"] = row["品目ＣＤ"];
                    densan_row["保管場所"] = row["保管場所"];
                    densan_row["Micos上の現在在庫"] = row["現在在庫数"];

                    //このあたりはMicosの在庫データからは分からない。
                    //densan_row["単位"] = row["品目ＣＤ"];
                    //densan_row["仕掛使用数"] = row["品目ＣＤ"];
                    //densan_row["在庫余裕分"] = row["品目ＣＤ"];

                    foreach(DataRow row_syanai in DensanAndSyanaiZaiko.Rows)
                    {
                        if(row["品目ＣＤ"].ToString() == row_syanai["品目ＣＤ"].ToString() &&
                            row_syanai["保管場所"].ToString()[0] != 'G')
                        {
                            densan_row["社内保管場所"] = row_syanai["保管場所"]];
                            densan_row["社内在庫"] = (float)row_syanai["現在在庫数"];

                            break;
                        }
                    }

                    DENSAN_ZAIKO_TABLE.Rows.Add(densan_row);
                }
            }

        }
        /// <summary>
        /// table.select()で使うためのクエリを作成する。第一引数 0: 結合なし　1: ANDで結合 2:ORで結合
        /// </summary>
        /// <param name="and_or"></param>
        /// <param name="column_name"></param>
        /// <param name="target"></param>
        /// <param name="combine_querry"></param>
        /// <returns></returns>
        private string querry_maker_fullmatch(int and_or, string column_name, string target, string combine_querry) 
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
        /// ﾃｰﾌﾞﾙの特定列col_nameの重複のない要素をコレクションとして返す。
        /// </summary>
        /// <param name="target_table"></param>
        /// <param name="col_name"></param>
        /// <returns></returns>
        private List<string> remove_doublicate_value_fromTable(DataTable target_table, string col_name)
        {
            List<string> notdoublicated_list = new List<string>();

            //データ抽出設定の親工程項目の追加
            DataTable notDoublicatedTable = new DataTable();
            DataView dtView = new DataView(target_table);
            notDoublicatedTable = dtView.ToTable(true, col_name); //DataViewオブジェクトにデータﾃｰﾌﾞﾙを読んで、"親工程"親工程の重複を消去してる。

            foreach (DataRow row in notDoublicatedTable.Rows)
            {
                notdoublicated_list.Add(row[col_name].ToString());
            }

            return notdoublicated_list;
        }

    }
}
