
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkedListBox_ZaikoOrigin_keihi = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ZaikoOrigin_hokan = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ZaikoOrigin_koutei = new System.Windows.Forms.CheckedListBox();
            this.button_ExtractedProduct_Display = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(250, 425);
            this.dataGridView1.TabIndex = 0;
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
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(340, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(455, 425);
            this.dataGridView2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBox_ZaikoOrigin_koutei);
            this.panel1.Controls.Add(this.checkedListBox_ZaikoOrigin_hokan);
            this.panel1.Controls.Add(this.checkedListBox_ZaikoOrigin_keihi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(33, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 311);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "フィルタ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(337, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "使用製品リスト";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "材料、在庫数、使われてる製品、その製品何個分の在庫があるか、";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(957, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "作れる製品数の最小値/製品数　＜　２０以下を抽出する的な。\r\n危険そうな在庫を抽出する。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(887, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(365, 36);
            this.label6.TabIndex = 6;
            this.label6.Text = "１，アッセイ管理の部品を選ぶ\r\n２，使用製品リスト（アッセイでかかわる製品）から危険そうな材料を抽出する。\r\n３，発注残を確認";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(887, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "出荷する製品とその数。\r\n";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.panel2.Location = new System.Drawing.Point(1043, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 184);
            this.panel2.TabIndex = 10;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "在庫データに反映する。";
            this.button1.UseVisualStyleBackColor = true;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(143, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "1つ前に戻る。";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(365, 398);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 211);
            this.panel3.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "使用製品CD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "材料CD";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "クエリ入力";
            // 
            // checkedListBox_ZaikoOrigin_keihi
            // 
            this.checkedListBox_ZaikoOrigin_keihi.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_keihi.Location = new System.Drawing.Point(20, 31);
            this.checkedListBox_ZaikoOrigin_keihi.Name = "checkedListBox_ZaikoOrigin_keihi";
            this.checkedListBox_ZaikoOrigin_keihi.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_keihi.TabIndex = 1;
            // 
            // checkedListBox_ZaikoOrigin_hokan
            // 
            this.checkedListBox_ZaikoOrigin_hokan.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_hokan.Location = new System.Drawing.Point(116, 31);
            this.checkedListBox_ZaikoOrigin_hokan.Name = "checkedListBox_ZaikoOrigin_hokan";
            this.checkedListBox_ZaikoOrigin_hokan.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_hokan.TabIndex = 2;
            // 
            // checkedListBox_ZaikoOrigin_koutei
            // 
            this.checkedListBox_ZaikoOrigin_koutei.FormattingEnabled = true;
            this.checkedListBox_ZaikoOrigin_koutei.Location = new System.Drawing.Point(212, 31);
            this.checkedListBox_ZaikoOrigin_koutei.Name = "checkedListBox_ZaikoOrigin_koutei";
            this.checkedListBox_ZaikoOrigin_koutei.Size = new System.Drawing.Size(90, 186);
            this.checkedListBox_ZaikoOrigin_koutei.TabIndex = 3;
            // 
            // button_ExtractedProduct_Display
            // 
            this.button_ExtractedProduct_Display.Location = new System.Drawing.Point(108, 18);
            this.button_ExtractedProduct_Display.Name = "button_ExtractedProduct_Display";
            this.button_ExtractedProduct_Display.Size = new System.Drawing.Size(213, 23);
            this.button_ExtractedProduct_Display.TabIndex = 11;
            this.button_ExtractedProduct_Display.Text = "選択した在庫から使用製品を抽出する。";
            this.button_ExtractedProduct_Display.UseVisualStyleBackColor = true;
            // 
            // 部品在庫管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 621);
            this.Controls.Add(this.button_ExtractedProduct_Display);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "部品在庫管理";
            this.Text = "部品在庫管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Button button_ExtractedProduct_Display;
    }
}