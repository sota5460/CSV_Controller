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
    public partial class Form2 : Form
    {
        
        public DataTable Component_Table_ICB;
        public DataTable Component_Table_MMB;

        public DataTable component_list = new DataTable(); //製品コードから構成部品を抽出し、その在庫を格納。（列名は在庫リストと同じ。）



        public Form2()
        {
            InitializeComponent();
        }

        public void read_database_column()
        {
            //foreach (DataColumn column in Component_Table_ICB.Columns)
            //{
            //    checkedListBox_display_column.Items.Add(column);
            //    Console.WriteLine(column);
            //}

            //foreach (DataColumn column in Component_Table_MMB.Columns)
            //{
            //    checkedListBox_display_column.Items.Add(column);
            //    Console.WriteLine(column);
            //}


                foreach (DataColumn column in Component_Table_MMB.Columns)
                {
                //checkedListBox_display_column.Items.Add(Component_Table_MMB.Rows[0][column]); //一行目の列名をチェックボックスに反映する。
                checkedListBox_display_column.Items.Add(column.ColumnName);
            }

            //foreach (DataRow row in Component_Table_MMB.Rows)
            //{
            //    foreach (DataColumn column in Component_Table_MMB.Columns)
            //    {
            //        Console.WriteLine(row[column]);
            //    }
            //}

            Console.WriteLine(Component_Table_MMB.Rows[0][0]);
            Console.WriteLine(Component_Table_MMB.Rows[0][0].ToString().Length);
        }

        public void init_component_list() //component_listに列名を追加する。
        {
            foreach (DataColumn column in Component_Table_ICB.Columns)  //列の名前を追加する。
            {
                component_list.Columns.Add(column.ColumnName, typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
        private void button_serach_component_Click(object sender, EventArgs e)
        {
            init_component_list();

            string component_cd = textBox_productcode_tosearch.Text;
            DataTable search_components = Component_Table_MMB.AsEnumerable().Where(x => (string)x["選択品目ＣＤ"] == component_cd).CopyToDataTable(); //検索が一個も引っかからないとエラーになる。

            Console.WriteLine(search_components.Rows[0][7]);
            Console.WriteLine(Component_Table_MMB.Rows[0][7].ToString().Length);

            int i = 0;
            foreach (DataRow row in search_components.Rows)
            {
                if(Component_Table_ICB.AsEnumerable().Any(x => (string)x["品目ＣＤ"] == (string)row["子品目コード"])==true) //copytodatatable使うときデータが一個も引っかからないとエラーになる。Any（）で存在チェックしてから使うのがテンプレ。
                {
                    component_list.Merge((Component_Table_ICB.AsEnumerable().Where(x => (string)x["品目ＣＤ"] == (string)row[7]).CopyToDataTable()));
                    //component_list.Rows.Add(Component_Table_ICB.AsEnumerable().Where(x => (string)x["品目ＣＤ"] == (string)row[7]).CopyToDataTable());
                    //component_list.Rows.Add(Component_Table_ICB.AsEnumerable().Where(x => (string)x["品目ＣＤ"] == (string)row["選択品目ＣＤ"]).CopyToDataTable());
                    i++;
                    
                }
                
            }

            Console.WriteLine(component_list.Rows[0][1].ToString());
            Console.WriteLine(component_list.Rows[1][1]);
            Console.WriteLine("aaa");
            Console.WriteLine(component_list.Rows[0][7].ToString().Length);
            Console.WriteLine("row num is {0} ", i);

        }
    }
}
