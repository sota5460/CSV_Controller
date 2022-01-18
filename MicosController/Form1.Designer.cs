
namespace MicosController
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenMicos_btn = new System.Windows.Forms.Button();
            this.btn_ZaikoOut = new System.Windows.Forms.Button();
            this.btn_ComponentOut = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.panel_micos_setting = new System.Windows.Forms.Panel();
            this.textBox_MicosWindow = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.button_micossetting_on = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button_processname = new System.Windows.Forms.Button();
            this.textBox_micosprocess = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_micos_filepath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_close_micossetting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_outputfilepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_buhin = new System.Windows.Forms.Panel();
            this.button_buhinsetting_on = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button_close_buhin_setting = new System.Windows.Forms.Button();
            this.comboBox_buhin_syubetu = new System.Windows.Forms.ComboBox();
            this.comboBox_buhin_tenkai = new System.Windows.Forms.ComboBox();
            this.comboBox_buhin_hyouji = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_buhin_keihikubun = new System.Windows.Forms.TextBox();
            this.button_MicosSetting = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_zaikoout_setting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_TANAOROSHI = new System.Windows.Forms.Button();
            this.button_create_db_zaiko = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_selected_ICB = new System.Windows.Forms.TextBox();
            this.textBox_selected_mmb = new System.Windows.Forms.TextBox();
            this.button_select_ICB = new System.Windows.Forms.Button();
            this.button_select_mmb = new System.Windows.Forms.Button();
            this.button_create_db = new System.Windows.Forms.Button();
            this.button_buhin_setting = new System.Windows.Forms.Button();
            this.panel_zaikoout_setting = new System.Windows.Forms.Panel();
            this.button_zaikosetting_on = new System.Windows.Forms.Button();
            this.button_close_zaiko_setting = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_keihi_r = new System.Windows.Forms.TextBox();
            this.textBox_keihi_l = new System.Windows.Forms.TextBox();
            this.comboBox_syuukei = new System.Windows.Forms.ComboBox();
            this.comboBox_syuturyoku = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel_micos_setting.SuspendLayout();
            this.panel_buhin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_zaikoout_setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenMicos_btn
            // 
            this.OpenMicos_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OpenMicos_btn.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OpenMicos_btn.Location = new System.Drawing.Point(27, 32);
            this.OpenMicos_btn.Name = "OpenMicos_btn";
            this.OpenMicos_btn.Size = new System.Drawing.Size(155, 43);
            this.OpenMicos_btn.TabIndex = 0;
            this.OpenMicos_btn.Text = "Micosを起動";
            this.OpenMicos_btn.UseVisualStyleBackColor = false;
            this.OpenMicos_btn.Click += new System.EventHandler(this.OpenMicos_btn_Click);
            // 
            // btn_ZaikoOut
            // 
            this.btn_ZaikoOut.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_ZaikoOut.Location = new System.Drawing.Point(27, 91);
            this.btn_ZaikoOut.Name = "btn_ZaikoOut";
            this.btn_ZaikoOut.Size = new System.Drawing.Size(261, 40);
            this.btn_ZaikoOut.TabIndex = 2;
            this.btn_ZaikoOut.Text = "在庫データを出力(ICBファイル)";
            this.btn_ZaikoOut.UseVisualStyleBackColor = true;
            this.btn_ZaikoOut.Click += new System.EventHandler(this.btn_ZaikoOut_Click);
            // 
            // btn_ComponentOut
            // 
            this.btn_ComponentOut.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_ComponentOut.Location = new System.Drawing.Point(27, 137);
            this.btn_ComponentOut.Name = "btn_ComponentOut";
            this.btn_ComponentOut.Size = new System.Drawing.Size(261, 44);
            this.btn_ComponentOut.TabIndex = 3;
            this.btn_ComponentOut.Text = "部品構成表を出力（MMB ファイル）";
            this.btn_ComponentOut.UseVisualStyleBackColor = true;
            this.btn_ComponentOut.Click += new System.EventHandler(this.btn_ComponentOut_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(208, 135);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 19);
            this.textBox_username.TabIndex = 4;
            // 
            // panel_micos_setting
            // 
            this.panel_micos_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_micos_setting.Controls.Add(this.textBox_MicosWindow);
            this.panel_micos_setting.Controls.Add(this.label22);
            this.panel_micos_setting.Controls.Add(this.button_micossetting_on);
            this.panel_micos_setting.Controls.Add(this.label12);
            this.panel_micos_setting.Controls.Add(this.button_processname);
            this.panel_micos_setting.Controls.Add(this.textBox_micosprocess);
            this.panel_micos_setting.Controls.Add(this.label11);
            this.panel_micos_setting.Controls.Add(this.textBox_micos_filepath);
            this.panel_micos_setting.Controls.Add(this.label10);
            this.panel_micos_setting.Controls.Add(this.button_close_micossetting);
            this.panel_micos_setting.Controls.Add(this.label2);
            this.panel_micos_setting.Controls.Add(this.textBox_outputfilepath);
            this.panel_micos_setting.Controls.Add(this.label1);
            this.panel_micos_setting.Controls.Add(this.textBox_username);
            this.panel_micos_setting.Location = new System.Drawing.Point(488, 16);
            this.panel_micos_setting.Name = "panel_micos_setting";
            this.panel_micos_setting.Size = new System.Drawing.Size(322, 226);
            this.panel_micos_setting.TabIndex = 5;
            // 
            // textBox_MicosWindow
            // 
            this.textBox_MicosWindow.Location = new System.Drawing.Point(208, 104);
            this.textBox_MicosWindow.Name = "textBox_MicosWindow";
            this.textBox_MicosWindow.Size = new System.Drawing.Size(100, 19);
            this.textBox_MicosWindow.TabIndex = 33;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label22.Location = new System.Drawing.Point(6, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 15);
            this.label22.TabIndex = 32;
            this.label22.Text = "Micosウインドウ名";
            // 
            // button_micossetting_on
            // 
            this.button_micossetting_on.Location = new System.Drawing.Point(155, 188);
            this.button_micossetting_on.Name = "button_micossetting_on";
            this.button_micossetting_on.Size = new System.Drawing.Size(75, 23);
            this.button_micossetting_on.TabIndex = 31;
            this.button_micossetting_on.Text = "設定を反映";
            this.button_micossetting_on.UseVisualStyleBackColor = true;
            this.button_micossetting_on.Click += new System.EventHandler(this.button_micossetting_on_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(16, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "Micosの詳細設定";
            // 
            // button_processname
            // 
            this.button_processname.Location = new System.Drawing.Point(118, 79);
            this.button_processname.Name = "button_processname";
            this.button_processname.Size = new System.Drawing.Size(84, 23);
            this.button_processname.TabIndex = 7;
            this.button_processname.Text = "プロセス取得";
            this.button_processname.UseVisualStyleBackColor = true;
            this.button_processname.Click += new System.EventHandler(this.button_processname_Click);
            // 
            // textBox_micosprocess
            // 
            this.textBox_micosprocess.Location = new System.Drawing.Point(208, 79);
            this.textBox_micosprocess.Name = "textBox_micosprocess";
            this.textBox_micosprocess.Size = new System.Drawing.Size(100, 19);
            this.textBox_micosprocess.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(8, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Micosプロセス名";
            // 
            // textBox_micos_filepath
            // 
            this.textBox_micos_filepath.Location = new System.Drawing.Point(208, 52);
            this.textBox_micos_filepath.Name = "textBox_micos_filepath";
            this.textBox_micos_filepath.Size = new System.Drawing.Size(100, 19);
            this.textBox_micos_filepath.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(10, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Micos実行ファイルパス";
            // 
            // button_close_micossetting
            // 
            this.button_close_micossetting.Location = new System.Drawing.Point(236, 188);
            this.button_close_micossetting.Name = "button_close_micossetting";
            this.button_close_micossetting.Size = new System.Drawing.Size(75, 23);
            this.button_close_micossetting.TabIndex = 19;
            this.button_close_micossetting.Text = "閉じる";
            this.button_close_micossetting.UseVisualStyleBackColor = true;
            this.button_close_micossetting.Click += new System.EventHandler(this.button_close_micossetting_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(8, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "出力ファイルパス";
            // 
            // textBox_outputfilepath
            // 
            this.textBox_outputfilepath.Location = new System.Drawing.Point(208, 163);
            this.textBox_outputfilepath.Name = "textBox_outputfilepath";
            this.textBox_outputfilepath.Size = new System.Drawing.Size(100, 19);
            this.textBox_outputfilepath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(8, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName";
            // 
            // panel_buhin
            // 
            this.panel_buhin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_buhin.Controls.Add(this.button_buhinsetting_on);
            this.panel_buhin.Controls.Add(this.label13);
            this.panel_buhin.Controls.Add(this.button_close_buhin_setting);
            this.panel_buhin.Controls.Add(this.comboBox_buhin_syubetu);
            this.panel_buhin.Controls.Add(this.comboBox_buhin_tenkai);
            this.panel_buhin.Controls.Add(this.comboBox_buhin_hyouji);
            this.panel_buhin.Controls.Add(this.label9);
            this.panel_buhin.Controls.Add(this.label8);
            this.panel_buhin.Controls.Add(this.label7);
            this.panel_buhin.Controls.Add(this.label6);
            this.panel_buhin.Controls.Add(this.label5);
            this.panel_buhin.Controls.Add(this.label4);
            this.panel_buhin.Controls.Add(this.label3);
            this.panel_buhin.Controls.Add(this.textBox_buhin_keihikubun);
            this.panel_buhin.Location = new System.Drawing.Point(27, 258);
            this.panel_buhin.Name = "panel_buhin";
            this.panel_buhin.Size = new System.Drawing.Size(447, 180);
            this.panel_buhin.TabIndex = 6;
            // 
            // button_buhinsetting_on
            // 
            this.button_buhinsetting_on.Location = new System.Drawing.Point(278, 152);
            this.button_buhinsetting_on.Name = "button_buhinsetting_on";
            this.button_buhinsetting_on.Size = new System.Drawing.Size(75, 23);
            this.button_buhinsetting_on.TabIndex = 32;
            this.button_buhinsetting_on.Text = "設定を反映";
            this.button_buhinsetting_on.UseVisualStyleBackColor = true;
            this.button_buhinsetting_on.Click += new System.EventHandler(this.button_buhinsetting_on_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(3, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 16);
            this.label13.TabIndex = 31;
            this.label13.Text = "部品構成表設定";
            // 
            // button_close_buhin_setting
            // 
            this.button_close_buhin_setting.Location = new System.Drawing.Point(359, 152);
            this.button_close_buhin_setting.Name = "button_close_buhin_setting";
            this.button_close_buhin_setting.Size = new System.Drawing.Size(75, 23);
            this.button_close_buhin_setting.TabIndex = 7;
            this.button_close_buhin_setting.Text = "閉じる";
            this.button_close_buhin_setting.UseVisualStyleBackColor = true;
            this.button_close_buhin_setting.Click += new System.EventHandler(this.button_close_buhin_setting_Click);
            // 
            // comboBox_buhin_syubetu
            // 
            this.comboBox_buhin_syubetu.FormattingEnabled = true;
            this.comboBox_buhin_syubetu.Items.AddRange(new object[] {
            "1",
            "Z",
            "O",
            "W"});
            this.comboBox_buhin_syubetu.Location = new System.Drawing.Point(144, 68);
            this.comboBox_buhin_syubetu.Name = "comboBox_buhin_syubetu";
            this.comboBox_buhin_syubetu.Size = new System.Drawing.Size(43, 20);
            this.comboBox_buhin_syubetu.TabIndex = 18;
            // 
            // comboBox_buhin_tenkai
            // 
            this.comboBox_buhin_tenkai.FormattingEnabled = true;
            this.comboBox_buhin_tenkai.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox_buhin_tenkai.Location = new System.Drawing.Point(144, 94);
            this.comboBox_buhin_tenkai.Name = "comboBox_buhin_tenkai";
            this.comboBox_buhin_tenkai.Size = new System.Drawing.Size(43, 20);
            this.comboBox_buhin_tenkai.TabIndex = 17;
            // 
            // comboBox_buhin_hyouji
            // 
            this.comboBox_buhin_hyouji.FormattingEnabled = true;
            this.comboBox_buhin_hyouji.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox_buhin_hyouji.Location = new System.Drawing.Point(144, 120);
            this.comboBox_buhin_hyouji.Name = "comboBox_buhin_hyouji";
            this.comboBox_buhin_hyouji.Size = new System.Drawing.Size(43, 20);
            this.comboBox_buhin_hyouji.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(218, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "1:全レベル　2:単一レベル";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(218, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "1:正展開　2:逆展開";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(219, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "1:製品 Z:加工部品 O:材料 W:硝子製品";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(16, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "表示レベル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(16, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "展開方法";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "種別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "経費区分";
            // 
            // textBox_buhin_keihikubun
            // 
            this.textBox_buhin_keihikubun.Location = new System.Drawing.Point(110, 43);
            this.textBox_buhin_keihikubun.Name = "textBox_buhin_keihikubun";
            this.textBox_buhin_keihikubun.Size = new System.Drawing.Size(77, 19);
            this.textBox_buhin_keihikubun.TabIndex = 8;
            // 
            // button_MicosSetting
            // 
            this.button_MicosSetting.Location = new System.Drawing.Point(316, 32);
            this.button_MicosSetting.Name = "button_MicosSetting";
            this.button_MicosSetting.Size = new System.Drawing.Size(130, 23);
            this.button_MicosSetting.TabIndex = 24;
            this.button_MicosSetting.Text = "Micosの詳細設定";
            this.button_MicosSetting.UseVisualStyleBackColor = true;
            this.button_MicosSetting.Click += new System.EventHandler(this.button_MicosSetting_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_zaikoout_setting
            // 
            this.button_zaikoout_setting.Location = new System.Drawing.Point(316, 61);
            this.button_zaikoout_setting.Name = "button_zaikoout_setting";
            this.button_zaikoout_setting.Size = new System.Drawing.Size(130, 23);
            this.button_zaikoout_setting.TabIndex = 25;
            this.button_zaikoout_setting.Text = "在庫データ出力設定";
            this.button_zaikoout_setting.UseVisualStyleBackColor = true;
            this.button_zaikoout_setting.Click += new System.EventHandler(this.button_zaikoout_setting_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_TANAOROSHI);
            this.panel1.Controls.Add(this.button_create_db_zaiko);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.textBox_selected_ICB);
            this.panel1.Controls.Add(this.textBox_selected_mmb);
            this.panel1.Controls.Add(this.button_select_ICB);
            this.panel1.Controls.Add(this.button_select_mmb);
            this.panel1.Controls.Add(this.button_create_db);
            this.panel1.Location = new System.Drawing.Point(855, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 226);
            this.panel1.TabIndex = 28;
            // 
            // button_TANAOROSHI
            // 
            this.button_TANAOROSHI.Location = new System.Drawing.Point(107, 175);
            this.button_TANAOROSHI.Name = "button_TANAOROSHI";
            this.button_TANAOROSHI.Size = new System.Drawing.Size(200, 23);
            this.button_TANAOROSHI.TabIndex = 7;
            this.button_TANAOROSHI.Text = "棚卸用";
            this.button_TANAOROSHI.UseVisualStyleBackColor = true;
            this.button_TANAOROSHI.Click += new System.EventHandler(this.button_TANAOROSHI_Click);
            // 
            // button_create_db_zaiko
            // 
            this.button_create_db_zaiko.Location = new System.Drawing.Point(107, 146);
            this.button_create_db_zaiko.Name = "button_create_db_zaiko";
            this.button_create_db_zaiko.Size = new System.Drawing.Size(200, 23);
            this.button_create_db_zaiko.TabIndex = 6;
            this.button_create_db_zaiko.Text = "在庫データベースを作成";
            this.button_create_db_zaiko.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label21.Location = new System.Drawing.Point(11, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(151, 16);
            this.label21.TabIndex = 5;
            this.label21.Text = "参照csvファイル設定";
            // 
            // textBox_selected_ICB
            // 
            this.textBox_selected_ICB.Location = new System.Drawing.Point(178, 77);
            this.textBox_selected_ICB.Name = "textBox_selected_ICB";
            this.textBox_selected_ICB.Size = new System.Drawing.Size(129, 19);
            this.textBox_selected_ICB.TabIndex = 4;
            // 
            // textBox_selected_mmb
            // 
            this.textBox_selected_mmb.Location = new System.Drawing.Point(178, 48);
            this.textBox_selected_mmb.Name = "textBox_selected_mmb";
            this.textBox_selected_mmb.Size = new System.Drawing.Size(129, 19);
            this.textBox_selected_mmb.TabIndex = 3;
            // 
            // button_select_ICB
            // 
            this.button_select_ICB.Location = new System.Drawing.Point(29, 75);
            this.button_select_ICB.Name = "button_select_ICB";
            this.button_select_ICB.Size = new System.Drawing.Size(133, 23);
            this.button_select_ICB.TabIndex = 2;
            this.button_select_ICB.Text = "在庫csvを選択";
            this.button_select_ICB.UseVisualStyleBackColor = true;
            this.button_select_ICB.Click += new System.EventHandler(this.button_select_ICB_Click);
            // 
            // button_select_mmb
            // 
            this.button_select_mmb.Location = new System.Drawing.Point(29, 46);
            this.button_select_mmb.Name = "button_select_mmb";
            this.button_select_mmb.Size = new System.Drawing.Size(133, 23);
            this.button_select_mmb.TabIndex = 1;
            this.button_select_mmb.Text = "部品構成csvを選択";
            this.button_select_mmb.UseVisualStyleBackColor = true;
            this.button_select_mmb.Click += new System.EventHandler(this.button_select_mmb_Click);
            // 
            // button_create_db
            // 
            this.button_create_db.Location = new System.Drawing.Point(107, 117);
            this.button_create_db.Name = "button_create_db";
            this.button_create_db.Size = new System.Drawing.Size(200, 23);
            this.button_create_db.TabIndex = 0;
            this.button_create_db.Text = "製品部品在庫データベースを作成";
            this.button_create_db.UseVisualStyleBackColor = true;
            this.button_create_db.Click += new System.EventHandler(this.button_create_db_Click);
            // 
            // button_buhin_setting
            // 
            this.button_buhin_setting.Location = new System.Drawing.Point(316, 91);
            this.button_buhin_setting.Name = "button_buhin_setting";
            this.button_buhin_setting.Size = new System.Drawing.Size(130, 23);
            this.button_buhin_setting.TabIndex = 29;
            this.button_buhin_setting.Text = "部品構成表設定";
            this.button_buhin_setting.UseVisualStyleBackColor = true;
            this.button_buhin_setting.Click += new System.EventHandler(this.button_buhin_setting_Click);
            // 
            // panel_zaikoout_setting
            // 
            this.panel_zaikoout_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_zaikoout_setting.Controls.Add(this.button_zaikosetting_on);
            this.panel_zaikoout_setting.Controls.Add(this.button_close_zaiko_setting);
            this.panel_zaikoout_setting.Controls.Add(this.label20);
            this.panel_zaikoout_setting.Controls.Add(this.label19);
            this.panel_zaikoout_setting.Controls.Add(this.label18);
            this.panel_zaikoout_setting.Controls.Add(this.textBox_keihi_r);
            this.panel_zaikoout_setting.Controls.Add(this.textBox_keihi_l);
            this.panel_zaikoout_setting.Controls.Add(this.comboBox_syuukei);
            this.panel_zaikoout_setting.Controls.Add(this.comboBox_syuturyoku);
            this.panel_zaikoout_setting.Controls.Add(this.label17);
            this.panel_zaikoout_setting.Controls.Add(this.label16);
            this.panel_zaikoout_setting.Controls.Add(this.label15);
            this.panel_zaikoout_setting.Controls.Add(this.label14);
            this.panel_zaikoout_setting.Location = new System.Drawing.Point(488, 258);
            this.panel_zaikoout_setting.Name = "panel_zaikoout_setting";
            this.panel_zaikoout_setting.Size = new System.Drawing.Size(529, 180);
            this.panel_zaikoout_setting.TabIndex = 30;
            // 
            // button_zaikosetting_on
            // 
            this.button_zaikosetting_on.Location = new System.Drawing.Point(357, 152);
            this.button_zaikosetting_on.Name = "button_zaikosetting_on";
            this.button_zaikosetting_on.Size = new System.Drawing.Size(75, 23);
            this.button_zaikosetting_on.TabIndex = 33;
            this.button_zaikosetting_on.Text = "設定を反映";
            this.button_zaikosetting_on.UseVisualStyleBackColor = true;
            this.button_zaikosetting_on.Click += new System.EventHandler(this.button_zaikosetting_on_Click);
            // 
            // button_close_zaiko_setting
            // 
            this.button_close_zaiko_setting.Location = new System.Drawing.Point(441, 152);
            this.button_close_zaiko_setting.Name = "button_close_zaiko_setting";
            this.button_close_zaiko_setting.Size = new System.Drawing.Size(75, 23);
            this.button_close_zaiko_setting.TabIndex = 32;
            this.button_close_zaiko_setting.Text = "閉じる";
            this.button_close_zaiko_setting.UseVisualStyleBackColor = true;
            this.button_close_zaiko_setting.Click += new System.EventHandler(this.button_close_zaiko_setting_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(231, 101);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 12);
            this.label20.TabIndex = 38;
            this.label20.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(210, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 12);
            this.label19.TabIndex = 37;
            this.label19.Text = "1:保管場所別";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(210, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(302, 12);
            this.label18.TabIndex = 32;
            this.label18.Text = "1:社内在庫 Z:社外在庫 3:別仕掛 4:総在庫 5:現品票別仕掛";
            // 
            // textBox_keihi_r
            // 
            this.textBox_keihi_r.Location = new System.Drawing.Point(265, 98);
            this.textBox_keihi_r.Name = "textBox_keihi_r";
            this.textBox_keihi_r.Size = new System.Drawing.Size(77, 19);
            this.textBox_keihi_r.TabIndex = 36;
            // 
            // textBox_keihi_l
            // 
            this.textBox_keihi_l.Location = new System.Drawing.Point(137, 98);
            this.textBox_keihi_l.Name = "textBox_keihi_l";
            this.textBox_keihi_l.Size = new System.Drawing.Size(77, 19);
            this.textBox_keihi_l.TabIndex = 32;
            // 
            // comboBox_syuukei
            // 
            this.comboBox_syuukei.FormattingEnabled = true;
            this.comboBox_syuukei.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox_syuukei.Location = new System.Drawing.Point(137, 68);
            this.comboBox_syuukei.Name = "comboBox_syuukei";
            this.comboBox_syuukei.Size = new System.Drawing.Size(43, 20);
            this.comboBox_syuukei.TabIndex = 35;
            // 
            // comboBox_syuturyoku
            // 
            this.comboBox_syuturyoku.FormattingEnabled = true;
            this.comboBox_syuturyoku.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_syuturyoku.Location = new System.Drawing.Point(137, 42);
            this.comboBox_syuturyoku.Name = "comboBox_syuturyoku";
            this.comboBox_syuturyoku.Size = new System.Drawing.Size(43, 20);
            this.comboBox_syuturyoku.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(31, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 34;
            this.label17.Text = "経費区分";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(33, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 33;
            this.label16.Text = "集計区分";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(11, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "在庫データ出力設定";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(33, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 32;
            this.label14.Text = "出力区分";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 450);
            this.Controls.Add(this.panel_zaikoout_setting);
            this.Controls.Add(this.button_buhin_setting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_zaikoout_setting);
            this.Controls.Add(this.button_MicosSetting);
            this.Controls.Add(this.panel_buhin);
            this.Controls.Add(this.panel_micos_setting);
            this.Controls.Add(this.btn_ComponentOut);
            this.Controls.Add(this.btn_ZaikoOut);
            this.Controls.Add(this.OpenMicos_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel_micos_setting.ResumeLayout(false);
            this.panel_micos_setting.PerformLayout();
            this.panel_buhin.ResumeLayout(false);
            this.panel_buhin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_zaikoout_setting.ResumeLayout(false);
            this.panel_zaikoout_setting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenMicos_btn;
        private System.Windows.Forms.Button btn_ZaikoOut;
        private System.Windows.Forms.Button btn_ComponentOut;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Panel panel_micos_setting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_outputfilepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_buhin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_buhin_keihikubun;
        private System.Windows.Forms.ComboBox comboBox_buhin_hyouji;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_buhin_syubetu;
        private System.Windows.Forms.ComboBox comboBox_buhin_tenkai;
        private System.Windows.Forms.Button button_close_buhin_setting;
        private System.Windows.Forms.Button button_close_micossetting;
        private System.Windows.Forms.TextBox textBox_micos_filepath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_micosprocess;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_processname;
        private System.Windows.Forms.Button button_MicosSetting;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_zaikoout_setting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_selected_ICB;
        private System.Windows.Forms.TextBox textBox_selected_mmb;
        private System.Windows.Forms.Button button_select_ICB;
        private System.Windows.Forms.Button button_select_mmb;
        private System.Windows.Forms.Button button_create_db;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_buhin_setting;
        private System.Windows.Forms.Panel panel_zaikoout_setting;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_keihi_r;
        private System.Windows.Forms.TextBox textBox_keihi_l;
        private System.Windows.Forms.ComboBox comboBox_syuukei;
        private System.Windows.Forms.ComboBox comboBox_syuturyoku;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_close_zaiko_setting;
        private System.Windows.Forms.Button button_micossetting_on;
        private System.Windows.Forms.Button button_buhinsetting_on;
        private System.Windows.Forms.Button button_zaikosetting_on;
        private System.Windows.Forms.Button button_create_db_zaiko;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button_TANAOROSHI;
        private System.Windows.Forms.TextBox textBox_MicosWindow;
        private System.Windows.Forms.Label label22;
    }
}

