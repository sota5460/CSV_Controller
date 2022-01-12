
namespace MicosController
{
    partial class Form2
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
            this.button_csvout = new System.Windows.Forms.Button();
            this.checkedListBox_display_column = new System.Windows.Forms.CheckedListBox();
            this.label_display_column = new System.Windows.Forms.Label();
            this.checkedListBox_serach_column = new System.Windows.Forms.CheckedListBox();
            this.label_search_column = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_serach_component = new System.Windows.Forms.Button();
            this.textBox_productcode_tosearch = new System.Windows.Forms.TextBox();
            this.textBox_querry_mmb = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_product_cd = new System.Windows.Forms.Label();
            this.panel_detail_search = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_close_panel_detail_search = new System.Windows.Forms.Button();
            this.comboBox_hokanbasyo = new System.Windows.Forms.ComboBox();
            this.comboBox_oyakoutei = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_detail_search = new System.Windows.Forms.Button();
            this.panel_more_detail_search = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_zaikoh = new System.Windows.Forms.TextBox();
            this.textBox_zaikol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_oyakoute_moredetail = new System.Windows.Forms.TextBox();
            this.textBox_hokanbasyo_moredetail = new System.Windows.Forms.TextBox();
            this.button_extract_with_detail = new System.Windows.Forms.Button();
            this.button_reflect_setting_moredetail = new System.Windows.Forms.Button();
            this.textBox_querry_icb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_detail_search.SuspendLayout();
            this.panel_more_detail_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_csvout
            // 
            this.button_csvout.Location = new System.Drawing.Point(15, 558);
            this.button_csvout.Name = "button_csvout";
            this.button_csvout.Size = new System.Drawing.Size(75, 23);
            this.button_csvout.TabIndex = 0;
            this.button_csvout.Text = "CSV出力";
            this.button_csvout.UseVisualStyleBackColor = true;
            this.button_csvout.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox_display_column
            // 
            this.checkedListBox_display_column.FormattingEnabled = true;
            this.checkedListBox_display_column.Location = new System.Drawing.Point(12, 85);
            this.checkedListBox_display_column.Name = "checkedListBox_display_column";
            this.checkedListBox_display_column.Size = new System.Drawing.Size(120, 130);
            this.checkedListBox_display_column.TabIndex = 1;
            // 
            // label_display_column
            // 
            this.label_display_column.AutoSize = true;
            this.label_display_column.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_display_column.Location = new System.Drawing.Point(9, 67);
            this.label_display_column.Name = "label_display_column";
            this.label_display_column.Size = new System.Drawing.Size(55, 15);
            this.label_display_column.TabIndex = 2;
            this.label_display_column.Text = "表示列";
            // 
            // checkedListBox_serach_column
            // 
            this.checkedListBox_serach_column.FormattingEnabled = true;
            this.checkedListBox_serach_column.Location = new System.Drawing.Point(12, 236);
            this.checkedListBox_serach_column.Name = "checkedListBox_serach_column";
            this.checkedListBox_serach_column.Size = new System.Drawing.Size(120, 130);
            this.checkedListBox_serach_column.TabIndex = 3;
            // 
            // label_search_column
            // 
            this.label_search_column.AutoSize = true;
            this.label_search_column.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_search_column.Location = new System.Drawing.Point(9, 218);
            this.label_search_column.Name = "label_search_column";
            this.label_search_column.Size = new System.Drawing.Size(55, 15);
            this.label_search_column.TabIndex = 4;
            this.label_search_column.Text = "検索列";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBox_display_column);
            this.panel1.Controls.Add(this.label_display_column);
            this.panel1.Controls.Add(this.label_search_column);
            this.panel1.Controls.Add(this.checkedListBox_serach_column);
            this.panel1.Location = new System.Drawing.Point(1059, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 378);
            this.panel1.TabIndex = 5;
            // 
            // button_serach_component
            // 
            this.button_serach_component.Location = new System.Drawing.Point(138, 35);
            this.button_serach_component.Name = "button_serach_component";
            this.button_serach_component.Size = new System.Drawing.Size(254, 23);
            this.button_serach_component.TabIndex = 6;
            this.button_serach_component.Text = "製品CDから部品在庫を検索する";
            this.button_serach_component.UseVisualStyleBackColor = true;
            this.button_serach_component.Click += new System.EventHandler(this.button_serach_component_Click);
            // 
            // textBox_productcode_tosearch
            // 
            this.textBox_productcode_tosearch.Location = new System.Drawing.Point(12, 35);
            this.textBox_productcode_tosearch.Name = "textBox_productcode_tosearch";
            this.textBox_productcode_tosearch.Size = new System.Drawing.Size(111, 19);
            this.textBox_productcode_tosearch.TabIndex = 7;
            // 
            // textBox_querry_mmb
            // 
            this.textBox_querry_mmb.Location = new System.Drawing.Point(220, 399);
            this.textBox_querry_mmb.Multiline = true;
            this.textBox_querry_mmb.Name = "textBox_querry_mmb";
            this.textBox_querry_mmb.Size = new System.Drawing.Size(172, 24);
            this.textBox_querry_mmb.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "クエリを入力";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(602, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(311, 290);
            this.dataGridView1.TabIndex = 10;
            // 
            // label_product_cd
            // 
            this.label_product_cd.AutoSize = true;
            this.label_product_cd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_product_cd.Location = new System.Drawing.Point(13, 12);
            this.label_product_cd.Name = "label_product_cd";
            this.label_product_cd.Size = new System.Drawing.Size(65, 16);
            this.label_product_cd.TabIndex = 11;
            this.label_product_cd.Text = "製品CD";
            // 
            // panel_detail_search
            // 
            this.panel_detail_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_detail_search.Controls.Add(this.button1);
            this.panel_detail_search.Controls.Add(this.button_close_panel_detail_search);
            this.panel_detail_search.Controls.Add(this.comboBox_hokanbasyo);
            this.panel_detail_search.Controls.Add(this.comboBox_oyakoutei);
            this.panel_detail_search.Controls.Add(this.textBox_zaikol);
            this.panel_detail_search.Controls.Add(this.textBox_zaikoh);
            this.panel_detail_search.Controls.Add(this.label2);
            this.panel_detail_search.Controls.Add(this.label1);
            this.panel_detail_search.Controls.Add(this.label4);
            this.panel_detail_search.Location = new System.Drawing.Point(12, 89);
            this.panel_detail_search.Name = "panel_detail_search";
            this.panel_detail_search.Size = new System.Drawing.Size(380, 128);
            this.panel_detail_search.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "さらに詳細";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_close_panel_detail_search
            // 
            this.button_close_panel_detail_search.Location = new System.Drawing.Point(293, 99);
            this.button_close_panel_detail_search.Name = "button_close_panel_detail_search";
            this.button_close_panel_detail_search.Size = new System.Drawing.Size(75, 23);
            this.button_close_panel_detail_search.TabIndex = 14;
            this.button_close_panel_detail_search.Text = "閉じる";
            this.button_close_panel_detail_search.UseVisualStyleBackColor = true;
            this.button_close_panel_detail_search.Click += new System.EventHandler(this.button_close_panel_detail_search_Click);
            // 
            // comboBox_hokanbasyo
            // 
            this.comboBox_hokanbasyo.FormattingEnabled = true;
            this.comboBox_hokanbasyo.Location = new System.Drawing.Point(164, 42);
            this.comboBox_hokanbasyo.Name = "comboBox_hokanbasyo";
            this.comboBox_hokanbasyo.Size = new System.Drawing.Size(121, 20);
            this.comboBox_hokanbasyo.TabIndex = 9;
            // 
            // comboBox_oyakoutei
            // 
            this.comboBox_oyakoutei.FormattingEnabled = true;
            this.comboBox_oyakoutei.Location = new System.Drawing.Point(164, 12);
            this.comboBox_oyakoutei.Name = "comboBox_oyakoutei";
            this.comboBox_oyakoutei.Size = new System.Drawing.Size(121, 20);
            this.comboBox_oyakoutei.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "保管場所";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "親工程";
            // 
            // button_detail_search
            // 
            this.button_detail_search.Location = new System.Drawing.Point(24, 60);
            this.button_detail_search.Name = "button_detail_search";
            this.button_detail_search.Size = new System.Drawing.Size(75, 23);
            this.button_detail_search.TabIndex = 13;
            this.button_detail_search.Text = "詳細条件";
            this.button_detail_search.UseVisualStyleBackColor = true;
            this.button_detail_search.Click += new System.EventHandler(this.button_detail_search_Click);
            // 
            // panel_more_detail_search
            // 
            this.panel_more_detail_search.Controls.Add(this.button_reflect_setting_moredetail);
            this.panel_more_detail_search.Controls.Add(this.textBox_hokanbasyo_moredetail);
            this.panel_more_detail_search.Controls.Add(this.textBox_oyakoute_moredetail);
            this.panel_more_detail_search.Controls.Add(this.button4);
            this.panel_more_detail_search.Controls.Add(this.label5);
            this.panel_more_detail_search.Controls.Add(this.label6);
            this.panel_more_detail_search.Location = new System.Drawing.Point(12, 230);
            this.panel_more_detail_search.Name = "panel_more_detail_search";
            this.panel_more_detail_search.Size = new System.Drawing.Size(380, 128);
            this.panel_more_detail_search.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(293, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "閉じる";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox_zaikoh
            // 
            this.textBox_zaikoh.Location = new System.Drawing.Point(248, 74);
            this.textBox_zaikoh.Name = "textBox_zaikoh";
            this.textBox_zaikoh.Size = new System.Drawing.Size(44, 19);
            this.textBox_zaikoh.TabIndex = 11;
            // 
            // textBox_zaikol
            // 
            this.textBox_zaikol.Location = new System.Drawing.Point(67, 74);
            this.textBox_zaikol.Name = "textBox_zaikol";
            this.textBox_zaikol.Size = new System.Drawing.Size(44, 19);
            this.textBox_zaikol.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(123, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "≦現在在庫数≦";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(16, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "保管場所";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(16, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "親工程";
            // 
            // textBox_oyakoute_moredetail
            // 
            this.textBox_oyakoute_moredetail.Location = new System.Drawing.Point(164, 12);
            this.textBox_oyakoute_moredetail.Name = "textBox_oyakoute_moredetail";
            this.textBox_oyakoute_moredetail.Size = new System.Drawing.Size(121, 19);
            this.textBox_oyakoute_moredetail.TabIndex = 15;
            // 
            // textBox_hokanbasyo_moredetail
            // 
            this.textBox_hokanbasyo_moredetail.Location = new System.Drawing.Point(164, 42);
            this.textBox_hokanbasyo_moredetail.Name = "textBox_hokanbasyo_moredetail";
            this.textBox_hokanbasyo_moredetail.Size = new System.Drawing.Size(121, 19);
            this.textBox_hokanbasyo_moredetail.TabIndex = 16;
            // 
            // button_extract_with_detail
            // 
            this.button_extract_with_detail.Location = new System.Drawing.Point(138, 64);
            this.button_extract_with_detail.Name = "button_extract_with_detail";
            this.button_extract_with_detail.Size = new System.Drawing.Size(254, 23);
            this.button_extract_with_detail.TabIndex = 16;
            this.button_extract_with_detail.Text = "製品CDから部品在庫を検索する(条件指定)";
            this.button_extract_with_detail.UseVisualStyleBackColor = true;
            this.button_extract_with_detail.Click += new System.EventHandler(this.button_extract_with_detail_Click);
            // 
            // button_reflect_setting_moredetail
            // 
            this.button_reflect_setting_moredetail.Location = new System.Drawing.Point(210, 99);
            this.button_reflect_setting_moredetail.Name = "button_reflect_setting_moredetail";
            this.button_reflect_setting_moredetail.Size = new System.Drawing.Size(75, 23);
            this.button_reflect_setting_moredetail.TabIndex = 17;
            this.button_reflect_setting_moredetail.Text = "条件を反映";
            this.button_reflect_setting_moredetail.UseVisualStyleBackColor = true;
            this.button_reflect_setting_moredetail.Click += new System.EventHandler(this.button_reflect_setting_moredetail_Click);
            // 
            // textBox_querry_icb
            // 
            this.textBox_querry_icb.Location = new System.Drawing.Point(220, 429);
            this.textBox_querry_icb.Multiline = true;
            this.textBox_querry_icb.Name = "textBox_querry_icb";
            this.textBox_querry_icb.Size = new System.Drawing.Size(172, 24);
            this.textBox_querry_icb.TabIndex = 17;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 593);
            this.Controls.Add(this.textBox_querry_icb);
            this.Controls.Add(this.button_extract_with_detail);
            this.Controls.Add(this.panel_more_detail_search);
            this.Controls.Add(this.button_detail_search);
            this.Controls.Add(this.panel_detail_search);
            this.Controls.Add(this.label_product_cd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_querry_mmb);
            this.Controls.Add(this.textBox_productcode_tosearch);
            this.Controls.Add(this.button_serach_component);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_csvout);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_detail_search.ResumeLayout(false);
            this.panel_detail_search.PerformLayout();
            this.panel_more_detail_search.ResumeLayout(false);
            this.panel_more_detail_search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_csvout;
        private System.Windows.Forms.CheckedListBox checkedListBox_display_column;
        private System.Windows.Forms.Label label_display_column;
        private System.Windows.Forms.CheckedListBox checkedListBox_serach_column;
        private System.Windows.Forms.Label label_search_column;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_serach_component;
        private System.Windows.Forms.TextBox textBox_productcode_tosearch;
        private System.Windows.Forms.TextBox textBox_querry_mmb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_product_cd;
        private System.Windows.Forms.Panel panel_detail_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_hokanbasyo;
        private System.Windows.Forms.ComboBox comboBox_oyakoutei;
        private System.Windows.Forms.Button button_detail_search;
        private System.Windows.Forms.Button button_close_panel_detail_search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_more_detail_search;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox_zaikoh;
        private System.Windows.Forms.TextBox textBox_zaikol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_hokanbasyo_moredetail;
        private System.Windows.Forms.TextBox textBox_oyakoute_moredetail;
        private System.Windows.Forms.Button button_extract_with_detail;
        private System.Windows.Forms.Button button_reflect_setting_moredetail;
        private System.Windows.Forms.TextBox textBox_querry_icb;
    }
}