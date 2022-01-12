using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;


namespace MicosController
{


    public partial class Form1 : Form
    {

        public string Micos_file_name = @"C:\Users\e33230-user3\OneDrive - hqhamamatsu.onmicrosoft.com\デスクトップ\PCPPC.hod";
        public string Micos_process_name = "acslaunch_win-64";
        public string username = "5460";
        public string Output_file_path = @"\\den3\IC\FROMAS400\5460";

        public long Micos_Open_Flag = 0;
        public long Micos_Enter_flag = 0;


        public string File_Name_default1 = "ICB0101_";
        public string File_Name_default2 = "MMB0032_";
        public string TheLatest_File_ICB = "";
        public string TheLatest_File_MMB = "";

        public int page_counter = 0; //製造管理者PCメニュー　＝　０

        public DataSet DS = new DataSet();
        public DataTable Component_Table_ICB = new DataTable("在庫リスト");
        public DataTable Component_Table_MMB = new DataTable("部品構成表");

        public Form2 form2;

       
        public void init_component_table_MMB()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TheLatest_File_MMB = openFileDialog1.FileName;
                TextFieldParser parser = new TextFieldParser(TheLatest_File_MMB, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り

                string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。行のカーソルは呼び出す度にインクリメント。
                DataRow row;

                for (int i = 0; i < column.Length; i++)  //列の名前を追加する。
                {
                    Component_Table_MMB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                    //Console.WriteLine(column[i]);
                }

                while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                {
                    string[] column_data = parser.ReadFields();

                    row = Component_Table_MMB.NewRow();
                    for (int i = 0; i < column.Length; i++)
                    {
                        row[i] = column[i];
                    }
                    Component_Table_MMB.Rows.Add(row);
                }

                DS.Tables.Add(Component_Table_MMB);
            }
        }

