using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicosController
{
    public partial class ASSY部品出庫 : Form
    {
        public DataTable ICB_Table { get; set; }
        public DataTable MMB_Table { get; set; }

        DataTableController datacontroller;
        public ASSY部品出庫()
        {
            InitializeComponent();
        }

        public void Init_DataTableController()
        {
            datacontroller = new DataTableController();
            datacontroller.MMB_Table = MMB_Table;
            datacontroller.ICB_Table = ICB_Table;

            datacontroller.Extract_Only_ASSY_MMB(); //ASSY用だから初期化の時点で部品構成MMBﾃｰﾌﾞﾙをアッセイだけにしとく。
        }

        private void button_Display_ZaikoData_Click(object sender, EventArgs e)
        {
            int mode = 0;

            if((textBox_ProductCD.Text =="" && textBox_ProductName.Text == "") ||
               textBox_ProductNum.Text == "" )
            {
                MessageBox.Show("検索対象を入力してください。");
                return;
            }

            if(textBox_ProductCD.TextLength > 6)
            {
                MessageBox.Show("製品CDは6文字以下です。");
                return;
            }

            if (textBox_ProductCD.Text != "")
            {
                mode = 0; //製品CDで検索する。製品CDになにかしらあると強制的に製品CDが優先される。
            }
            else
            {
                mode = 1;　//製品名で検索する。
            }

            float Product_Num;

            switch (mode)
            {
                case (0):
                    string ProductCD = textBox_ProductCD.Text;
                    Product_Num = float.Parse(textBox_ProductNum.Text);
                    datacontroller.Set_OriginMMB_toSimTable();

                    datacontroller.Create_Zaiko_Table_with_ProductCD_ProductNum(ProductCD, Product_Num);

                    dataGridView_ZaikoDisplay.DataSource = datacontroller.Zaiko_Table_afterFilter_Current;

                    datacontroller.Create_ZaikoManufacutureProductTable_fromProductCD(ProductCD, Product_Num);

                    dataGridView_selectedPMT.DataSource = datacontroller.Zaiko_Table_manufactureProduct;
                    break;
                case (1):
                    string ProductName = textBox_ProductName.Text;
                    Product_Num = float.Parse(textBox_ProductNum.Text);
                    datacontroller.Set_OriginMMB_toSimTable();

                    datacontroller.Create_Zaiko_Table_with_ProductName_ProductNum(ProductName, Product_Num);

                    dataGridView_ZaikoDisplay.DataSource = datacontroller.Zaiko_Table_afterFilter_Current;

                    datacontroller.Create_ZaikoManufacutureProductTable_fromProductName(ProductName, Product_Num);

                    dataGridView_selectedPMT.DataSource = datacontroller.Zaiko_Table_manufactureProduct;

                    break;

            }
            

           
        }
    }
}
