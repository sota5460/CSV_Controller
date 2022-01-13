
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_serach_component = new System.Windows.Forms.Button();
            this.textBox_productcode_tosearch = new System.Windows.Forms.TextBox();
            this.textBox_querry_mmb = new System.Windows.Forms.TextBox();
            this.dataGridView_result = new System.Windows.Forms.DataGridView();
            this.label_product_cd = new System.Windows.Forms.Label();
            this.panel_detail_search = new System.Windows.Forms.Panel();
            this.button_extract_detail = new System.Windows.Forms.Button();
            this.button_close_panel_detail_search = new System.Windows.Forms.Button();
            this.comboBox_hokanbasyo = new System.Windows.Forms.ComboBox();
            this.button_reflect_setting_moredetail = new System.Windows.Forms.Button();
            this.comboBox_oyakoutei = new System.Windows.Forms.ComboBox();
            this.textBox_zaikol = new System.Windows.Forms.TextBox();
            this.textBox_zaikoh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_detail_search = new System.Windows.Forms.Button();
            this.panel_querry_search = new System.Windows.Forms.Panel();
            this.button_querry_extract = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_querry_icb = new System.Windows.Forms.TextBox();
            this.button_panel_querry_close = new System.Windows.Forms.Button();
            this.button_extract_with_detail = new System.Windows.Forms.Button();
            this.checkedListBox_keihi = new System.Windows.Forms.CheckedListBox();
            this.panel_table_extract = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_result)).BeginInit();
            this.panel_detail_search.SuspendLayout();
            this.panel_querry_search.SuspendLayout();
            this.panel_table_extract.SuspendLayout();
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
            // 
            // checkedListBox_display_column
            // 
            this.checkedListBox_display_column.FormattingEnabled = true;
            this.checkedListBox_display_column.Location = new System.Drawing.Point(12, 29);
            this.checkedListBox_display_column.Name = "checkedListBox_display_column";
            this.checkedListBox_display_column.Size = new System.Drawing.Size(120, 130);
            this.checkedListBox_display_column.TabIndex = 1;
            this.checkedListBox_display_column.SelectedValueChanged += new System.EventHandler(this.checkedListBox_display_column_SelectedValueChanged);
            // 
            // label_display_column
            // 
            this.label_display_column.AutoSize = true;
            this.label_display_column.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_display_column.Location = new System.Drawing.Point(9, 8);
            this.label_display_column.Name = "label_display_column";
            this.label_display_column.Size = new System.Drawing.Size(55, 15);
            this.label_display_column.TabIndex = 2;
            this.label_display_column.Text = "表示列";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBox_display_column);
            this.panel1.Controls.Add(this.label_display_column);
            this.panel1.Location = new System.Drawing.Point(1059, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 178);
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
            this.textBox_querry_mmb.Location = new System.Drawing.Point(174, 18);
            this.textBox_querry_mmb.Multiline = true;
            this.textBox_querry_mmb.Name = "textBox_querry_mmb";
            this.textBox_querry_mmb.Size = new System.Drawing.Size(192, 24);
            this.textBox_querry_mmb.TabIndex = 8;
            // 
            // dataGridView_result
            // 
            this.dataGridView_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_result.Location = new System.Drawing.Point(417, 35);
            this.dataGridView_result.Name = "dataGridView_result";
            this.dataGridView_result.RowTemplate.Height = 21;
            this.dataGridView_result.Size = new System.Drawing.Size(626, 437);
            this.dataGridView_result.TabIndex = 10;
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
            this.panel_detail_search.Controls.Add(this.button_extract_detail);
            this.panel_detail_search.Controls.Add(this.button_close_panel_detail_search);
            this.panel_detail_search.Controls.Add(this.comboBox_hokanbasyo);
            this.panel_detail_search.Controls.Add(this.button_reflect_setting_moredetail);
            this.panel_detail_search.Controls.Add(this.comboBox_oyakoutei);
            this.panel_detail_search.Controls.Add(this.textBox_zaikol);
            this.panel_detail_search.Controls.Add(this.textBox_zaikoh);
            this.panel_detail_search.Controls.Add(this.label2);
            this.panel_detail_search.Controls.Add(this.label1);
            this.panel_detail_search.Controls.Add(this.label4);
            this.panel_detail_search.Location = new System.Drawing.Point(12, 136);
            this.panel_detail_search.Name = "panel_detail_search";
            this.panel_detail_search.Size = new System.Drawing.Size(380, 171);
            this.panel_detail_search.TabIndex = 12;
            // 
            // button_extract_detail
            // 
            this.button_extract_detail.Location = new System.Drawing.Point(291, 111);
            this.button_extract_detail.Name = "button_extract_detail";
            this.button_extract_detail.Size = new System.Drawing.Size(75, 23);
            this.button_extract_detail.TabIndex = 18;
            this.button_extract_detail.Text = "抽出する";
            this.button_extract_detail.UseVisualStyleBackColor = true;
            this.button_extract_detail.Click += new System.EventHandler(this.button_extract_detail_Click);
            // 
            // button_close_panel_detail_search
            // 
            this.button_close_panel_detail_search.Location = new System.Drawing.Point(292, 143);
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
            // button_reflect_setting_moredetail
            // 
            this.button_reflect_setting_moredetail.Location = new System.Drawing.Point(210, 111);
            this.button_reflect_setting_moredetail.Name = "button_reflect_setting_moredetail";
            this.button_reflect_setting_moredetail.Size = new System.Drawing.Size(75, 23);
            this.button_reflect_setting_moredetail.TabIndex = 17;
            this.button_reflect_setting_moredetail.Text = "条件を反映";
            this.button_reflect_setting_moredetail.UseVisualStyleBackColor = true;
            this.button_reflect_setting_moredetail.Click += new System.EventHandler(this.button_reflect_setting_moredetail_Click);
            // 
            // comboBox_oyakoutei
            // 
            this.comboBox_oyakoutei.FormattingEnabled = true;
            this.comboBox_oyakoutei.Location = new System.Drawing.Point(164, 12);
            this.comboBox_oyakoutei.Name = "comboBox_oyakoutei";
            this.comboBox_oyakoutei.Size = new System.Drawing.Size(121, 20);
            this.comboBox_oyakoutei.TabIndex = 8;
            // 
            // textBox_zaikol
            // 
            this.textBox_zaikol.Location = new System.Drawing.Point(67, 74);
            this.textBox_zaikol.Name = "textBox_zaikol";
            this.textBox_zaikol.Size = new System.Drawing.Size(44, 19);
            this.textBox_zaikol.TabIndex = 10;
            // 
            // textBox_zaikoh
            // 
            this.textBox_zaikoh.Location = new System.Drawing.Point(248, 74);
            this.textBox_zaikoh.Name = "textBox_zaikoh";
            this.textBox_zaikoh.Size = new System.Drawing.Size(44, 19);
            this.textBox_zaikoh.TabIndex = 11;
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
            // button_detail_search
            // 
            this.button_detail_search.Location = new System.Drawing.Point(139, 64);
            this.button_detail_search.Name = "button_detail_search";
            this.button_detail_search.Size = new System.Drawing.Size(253, 23);
            this.button_detail_search.TabIndex = 13;
            this.button_detail_search.Text = "条件を指定して部品在庫を検索する";
            this.button_detail_search.UseVisualStyleBackColor = true;
            this.button_detail_search.Click += new System.EventHandler(this.button_detail_search_Click);
            // 
            // panel_querry_search
            // 
            this.panel_querry_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_querry_search.Controls.Add(this.button_querry_extract);
            this.panel_querry_search.Controls.Add(this.label5);
            this.panel_querry_search.Controls.Add(this.label3);
            this.panel_querry_search.Controls.Add(this.textBox_querry_icb);
            this.panel_querry_search.Controls.Add(this.button_panel_querry_close);
            this.panel_querry_search.Controls.Add(this.textBox_querry_mmb);
            this.panel_querry_search.Location = new System.Drawing.Point(12, 313);
            this.panel_querry_search.Name = "panel_querry_search";
            this.panel_querry_search.Size = new System.Drawing.Size(380, 159);
            this.panel_querry_search.TabIndex = 15;
            // 
            // button_querry_extract
            // 
            this.button_querry_extract.Location = new System.Drawing.Point(291, 102);
            this.button_querry_extract.Name = "button_querry_extract";
            this.button_querry_extract.Size = new System.Drawing.Size(75, 23);
            this.button_querry_extract.TabIndex = 19;
            this.button_querry_extract.Text = "抽出する";
            this.button_querry_extract.UseVisualStyleBackColor = true;
            this.button_querry_extract.Click += new System.EventHandler(this.button_querry_extract_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "在庫表のクエリ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "部品構成リストのクエリ";
            // 
            // textBox_querry_icb
            // 
            this.textBox_querry_icb.Location = new System.Drawing.Point(174, 48);
            this.textBox_querry_icb.Multiline = true;
            this.textBox_querry_icb.Name = "textBox_querry_icb";
            this.textBox_querry_icb.Size = new System.Drawing.Size(192, 24);
            this.textBox_querry_icb.TabIndex = 17;
            // 
            // button_panel_querry_close
            // 
            this.button_panel_querry_close.Location = new System.Drawing.Point(292, 131);
            this.button_panel_querry_close.Name = "button_panel_querry_close";
            this.button_panel_querry_close.Size = new System.Drawing.Size(75, 23);
            this.button_panel_querry_close.TabIndex = 14;
            this.button_panel_querry_close.Text = "閉じる";
            this.button_panel_querry_close.UseVisualStyleBackColor = true;
            this.button_panel_querry_close.Click += new System.EventHandler(this.button_panel_querry_close_Click);
            // 
            // button_extract_with_detail
            // 
            this.button_extract_with_detail.Location = new System.Drawing.Point(139, 97);
            this.button_extract_with_detail.Name = "button_extract_with_detail";
            this.button_extract_with_detail.Size = new System.Drawing.Size(254, 23);
            this.button_extract_with_detail.TabIndex = 16;
            this.button_extract_with_detail.Text = "クエリから部品在庫を検索する";
            this.button_extract_with_detail.UseVisualStyleBackColor = true;
            this.button_extract_with_detail.Click += new System.EventHandler(this.button_extract_with_detail_Click);
            // 
            // checkedListBox_keihi
            // 
            this.checkedListBox_keihi.FormattingEnabled = true;
            this.checkedListBox_keihi.Location = new System.Drawing.Point(13, 19);
            this.checkedListBox_keihi.Name = "checkedListBox_keihi";
            this.checkedListBox_keihi.Size = new System.Drawing.Size(120, 46);
            this.checkedListBox_keihi.TabIndex = 3;
            this.checkedListBox_keihi.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_keihi_SelectedIndexChanged);
            // 
            // panel_table_extract
            // 
            this.panel_table_extract.Controls.Add(this.checkedListBox_keihi);
            this.panel_table_extract.Location = new System.Drawing.Point(417, 478);
            this.panel_table_extract.Name = "panel_table_extract";
            this.panel_table_extract.Size = new System.Drawing.Size(626, 88);
            this.panel_table_extract.TabIndex = 17;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 593);
            this.Controls.Add(this.panel_table_extract);
            this.Controls.Add(this.button_extract_with_detail);
            this.Controls.Add(this.panel_querry_search);
            this.Controls.Add(this.button_detail_search);
            this.Controls.Add(this.panel_detail_search);
            this.Controls.Add(this.label_product_cd);
            this.Controls.Add(this.dataGridView_result);
            this.Controls.Add(this.textBox_productcode_tosearch);
            this.Controls.Add(this.button_serach_component);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_csvout);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_result)).EndInit();
            this.panel_detail_search.ResumeLayout(false);
            this.panel_detail_search.PerformLayout();
            this.panel_querry_search.ResumeLayout(false);
            this.panel_querry_search.PerformLayout();
            this.panel_table_extract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_csvout;
        private System.Windows.Forms.CheckedListBox checkedListBox_display_column;
        private System.Windows.Forms.Label label_display_column;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_serach_component;
        private System.Windows.Forms.TextBox textBox_productcode_tosearch;
        private System.Windows.Forms.TextBox textBox_querry_mmb;
        private System.Windows.Forms.DataGridView dataGridView_result;
        private System.Windows.Forms.Label label_product_cd;
        private System.Windows.Forms.Panel panel_detail_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_hokanbasyo;
        private System.Windows.Forms.ComboBox comboBox_oyakoutei;
        private System.Windows.Forms.Button button_detail_search;
        private System.Windows.Forms.Button button_close_panel_detail_search;
        private System.Windows.Forms.Panel panel_querry_search;
        private System.Windows.Forms.Button button_panel_querry_close;
        private System.Windows.Forms.TextBox textBox_zaikoh;
        private System.Windows.Forms.TextBox textBox_zaikol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_extract_with_detail;
        private System.Windows.Forms.Button button_reflect_setting_moredetail;
        private System.Windows.Forms.TextBox textBox_querry_icb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_extract_detail;
        private System.Windows.Forms.Button button_querry_extract;
        private System.Windows.Forms.CheckedListBox checkedListBox_keihi;
        private System.Windows.Forms.Panel panel_table_extract;
    }
}