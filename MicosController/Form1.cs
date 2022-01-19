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
        public string Micos_Window_Title = "A - 5250 ディスプレイ";
        public string username = "5460";
        public string Output_file_path = @"\\den3\IC\FROMAS400\5460";

        public bool Micos_Setting_flag = false;
        public long Micos_Open_Flag = 0;
        public long Micos_Enter_flag = 0;
        public long File_Creaging_flag = 0;


        public string File_Name_default1 = "ICB0101_";
        public string File_Name_default2 = "MMB0032_";
        public string TheLatest_File_ICB = "";
        public string TheLatest_File_MMB = "";
        public string[] TheLatest_Multi_File_ICB;
        public string[] TheLatest_Multi_File_MMB;

        //Micosコマンド用変数
        //部品構成表出力のとき
        public string keihikubun = "33241";
        public string syubetu = "1";
        public string tenkai = "1";
        public string hyouji = "1";
        //在庫データ出力のとき
        public string syuturyoku = "1";
        public string syuukei = "1";
        public string keihi_l = "33231";
        public string keihi_r = "33243";

        public int page_counter = 0; //製造管理者PCメニュー　＝　０

        public DataSet DS = new DataSet();
        public DataTable Component_Table_ICB = new DataTable("在庫リスト");
        public DataTable Component_Table_MMB = new DataTable("部品構成表");

        //複数ファイル読み込むときに一番初めのファイルから列名を読み込む。
        public bool first_file_flag = true;

        public Form2 form2;
        public Tanaoroshi tanaoroshi_form;
        public 部品在庫管理 buhinzaikokanri_form;



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
            read_default();
            Init_forms();
        }

        public void read_default()
        {
            username = Properties.Settings.Default.username;
            Micos_file_name = Properties.Settings.Default.MicosFile_Path;
            Micos_process_name = Properties.Settings.Default.Micos_ProcessName;
            Micos_Window_Title = Properties.Settings.Default.Micos_WindowName;
            Output_file_path = Properties.Settings.Default.Micos_OutPutPath;

        }
        public void Init_forms()
        {
            panel_micos_setting.Visible = false;
            panel_micos_setting.Enabled = false;

            panel_buhin.Visible = false;
            panel_buhin.Enabled = false;

            panel_zaikoout_setting.Visible = false;
            panel_zaikoout_setting.Enabled = false;

            //コンボボックス　デフォルト入力
            comboBox_buhin_hyouji.SelectedIndex = 1;
            comboBox_buhin_syubetu.SelectedIndex = 1;
            comboBox_buhin_tenkai.SelectedIndex = 1;

            //テキストボックス　デフォルト入力
            textBox_micos_filepath.Text = Micos_file_name;
            textBox_micosprocess.Text = Micos_process_name;
            textBox_MicosWindow.Text = Micos_Window_Title;
            textBox_username.Text = username;
            textBox_outputfilepath.Text = Output_file_path;

            //部品構成票出力　デフォルト入力
            textBox_buhin_keihikubun.Text = keihikubun;
            comboBox_buhin_syubetu.SelectedItem = syubetu;
            comboBox_buhin_tenkai.SelectedItem = tenkai;
            comboBox_buhin_hyouji.SelectedItem = hyouji;

            //在庫出力設定　デフォルト入力
            comboBox_syuturyoku.SelectedItem = syuturyoku;
            comboBox_syuukei.SelectedItem = syuukei;
            textBox_keihi_l.Text = keihi_l;
            textBox_keihi_r.Text = keihi_r;

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





        /// <summary>
        /// ボタンクリック系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMicos_btn_Click(object sender, EventArgs e)
        {
            //もしMicosがすでに開いていたら一度消す。
            Close_MicosWindow();

            //Micosを開く。
            Open_Micos();

        }
        private void btn_ZaikoOut_Click(object sender, EventArgs e)
        {


            if (File_Creaging_flag == 1)
            {
                return;
            }

            Activate_MicosWindow();

            if (Micos_Open_Flag == 0)
            {
                return;
            }

            OpenMicos_btn.Enabled = false;
            btn_ZaikoOut.Enabled = false;
            btn_ComponentOut.Enabled = false;


            EnterCommand_Micos(username);

            Export_ZaikoData(syuturyoku, syuukei, keihi_l, keihi_r);

            File_Exisist_Check(Output_file_path, 0);


        }

        private void btn_ComponentOut_Click(object sender, EventArgs e)
        {


            if (File_Creaging_flag == 1)
            {
                return;
            }

            Activate_MicosWindow();
            if (Micos_Open_Flag == 0)
            {
                return;
            }

            OpenMicos_btn.Enabled = false;
            btn_ZaikoOut.Enabled = false;
            btn_ComponentOut.Enabled = false;



            EnterCommand_Micos(username);

            Export_ComponentData(keihikubun, syubetu, tenkai, hyouji);

            File_Exisist_Check(Output_file_path, 1);


        }


        /// <summary>
        /// パネルを開くクリック
        /// </summary>
        private void button_buhin_setting_Click(object sender, EventArgs e)
        {
            panel_buhin.Visible = true;
            panel_buhin.Enabled = true;
        }
        private void button_zaikoout_setting_Click(object sender, EventArgs e)
        {
            panel_zaikoout_setting.Visible = true;
            panel_zaikoout_setting.Enabled = true;
        }
        private void button_MicosSetting_Click(object sender, EventArgs e)
        {
            panel_micos_setting.Visible = true;
            panel_micos_setting.Enabled = true;
        }

        /// <summary>
        ///パネルを閉じるクリック
        /// </summary>
        private void button_close_micossetting_Click(object sender, EventArgs e)
        {
            panel_micos_setting.Enabled = false;
            panel_micos_setting.Visible = false;
        }
        private void button_close_buhin_setting_Click(object sender, EventArgs e)
        {
            panel_buhin.Enabled = false;
            panel_buhin.Visible = false;
        }
        private void button_close_zaiko_setting_Click(object sender, EventArgs e)
        {
            panel_zaikoout_setting.Visible = false;
            panel_zaikoout_setting.Enabled = false;
        }

        /// <summary>
        /// 設定を反映クリック
        /// </summary>
        private void button_micossetting_on_Click(object sender, EventArgs e)
        {
            Micos_file_name = textBox_micos_filepath.Text;
            Output_file_path = textBox_outputfilepath.Text;
            username = textBox_username.Text;
            Micos_process_name = textBox_micosprocess.Text;
            Micos_Window_Title = textBox_MicosWindow.Text;

            Micos_Setting_flag = true;
        }
        private void button_buhinsetting_on_Click(object sender, EventArgs e)
        {
            keihikubun = textBox_buhin_keihikubun.Text;
            syubetu = comboBox_buhin_syubetu.SelectedItem.ToString();
            tenkai = comboBox_buhin_tenkai.SelectedItem.ToString();
            hyouji = comboBox_buhin_hyouji.SelectedItem.ToString();
        }
        private void button_zaikosetting_on_Click(object sender, EventArgs e)
        {
            syuturyoku = comboBox_syuturyoku.SelectedItem.ToString();
            syuukei = comboBox_syuukei.SelectedItem.ToString();
            keihi_l = textBox_keihi_l.Text;
            keihi_r = textBox_keihi_r.Text;
        }

       /// <summary>
       /// プロセス名取得ボタン
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_processname_Click(object sender, EventArgs e)
        {
            GetProcessName();
        }

        /// <summary>
        /// データベース作成用ファイル選択ボタン
        /// </summary>
        /// 
        private void button_select_mmb_Click(object sender, EventArgs e)
        {
            //init_component_table_MMB();
            //textBox_selected_mmb.Text = TheLatest_File_MMB;
            init_conponent_table_multi_MMB();
            
        }

        private void button_select_ICB_Click(object sender, EventArgs e)
        {
            //init_component_table_ICB();
            //textBox_selected_ICB.Text = TheLatest_File_ICB;
            init_component_table_multi_ICB();
           
        }
        /// <summary>
        /// 別フォームを開くクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_db_Click(object sender, EventArgs e)
        {
            Transport_Form2();
            form2.read_database_column();
        }

        private void button_TANAOROSHI_Click(object sender, EventArgs e)
        {
            Transport_tanaoroshi_form();

        }

        private void button_buhinzaikokanri_Click(object sender, EventArgs e)
        {
            Transport_ZaikoKanri_form();
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

        async private void File_Exisist_Check(string filepath,long mode) //出力ファイルができるまで作成されたか確認する。mode = 0（ICBファイル（在庫）のチェック） mode = 1(MMBファイル(部品構成)のチェック)
        {
            File_Creaging_flag = 1;

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
                            File_Creaging_flag = 0;
                            break;
                        }

                        files1 = Directory.GetFiles(filepath, filename1 + "??.CSV");

                        if (files1.Length > 0)
                        {
                            TheLatest_File_ICB += files1[0];
                            MessageBox.Show(TheLatest_File_ICB + "を取得しました。");
                            File_Creaging_flag = 0;
                            break;
                        }

                        files2 = Directory.GetFiles(filepath, filename2 + "??.CSV");

                        if (files2.Length > 0)
                        {
                            TheLatest_File_ICB += files2[0];
                            MessageBox.Show(TheLatest_File_ICB + "を取得しました。");
                            File_Creaging_flag = 0;
                            break;
                        }

                        if (i == 179) { MessageBox.Show("ファイルが生成されていません。"); } //180秒間監視してファイル出なかったら終わり。
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
                            File_Creaging_flag = 0;
                            break;
                        }

                        files1 = Directory.GetFiles(filepath, filename1 + "??.CSV");

                        if (files1.Length > 0)
                        {
                            TheLatest_File_MMB += files1[0];
                            MessageBox.Show(TheLatest_File_MMB + "を取得しました。");
                            File_Creaging_flag = 0;
                            break;
                        }

                        files2 = Directory.GetFiles(filepath, filename2 + "??.CSV");

                        if (files2.Length > 0)
                        {
                            TheLatest_File_MMB += files2[0];
                            MessageBox.Show(TheLatest_File_MMB + "を取得しました。");
                            File_Creaging_flag = 0;
                            break;
                        }

                        if (i == 179) { MessageBox.Show("ファイルが生成されていません。"); File_Creaging_flag = 0; }
                        await Task.Delay(1000);
                    }
                    break;
            }

            OpenMicos_btn.Enabled = true;
            btn_ZaikoOut.Enabled = true;
            btn_ComponentOut.Enabled = true;
        }

        /// <summary>
        /// Micos操作メソッドたち
        /// </summary>
        /// <param name="keihikubun"></param>
        /// <param name="syubetsu"></param>
        /// <param name="tenkai"></param>
        /// <param name="hyouji"></param>
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
            Console.Write(messagebox);
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
            Micos_Enter_flag = 0;
            page_counter = 0;

            Detect_Micos_On_Window(Micos_Window_Title);
        }

        async private void Detect_Micos_On_Window(string Micos_Window_Title) //0.1秒毎に100回（合計10秒）Micosのスタートウインドウがあるか確認する。
        {
            for (int i = 0; i < 100; i++)
            {
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                {
                    if (p.MainWindowTitle == Micos_Window_Title)
                    {
                        this.Activate();
                        MessageBox.Show("Micosがスタート画面になっているのを確認してください。");
                        return;
                    }
                }
                await Task.Delay(100);
            }
            this.Activate();
            MessageBox.Show("Micosのスタート画面が認識されません。");

        }

        /// <summary>
        /// データベース関連
        /// </summary>
        public void Transport_Form2()//データベース用フォームを開く
        {
            form2 = new Form2();
            form2.Show();
            form2.Component_Table_ICB = Component_Table_ICB;
            form2.Component_Table_MMB = Component_Table_MMB;
        }
        public void init_component_table_MMB() //シングルMMB（部品構成票）ファイル読み込み
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
                    for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                    {
                        row[i] = column_data[i];
                    }
                    Component_Table_MMB.Rows.Add(row);
                }

                DS.Tables.Add(Component_Table_MMB);
            }
        }

        public void init_component_table_ICB() //シングルICB（在庫リスト）ファイル読み込み。列名["現在在庫数"]のみfloat型
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

                    if (column[i] == "現在在庫数") // 10列目：現在在庫数
                    {
                        Component_Table_ICB.Columns.Add(column[i], typeof(float)); //現在在庫数だけint型
                    }
                    else
                    {
                        Component_Table_ICB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                    }
                }

                while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                {
                    string[] column_data = parser.ReadFields();

                    row = Component_Table_ICB.NewRow();
                    for (int i = 0; i < column.Length - 1; i++)
                    {
                        if (i == 10)
                        {
                            row[i] = float.Parse(column_data[i]);
                        }
                        else
                        {
                            row[i] = column_data[i];
                        }

                    }
                    Component_Table_ICB.Rows.Add(row);
                }

                DS.Tables.Add(Component_Table_ICB);
            }
        }

        public void init_conponent_table_multi_MMB()　//複数MMB（部品構成票）ファイル読み込み
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename_mmb in openFileDialog1.FileNames)
                {


                    TextFieldParser parser = new TextFieldParser(filename_mmb, Encoding.GetEncoding("Shift_JIS")); //第一引数：開きたいcsvファイルパス、第二引数：エンコード
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");// ","区切り


                    string[] column = parser.ReadFields();    //一行ずつcolumnに配列で格納されるっぽい。行のカーソルは呼び出す度にインクリメント。
                    DataRow row;

                    if (first_file_flag) //一つ目のファイルのときだけ列の名前を取得する。
                    {
                        for (int i = 0; i < column.Length; i++)  //列の名前を追加する。
                        {
                            if (column[i]=="数量")
                            {
                                Component_Table_MMB.Columns.Add(column[i], typeof(float));
                            }
                            else
                            {
                                Component_Table_MMB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                            }
                           
                                                                                        
                        }

                        first_file_flag = false;
                    }


                    while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                    {
                        string[] column_data = parser.ReadFields();

                        row = Component_Table_MMB.NewRow();
                        for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                        {
                            row[i] = column_data[i];
                        }
                        Component_Table_MMB.Rows.Add(row);
                    }

                    textBox_selected_mmb.AppendText(filename_mmb+" , ");
                }
                DS.Tables.Add(Component_Table_MMB);
                first_file_flag = true;
            }
        }

        public void init_component_table_multi_ICB() //複数ICB（在庫リスト）ファイル読み込み。列名["現在在庫数"] のみfloat型
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

                            if (column[i] == "現在在庫数") // 10列目：現在在庫数
                            {
                                Component_Table_ICB.Columns.Add(column[i], typeof(float)); //現在在庫数だけint型
                            }
                            else
                            {
                                Component_Table_ICB.Columns.Add(column[i], typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                            }
                        }

                        first_file_flag = false;
                    }


                    while (parser.EndOfData == false)       //2行目以降のデータをﾃｰﾌﾞﾙに格納していく。
                    {
                        string[] column_data = parser.ReadFields();

                        row = Component_Table_ICB.NewRow();
                        for (int i = 0; i < column.Length - 1; i++) //MMBファイルの方は一番右の列が列名だけ用意されて要素が存在しないので、-1してある。
                        {
                            row[i] = column_data[i];
                        }
                        Component_Table_ICB.Rows.Add(row);
                    }
                    textBox_selected_ICB.AppendText(filename_icb + " , ");
                }
                DS.Tables.Add(Component_Table_ICB);
                first_file_flag = true;
            }
        }

        /// <summary>
        /// 棚卸関連
        /// </summary>
        public void Transport_tanaoroshi_form()
        {
            tanaoroshi_form = new Tanaoroshi();
            tanaoroshi_form.Show();

            //Micos関連変数代入。
            tanaoroshi_form.username = username;
            tanaoroshi_form.Micos_file_name = Micos_file_name;
            tanaoroshi_form.Micos_process_name = Micos_process_name;
            tanaoroshi_form.Micos_Window_Title = Micos_Window_Title;
        }

        public void Transport_ZaikoKanri_form()
        {
            buhinzaikokanri_form = new 部品在庫管理();
            buhinzaikokanri_form.Show();

            buhinzaikokanri_form.Zaiko_Data_Original_Table=Component_Table_ICB;
            buhinzaikokanri_form.Component_Data_Original_Table = Component_Table_MMB;

            buhinzaikokanri_form.init_Zaiko_Data_Display_Table();


        }
        /// <summary>
        /// 設定変更したときに、変更値を保存する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Micos_Setting_flag)
            {
                DialogResult result = MessageBox.Show("変更したユーザー情報を保存しますか？", "ユーザーデータの更新", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.username = username;
                    Properties.Settings.Default.MicosFile_Path = Micos_file_name;
                    Properties.Settings.Default.Micos_ProcessName = Micos_process_name;
                    Properties.Settings.Default.Micos_WindowName = Micos_Window_Title;
                    Properties.Settings.Default.Micos_OutPutPath = Output_file_path;

                    Properties.Settings.Default.Save();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
        }


    }
}
