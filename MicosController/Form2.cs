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

        public DataTable search_components_detail;

        //重複消去するためオブジェクト　
        public DataTable notDublicated; //重複を消したﾃｰﾌﾞﾙ
        public DataView dtView;　// ﾃｰﾌﾞﾙ操作するためのオブジェクト。

        //検索条件用の変数
        public string component_cd;
        public string oya_koutei = "???";
        public string hokan_basyo = "???????";
        public float zaiko_l=0;
        public float zaiko_h=100000000;

        public string querry_statement = "[親工程] LIKE '%%'";
        public string querry_mmb = "";
        public string querry_icb = "";



        public Form2()
        {
            InitializeComponent();

            init_component();
        }

        public void init_component()
        {
            panel_detail_search.Visible = false;
            panel_detail_search.Enabled = false;

            panel_querry_search.Visible = false;
            panel_querry_search.Enabled = false;


            textBox_zaikoh.Text = zaiko_l.ToString();
            textBox_zaikol.Text = zaiko_h.ToString();
        }

        public void read_database_column() //データベースを読んで、チェックボックスに項目を追加する。
        {
            //表示列項目の追加
            foreach (DataColumn column in Component_Table_MMB.Columns)
            {
            checkedListBox_display_column.Items.Add(column.ColumnName);　// Component_Table_MMBﾃｰﾌﾞﾙの列名をチェックボックスに反映する。
            }

            //データ抽出設定の親工程項目の追加
            dtView = new DataView(Component_Table_MMB);
            notDublicated = dtView.ToTable(true,"親工程"); //DataViewオブジェクトにデータﾃｰﾌﾞﾙを読んで、"親工程"親工程の重複を消去してる。

            foreach (DataRow row in notDublicated.Rows){
                comboBox_oyakoutei.Items.Add(row["親工程"]);
            }

            //データ抽出設定の保管場所項目の追加
            notDublicated = dtView.ToTable(true, "標準出庫保管場所");

            foreach (DataRow row in notDublicated.Rows)
            {
                comboBox_hokanbasyo.Items.Add(row["標準出庫保管場所"]);
            }

            init_component_list();

            Console.WriteLine(Component_Table_MMB.Rows[0][0]);
            Console.WriteLine(Component_Table_MMB.Rows[0][0].ToString().Length);
        }

        public void init_component_list() //component_listに列名を追加する。
        {
            foreach (DataColumn column in Component_Table_ICB.Columns)  //列の名前を追加する。
            {
                if (column.ColumnName =="現在在庫数")
                {
                    component_list.Columns.Add(column.ColumnName, typeof(float)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                }
                else
                {
                    component_list.Columns.Add(column.ColumnName, typeof(string)); //すべてstringとして格納する。とりあえずstringで格納して、後で変換すればいい。
                }
                
            }
        }

        public void read_setting_moredetail()
        {
            oya_koutei = comboBox_oyakoutei.SelectedItem.ToString();
            hokan_basyo = comboBox_hokanbasyo.SelectedItem.ToString();
            zaiko_l = float.Parse(textBox_zaikol.Text);
            zaiko_h = float.Parse(textBox_zaikoh.Text);
        }


        
        private void button_serach_component_Click(object sender, EventArgs e)
        {
            if (textBox_productcode_tosearch.Text == "")
            {
                MessageBox.Show("品目CDを入力してください。");
                return;
            }
            else
            {
                component_cd = textBox_productcode_tosearch.Text.PadLeft(6, '0'); //6文字で0左詰め
            }

            component_cd = textBox_productcode_tosearch.Text.PadLeft(6,'0'); //6文字で0左詰め
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

        private void detail_search()
        {
            if (textBox_productcode_tosearch.Text == "")
            {
                MessageBox.Show("品目CDを入力してください。");
                return;
            }
            else
            {
                component_cd = textBox_productcode_tosearch.Text.PadLeft(6, '0'); //6文字で0左詰め
            }


            if (Component_Table_MMB.AsEnumerable()
                .Any(x => (string)x["選択品目ＣＤ"] == component_cd && (string)x["親工程"] == oya_koutei) == true)
            {
                search_components_detail = Component_Table_MMB.AsEnumerable()
               .Where(x => (string)x["選択品目ＣＤ"] == component_cd && (string)x["親工程"] == oya_koutei)

               .CopyToDataTable(); //検索が一個も引っかからないとエラーになる。
            }
            else
            {
                MessageBox.Show("条件にあうデータがありません。");
                return;
            }

            //Component_Table_MMB.Rows["親工程"].

            //Console.WriteLine(search_components_detail.Rows[0][7]);
            //Console.WriteLine(Component_Table_MMB.Rows[0][7].ToString().Length);
            int i = 0;
            foreach (DataRow row in search_components_detail.Rows)
            {
                if (Component_Table_ICB.AsEnumerable().Any(x => (string)x["品目ＣＤ"] == (string)row["子品目コード"] && (string)x["保管場所"] == hokan_basyo && zaiko_l <= (float)x["現在在庫数"] && zaiko_h >= (float)x["現在在庫数"]))//copytodatatable使うときデータが一個も引っかからないとエラーになる。Any（）で存在チェックしてから使うのがテンプレ。
                {
                    component_list.Merge((Component_Table_ICB.AsEnumerable()
                        .Where(x => (string)x["品目ＣＤ"] == (string)row["子品目コード"] && (string)x["保管場所"] == hokan_basyo && zaiko_l <= (float)x["現在在庫数"] && zaiko_h >= (float)x["現在在庫数"])
                        .CopyToDataTable()));
                    i++;
                }
            }
            Console.WriteLine("{0}個のデータが見つかりました。", i);
        }

        private void detail_search_byQuerry()
        {

            //品目CDの入力確認と代入
            if (textBox_productcode_tosearch.Text == "")
            {
                MessageBox.Show("品目CDを入力してください。");
                return;
            }
            else
            {
                component_cd = textBox_productcode_tosearch.Text.PadLeft(6, '0'); //6文字で0左詰め
            }

            //クエリの入力確認と代入
            if (textBox_querry_mmb.Text == "" || textBox_querry_icb.Text == "")
            {
                MessageBox.Show("クエリを入力してください。");
                return;
            }
            else
            {
                querry_icb = textBox_querry_icb.Text;
                querry_mmb = textBox_querry_mmb.Text;
                //クエリ文の作成
                querry_mmb = "選択品目ＣＤ " + "LIKE " + "'" + component_cd + "'" + " AND " + querry_mmb;
            }


            //クエリ文で部品構成リスト(mmbファイル)から特定製品の部品を抽出して、新しいﾃｰﾌﾞﾙに格納する。
            if (Component_Table_MMB.Select(querry_mmb).Length != 0)
            {
                search_components_detail = Component_Table_MMB.Select(querry_mmb).CopyToDataTable();
            }
            else
            {
                MessageBox.Show("条件にあうデータがありません。");
                return;
            }


            //部品構成リストから抽出した部品の在庫を在庫リスト（icbファイル）から抽出する。
            int i = 0;
            foreach (DataRow row in search_components_detail.Rows)
            {
                //クエリ文の作成
                string kohinmoku = row["子品目コード"].ToString();
                querry_icb = "品目ＣＤ " + "LIKE " + "'" + kohinmoku + "'" + " AND " + querry_mmb;

                if (Component_Table_ICB.Select(querry_icb).Length != 0)
                {
                    component_list.Merge((Component_Table_ICB.Select(querry_icb).CopyToDataTable()));
                    i++;
                }
            }
            Console.WriteLine("{0}個のデータが見つかりました。", i);
        }

        private void button_detail_search_Click(object sender, EventArgs e)
        {
            panel_detail_search.Visible = true;
            panel_detail_search.Enabled = true;
        }

        private void button_close_panel_detail_search_Click(object sender, EventArgs e)
        {
            panel_detail_search.Visible = false;
            panel_detail_search.Enabled = false;
        }

        private void button_reflect_setting_moredetail_Click(object sender, EventArgs e)
        {
            read_setting_moredetail();
        }



        private void button_extract_with_detail_Click(object sender, EventArgs e)
        {
            panel_querry_search.Enabled = true;
            panel_querry_search.Visible = true;
        }

        private void button_panel_querry_close_Click(object sender, EventArgs e)
        {
            panel_querry_search.Visible = false;
            panel_querry_search.Enabled = false;
        }

        private void button_querry_extract_Click(object sender, EventArgs e)
        {
            detail_search_byQuerry();
        }

        private void button_extract_detail_Click(object sender, EventArgs e)
        {
            detail_search();
        }
    }
}