        public void init_component_table_ICB()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TheLatest_File_ICB = openFileDialog1.FileName;
                TextFieldParser parser = new TextFieldParser(TheLatest_File_ICB, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り

                string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。行のカーソルは呼び出す度にインクリメント。
                DataRow row;

                for (int i = 0; i < column.Length; i++)  //列の名前を追加する。
                {
                    Component_Table_ICB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                    Console.WriteLine(column[i]);
                }

                while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                {
                    string[] column_data = parser.ReadFields();

                    row = Component_Table_ICB.NewRow();
                    for (int i = 0; i < column.Length; i++)
                    {
                        row[i] = column[i];
                    }
                    Component_Table_ICB.Rows.Add(row);
                }

                DS.Tables.Add(Component_Table_ICB);
            }
        }

        public void init_component_table_fromCSV()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                TextFieldParser parser = new TextFieldParser(openFileDialog1.FileName, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り
                //parser.SetDelimiters("\t");                    // タブ区切り(TSVファイルの場合)

                    string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。

                    for (int i = 0; i < column.Length; i++)
                    {
                    Component_Table_ICB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                    Console.WriteLine(column[i]);
                    }
            }

            Console.Write(Component_Table_ICB.Columns);
        }




        public string[] ComponentList;

        public Form1()
        {
            InitializeComponent();

            Init_forms();
        }

        public void Init_forms()
        {
            panel_micos_setting.Visible = false;
            panel_micos_setting.Enabled = false;

            panel_buhin.Visible = false;
            panel_buhin.Enabled = false;

            //コンボボックス　デフォルト入力
            comboBox_buhin_hyouji.SelectedIndex = 1;
            comboBox_buhin_syubetu.SelectedIndex = 1;
            comboBox_buhin_tenkai.SelectedIndex = 1;

            //テキストボックス　デフォルト入力
            textBox_micos_filepath.Text = Micos_file_name;
            textBox_micosprocess.Text = Micos_process_name;
            textBox_username.Text = username;
            textBox_outputfilepath.Text = Output_file_path;

        }

        private void button_create_db_Click(object sender, EventArgs e)
        {
            Transport_Form2();
            form2.read_database_column();
        }
        private void OpenMicos_btn_Click(object sender, EventArgs e)
        {
            //もしMicosがすでに開いていたら一度消す。
            Close_MicosWindow();

            //Micosを開く。
            Open_Micos();

        }

        private void button_MicosSetting_Click(object sender, EventArgs e)
        {
            panel_micos_setting.Visible = true;
            panel_micos_setting.Enabled = true;
        }

        private void GetWindow_btn_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process p in
            System.Diagnostics.Process.GetProcesses())
            {
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.MainWindowTitle.Length != 0)
                {
                    Console.WriteLine("プロセス名:" + p.ProcessName);
                    Console.WriteLine("タイトル名:" + p.MainWindowTitle);
                }
            }
        }

        //micosのプロセス名を取得するとき用
        private void button_processname_Click(object sender, EventArgs e)
        {
            GetProcessName();
        }

        private void button_select_mmb_Click(object sender, EventArgs e)
        {
            init_component_table_MMB();
            textBox_selected_mmb.Text = TheLatest_File_MMB;
        }

        private void MicosController1_btn_Click(object sender, EventArgs e)
        {
            Activate_MicosWindow();

            if(Micos_Open_Flag == 0)
            {
                return;
            }

            EnterCommand_Micos(username);

            Export_ComponentData("33241","1","1","1");
            //Export_ZaikoData("1","1","33231","33242");

            //File_Exisist_Check(Output_file_path, 0);
            File_Exisist_Check(Output_file_path, 1);

        }

        private void CSV_Extract()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //label1.Text = openFileDialog1.FileName;

                TextFieldParser parser = new TextFieldParser(openFileDialog1.FileName, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り
                //parser.SetDelimiters("\t");                    // タブ区切り(TSVファイルの場合)

                while (parser.EndOfData == false)
                {
                    string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。

                    for (int i = 0; i < column.Length; i++)
                    {
                        //textBox1.Text += column[i] + "\r\n";
                        Console.WriteLine(column[i]);
                    }
                    //textBox1.Text += "===\r\n";
                }
            }
        }



        private void CSV_Search_Component_fromProduct(string filepath, long search_column_num, string search_string, long mode) //第一引数：csvファイルパス　第二引数：検索する列　第三引数：検索する文字列（製品コードとか）
        {
            TextFieldParser parser = new TextFieldParser(filepath, Encoding.GetEncoding("Shift_JIS"));

            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            DataRow row;

            while(parser.EndOfData == false)
            {
                string[] column = parser.ReadFields();
                
                if (column[search_column_num] == search_string)
                {
                    row = Component_Table_ICB.NewRow();
                    for(int i = 0; i < column.Length; i++)
                    {
                        row[i] = column[i];
                    }
                    Component_Table_ICB.Rows.Add(row);
                }
            }

        }

        async private void File_Exisist_Check(string filepath,long mode)
        {
            DateTime dt = DateTime.Now;
            DateTime dt1 = dt.AddMinutes(1);
            DateTime dt2 = dt.AddMinutes(2);

            string dt_string = dt.ToString("yyyyMMddHHmm");
            string dt1_string = dt1.ToString("yyyyMMddHHmm");
            string dt2_string = dt2.ToString("yyyyMMddHHmm");

            string filename = "";
            string filename1 = "";
            string filename2 = "";

            string[] files;
            string[] files1;
            string[] files2;

            switch (mode)
            {
                case (0):
                    filename += File_Name_default1 + dt_string;
                    filename1 += File_Name_default1 + dt1_string;
                    filename2 += File_Name_default1 + dt2_string;

                    for (int i = 0; i < 180; i++) //180秒間ファイルが生成されているかどうか監視する。
                    {
                        files = Directory.GetFiles(filepath, filename + "??.CSV");

                        if (files.Length > 0)
                        {                     //getfilesが存在するかどうかの判定は配列の長さ>０で判定。array[0]==""では判定できない。
                            TheLatest_File_ICB += files[0];
                            MessageBox.Show(TheLatest_File_ICB + "を取得しました。");
                            break;
                        }

                        files1 = Directory.GetFiles(filepath, filename1 + "??.CSV");

                        if (files1.Length > 0)
                        {
                            TheLatest_File_ICB += files1[0];
                            MessageBox.Show(TheLatest_File_ICB + "を取得しました。");
                            break;
                        }

                        files2 = Directory.GetFiles(filepath, filename2 + "??.CSV");

                        if (files2.Length > 0)
                        {
                            TheLatest_File_ICB += files2[0];
                            MessageBox.Show(TheLatest_File_ICB + "を取得しました。");
                            break;
                        }

                        if (i == 179) { MessageBox.Show("ファイルが生成されていません。"); }
                        await Task.Delay(1000);
                    }
                    break;

                case (1):
                    filename += File_Name_default2 + dt_string;
                    filename1 += File_Name_default2 + dt1_string;
                    filename2 += File_Name_default2 + dt2_string;

                    for (int i = 0; i < 180; i++) //180秒間ファイルが生成されているかどうか監視する。
                    {
                        files = Directory.GetFiles(filepath, filename + "??.CSV");

                        if (files.Length > 0)//getfilesが存在するかどうかの判定は配列の長さ>０で判定。array[0]==""では判定できない。
                        {                     
                            TheLatest_File_MMB += files[0];
                            MessageBox.Show(TheLatest_File_MMB + "を取得しました。");
                            break;
                        }

                        files1 = Directory.GetFiles(filepath, filename1 + "??.CSV");

                        if (files1.Length > 0)
                        {
                            TheLatest_File_MMB += files1[0];
                            MessageBox.Show(TheLatest_File_MMB + "を取得しました。");
                            break;
                        }

                        files2 = Directory.GetFiles(filepath, filename2 + "??.CSV");

                        if (files2.Length > 0)
                        {
                            TheLatest_File_MMB += files2[0];
                            MessageBox.Show(TheLatest_File_MMB + "を取得しました。");
                            break;
                        }

                        if (i == 179) { MessageBox.Show("ファイルが生成されていません。"); }
                        await Task.Delay(1000);
                    }
                    break;
            }
        }

        private void Export_ComponentData(string keihikubun, string syubetsu, string tenkai, string hyouji)
        {
            if(keihikubun.Length != 5 || syubetsu.Length != 1 || tenkai.Length != 1 || hyouji.Length != 1)
            {
                MessageBox.Show("Micosコマンドの文字数が正しくありません。");
                return;
            }

            if(page_counter> 0)
            {
                for(int i = 0; i < page_counter; i++)
                {
                    SendKeys.SendWait("{F3}");
                }
            }


            SendKeys.SendWait("61");
            SendKeys.SendWait("{ENTER}");
            page_counter++;

            SendKeys.SendWait("9");
            SendKeys.SendWait("{ENTER}");
            page_counter++;


            SendKeys.SendWait(keihikubun + syubetsu + tenkai + hyouji);
            SendKeys.SendWait("{ENTER}");

            SendKeys.SendWait("{ENTER}");
        }

        private void Export_ZaikoData(string syuturyoku, string syukei, string keihi_l, string keihi_r)
        {
            if (syuturyoku.Length != 1 || syukei.Length != 1 || keihi_l.Length != 5 || keihi_r.Length != 5)
            {
                MessageBox.Show("Micosコマンドの文字数が正しくありません。");
                return;
            }


            if (page_counter > 0)
            {
                for (int i = 0; i < page_counter; i++)
                {
                    SendKeys.SendWait("{F3}");
                }
            }

            SendKeys.SendWait("11");
            SendKeys.SendWait("{ENTER}");
            page_counter++;

            SendKeys.SendWait("21");
            SendKeys.SendWait("{ENTER}");
            page_counter++;


            SendKeys.SendWait(syuturyoku + syukei + keihi_l + keihi_r);
            SendKeys.SendWait("{ENTER}");

            SendKeys.SendWait("{ENTER}");

        }





        private void EnterCommand_Micos(string username)
        {
            if(Micos_Enter_flag == 0)
            {
                SendKeys.SendWait("{F3}");

                SendKeys.SendWait(username);
                SendKeys.SendWait(username);

                SendKeys.SendWait("{ENTER}");

                Micos_Enter_flag = 1;
            }
        }

        private void GetProcessName()
        {
            string messagebox = "";

            foreach (System.Diagnostics.Process p in
            System.Diagnostics.Process.GetProcesses())
            {
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.MainWindowTitle.Length != 0)
                {
                    messagebox += ("プロセス名:" + p.ProcessName + "\n");
                    messagebox += ("タイトル名:" + p.MainWindowTitle + "\n");
                }
            }

            MessageBox.Show(messagebox);
        }

        private void Activate_MicosWindow()
        {
            //micosのプロセスを探す
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(Micos_process_name);
            if (0 < ps.Length)
            {
                //見つかった時は、アクティブにする
                Microsoft.VisualBasic.Interaction.AppActivate(ps[0].Id);
            }
            else
            {
                MessageBox.Show("Micosが開かれていません。");
                Micos_Open_Flag = 0;
            }
        }

        private void Close_MicosWindow()
        {
            //すでにmicosが開いていないかチェックして、開いていたら消す。
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(Micos_process_name);
            if (0 < ps.Length)
            {
                //見つかった時は消す。
                //ps[0].Close();
                ps[0].Kill();
            }
        }

        private void Open_Micos()
        {
            //micosを開く。
            Process pt = new Process();
            //ps.StartInfo.FileName = @"C:\Users\e33230-user3\OneDrive - hqhamamatsu.onmicrosoft.com\デスクトップ\PCPPC.hod";
            pt.StartInfo.FileName = Micos_file_name;
            pt.Start();

            Micos_Open_Flag = 1;
        }

        public void Transport_Form2()
        {
            form2 = new Form2();
            form2.Show();
            form2.Component_Table_ICB = Component_Table_ICB;
            form2.Component_Table_MMB = Component_Table_MMB;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CSV_Extract();
        }

        private void button_debug_Click(object sender, EventArgs e)
        {
           // init_component_table();
            init_component_table_fromCSV();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CSV_Search_Component_fromProduct(openFileDialog1.FileName,1,textBox_dbug.Text,0);
                Console.WriteLine(openFileDialog1.FileName);
            }

            foreach (DataRow row in Component_Table_ICB.Rows)
            {
                foreach(DataColumn column in Component_Table_ICB.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
            Console.WriteLine(Component_Table_ICB.Rows[1][1].ToString());

        }


    }
}
