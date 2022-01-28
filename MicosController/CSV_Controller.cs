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
        /// オリジナルの部品構成Ｍｉｃｏｓデータから、外注に送る材料だけを抽出したもの。
        /// </summary>
        public DataTable GaityuBuhinTable { get;set;}
        public DataTable GaityuZaiikoTable { get; set; }
        private List<string> GaityuuZaikoTable_col = new List<string>() { "経費","品目ＣＤ","品名","保管場所","現在在庫数(Micos)","現在仕掛数", "在庫余裕分", "社内保管場所", "社内在庫", "使用製品その個数" };
        private List<string> GaityuuZaikoTable_col_ver2 = new List<string>() { "材料情報", "保管場所情報", "使用製品情報" };

        private struct same_zaiko_data
        {
            //重複しないユニークなやつ
            public string hinmei;
            public string keihi;
            public string zairyo_code;

            //外注在庫が同じ品名で複数存在する可能性あり 
            public string gaityu_hokanbasyo;
            public float gaityu_zaikosu;
            public Dictionary<string, zaiko_key_hokanbasyo> hokanbasyo_dic;
            

            public string syanai_hokanbasyo;
            public float syanai_zaikosu;
            //public Dictionary<string, zaiko_each_hokanbasyo>

        }

        private struct zairyo_siyousu_data
        {
            public string zairyo_code;

            public string siyou_seihin_code;

            public float siyousu;
        }

        //Dictionary<zairyou,hokanbasyo_zaikosuu_data>
       

        private struct zairyou
        {
            public string zairyou_code;
            public string zairyou_seihinmei;
        }

        private struct hokanbasyo_siyouseihin_data
        {
            public string zairyou_code;
            public string hokan_basyo;
            public string keihi;
            public float zaiko_su;

            public Dictionary<string,float> seihin_siyousu;// key : 使用する製品CD　float ：使用数
        }

        private struct hokanbasyo_data
        {
            public string zairyou_code;
            public string keihi;
            public string hokan_basyo;
            public float zaikosu;
        }

        private struct seihin_siyou_data
        {
            public string seihin_code;
            public string zairyou_code;
            public string siyou_su;
        }

        private struct zaiko_key_hokanbasyo
        {
            public string keihi;
            public float genzai_zaiko;
        }



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
                        if (column[i] == "数量"||
                            column[i] == "現在在庫数"
                            
                            )
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
                            densan_row["社内保管場所"] = row_syanai["保管場所"];
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
        ///<summary>
        ///部品構成csv（MMB）を渡すと外注工程750だけ抽出した部品テーブルGaityuBuhinTableを作成する。（いらない出庫場所ｃ－-とかを取り除く）
        ///<summary>
        public void Create_GaityuBuhinTable(List<string> csv_file_path)
        {
            GaityuBuhinTable = new DataTable();
            Read_CSV_to_Table(csv_file_path);

            //親工程を全レベルに記入する。
            Fill_Oyakoutei(Read_CSV_Table);

            //工程が750かつ出荷場所がGではじまるのものだけを抽出する。
            GaityuBuhinTable = G_750_Filter(Read_CSV_Table);

            int row_cnt = 0;
            for(int i = 0; i < GaityuBuhinTable.Rows.Count; i++)
            {
                //子品目コード列の要素の１文字目がZ　かつ　子品目コードにアッセンブリを含むとき　そのデータを消去する。
                if(GaityuBuhinTable.Rows[row_cnt]["子品目コード"].ToString()[0] == 'Z'&&
                    GaityuBuhinTable.Rows[row_cnt]["子品名"].ToString().Contains("ｱｯｾﾝﾌﾞﾘ"))
                {
                    GaityuBuhinTable.Rows[row_cnt].Delete();
                    row_cnt--;
                }
                row_cnt++;
            }

            ///
            row_cnt =0;
            for(int i = 0; i<GaityuBuhinTable.Rows.Count; i++)
            {
                if (row_cnt>=GaityuBuhinTable.Rows.Count-1)
                {
                    break;
                }

                if (GaityuBuhinTable.Rows[row_cnt]["子品目コード"].ToString()[0] == 'Z')
                {

                    ///zコード傘下のレベルと製品情報を保持する。zコード傘下の部品を除外する。
                    string seihin_z = GaityuBuhinTable.Rows[row_cnt]["選択品名"].ToString();
                    string level_z ="";

                    //zコードとzコードの下の材料が異なるレベルになっているかどうか確認している。
                    if (GaityuBuhinTable.Rows[row_cnt + 1]["レベル"].ToString() != GaityuBuhinTable.Rows[row_cnt]["レベル"].ToString())
                    {
                        level_z = GaityuBuhinTable.Rows[row_cnt+1]["レベル"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Zレベル傘下のレベルがおかしい。");
                    }
                    

                    for(int j = row_cnt; j < GaityuBuhinTable.Rows.Count; j++)
                    {
                        //ｚ部品コードの中身の一番下の行を取得。（品名が変わるorレベルが変わったときの行番号を取得。変わったときの行を取得するから１マイナスして数を調整してる。）
                        if(GaityuBuhinTable.Rows[j]["選択品名"].ToString()!=seihin_z || GaityuBuhinTable.Rows[j]["レベル"].ToString()!= level_z)
                        {
                            //ｚコードの中身が何個あるか。何行削除するか。
                            int z_buhin_component_num = j - row_cnt - 1; 　
                            for(int a = 0; a < z_buhin_component_num; a++)
                            {
                                //ｚコードの一個下の行をｚコードの中身の数だけ削除する。
                                GaityuBuhinTable.Rows[row_cnt+1].Delete(); 
                            }
                            break;
                        }
                        
                    }
                }

                row_cnt++;
            }

        }

        public void Create_GaityuZaikoTable(List<string> csv_file_path)
        {
            Read_ZAIKOLISTcsv(csv_file_path);


            if (ZAIKO_LIST_MicosOrigin_Table.Rows.Count <= 0)
            {
                MessageBox.Show("error");
                return;
            }

            GaityuZaiikoTable = new DataTable();

            GaityuZaiikoTable = MicosZaikoToGaityuZaiko(ZAIKO_LIST_MicosOrigin_Table);

            MessageBox.Show("done");

            
        }
        
        ///<summary>
        ///引数で渡した部品構成リストテーブルの親工程の空白を埋めるもの。
        ///<summary>
        public void Fill_Oyakoutei(DataTable BuhinTable)
        {
            int i =0;
            foreach(DataRow row in BuhinTable.Rows)
            {
                if (row["親工程"].ToString() == "")
                {
                    row["親工程"] = BuhinTable.Rows[i-1]["親工程"];
                }
                i++;
            }
        }
        /// <summary>
        /// 引数として渡した成部品テーブルから保管場所がGで始まるかつ、工程が750のものを抽出したものをテーブルで返す。
        /// select分を使用する場合、順番がプライマリキー順になるので、テーブルの順番通りに抽出したい場合はforeach分で自作するか、selectの第二引数にプライマリキーを指定。
        /// </summary>
        /// <param name="BuhinTable"></param>
        /// <returns></returns>
        public DataTable G_750_Filter(DataTable BuhinTable)
        {
            DataTable return_Table = new DataTable();
            
            foreach(DataColumn column in BuhinTable.Columns)
            {
                return_Table.Columns.Add(column.ColumnName, column.DataType);
            }

            int col_num_max = return_Table.Columns.Count;
            foreach(DataRow row in BuhinTable.Rows)
            {
                if (row["標準出庫保管場所"].ToString()=="")
                {
                    continue;
                }


                if (row["標準出庫保管場所"].ToString()[0]=='G' && row["親工程"].ToString() == "750")
                {
                    DataRow add_row = return_Table.NewRow();

                    for(int i =0; i< col_num_max; i++)
                    {
                        add_row[i] = row[i];
                    }

                    return_Table.Rows.Add(add_row);

                }
            }

            return return_Table;
        }
        /// <summary>
        /// 親工程750のみを抽出したいとき。
        /// </summary>
        /// <param name="BuhinTable"></param>
        /// <returns></returns>
        public DataTable Filter750(DataTable BuhinTable)
        {
            DataTable return_Table = new DataTable();

            foreach (DataColumn column in BuhinTable.Columns)
            {
                return_Table.Columns.Add(column.ColumnName, column.DataType);
            }

            int col_num_max = return_Table.Columns.Count;
            foreach (DataRow row in BuhinTable.Rows)
            {
               
                if (row["親工程"].ToString() == "750")
                {
                    DataRow add_row = return_Table.NewRow();

                    for (int i = 0; i < col_num_max; i++)
                    {
                        add_row[i] = row[i];
                    }

                    return_Table.Rows.Add(add_row);

                }
            }

            return return_Table;
        }
        /// <summary>
        /// 標準出庫場所の先頭文字がCのものを取り除いたものを返す。
        /// </summary>
        /// <param name="BuhinTable"></param>
        /// <returns></returns>
        public DataTable C_Filter(DataTable BuhinTable)
        {
            DataTable return_Table = new DataTable();

            foreach (DataColumn column in BuhinTable.Columns)
            {
                return_Table.Columns.Add(column.ColumnName, column.DataType);
            }

            int col_num_max = return_Table.Columns.Count;
            foreach (DataRow row in BuhinTable.Rows)
            {
                if (row["標準出庫保管場所"].ToString() == "")
                {
                    continue;
                }

                if (row["標準出庫保管場所"].ToString()[0] != 'C')
                {
                    DataRow add_row = return_Table.NewRow();

                    for (int i = 0; i < col_num_max; i++)
                    {
                        add_row[i] = row[i];
                    }

                    return_Table.Rows.Add(add_row);

                }
            }

            return return_Table;
        }
        /// <summary>
        /// 子品目の先頭がYのものを取り除きたいとき。
        /// </summary>
        /// <param name="BuhinTable"></param>
        /// <returns></returns>
        public DataTable Y_Filter(DataTable BuhinTable)
        {
            DataTable return_Table = new DataTable();

            foreach (DataColumn column in BuhinTable.Columns)
            {
                return_Table.Columns.Add(column.ColumnName, column.DataType);
            }

            int col_num_max = return_Table.Columns.Count;
            foreach (DataRow row in BuhinTable.Rows)
            {

                if (row["子品目コード"].ToString()[0] != 'Y')
                {
                    DataRow add_row = return_Table.NewRow();

                    for (int i = 0; i < col_num_max; i++)
                    {
                        add_row[i] = row[i];
                    }

                    return_Table.Rows.Add(add_row);

                }
            }

            return return_Table;
        }
        /// <summary>
        /// 同じ材料コードでも在庫データ上では外注保管場所と社内保管場所の二つあるので、それを一つのテーブルにまとめる。
        /// GaityuBuhinTableが存在する状態で
        /// MicosOriginalZaikoDataを渡せばよい。
        /// </summary>
        /// <param name="MicosZaikoTable"></param>
        /// <returns></returns>
        public DataTable MicosZaikoToGaityuZaiko(DataTable MicosZaikoTable)
        {
            DataTable return_Table = new DataTable();

            DataTable Only_GaityuMicosZaikoExtracted_Table = new DataTable();

            List<string> GaityuBuhinList_code = new List<string>();
            GaityuBuhinList_code = remove_doublicate_value_fromTable(GaityuBuhinTable, "子品目コード");
            List<string> GaityuBuhinList_hinmei = new List<string>();
            GaityuBuhinList_hinmei = remove_doublicate_value_fromTable(GaityuBuhinTable, "子品名");

            //外注で使用する部品リストを作る。（部品リスト=>品名と品目CD, 在庫０の可能性を考慮して構成部品リストから抽出した外注材料から重複を取り除いたもの）
            List<zairyou> GaityuBuhinList = new List<zairyou>();
            for(int i = 0; i < GaityuBuhinList_code.Count; i++)
            {
                zairyou zairyou = new zairyou();
                zairyou.zairyou_code = GaityuBuhinList_code[i];
                zairyou.zairyou_seihinmei = GaityuBuhinList_hinmei[i];

                GaityuBuhinList.Add(zairyou);
            }

            //bool first_zairyou_flag = true;

            //Dictionary<string, same_zaiko_data> GaityuZaikoDic = new Dictionary<string, same_zaiko_data>();

            Dictionary<zairyou, Dictionary<string, hokanbasyo_siyouseihin_data>> Zaiko_Dic = new Dictionary<zairyou, Dictionary<string, hokanbasyo_siyouseihin_data>>();



            foreach (zairyou zairyou in GaityuBuhinList)
            {
                //DataTable table_for_each_zairyou;
                same_zaiko_data zaiko_syanai_gaityu = new same_zaiko_data();
                //bool g_flag = false;
                //bool h_flag = false;

                zaiko_syanai_gaityu.zairyo_code = zairyou.zairyou_code;
                zaiko_syanai_gaityu.hinmei = zairyou.zairyou_seihinmei;

                Dictionary<string, hokanbasyo_siyouseihin_data> hokanbasyo_and_seihin = new Dictionary<string, hokanbasyo_siyouseihin_data>();

                    if (ZAIKO_LIST_MicosOrigin_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == zairyou.zairyou_code).Any())
                    {
                        Only_GaityuMicosZaikoExtracted_Table = ZAIKO_LIST_MicosOrigin_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == zairyou.zairyou_code).CopyToDataTable();


                        foreach (DataRow row in Only_GaityuMicosZaikoExtracted_Table.Rows)
                        {
                        //if (row["保管場所"].ToString()[0] == 'G')
                        //{
                        //    //zaiko_syanai_gaityu.hinmei = row["品名"].ToString();
                        //    //zaiko_syanai_gaityu.zairyo_code = row["品目ＣＤ"].ToString();

                        //    zaiko_syanai_gaityu.keihi = row["経費"].ToString();
                        //    zaiko_syanai_gaityu.gaityu_hokanbasyo = row["保管場所"].ToString();
                        //    zaiko_syanai_gaityu.gaityu_zaikosu = (float)row["現在在庫数"];

                        //    g_flag = true;
                        //}
                        //if (row["保管場所"].ToString()[0] == 'H')
                        //{
                        //    zaiko_syanai_gaityu.keihi = row["経費"].ToString();
                        //    zaiko_syanai_gaityu.syanai_hokanbasyo = row["保管場所"].ToString();
                        //    zaiko_syanai_gaityu.syanai_zaikosu = (float)row["現在在庫数"];

                        //    h_flag = true;
                        //}

                        //zaiko_key_hokanbasyo zaiko_data = new zaiko_key_hokanbasyo();
                        //zaiko_data.genzai_zaiko = (float)row["現在在庫数"];
                        //zaiko_data.keihi = row["経費"].ToString();
                        //zaiko_syanai_gaityu.hokanbasyo_dic.Add(row["保管場所"].ToString(),zaiko_data);

                        //hokanbasyo_zaikosuu_data each_hokanbasyo_zaikosu = new hokanbasyo_zaikosuu_data();
                        //each_hokanbasyo_zaikosu.zairyou_code = zairyou.zairyou_code;
                        //each_hokanbasyo_zaikosu.hokan_basyo = row["保管場所"].ToString();
                        //each_hokanbasyo_zaikosu.keihi = row["経費"].ToString();
                        //each_hokanbasyo_zaikosu.zaiko_su = (float)row["現在在庫数"];

                        //Dictionary<string, float> seihin_siyousu = new Dictionary<string, float>();
                        //foreach (DataRow row_gaityu in GaityuBuhinTable.Rows)
                        //{
                        //    if (row["保管場所"].ToString()==row_gaityu["標準出庫保管場所"].ToString() && row["品目ＣＤ"].ToString() == row_gaityu["子品目コード"].ToString())
                        //    {
                        //        seihin_siyousu.Add(row["品目ＣＤ"].ToString(),(float)row_gaityu["数量"]);
                        //    }
                        //}

                        //each_hokanbasyo_zaikosu.seihin_siyousu = seihin_siyousu;

                        hokanbasyo_siyouseihin_data hokanbasyo_Data = new hokanbasyo_siyouseihin_data();
                        hokanbasyo_Data.zairyou_code = zairyou.zairyou_code;
                        hokanbasyo_Data.hokan_basyo = row["保管場所"].ToString();
                        hokanbasyo_Data.keihi = row["経費"].ToString();
                        hokanbasyo_Data.zaiko_su = (float)row["現在在庫数"];

                        Dictionary<string, float> seihin_siyousu = new Dictionary<string, float>();
                        foreach (DataRow row_gaityu in GaityuBuhinTable.Rows)
                        {
                            if (row["保管場所"].ToString() == row_gaityu["標準出庫保管場所"].ToString() && hokanbasyo_Data.zairyou_code == row_gaityu["子品目コード"].ToString())
                            {
                                seihin_siyousu.Add(row_gaityu["選択品目ＣＤ"].ToString(), (float)row_gaityu["数量"]);
                            }
                        }

                        hokanbasyo_Data.seihin_siyousu = seihin_siyousu;

                        hokanbasyo_and_seihin.Add(row["保管場所"].ToString(), hokanbasyo_Data);
                        }

                        //if (g_flag == true && h_flag == false)
                        //{
                        //    zaiko_syanai_gaityu.syanai_hokanbasyo = "なし";
                        //    zaiko_syanai_gaityu.syanai_zaikosu = 0;
                        //}
                        //if(g_flag ==false && h_flag == true)
                        //{
                        //    zaiko_syanai_gaityu.gaityu_hokanbasyo = "なし";
                        //    zaiko_syanai_gaityu.gaityu_zaikosu = 0;
                        //}

                        

                        //GaityuZaikoDic.Add(zairyou.zairyou_code, zaiko_syanai_gaityu);

                        //first_zairyou_flag = false;

                    }
                else //GもHもどちらもないパターン。在庫がどこにもない。
                {
                    //zaiko_syanai_gaityu.syanai_hokanbasyo = "なし";
                    //zaiko_syanai_gaityu.syanai_zaikosu = 0;
                    //zaiko_syanai_gaityu.gaityu_hokanbasyo = "なし";
                    //zaiko_syanai_gaityu.gaityu_zaikosu = 0;
                    //GaityuZaikoDic.Add(zairyou.zairyou_code, zaiko_syanai_gaityu);

                    //hokanbasyo_siyouseihin_data hokanbasyo_Data = new hokanbasyo_siyouseihin_data();
                    //hokanbasyo_Data.zairyou_code = zairyou.zairyou_code;
                    //hokanbasyo_Data.hokan_basyo = "なし";
                    //hokanbasyo_Data.keihi ="なし";
                    //hokanbasyo_Data.zaiko_su = 0;

                    string zaikonashi_zairyo = zairyou.zairyou_code;

                    Dictionary<string, float> seihin_siyousu = new Dictionary<string, float>();
                    foreach (DataRow row_gaityu in GaityuBuhinTable.Rows)
                    {
                        if (zaikonashi_zairyo == row_gaityu["子品目コード"].ToString())
                        {
                            hokanbasyo_siyouseihin_data hokanbasyo_Data = new hokanbasyo_siyouseihin_data();
                            hokanbasyo_Data.zairyou_code = zaikonashi_zairyo;
                            hokanbasyo_Data.hokan_basyo = row_gaityu["標準出庫保管場所"].ToString();
                            hokanbasyo_Data.keihi = row_gaityu["親経費"].ToString();
                            hokanbasyo_Data.zaiko_su = 0;

                            Dictionary<string, float> seihin_siyousu2 = new Dictionary<string, float>();
                            foreach (DataRow row_gaityu2 in GaityuBuhinTable.Rows)
                            {
                                if(row_gaityu2["子品目コード"].ToString() == zaikonashi_zairyo && row_gaityu2["標準出庫保管場所"]==hokanbasyo_Data.hokan_basyo)
                                {
                                    seihin_siyousu2.Add(row_gaityu2["選択品目ＣＤ"].ToString(), (float)row_gaityu2["数量"]);
                                }
                            }
                            hokanbasyo_Data.seihin_siyousu = seihin_siyousu2;


                            hokanbasyo_and_seihin.Add(hokanbasyo_Data.hokan_basyo, hokanbasyo_Data);
                            break;
                        }
                    }
                }

                //}
                //else
                //{
                //    // table_for_each_zairyou = ZAIKO_LIST_MicosOrigin_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == zairyou).CopyToDataTable();

                //    if (ZAIKO_LIST_MicosOrigin_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == zairyou.zairyou_code).Any())
                //    {
                //        Only_GaityuMicosZaikoExtracted_Table = ZAIKO_LIST_MicosOrigin_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == zairyou.zairyou_code).CopyToDataTable();

                //        foreach (DataRow row in Only_GaityuMicosZaikoExtracted_Table.Rows)
                //        {
                //            //在庫が存在しない場合、nullや０になる。
                //            if (row["保管場所"].ToString()[0] == 'G')
                //            {
                //                zaiko_syanai_gaityu.hinmei = row["品名"].ToString();
                //                zaiko_syanai_gaityu.zairyo_code = row["品目ＣＤ"].ToString();
                //                zaiko_syanai_gaityu.keihi = row["経費"].ToString();

                //                zaiko_syanai_gaityu.gaityu_hokanbasyo = row["保管場所"].ToString();
                //                zaiko_syanai_gaityu.gaityu_zaikosu = (float)row["現在在庫数"];

                //                g_flag = true;
                //            }
                //            if (row["保管場所"].ToString()[0] == 'H')
                //            {


                //                zaiko_syanai_gaityu.syanai_hokanbasyo = row["保管場所"].ToString();
                //                zaiko_syanai_gaityu.syanai_zaikosu = (float)row["現在在庫数"];

                //                h_flag = true;
                //            }
                //        }



                //        GaityuZaikoDic.Add(zairyou.zairyou_code, zaiko_syanai_gaityu);

                //    }
                //    else //在庫が０で存在しないとき。
                //    {

                //    }



                //    GaityuZaikoDic.Add(zairyou, zaiko_syanai_gaityu);

                //    Only_GaityuMicosZaikoExtracted_Table.Merge(table_for_each_zairyou);
                //}

                Zaiko_Dic.Add(zairyou, hokanbasyo_and_seihin);

            }



            GaityuZaikoTableColAdd_ver2(return_Table);

            //List<string> Zairyou_List = new List<string>();
            //Zairyou_List = remove_doublicate_value_fromTable(MicosZaikoTable,"品目ＣＤ");

            foreach(zairyou distinct_zairyou in GaityuBuhinList)
            {
                DataRow newrow = return_Table.NewRow();
                Dictionary<string, zairyo_siyousu_data> zaiko_data_eachzairyo = new Dictionary<string, zairyo_siyousu_data>();
                zairyo_siyousu_data each_zairyo_siyousu = new zairyo_siyousu_data();

                foreach(DataRow row in GaityuBuhinTable.Rows)
                {
                    if (row["子品目コード"].ToString() == distinct_zairyou.zairyou_code)
                    {
                        each_zairyo_siyousu.siyousu = (float)row["数量"];
                        each_zairyo_siyousu.siyou_seihin_code = row["選択品目ＣＤ"].ToString();
                        each_zairyo_siyousu.zairyo_code = row["子品目コード"].ToString();
                        zaiko_data_eachzairyo.Add(row["選択品目ＣＤ"].ToString(),each_zairyo_siyousu);
                    }
                }


               // newrow["経費"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].keihi;
               // newrow["品目ＣＤ"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].zairyo_code;
               // newrow["品名"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].hinmei;
               // newrow["保管場所"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].gaityu_hokanbasyo;
               // newrow["現在在庫数(Micos)"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].gaityu_zaikosu;
               // //row["現在仕掛数"]
               // //row["在庫余裕分"]
               // newrow["社内保管場所"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].syanai_hokanbasyo;
               // newrow["社内在庫"] = GaityuZaikoDic[distinct_zairyou.zairyou_code].syanai_zaikosu;
               // //newrow["使用製品その個数"] = each_zairyo_siyousu;

               // Dictionary<string, zairyo_siyousu_data> domy = new Dictionary<string, zairyo_siyousu_data>();
               // domy.Add(each_zairyo_siyousu.siyou_seihin_code,each_zairyo_siyousu);

               //newrow["使用製品その個数"] =domy;
               

                return_Table.Rows.Add(newrow);
            }

           
            //"経費","品目ＣＤ","品名","保管場所","現在在庫数(Micos)","現在仕掛数", "在庫余裕分", "社内保管場所", "社内在庫", "使用製品その個数"

            return return_Table;
        }

        public void GaityuZaikoTableColAdd(DataTable GaityuTable)
        {
            //GaityuZaikoTableの列を作成
           　foreach (string col in GaityuuZaikoTable_col)
            {
                if (
                    col == "現在在庫数(Micos)" ||
                    col == "現在仕掛数" ||
                    col == "在庫余裕分" ||
                    col == "社内在庫"
                    )
                {
                    GaityuTable.Columns.Add(col, typeof(float));
                    continue;
                }
                if (
                    col == "使用製品その個数"
                    )
                {
                    GaityuTable.Columns.Add(col, typeof(Dictionary<string, zairyo_siyousu_data>));
                    continue;
                }
                else
                {
                    GaityuTable.Columns.Add(col, typeof(string));
                }
            }
        }

        public void GaityuZaikoTableColAdd_ver2(DataTable GaityuTable)
        {
            //GaityuZaikoTableの列を作成
           　foreach (string col in GaityuuZaikoTable_col_ver2)
            {
                if (
                    col == "材料情報"                     )
                {
                    GaityuTable.Columns.Add(col, typeof(zairyou));
                    continue;
                }
                if (
                    col == "保管場所情報"
                    )
                {
                    GaityuTable.Columns.Add(col, typeof(hokanbasyo_siyouseihin_data));
                    continue;
                }
                if (
                   col == "使用製品情報"
                   )
                {
                    GaityuTable.Columns.Add(col, typeof(Dictionary<string ,float>));
                    continue;
                }

            }
        }
    }
}
