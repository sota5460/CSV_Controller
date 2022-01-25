
namespace MicosController
{
    partial class ASSY部品出庫
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
            this.dataGridView_ZaikoDisplay = new System.Windows.Forms.DataGridView();
            this.textBox_ProductName = new System.Windows.Forms.TextBox();
            this.textBox_ProductNum = new System.Windows.Forms.TextBox();
            this.textBox_ProductCD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Display_ZaikoData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_selectedPMT = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button_CreateLabel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_selectedPMT)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_ZaikoDisplay
            // 
            this.dataGridView_ZaikoDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ZaikoDisplay.Location = new System.Drawing.Point(6, 10);
            this.dataGridView_ZaikoDisplay.Name = "dataGridView_ZaikoDisplay";
            this.dataGridView_ZaikoDisplay.RowTemplate.Height = 21;
            this.dataGridView_ZaikoDisplay.Size = new System.Drawing.Size(738, 551);
            this.dataGridView_ZaikoDisplay.TabIndex = 0;
            this.dataGridView_ZaikoDisplay.Font=new System.Drawing.Font(dataGridView_ZaikoDisplay.Font.Name, 12);
            // 
            // textBox_ProductName
            // 
            this.textBox_ProductName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_ProductName.Location = new System.Drawing.Point(91, 45);
            this.textBox_ProductName.Name = "textBox_ProductName";
            this.textBox_ProductName.Size = new System.Drawing.Size(156, 23);
            this.textBox_ProductName.TabIndex = 1;
            // 
            // textBox_ProductNum
            // 
            this.textBox_ProductNum.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_ProductNum.Location = new System.Drawing.Point(172, 84);
            this.textBox_ProductNum.Name = "textBox_ProductNum";
            this.textBox_ProductNum.Size = new System.Drawing.Size(75, 23);
            this.textBox_ProductNum.TabIndex = 2;
            // 
            // textBox_ProductCD
            // 
            this.textBox_ProductCD.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_ProductCD.Location = new System.Drawing.Point(91, 11);
            this.textBox_ProductCD.Name = "textBox_ProductCD";
            this.textBox_ProductCD.Size = new System.Drawing.Size(156, 23);
            this.textBox_ProductCD.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "外注に送る材料を在庫データに反映する。";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "一つ前に戻る。";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "元に戻す。";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(1041, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 136);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "製品CD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "製品名";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_Display_ZaikoData);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_ProductCD);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox_ProductName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_ProductNum);
            this.panel2.Location = new System.Drawing.Point(12, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 164);
            this.panel2.TabIndex = 12;
            // 
            // button_Display_ZaikoData
            // 
            this.button_Display_ZaikoData.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Display_ZaikoData.Location = new System.Drawing.Point(6, 125);
            this.button_Display_ZaikoData.Name = "button_Display_ZaikoData";
            this.button_Display_ZaikoData.Size = new System.Drawing.Size(241, 23);
            this.button_Display_ZaikoData.TabIndex = 13;
            this.button_Display_ZaikoData.Text = "集める材料を表示";
            this.button_Display_ZaikoData.UseVisualStyleBackColor = true;
            this.button_Display_ZaikoData.Click += new System.EventHandler(this.button_Display_ZaikoData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "数量";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(268, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(758, 593);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_ZaikoDisplay);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(750, 567);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "外注先に送る材料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_selectedPMT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(750, 567);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "選択したPMT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_selectedPMT
            // 
            this.dataGridView_selectedPMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_selectedPMT.Location = new System.Drawing.Point(6, 10);
            this.dataGridView_selectedPMT.Name = "dataGridView_selectedPMT";
            this.dataGridView_selectedPMT.RowTemplate.Height = 21;
            this.dataGridView_selectedPMT.Size = new System.Drawing.Size(738, 150);
            this.dataGridView_selectedPMT.TabIndex = 15;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(18, 375);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(241, 220);
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(233, 194);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "表示列";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(233, 194);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "並び替え";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "受注製品";
            // 
            // button_CreateLabel
            // 
            this.button_CreateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_CreateLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_CreateLabel.Location = new System.Drawing.Point(1129, 220);
            this.button_CreateLabel.Name = "button_CreateLabel";
            this.button_CreateLabel.Size = new System.Drawing.Size(193, 33);
            this.button_CreateLabel.TabIndex = 16;
            this.button_CreateLabel.Text = "ラベルを作成する。";
            this.button_CreateLabel.UseVisualStyleBackColor = false;
            this.button_CreateLabel.Click += new System.EventHandler(this.button_CreateLabel_Click);
            // 
            // ASSY部品出庫
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 626);
            this.Controls.Add(this.button_CreateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ASSY部品出庫";
            this.Text = "ASSY部品出庫";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ZaikoDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_selectedPMT)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ZaikoDisplay;
        private System.Windows.Forms.TextBox textBox_ProductName;
        private System.Windows.Forms.TextBox textBox_ProductNum;
        private System.Windows.Forms.TextBox textBox_ProductCD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Display_ZaikoData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView_selectedPMT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CreateLabel;
    }
}