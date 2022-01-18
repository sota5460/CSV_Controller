
namespace MicosController
{
    partial class Tanaoroshi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tanaoroshi));
            this.dataGridView_CurrentMicos = new System.Windows.Forms.DataGridView();
            this.dataGridView_ActualZaiko = new System.Windows.Forms.DataGridView();
            this.dataGridView_Difference_Table = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox_CurrentMicos_keihi = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ActualZaiko_keihi = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_filepath_micos = new System.Windows.Forms.TextBox();
            this.button_fileselect_micos = new System.Windows.Forms.Button();
            this.textBox_filepath_zaiko = new System.Windows.Forms.TextBox();
            this.button_fileselect_zaiko = new System.Windows.Forms.Button();
            this.button_create_diffrencetable = new System.Windows.Forms.Button();
            this.checkedListBox_currentMicos_hokan = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_currentMicos_koutei = new System.Windows.Forms.CheckedListBox();
            this.button_filter_Micos = new System.Windows.Forms.Button();
            this.textBox_queeryStatement = new System.Windows.Forms.TextBox();
            this.button_extract_queeryStatement = new System.Windows.Forms.Button();
            this.button_csv_templateOut = new System.Windows.Forms.Button();
            this.panel_adjust_micos = new System.Windows.Forms.Panel();
            this.checkedListBox_adjust_hokanbasyo = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_adjust_micos = new System.Windows.Forms.Button();
            this.button_zaiko_adjust_screen = new System.Windows.Forms.Button();
            this.OpenMicos_btn = new System.Windows.Forms.Button();
            this.button_Micos_csv = new System.Windows.Forms.Button();
            this.textBox_howtoquerry = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CurrentMicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ActualZaiko)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Difference_Table)).BeginInit();
            this.panel_adjust_micos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_CurrentMicos
            // 
            this.dataGridView_CurrentMicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CurrentMicos.Location = new System.Drawing.Point(12, 50);
            this.dataGridView_CurrentMicos.Name = "dataGridView_CurrentMicos";
            this.dataGridView_CurrentMicos.RowTemplate.Height = 21;
            this.dataGridView_CurrentMicos.Size = new System.Drawing.Size(400, 380);
            this.dataGridView_CurrentMicos.TabIndex = 0;
            // 
            // dataGridView_ActualZaiko
            // 
            this.dataGridView_ActualZaiko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ActualZaiko.Location = new System.Drawing.Point(439, 50);
            this.dataGridView_ActualZaiko.Name = "dataGridView_ActualZaiko";
            this.dataGridView_ActualZaiko.RowTemplate.Height = 21;
            this.dataGridView_ActualZaiko.Size = new System.Drawing.Size(400, 380);
            this.dataGridView_ActualZaiko.TabIndex = 1;
            // 
            // dataGridView_Difference_Table
            // 
            this.dataGridView_Difference_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Difference_Table.Location = new System.Drawing.Point(1065, 50);
            this.dataGridView_Difference_Table.Name = "dataGridView_Difference_Table";
            this.dataGridView_Difference_Table.RowTemplate.Height = 21;
            this.dataGridView_Difference_Table.Size = new System.Drawing.Size(300, 380);
            this.dataGridView_Difference_Table.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "現在Micos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(435, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "実在庫";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(1061, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Micosと実在庫の差異";
            // 
            // checkedListBox_CurrentMicos_keihi
            // 
            this.checkedListBox_CurrentMicos_keihi.FormattingEnabled = true;
            this.checkedListBox_CurrentMicos_keihi.Location = new System.Drawing.Point(12, 434);
            this.checkedListBox_CurrentMicos_keihi.Name = "checkedListBox_CurrentMicos_keihi";
            this.checkedListBox_CurrentMicos_keihi.Size = new System.Drawing.Size(199, 46);
            this.checkedListBox_CurrentMicos_keihi.TabIndex = 7;
            // 
            // checkedListBox_ActualZaiko_keihi
            // 
            this.checkedListBox_ActualZaiko_keihi.FormattingEnabled = true;
            this.checkedListBox_ActualZaiko_keihi.Location = new System.Drawing.Point(439, 436);
            this.checkedListBox_ActualZaiko_keihi.Name = "checkedListBox_ActualZaiko_keihi";
            this.checkedListBox_ActualZaiko_keihi.Size = new System.Drawing.Size(199, 46);
            this.checkedListBox_ActualZaiko_keihi.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_filepath_micos
            // 
            this.textBox_filepath_micos.Location = new System.Drawing.Point(241, 437);
            this.textBox_filepath_micos.Multiline = true;
            this.textBox_filepath_micos.Name = "textBox_filepath_micos";
            this.textBox_filepath_micos.Size = new System.Drawing.Size(170, 45);
            this.textBox_filepath_micos.TabIndex = 9;
            // 
            // button_fileselect_micos
            // 
            this.button_fileselect_micos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_fileselect_micos.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_fileselect_micos.Location = new System.Drawing.Point(241, 488);
            this.button_fileselect_micos.Name = "button_fileselect_micos";
            this.button_fileselect_micos.Size = new System.Drawing.Size(170, 35);
            this.button_fileselect_micos.TabIndex = 10;
            this.button_fileselect_micos.Text = "Micos在庫ファイルを選択する";
            this.button_fileselect_micos.UseVisualStyleBackColor = false;
            this.button_fileselect_micos.Click += new System.EventHandler(this.button_fileselect_micos_Click);
            // 
            // textBox_filepath_zaiko
            // 
            this.textBox_filepath_zaiko.Location = new System.Drawing.Point(669, 437);
            this.textBox_filepath_zaiko.Multiline = true;
            this.textBox_filepath_zaiko.Name = "textBox_filepath_zaiko";
            this.textBox_filepath_zaiko.Size = new System.Drawing.Size(170, 45);
            this.textBox_filepath_zaiko.TabIndex = 11;
            // 
            // button_fileselect_zaiko
            // 
            this.button_fileselect_zaiko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_fileselect_zaiko.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_fileselect_zaiko.Location = new System.Drawing.Point(669, 488);
            this.button_fileselect_zaiko.Name = "button_fileselect_zaiko";
            this.button_fileselect_zaiko.Size = new System.Drawing.Size(170, 35);
            this.button_fileselect_zaiko.TabIndex = 12;
            this.button_fileselect_zaiko.Text = "実在庫ファイルを選択する";
            this.button_fileselect_zaiko.UseVisualStyleBackColor = false;
            this.button_fileselect_zaiko.Click += new System.EventHandler(this.button_fileselect_zaiko_Click);
            // 
            // button_create_diffrencetable
            // 
            this.button_create_diffrencetable.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_create_diffrencetable.Location = new System.Drawing.Point(855, 212);
            this.button_create_diffrencetable.Name = "button_create_diffrencetable";
            this.button_create_diffrencetable.Size = new System.Drawing.Size(204, 71);
            this.button_create_diffrencetable.TabIndex = 13;
            this.button_create_diffrencetable.Text = "Micosと実在庫の差を表示";
            this.button_create_diffrencetable.UseVisualStyleBackColor = true;
            this.button_create_diffrencetable.Click += new System.EventHandler(this.button_create_diffrencetable_Click);
            // 
            // checkedListBox_currentMicos_hokan
            // 
            this.checkedListBox_currentMicos_hokan.FormattingEnabled = true;
            this.checkedListBox_currentMicos_hokan.Location = new System.Drawing.Point(12, 488);
            this.checkedListBox_currentMicos_hokan.Name = "checkedListBox_currentMicos_hokan";
            this.checkedListBox_currentMicos_hokan.Size = new System.Drawing.Size(199, 46);
            this.checkedListBox_currentMicos_hokan.TabIndex = 14;
            // 
            // checkedListBox_currentMicos_koutei
            // 
            this.checkedListBox_currentMicos_koutei.FormattingEnabled = true;
            this.checkedListBox_currentMicos_koutei.Location = new System.Drawing.Point(12, 540);
            this.checkedListBox_currentMicos_koutei.Name = "checkedListBox_currentMicos_koutei";
            this.checkedListBox_currentMicos_koutei.Size = new System.Drawing.Size(199, 46);
            this.checkedListBox_currentMicos_koutei.TabIndex = 15;
            // 
            // button_filter_Micos
            // 
            this.button_filter_Micos.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_filter_Micos.Location = new System.Drawing.Point(12, 592);
            this.button_filter_Micos.Name = "button_filter_Micos";
            this.button_filter_Micos.Size = new System.Drawing.Size(199, 34);
            this.button_filter_Micos.TabIndex = 16;
            this.button_filter_Micos.Text = "フィルタで抽出";
            this.button_filter_Micos.UseVisualStyleBackColor = true;
            this.button_filter_Micos.Click += new System.EventHandler(this.button_filter_Micos_Click);
            // 
            // textBox_queeryStatement
            // 
            this.textBox_queeryStatement.Location = new System.Drawing.Point(225, 580);
            this.textBox_queeryStatement.Name = "textBox_queeryStatement";
            this.textBox_queeryStatement.Size = new System.Drawing.Size(187, 19);
            this.textBox_queeryStatement.TabIndex = 17;
            this.textBox_queeryStatement.MouseHover += new System.EventHandler(this.textBox_queeryStatement_MouseHover);
            // 
            // button_extract_queeryStatement
            // 
            this.button_extract_queeryStatement.Location = new System.Drawing.Point(225, 605);
            this.button_extract_queeryStatement.Name = "button_extract_queeryStatement";
            this.button_extract_queeryStatement.Size = new System.Drawing.Size(136, 23);
            this.button_extract_queeryStatement.TabIndex = 18;
            this.button_extract_queeryStatement.Text = "クエリで抽出";
            this.button_extract_queeryStatement.UseVisualStyleBackColor = true;
            this.button_extract_queeryStatement.Click += new System.EventHandler(this.button_extract_queeryStatement_Click);
            // 
            // button_csv_templateOut
            // 
            this.button_csv_templateOut.Location = new System.Drawing.Point(455, 603);
            this.button_csv_templateOut.Name = "button_csv_templateOut";
            this.button_csv_templateOut.Size = new System.Drawing.Size(268, 23);
            this.button_csv_templateOut.TabIndex = 20;
            this.button_csv_templateOut.Text = "実在庫用テンプレートを出力";
            this.button_csv_templateOut.UseVisualStyleBackColor = true;
            this.button_csv_templateOut.Click += new System.EventHandler(this.button_csv_templateOut_Click);
            // 
            // panel_adjust_micos
            // 
            this.panel_adjust_micos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_adjust_micos.Controls.Add(this.checkedListBox_adjust_hokanbasyo);
            this.panel_adjust_micos.Controls.Add(this.label4);
            this.panel_adjust_micos.Controls.Add(this.button_adjust_micos);
            this.panel_adjust_micos.Controls.Add(this.button_zaiko_adjust_screen);
            this.panel_adjust_micos.Controls.Add(this.OpenMicos_btn);
            this.panel_adjust_micos.Location = new System.Drawing.Point(1065, 448);
            this.panel_adjust_micos.Name = "panel_adjust_micos";
            this.panel_adjust_micos.Size = new System.Drawing.Size(300, 151);
            this.panel_adjust_micos.TabIndex = 21;
            // 
            // checkedListBox_adjust_hokanbasyo
            // 
            this.checkedListBox_adjust_hokanbasyo.FormattingEnabled = true;
            this.checkedListBox_adjust_hokanbasyo.Location = new System.Drawing.Point(187, 42);
            this.checkedListBox_adjust_hokanbasyo.Name = "checkedListBox_adjust_hokanbasyo";
            this.checkedListBox_adjust_hokanbasyo.Size = new System.Drawing.Size(108, 88);
            this.checkedListBox_adjust_hokanbasyo.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = " Micosの数を在庫数に合わせる。";
            // 
            // button_adjust_micos
            // 
            this.button_adjust_micos.Location = new System.Drawing.Point(6, 117);
            this.button_adjust_micos.Name = "button_adjust_micos";
            this.button_adjust_micos.Size = new System.Drawing.Size(162, 23);
            this.button_adjust_micos.TabIndex = 2;
            this.button_adjust_micos.Text = "在庫調整を行う";
            this.button_adjust_micos.UseVisualStyleBackColor = true;
            this.button_adjust_micos.Click += new System.EventHandler(this.button_adjust_micos_Click);
            // 
            // button_zaiko_adjust_screen
            // 
            this.button_zaiko_adjust_screen.Location = new System.Drawing.Point(6, 77);
            this.button_zaiko_adjust_screen.Name = "button_zaiko_adjust_screen";
            this.button_zaiko_adjust_screen.Size = new System.Drawing.Size(162, 23);
            this.button_zaiko_adjust_screen.TabIndex = 1;
            this.button_zaiko_adjust_screen.Text = "在庫調整画面へ";
            this.button_zaiko_adjust_screen.UseVisualStyleBackColor = true;
            this.button_zaiko_adjust_screen.Click += new System.EventHandler(this.button_zaiko_adjust_screen_Click);
            // 
            // OpenMicos_btn
            // 
            this.OpenMicos_btn.Location = new System.Drawing.Point(6, 42);
            this.OpenMicos_btn.Name = "OpenMicos_btn";
            this.OpenMicos_btn.Size = new System.Drawing.Size(162, 23);
            this.OpenMicos_btn.TabIndex = 0;
            this.OpenMicos_btn.Text = "Micosを開く";
            this.OpenMicos_btn.UseVisualStyleBackColor = true;
            this.OpenMicos_btn.Click += new System.EventHandler(this.OpenMicos_btn_Click);
            // 
            // button_Micos_csv
            // 
            this.button_Micos_csv.Location = new System.Drawing.Point(455, 551);
            this.button_Micos_csv.Name = "button_Micos_csv";
            this.button_Micos_csv.Size = new System.Drawing.Size(268, 46);
            this.button_Micos_csv.TabIndex = 22;
            this.button_Micos_csv.Text = "抽出したMicosデータをCSV出力";
            this.button_Micos_csv.UseVisualStyleBackColor = true;
            this.button_Micos_csv.Click += new System.EventHandler(this.button_Micos_csv_Click);
            // 
            // textBox_howtoquerry
            // 
            this.textBox_howtoquerry.Location = new System.Drawing.Point(439, 488);
            this.textBox_howtoquerry.Multiline = true;
            this.textBox_howtoquerry.Name = "textBox_howtoquerry";
            this.textBox_howtoquerry.Size = new System.Drawing.Size(332, 151);
            this.textBox_howtoquerry.TabIndex = 23;
            this.textBox_howtoquerry.Text = resources.GetString("textBox_howtoquerry.Text");
            // 
            // Tanaoroshi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 649);
            this.Controls.Add(this.textBox_howtoquerry);
            this.Controls.Add(this.button_extract_queeryStatement);
            this.Controls.Add(this.textBox_queeryStatement);
            this.Controls.Add(this.button_Micos_csv);
            this.Controls.Add(this.panel_adjust_micos);
            this.Controls.Add(this.button_csv_templateOut);
            this.Controls.Add(this.button_filter_Micos);
            this.Controls.Add(this.checkedListBox_currentMicos_koutei);
            this.Controls.Add(this.checkedListBox_currentMicos_hokan);
            this.Controls.Add(this.button_create_diffrencetable);
            this.Controls.Add(this.button_fileselect_zaiko);
            this.Controls.Add(this.textBox_filepath_zaiko);
            this.Controls.Add(this.button_fileselect_micos);
            this.Controls.Add(this.textBox_filepath_micos);
            this.Controls.Add(this.checkedListBox_ActualZaiko_keihi);
            this.Controls.Add(this.checkedListBox_CurrentMicos_keihi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Difference_Table);
            this.Controls.Add(this.dataGridView_ActualZaiko);
            this.Controls.Add(this.dataGridView_CurrentMicos);
            this.Name = "Tanaoroshi";
            this.Text = "Tanaoroshi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CurrentMicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ActualZaiko)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Difference_Table)).EndInit();
            this.panel_adjust_micos.ResumeLayout(false);
            this.panel_adjust_micos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_CurrentMicos;
        private System.Windows.Forms.DataGridView dataGridView_ActualZaiko;
        private System.Windows.Forms.DataGridView dataGridView_Difference_Table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBox_CurrentMicos_keihi;
        private System.Windows.Forms.CheckedListBox checkedListBox_ActualZaiko_keihi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_filepath_micos;
        private System.Windows.Forms.Button button_fileselect_micos;
        private System.Windows.Forms.TextBox textBox_filepath_zaiko;
        private System.Windows.Forms.Button button_fileselect_zaiko;
        private System.Windows.Forms.Button button_create_diffrencetable;
        private System.Windows.Forms.CheckedListBox checkedListBox_currentMicos_hokan;
        private System.Windows.Forms.CheckedListBox checkedListBox_currentMicos_koutei;
        private System.Windows.Forms.Button button_filter_Micos;
        private System.Windows.Forms.TextBox textBox_queeryStatement;
        private System.Windows.Forms.Button button_extract_queeryStatement;
        private System.Windows.Forms.Button button_csv_templateOut;
        private System.Windows.Forms.Panel panel_adjust_micos;
        private System.Windows.Forms.Button button_adjust_micos;
        private System.Windows.Forms.Button button_zaiko_adjust_screen;
        private System.Windows.Forms.Button OpenMicos_btn;
        private System.Windows.Forms.Button button_Micos_csv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox_adjust_hokanbasyo;
        private System.Windows.Forms.TextBox textBox_howtoquerry;
    }
}