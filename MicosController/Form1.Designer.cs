
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
            this.GetWindow_btn = new System.Windows.Forms.Button();
            this.MicosController1_btn = new System.Windows.Forms.Button();
            this.MicosController2 = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.panel_micos_setting = new System.Windows.Forms.Panel();
            this.button_processname = new System.Windows.Forms.Button();
            this.textBox_micosprocess = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_micos_filepath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_close_micossetting_panel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_outputfilepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_buhin = new System.Windows.Forms.Panel();
            this.button_close_buhin_panel = new System.Windows.Forms.Button();
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_MicosSetting = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button_debug = new System.Windows.Forms.Button();
            this.textBox_dbug = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_selected_ICB = new System.Windows.Forms.TextBox();
            this.textBox_selected_mmb = new System.Windows.Forms.TextBox();
            this.button_select_ICB = new System.Windows.Forms.Button();
            this.button_select_mmb = new System.Windows.Forms.Button();
            this.button_create_db = new System.Windows.Forms.Button();
            this.panel_micos_setting.SuspendLayout();
            this.panel_buhin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenMicos_btn
            // 
            this.OpenMicos_btn.Location = new System.Drawing.Point(37, 34);
            this.OpenMicos_btn.Name = "OpenMicos_btn";
            this.OpenMicos_btn.Size = new System.Drawing.Size(88, 31);
            this.OpenMicos_btn.TabIndex = 0;
            this.OpenMicos_btn.Text = "OpenMicos";
            this.OpenMicos_btn.UseVisualStyleBackColor = true;
            this.OpenMicos_btn.Click += new System.EventHandler(this.OpenMicos_btn_Click);
            // 
            // GetWindow_btn
            // 
            this.GetWindow_btn.Location = new System.Drawing.Point(37, 92);
            this.GetWindow_btn.Name = "GetWindow_btn";
            this.GetWindow_btn.Size = new System.Drawing.Size(88, 23);
            this.GetWindow_btn.TabIndex = 1;
            this.GetWindow_btn.Text = "GetWindow";
            this.GetWindow_btn.UseVisualStyleBackColor = true;
            this.GetWindow_btn.Click += new System.EventHandler(this.GetWindow_btn_Click);
            // 
            // MicosController1_btn
            // 
            this.MicosController1_btn.Location = new System.Drawing.Point(37, 143);
            this.MicosController1_btn.Name = "MicosController1_btn";
            this.MicosController1_btn.Size = new System.Drawing.Size(121, 23);
            this.MicosController1_btn.TabIndex = 2;
            this.MicosController1_btn.Text = "MicosZaikoOut";
            this.MicosController1_btn.UseVisualStyleBackColor = true;
            this.MicosController1_btn.Click += new System.EventHandler(this.MicosController1_btn_Click);
            // 
            // MicosController2
            // 
            this.MicosController2.Location = new System.Drawing.Point(37, 172);
            this.MicosController2.Name = "MicosController2";
            this.MicosController2.Size = new System.Drawing.Size(121, 23);
            this.MicosController2.TabIndex = 3;
            this.MicosController2.Text = "MicosCompOut";
            this.MicosController2.UseVisualStyleBackColor = true;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(208, 77);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 19);
            this.textBox_username.TabIndex = 4;
            // 
            // panel_micos_setting
            // 
            this.panel_micos_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_micos_setting.Controls.Add(this.button_processname);
            this.panel_micos_setting.Controls.Add(this.textBox_micosprocess);
            this.panel_micos_setting.Controls.Add(this.label11);
            this.panel_micos_setting.Controls.Add(this.textBox_micos_filepath);
            this.panel_micos_setting.Controls.Add(this.label10);
            this.panel_micos_setting.Controls.Add(this.button_close_micossetting_panel);
            this.panel_micos_setting.Controls.Add(this.label2);
            this.panel_micos_setting.Controls.Add(this.textBox_outputfilepath);
            this.panel_micos_setting.Controls.Add(this.label1);
            this.panel_micos_setting.Controls.Add(this.textBox_username);
            this.panel_micos_setting.Location = new System.Drawing.Point(446, 34);
            this.panel_micos_setting.Name = "panel_micos_setting";
            this.panel_micos_setting.Size = new System.Drawing.Size(321, 207);
            this.panel_micos_setting.TabIndex = 5;
            // 
            // button_processname
            // 
            this.button_processname.Location = new System.Drawing.Point(35, 58);
            this.button_processname.Name = "button_processname";
            this.button_processname.Size = new System.Drawing.Size(112, 23);
            this.button_processname.TabIndex = 7;
            this.button_processname.Text = "プロセス名取得";
            this.button_processname.UseVisualStyleBackColor = true;
            this.button_processname.Click += new System.EventHandler(this.button_processname_Click);
            // 
            // textBox_micosprocess
            // 
            this.textBox_micosprocess.Location = new System.Drawing.Point(208, 40);
            this.textBox_micosprocess.Name = "textBox_micosprocess";
            this.textBox_micosprocess.Size = new System.Drawing.Size(100, 19);
            this.textBox_micosprocess.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "Micosプロセス名";
            // 
            // textBox_micos_filepath
            // 
            this.textBox_micos_filepath.Location = new System.Drawing.Point(208, 12);
            this.textBox_micos_filepath.Name = "textBox_micos_filepath";
            this.textBox_micos_filepath.Size = new System.Drawing.Size(100, 19);
            this.textBox_micos_filepath.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "Micos実行ファイルパス";
            // 
            // button_close_micossetting_panel
            // 
            this.button_close_micossetting_panel.Location = new System.Drawing.Point(224, 161);
            this.button_close_micossetting_panel.Name = "button_close_micossetting_panel";
            this.button_close_micossetting_panel.Size = new System.Drawing.Size(75, 23);
            this.button_close_micossetting_panel.TabIndex = 19;
            this.button_close_micossetting_panel.Text = "閉じる";
            this.button_close_micossetting_panel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "出力ファイルパス";
            // 
            // textBox_outputfilepath
            // 
            this.textBox_outputfilepath.Location = new System.Drawing.Point(208, 107);
            this.textBox_outputfilepath.Name = "textBox_outputfilepath";
            this.textBox_outputfilepath.Size = new System.Drawing.Size(100, 19);
            this.textBox_outputfilepath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName";
            // 
            // panel_buhin
            // 
            this.panel_buhin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_buhin.Controls.Add(this.button_close_buhin_panel);
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
            this.panel_buhin.Controls.Add(this.textBox3);
            this.panel_buhin.Location = new System.Drawing.Point(68, 259);
            this.panel_buhin.Name = "panel_buhin";
            this.panel_buhin.Size = new System.Drawing.Size(440, 152);
            this.panel_buhin.TabIndex = 6;
            // 
            // button_close_buhin_panel
            // 
            this.button_close_buhin_panel.Location = new System.Drawing.Point(352, 117);
            this.button_close_buhin_panel.Name = "button_close_buhin_panel";
            this.button_close_buhin_panel.Size = new System.Drawing.Size(75, 23);
            this.button_close_buhin_panel.TabIndex = 7;
            this.button_close_buhin_panel.Text = "閉じる";
            this.button_close_buhin_panel.UseVisualStyleBackColor = true;
            // 
            // comboBox_buhin_syubetu
            // 
            this.comboBox_buhin_syubetu.FormattingEnabled = true;
            this.comboBox_buhin_syubetu.Items.AddRange(new object[] {
            "1",
            "Z",
            "O",
            "W"});
            this.comboBox_buhin_syubetu.Location = new System.Drawing.Point(144, 39);
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
            this.comboBox_buhin_tenkai.Location = new System.Drawing.Point(144, 65);
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
            this.comboBox_buhin_hyouji.Location = new System.Drawing.Point(144, 90);
            this.comboBox_buhin_hyouji.Name = "comboBox_buhin_hyouji";
            this.comboBox_buhin_hyouji.Size = new System.Drawing.Size(43, 20);
            this.comboBox_buhin_hyouji.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "1:全レベル　2:単一レベル";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "1:正展開　2:逆展開";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "1:製品 Z:加工部品 O:材料 W:硝子製品";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "表示レベル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "展開方法";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "種別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "経費区分";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(110, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(77, 19);
            this.textBox3.TabIndex = 8;
            // 
            // button_MicosSetting
            // 
            this.button_MicosSetting.Location = new System.Drawing.Point(166, 38);
            this.button_MicosSetting.Name = "button_MicosSetting";
            this.button_MicosSetting.Size = new System.Drawing.Size(120, 23);
            this.button_MicosSetting.TabIndex = 24;
            this.button_MicosSetting.Text = "Micosの詳細設定";
            this.button_MicosSetting.UseVisualStyleBackColor = true;
            this.button_MicosSetting.Click += new System.EventHandler(this.button_MicosSetting_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_debug
            // 
            this.button_debug.Location = new System.Drawing.Point(539, 306);
            this.button_debug.Name = "button_debug";
            this.button_debug.Size = new System.Drawing.Size(75, 23);
            this.button_debug.TabIndex = 26;
            this.button_debug.Text = "デバッグ用";
            this.button_debug.UseVisualStyleBackColor = true;
            this.button_debug.Click += new System.EventHandler(this.button_debug_Click);
            // 
            // textBox_dbug
            // 
            this.textBox_dbug.Location = new System.Drawing.Point(638, 308);
            this.textBox_dbug.Name = "textBox_dbug";
            this.textBox_dbug.Size = new System.Drawing.Size(108, 19);
            this.textBox_dbug.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_selected_ICB);
            this.panel1.Controls.Add(this.textBox_selected_mmb);
            this.panel1.Controls.Add(this.button_select_ICB);
            this.panel1.Controls.Add(this.button_select_mmb);
            this.panel1.Controls.Add(this.button_create_db);
            this.panel1.Location = new System.Drawing.Point(855, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 369);
            this.panel1.TabIndex = 28;
            // 
            // textBox_selected_ICB
            // 
            this.textBox_selected_ICB.Location = new System.Drawing.Point(178, 79);
            this.textBox_selected_ICB.Name = "textBox_selected_ICB";
            this.textBox_selected_ICB.Size = new System.Drawing.Size(129, 19);
            this.textBox_selected_ICB.TabIndex = 4;
            // 
            // textBox_selected_mmb
            // 
            this.textBox_selected_mmb.Location = new System.Drawing.Point(178, 40);
            this.textBox_selected_mmb.Name = "textBox_selected_mmb";
            this.textBox_selected_mmb.Size = new System.Drawing.Size(129, 19);
            this.textBox_selected_mmb.TabIndex = 3;
            // 
            // button_select_ICB
            // 
            this.button_select_ICB.Location = new System.Drawing.Point(29, 77);
            this.button_select_ICB.Name = "button_select_ICB";
            this.button_select_ICB.Size = new System.Drawing.Size(133, 23);
            this.button_select_ICB.TabIndex = 2;
            this.button_select_ICB.Text = "在庫csvを選択";
            this.button_select_ICB.UseVisualStyleBackColor = true;
            // 
            // button_select_mmb
            // 
            this.button_select_mmb.Location = new System.Drawing.Point(29, 38);
            this.button_select_mmb.Name = "button_select_mmb";
            this.button_select_mmb.Size = new System.Drawing.Size(133, 23);
            this.button_select_mmb.TabIndex = 1;
            this.button_select_mmb.Text = "部品構成csvを選択";
            this.button_select_mmb.UseVisualStyleBackColor = true;
            this.button_select_mmb.Click += new System.EventHandler(this.button_select_mmb_Click);
            // 
            // button_create_db
            // 
            this.button_create_db.Location = new System.Drawing.Point(75, 128);
            this.button_create_db.Name = "button_create_db";
            this.button_create_db.Size = new System.Drawing.Size(179, 23);
            this.button_create_db.TabIndex = 0;
            this.button_create_db.Text = "データベースを作成";
            this.button_create_db.UseVisualStyleBackColor = true;
            this.button_create_db.Click += new System.EventHandler(this.button_create_db_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_dbug);
            this.Controls.Add(this.button_debug);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_MicosSetting);
            this.Controls.Add(this.panel_buhin);
            this.Controls.Add(this.panel_micos_setting);
            this.Controls.Add(this.MicosController2);
            this.Controls.Add(this.MicosController1_btn);
            this.Controls.Add(this.GetWindow_btn);
            this.Controls.Add(this.OpenMicos_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_micos_setting.ResumeLayout(false);
            this.panel_micos_setting.PerformLayout();
            this.panel_buhin.ResumeLayout(false);
            this.panel_buhin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenMicos_btn;
        private System.Windows.Forms.Button GetWindow_btn;
        private System.Windows.Forms.Button MicosController1_btn;
        private System.Windows.Forms.Button MicosController2;
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox_buhin_hyouji;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_buhin_syubetu;
        private System.Windows.Forms.ComboBox comboBox_buhin_tenkai;
        private System.Windows.Forms.Button button_close_buhin_panel;
        private System.Windows.Forms.Button button_close_micossetting_panel;
        private System.Windows.Forms.TextBox textBox_micos_filepath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_micosprocess;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_processname;
        private System.Windows.Forms.Button button_MicosSetting;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_debug;
        private System.Windows.Forms.TextBox textBox_dbug;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_selected_ICB;
        private System.Windows.Forms.TextBox textBox_selected_mmb;
        private System.Windows.Forms.Button button_select_ICB;
        private System.Windows.Forms.Button button_select_mmb;
        private System.Windows.Forms.Button button_create_db;
    }
}

