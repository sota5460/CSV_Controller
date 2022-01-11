
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 378);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "製品CDから部品在庫を検索する";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(287, 435);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 19);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(226, 470);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 61);
            this.textBox2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "クエリを入力";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(226, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(311, 290);
            this.dataGridView1.TabIndex = 10;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 593);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_csvout);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}