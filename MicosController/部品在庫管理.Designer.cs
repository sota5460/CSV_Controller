
namespace MicosController
{
    partial class 部品在庫管理
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_ZaikoDataDisplayTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ZaikoComponentList = new System.Windows.Forms.DataGridView();
            this.panel_fitler_zaiko_display = new System.Windows.Forms.Panel();
            this.button_filter_zaikodisplay = new System.Windows.Forms.Button();
            this.button_querry_zaikodisplay = new System.Windows.Forms.Button();
            this.textBox_querry_zaikodisplay = new System.Windows.Forms.TextBox();
            this.button_panel_fileter_zaikodisplay_close = new System.Windows.Forms.Button();
            this.checkedListBox_ZaikoOrigin_koutei = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ZaikoOrigin_hokan = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ZaikoOrigin_keihi = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_create_ZaikoComponentListTable = new System.Windows.Forms.Button();
            this.dataGridView_ProductZaikoList = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView_cell_component_table = new System.Windows.Forms.DataGridView();
            this.button_filter_zaikodisplay_open = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button_filter_above_productnum = new System.Windows.Forms.Button();
            this.button_filter_below_productnum = new System.Windows.Forms.Button();
            this.button_filter_equal_productnum = new System.Windows.Forms.Button();
            this.button_filter_usedproductname = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_filter_above_productnum = new System.Windows.Forms.TextBox();
            this.textBox_filter_below_productnum = new System.Windows.Forms.TextBox();
            this.textBox_filter_equal_productnum = new System.Windows.Forms.TextBox();
            this.button_querry_ZaikoComponentList = new System.Windows.Forms.Button();
            this.button_release_filter_zaikocomponent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoDataDisplayTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoComponentList)).BeginInit();
            this.panel_fitler_zaiko_display.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductZaikoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cell_component_table)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_ZaikoDataDisplayTable
            // 
            this.dataGridView_ZaikoDataDisplayTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ZaikoDataDisplayTable.Location = new System.Drawing.Point(12, 44);
            this.dataGridView_ZaikoDataDisplayTable.Name = "dataGridView_ZaikoDataDisplayTable";
            this.dataGridView_ZaikoDataDisplayTable.RowTemplate.Height = 21;
            this.dataGridView_ZaikoDataDisplayTable.Size = new System.Drawing.Size(250, 425);
            this.dataGridView_ZaikoDataDisplayTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "対象の在庫";
            // 
            // dataGridView_ZaikoComponentList
            // 
            this.dataGridView_ZaikoComponentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ZaikoComponentList.Location = new System.Drawing.Point(24, 38);
            this.dataGridView_ZaikoComponentList.Name = "dataGridView_ZaikoComponentList";
            this.dataGridView_ZaikoComponentList.RowTemplate.Height = 21;
            this.dataGridView_ZaikoComponentList.Size = new System.Drawing.Size(455, 422);
            this.dataGridView_ZaikoComponentList.TabIndex = 2;
            this.dataGridView_ZaikoComponentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ZaikoComponentList_CellClick);
            // 
            // panel_fitler_zaiko_display
            // 
            this.panel_fitler_zaiko_display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_fitler_zaiko_display.Controls.Add(this.button_filter_zaikodisplay);
            this.panel_fitler_zaiko_display.Controls.Add(this.button_querry_zaikodisplay);
            this.panel_fitler_zaiko_display.Controls.Add(this.textBox_querry_zaikodisplay);
            this.panel_fitler_zaiko_display.Controls.Add(this.button_panel_fileter_zaikodisplay_close);
            this.panel_fitler_zaiko_display.Controls.Add(this.checkedListBox_ZaikoOrigin_koutei);
            this.panel_fitler_zaiko_display.Controls.Add(this.checkedListBox_ZaikoOrigin_hokan);
            this.panel_fitler_zaiko_display.Controls.Add(this.checkedListBox_ZaikoOrigin_keihi);
            this.panel_fitler_zaiko_display.Controls.Add(this.label2);
            this.panel_fitler_zaiko_display.Location = new System.Drawing.Point(47, 295);
            this.panel_fitler_zaiko_display.Name = "panel_fitler_zaiko_display";
            this.panel_fitler_zaiko_display.Size = new System.Drawing.Size(326, 311);
            this.panel_fitler_zaiko_display.TabIndex = 3;
            // 
            // button_filter_zaikodisplay
            // 
            this.button_filter_zaikodisplay.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_filter_zaikodisplay.Location = new System.Drawing.Point(185, 227);
            this.button_filter_zaikodisplay.Name = "button_filter_zaikodisplay";
            this.button_filter_zaikodisplay.Size = new System.Drawing.Size(117, 23);
            this.button_filter_zaikodisplay.TabIndex = 18;
            this.button_filter_zaikodisplay.Text = "フィルタで抽出";
            this.button_filter_zaikodisplay.UseVisualStyleBackColor = true;
            // 
            // button_querry_zaikodisplay
            // 
            this.button_querry_zaikodisplay.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_querry_zaikodisplay.Location = new System.Drawing.Point(20, 275);
            this.button_querry_zaikodisplay.Name = "button_querry_zaikodisplay";
            this.button_querry_zaikodisplay.Size = new System.Drawing.Size(75, 23);
            this.button_querry_zaikodisplay.TabIndex = 17;
            this.button_querry_zaikodisplay.Text = "クエリで抽出";
            this.button_querry_zaikodisplay.UseVisualStyleBackColor = true;
            this.button_querry_zaikodisplay.Click += new System.EventHandler(this.button_querry_zaikodisplay_Click);
            // 
            // textBox_querry_zaikodisplay
            // 
            this.textBox_querry_zaikodisplay.Location = new System.Drawing.Point(20, 250);
            this.textBox_querry_zaikodisplay.Name = "textBox_querry_zaikodisplay";
            this.textBox_querry_zaikodisplay.Size = new System.Drawing.Size(116, 19);
            this.textBox_querry_zaikodisplay.TabIndex = 16;
            // 
            // button_panel_fileter_zaikodisplay_close
            // 
            this.button_panel_fileter_zaikodisplay_close.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_panel_fileter_zaikodisplay_close.Location = new System.Drawing.Point(236, 278);
            this.button_panel_fileter_zaikodisplay_close.Name = "button_panel_fileter_zaikodisplay_close";
            this.button_panel_fileter_zaikodisplay_close.Size = new System.Drawing.Size(75, 23);
            this.button_panel_fileter_zaikodisplay_close.TabIndex = 16;
            this.button_panel_fileter_zaikodisplay_close.Text = "閉じる";
            this.button_panel_fileter_zaikodisplay_close.UseVisualStyleBackColor = true;
            this.button_panel_fileter_zaikodisplay_close.Click += new System.EventHandler(this.button_panel_fileter_zaikodisplay_close_Click);
            // 
            // checkedListBox_ZaikoOrigin_koutei
            // 
            this.checkedListBox_ZaikoOrigin_koutei.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_koutei.Location = new System.Drawing.Point(212, 35);
            this.checkedListBox_ZaikoOrigin_koutei.Name = "checkedListBox_ZaikoOrigin_koutei";
            this.checkedListBox_ZaikoOrigin_koutei.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_koutei.TabIndex = 3;
            // 
            // checkedListBox_ZaikoOrigin_hokan
            // 
            this.checkedListBox_ZaikoOrigin_hokan.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_hokan.Location = new System.Drawing.Point(116, 35);
            this.checkedListBox_ZaikoOrigin_hokan.Name = "checkedListBox_ZaikoOrigin_hokan";
            this.checkedListBox_ZaikoOrigin_hokan.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_hokan.TabIndex = 2;
            // 
            // checkedListBox_ZaikoOrigin_keihi
            // 
            this.checkedListBox_ZaikoOrigin_keihi.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_keihi.Location = new System.Drawing.Point(20, 35);
            this.checkedListBox_ZaikoOrigin_keihi.Name = "checkedListBox_ZaikoOrigin_keihi";
            this.checkedListBox_ZaikoOrigin_keihi.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_keihi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "フィルタ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "使用製品リスト";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(981, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "材料、在庫数、使われてる製品、その製品何個分の在庫があるか、";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1120, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "作れる製品数の最小値/製品数　＜　２０以下を抽出する的な。\r\n危険そうな在庫を抽出する。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1008, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(365, 36);
            this.label6.TabIndex = 6;
            this.label6.Text = "１，アッセイ管理の部品を選ぶ\r\n２，使用製品リスト（アッセイでかかわる製品）から危険そうな材料を抽出する。\r\n３，発注残を確認";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1186, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "出荷する製品とその数。\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 19);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(134, 19);
            this.textBox2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(1186, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 184);
            this.panel2.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(143, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "1つ前に戻る。";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "オリジナルに戻す。";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "在庫データに反映する。";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(53, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "出荷数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(13, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "出荷製品CD";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_release_filter_zaikocomponent);
            this.panel3.Controls.Add(this.button_querry_ZaikoComponentList);
            this.panel3.Controls.Add(this.textBox_filter_equal_productnum);
            this.panel3.Controls.Add(this.textBox_filter_below_productnum);
            this.panel3.Controls.Add(this.textBox_filter_above_productnum);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.button_filter_usedproductname);
            this.panel3.Controls.Add(this.button_filter_equal_productnum);
            this.panel3.Controls.Add(this.button_filter_below_productnum);
            this.panel3.Controls.Add(this.button_filter_above_productnum);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(485, 264);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 314);
            this.panel3.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "クエリ入力";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(14, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "使用製品数で抽出";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(341, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "使用製品CDで抽出";
            // 
            // button_create_ZaikoComponentListTable
            // 
            this.button_create_ZaikoComponentListTable.Location = new System.Drawing.Point(108, 18);
            this.button_create_ZaikoComponentListTable.Name = "button_create_ZaikoComponentListTable";
            this.button_create_ZaikoComponentListTable.Size = new System.Drawing.Size(213, 23);
            this.button_create_ZaikoComponentListTable.TabIndex = 11;
            this.button_create_ZaikoComponentListTable.Text = "選択した在庫から使用製品を抽出する。";
            this.button_create_ZaikoComponentListTable.UseVisualStyleBackColor = true;
            this.button_create_ZaikoComponentListTable.Click += new System.EventHandler(this.button_create_ZaikoComponentListTable_Click);
            // 
            // dataGridView_ProductZaikoList
            // 
            this.dataGridView_ProductZaikoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProductZaikoList.Location = new System.Drawing.Point(18, 38);
            this.dataGridView_ProductZaikoList.Name = "dataGridView_ProductZaikoList";
            this.dataGridView_ProductZaikoList.RowTemplate.Height = 21;
            this.dataGridView_ProductZaikoList.Size = new System.Drawing.Size(455, 425);
            this.dataGridView_ProductZaikoList.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(516, 326);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "製品ＣＤ、現在在庫で生産可能数、使用材料";
            // 
            // dataGridView_cell_component_table
            // 
            this.dataGridView_cell_component_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cell_component_table.Location = new System.Drawing.Point(485, 38);
            this.dataGridView_cell_component_table.Name = "dataGridView_cell_component_table";
            this.dataGridView_cell_component_table.RowTemplate.Height = 21;
            this.dataGridView_cell_component_table.Size = new System.Drawing.Size(297, 207);
            this.dataGridView_cell_component_table.TabIndex = 14;
            // 
            // button_filter_zaikodisplay_open
            // 
            this.button_filter_zaikodisplay_open.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_filter_zaikodisplay_open.Location = new System.Drawing.Point(12, 484);
            this.button_filter_zaikodisplay_open.Name = "button_filter_zaikodisplay_open";
            this.button_filter_zaikodisplay_open.Size = new System.Drawing.Size(75, 23);
            this.button_filter_zaikodisplay_open.TabIndex = 15;
            this.button_filter_zaikodisplay_open.Text = "フィルタ";
            this.button_filter_zaikodisplay_open.UseVisualStyleBackColor = true;
            this.button_filter_zaikodisplay_open.Click += new System.EventHandler(this.button_filter_zaikodisplay_open_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(384, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 610);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_cell_component_table);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.dataGridView_ZaikoComponentList);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "各材料の使用製品リスト";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_ProductZaikoList);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "各製品の仕様材料リスト";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "使用製品数";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button_filter_above_productnum
            // 
            this.button_filter_above_productnum.Location = new System.Drawing.Point(157, 38);
            this.button_filter_above_productnum.Name = "button_filter_above_productnum";
            this.button_filter_above_productnum.Size = new System.Drawing.Size(108, 23);
            this.button_filter_above_productnum.TabIndex = 4;
            this.button_filter_above_productnum.Text = "以上";
            this.button_filter_above_productnum.UseVisualStyleBackColor = true;
            this.button_filter_above_productnum.Click += new System.EventHandler(this.button_filter_above_productnum_Click);
            // 
            // button_filter_below_productnum
            // 
            this.button_filter_below_productnum.Location = new System.Drawing.Point(157, 67);
            this.button_filter_below_productnum.Name = "button_filter_below_productnum";
            this.button_filter_below_productnum.Size = new System.Drawing.Size(108, 23);
            this.button_filter_below_productnum.TabIndex = 5;
            this.button_filter_below_productnum.Text = "以下";
            this.button_filter_below_productnum.UseVisualStyleBackColor = true;
            this.button_filter_below_productnum.Click += new System.EventHandler(this.button_filter_below_productnum_Click);
            // 
            // button_filter_equal_productnum
            // 
            this.button_filter_equal_productnum.Location = new System.Drawing.Point(157, 96);
            this.button_filter_equal_productnum.Name = "button_filter_equal_productnum";
            this.button_filter_equal_productnum.Size = new System.Drawing.Size(108, 23);
            this.button_filter_equal_productnum.TabIndex = 6;
            this.button_filter_equal_productnum.Text = "等しい";
            this.button_filter_equal_productnum.UseVisualStyleBackColor = true;
            this.button_filter_equal_productnum.Click += new System.EventHandler(this.button_filter_equal_productnum_Click);
            // 
            // button_filter_usedproductname
            // 
            this.button_filter_usedproductname.Location = new System.Drawing.Point(157, 183);
            this.button_filter_usedproductname.Name = "button_filter_usedproductname";
            this.button_filter_usedproductname.Size = new System.Drawing.Size(108, 23);
            this.button_filter_usedproductname.TabIndex = 7;
            this.button_filter_usedproductname.Text = "抽出";
            this.button_filter_usedproductname.UseVisualStyleBackColor = true;
            this.button_filter_usedproductname.Click += new System.EventHandler(this.button_filter_usedproductname_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(14, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "使用製品で抽出";
            // 
            // textBox_filter_above_productnum
            // 
            this.textBox_filter_above_productnum.Location = new System.Drawing.Point(51, 40);
            this.textBox_filter_above_productnum.Name = "textBox_filter_above_productnum";
            this.textBox_filter_above_productnum.Size = new System.Drawing.Size(100, 19);
            this.textBox_filter_above_productnum.TabIndex = 10;
            // 
            // textBox_filter_below_productnum
            // 
            this.textBox_filter_below_productnum.Location = new System.Drawing.Point(51, 71);
            this.textBox_filter_below_productnum.Name = "textBox_filter_below_productnum";
            this.textBox_filter_below_productnum.Size = new System.Drawing.Size(100, 19);
            this.textBox_filter_below_productnum.TabIndex = 11;
            // 
            // textBox_filter_equal_productnum
            // 
            this.textBox_filter_equal_productnum.Location = new System.Drawing.Point(51, 100);
            this.textBox_filter_equal_productnum.Name = "textBox_filter_equal_productnum";
            this.textBox_filter_equal_productnum.Size = new System.Drawing.Size(100, 19);
            this.textBox_filter_equal_productnum.TabIndex = 12;
            // 
            // button_querry_ZaikoComponentList
            // 
            this.button_querry_ZaikoComponentList.Location = new System.Drawing.Point(157, 235);
            this.button_querry_ZaikoComponentList.Name = "button_querry_ZaikoComponentList";
            this.button_querry_ZaikoComponentList.Size = new System.Drawing.Size(108, 23);
            this.button_querry_ZaikoComponentList.TabIndex = 13;
            this.button_querry_ZaikoComponentList.Text = "抽出";
            this.button_querry_ZaikoComponentList.UseVisualStyleBackColor = true;
            this.button_querry_ZaikoComponentList.Click += new System.EventHandler(this.button_querry_ZaikoComponentList_Click);
            // 
            // button_release_filter_zaikocomponent
            // 
            this.button_release_filter_zaikocomponent.Location = new System.Drawing.Point(157, 278);
            this.button_release_filter_zaikocomponent.Name = "button_release_filter_zaikocomponent";
            this.button_release_filter_zaikocomponent.Size = new System.Drawing.Size(108, 23);
            this.button_release_filter_zaikocomponent.TabIndex = 14;
            this.button_release_filter_zaikocomponent.Text = "元に戻す";
            this.button_release_filter_zaikocomponent.UseVisualStyleBackColor = true;
            this.button_release_filter_zaikocomponent.Click += new System.EventHandler(this.button_release_filter_zaikocomponent_Click);
            // 
            // 部品在庫管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 640);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_filter_zaikodisplay_open);
            this.Controls.Add(this.button_create_ZaikoComponentListTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel_fitler_zaiko_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ZaikoDataDisplayTable);
            this.Name = "部品在庫管理";
            this.Text = "部品在庫管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoDataDisplayTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoComponentList)).EndInit();
            this.panel_fitler_zaiko_display.ResumeLayout(false);
            this.panel_fitler_zaiko_display.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductZaikoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cell_component_table)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ZaikoDataDisplayTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_ZaikoComponentList;
        private System.Windows.Forms.Panel panel_fitler_zaiko_display;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBox_ZaikoOrigin_koutei;
        private System.Windows.Forms.CheckedListBox checkedListBox_ZaikoOrigin_hokan;
        private System.Windows.Forms.CheckedListBox checkedListBox_ZaikoOrigin_keihi;
        private System.Windows.Forms.Button button_create_ZaikoComponentListTable;
        private System.Windows.Forms.DataGridView dataGridView_ProductZaikoList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView_cell_component_table;
        private System.Windows.Forms.Button button_filter_zaikodisplay_open;
        private System.Windows.Forms.Button button_panel_fileter_zaikodisplay_close;
        private System.Windows.Forms.Button button_filter_zaikodisplay;
        private System.Windows.Forms.Button button_querry_zaikodisplay;
        private System.Windows.Forms.TextBox textBox_querry_zaikodisplay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_filter_usedproductname;
        private System.Windows.Forms.Button button_filter_equal_productnum;
        private System.Windows.Forms.Button button_filter_below_productnum;
        private System.Windows.Forms.Button button_filter_above_productnum;
        private System.Windows.Forms.TextBox textBox_filter_equal_productnum;
        private System.Windows.Forms.TextBox textBox_filter_below_productnum;
        private System.Windows.Forms.TextBox textBox_filter_above_productnum;
        private System.Windows.Forms.Button button_querry_ZaikoComponentList;
        private System.Windows.Forms.Button button_release_filter_zaikocomponent;
    }
}