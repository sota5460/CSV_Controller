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
    public partial class 部品在庫管理 : Form
    {

        public DataTable Zaiko_Data_Original_Table { get; set; }
        public DataTable Component_Data_Original_Table { get; set; }

        public DataTable Zaiko_Data_Display_Table { get; set; }
        ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// 各材料に対する使用製品に関するﾃｰﾌﾞﾙ
        /// </summary>
        public DataTable Zaiko_ComponentList_Table { get; set; }
        public DataTable Zaiko_ComponentList_Table_afterFilter { get; set; }
        public DataTable cell_component_table { get; set; }


        ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// 各製品に対する材料在庫に関するﾃｰﾌﾞﾙ
        /// </summary>
        public DataTable Product_ZaikoList_Table { get; set; }

        public DataTable cell_component_zaiko_table { get; set; }

        public struct zaiko_info
        {
            public string zairyou_name;　//部品構成リスト、在庫リストから抽出
            public float gennzai_zaiko; //在庫リストから抽出
            public float siyou_suu;　//部品構成リストから抽出
            public string tani;      //部品構成リスト、在庫リストから抽出
            public string hokan_basyo;　//部品構成リスト、在庫リストから抽出
        }

        public struct zairyou_info //部品構成リストの材料情報格納用。
        {
            public string zairyou_code;
            public string zairyou_hokan_basyo;
            public float zairyou_siyousou;
        }

        public struct distinct_zairyo
        {
            public string zairyou_code;
            public string zairyou_hokan_basyo;
        }

        public DataTable notDoublicated_Component_Table { get; set; }

        
        

        public 部品在庫管理()
        {
            InitializeComponent();
            init_form();

            
        }

        public void init_form()
        {
            //パネルdisable
            panel_fitler_zaiko_display.Visible = false;
            panel_fitler_zaiko_display.Enabled = false;
        }



        public void init_Zaiko_Data_Display_Table()
        {
            Zaiko_Data_Display_Table = Zaiko_Data_Original_Table;
            dataGridView_ZaikoDataDisplayTable.DataSource = Zaiko_Data_Display_Table;

            init_checkbox_filter_ZaikoOrigin();
        }
        public void init_checkbox_filter_ZaikoOrigin()
        {
            DataTable notDoublicated_table;
            DataView dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table= dtView.ToTable(true, "保管場所"); //"保管場所"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_hokan.Items.Add(row["保管場所"]); //"保管場所"列の重複してないものをチェックボックスに追加する。
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table = dtView.ToTable(true, "経費"); //"経費"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table = dtView.ToTable(true, "工程"); //"工程"列の重複を取り除く
            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_koutei.Items.Add(row["工程"]); //"工程"列の重複してないものをチェックボックスに追加する。
            }
        }

        ////aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// 各材料の使用製品リストに関する関数たち
        /// </summary>
        ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        public void create_Zaiko_ComponentList_Table()
        {
            Zaiko_ComponentList_Table = new DataTable();

            Zaiko_ComponentList_Table.Columns.Add("品目ＣＤ", typeof(string));
            Zaiko_ComponentList_Table.Columns.Add("保管場所", typeof(string));
            Zaiko_ComponentList_Table.Columns.Add("現在在庫数", typeof(float));
            Zaiko_ComponentList_Table.Columns.Add("使用製品群", typeof(Dictionary<string,float>)); //dictionaryには製品名と材料使用数を入れる。

            

            foreach (DataRow Zaikorow in Zaiko_Data_Display_Table.Rows)
            {

                DataRow row = Zaiko_ComponentList_Table.NewRow(); //初期化
                var dic = new Dictionary<string, float>(); //初期化
                row["品目ＣＤ"] = Zaikorow["品目ＣＤ"].ToString(); //部品材料名を格納
                row["保管場所"] = Zaikorow["保管場所"];
                float current_zaiko = (float)Zaikorow["現在在庫数"];
                row["現在在庫数"] = current_zaiko;

                //foreach (DataRow Componentrow in Component_Data_Original_Table.Rows)
                foreach (DataRow Componentrow in notDoublicated_Component_Table.Rows)
                {
                    if (Zaikorow["品目ＣＤ"].ToString()==Componentrow["子品目コード"].ToString() && Zaikorow["保管場所"].ToString()==Componentrow["標準出庫保管場所"].ToString())
                    {
                        float suuryou = (float)Componentrow["数量"]; //float型で一度キャストして変数に入れないとうまくいかない。
                        dic.Add(Componentrow["選択品目ＣＤ"].ToString(),suuryou);
                    }
                }

                row["使用製品群"] = dic;

                Zaiko_ComponentList_Table.Rows.Add(row);

            }

            dataGridView_ZaikoComponentList.DataSource = Zaiko_ComponentList_Table; 
            Zaiko_ComponentList_Table_afterFilter = Zaiko_ComponentList_Table.Copy();　//オリジナルとフィルター抽出用でﾃｰﾌﾞﾙを分けておく。
        }

        public DataTable Sum_and_DeleteDoublicated_Table(DataTable TargetTable,string groupby_col, string sum_col_name,int sum_col_num, string doublicated_col,string doublicated_col2) //TargetTableを指定した列（groupby_col）で分けたあとで、sum_col_name列の重複を消して、合計値を代わりにだす。計算値はfloat
        {
            DataTable ReturnTable = new DataTable();

            foreach(DataColumn column in TargetTable.Columns) //ReturnTableに列名だけ加えておく。
            {
                ReturnTable.Columns.Add(column.ColumnName, column.DataType);
            }


            DataTable notDoublicated_table = new DataTable();
            DataView dtView = new DataView(TargetTable);

            notDoublicated_table = dtView.ToTable(true, groupby_col);


            //製品リストを作成
            List<string> groupby_list = new List<string>();

            foreach(DataRow row in notDoublicated_table.Rows)
            {
                groupby_list.Add(row[groupby_col].ToString());
            }

            //groupby_colで分けたﾃｰﾌﾞﾙを作って、重複成分を消して合計値を代入したﾃｰﾌﾞﾙを作るっていうのを繰り返す。
            foreach(string list_comp in groupby_list)
            {
                DataTable each_list_table = new DataTable();
                DataTable each_list_table_modified = new DataTable();

                //製品ごとにﾃｰﾌﾞﾙをグループ分けして、ﾃｰﾌﾞﾙに格納する。
                each_list_table = TargetTable.AsEnumerable()
                    .Where(x => (string)x[groupby_col] == list_comp)
                    .CopyToDataTable();

                foreach(DataColumn column in each_list_table.Columns)
                {
                    each_list_table_modified.Columns.Add(column.ColumnName, column.DataType);
                }


                //DataRow DistinctComponent_Row;
                //bool first_flag = true;
              
                float sum = 0;

                foreach(DataRow row1 in each_list_table.Rows)
                {
                    DataRow DistinctComponent_Row = each_list_table_modified.NewRow();
                    foreach (DataRow row2 in each_list_table.Rows)
                    {
                        if (row1[doublicated_col].ToString() == row2[doublicated_col].ToString() && row1[doublicated_col2].ToString() == row2[doublicated_col2].ToString()) //もし重複項目二つあればここに追加する。 && row1[doublicated_col2].ToString() == row2[doublicated_col2].ToString()
                        {
                            //if (first_flag==false)
                            //{
                            //    sum += (float)row2[sum_col_name];
                            //    //doublicated_flag = true;
                            //}

                            //if(first_flag) //初回の重複はフラグを立てて、初期値を代入する。
                            //{
                            //    first_flag = false;
                            //    sum += (float)row2[sum_col_name];
                            //}
                            
                            sum += (float)row2[sum_col_name];

                        }
                    }
                    //first_flag = true;

                    //if(doublicated_flag == false)
                    //{

                    //    //DistinctComponent_Row = row1; //重複してなかったら単にコピー
                    //    for(int i = 0; i < each_list_table.Columns.Count; i++)
                    //    {
                    //        if( i == sum_col_num)
                    //        {
                    //            DistinctComponent_Row[i] = (float)sum;
                    //        }
                    //        else
                    //        {
                    //            DistinctComponent_Row[i] = row1[i].ToString();
                    //        }

                    //    }

                    //}
                    //else
                    //{
                    //    for (int i = 0; i < each_list_table.Columns.Count; i++)
                    //    {
                    //        if (i == sum_col_num)
                    //        {
                    //            DistinctComponent_Row[i] = (float)sum;
                    //        }
                    //        else
                    //        {
                    //            DistinctComponent_Row[i] = row1[i].ToString();
                    //        }

                    //    }


                    //    //DistinctComponent_Row = row1;
                    //    //DistinctComponent_Row[sum_col_name] = sum; //合計値を書き換える。
                    //}

                    for (int i = 0; i < each_list_table.Columns.Count; i++)
                    {
                        if (i == sum_col_num)
                        {
                            DistinctComponent_Row[i] = (float)sum; 
                            sum = 0; //sumを代入したら次のために初期化
                           
                        }
                        else
                        {
                            DistinctComponent_Row[i] = row1[i].ToString();
                        }

                    }

                    bool already_exist = false;

                    foreach(DataRow row in each_list_table_modified.Rows)
                    {
                        if(row[doublicated_col].ToString()==DistinctComponent_Row[doublicated_col].ToString() && row[doublicated_col2].ToString() == DistinctComponent_Row[doublicated_col2].ToString())//今作成したrowがすでにeach_list_table_modifiedに存在するかチェックする。
                        {
                            already_exist = true;
                        }
                    }

                    if(already_exist == false)
                    {
                        each_list_table_modified.Rows.Add(DistinctComponent_Row);
                    }

                    already_exist = false;

                    //each_list_table_modified.Rows.Add(DistinctComponent_Row); //とりあえず重複しているデータもデータﾃｰﾌﾞﾙに格納する。
                    //each_list_table_modified.

                }

                

                //DataView dt = new DataView(each_list_table_modified);
                //each_list_table_modified = dt.ToTable(true, doublicated_col,doublicated_col2); //重複列を消去する。
                //each_list_table_modified = dt.ToTable(true, doublicated_col); //重複列を消去する。

                //DataTable newDT = new DataTable();
                //foreach (DataColumn column in TargetTable.Columns) //ReturnTableに列名だけ加えておく。
                //{
                //    newDT.Columns.Add(column.ColumnName, column.DataType);
                //}

                //newDT = each_list_table_modified.AsEnumerable()
                //    .GroupBy(filter => new {fil_col1 = filter.Field<string>(doublicated_col),fil_col2 = filter.Field<string>(doublicated_col2)})
                //    .Select(x =>
                //    {
                //        DataRow row = newDT.NewRow();
                //        for(int j =0; j < newDT.Columns.Count; j++)
                //        {
                //            row[i] = x
                //        }
                //    })

                ReturnTable.Merge(each_list_table_modified);

                //DataTable notDoublicated_smalltable = new DataTable();
                //DataView dtView_smalltable = new DataView(each_list_table);

                //notDoublicated_smalltable = dtView.ToTable(true, doublicated_col);

                /////
                //var each_material = each_list_table.AsEnumerable().GroupBy(x => x[doublicated_col]);

                //foreach(var single_material in each_material)
                //{
                //    single_material.
                //}
                    

                


            }

            return ReturnTable;
            //var temp_array = TargetTable.AsEnumerable().GroupBy(x => x[groupby_col]);
            
            //foreach(var each_dic in temp_array)
            //{
            //    each_dic
            //}
        }

        public void init_cell_component_table() //セルクリック時のデータﾃｰﾌﾞﾙの列だけ作っとく
        {
            cell_component_table = new DataTable();
            cell_component_table.Columns.Add("選択品目ＣＤ",typeof(string));
            cell_component_table.Columns.Add("数量",typeof(float));
        }
        private void button_create_ZaikoComponentListTable_Click(object sender, EventArgs e)
        {
            notDoublicated_Component_Table = Sum_and_DeleteDoublicated_Table(Component_Data_Original_Table, "選択品目ＣＤ", "数量",10 ,"子品目コード", "標準出庫保管場所");
            
            create_Zaiko_ComponentList_Table();
        }

        private void dataGridView_ZaikoComponentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            init_cell_component_table();
            if(e.ColumnIndex == 3)
            {
                DataRow select_row =Zaiko_ComponentList_Table_afterFilter.Rows[e.RowIndex];
                Dictionary<string,float> dic = (Dictionary<string,float>)select_row["使用製品群"];

                foreach(KeyValuePair<string,float> kvp in dic)
                {
                    DataRow row = cell_component_table.NewRow();
                    row["選択品目ＣＤ"] = kvp.Key;
                    row["数量"] = kvp.Value;

                    cell_component_table.Rows.Add(row);
                }

            }

            dataGridView_cell_component_table.DataSource = cell_component_table;
        }

        private void button_filter_zaikodisplay_open_Click(object sender, EventArgs e)
        {
            panel_fitler_zaiko_display.Visible = true;
            panel_fitler_zaiko_display.Enabled = true;

            button_filter_zaikodisplay_open.Enabled = false;
            button_filter_zaikodisplay_open.Visible = false;
        }

        private void button_panel_fileter_zaikodisplay_close_Click(object sender, EventArgs e)
        {
            panel_fitler_zaiko_display.Visible = false;
            panel_fitler_zaiko_display.Enabled = false;
        }

        private void button_querry_zaikodisplay_Click(object sender, EventArgs e)
        {
            string queery = textBox_querry_zaikodisplay.Text;

            //select(クエリ)で検索になにも引っかからないとエラーになる。Anyかなんかで条件分岐入れた方がいい。s
            Zaiko_Data_Display_Table = Zaiko_Data_Display_Table.Select(queery).CopyToDataTable();

            dataGridView_ZaikoDataDisplayTable.DataSource = Zaiko_Data_Display_Table;
        }
        /// <summary>
        /// 材料とそれを使っている製品ﾃｰﾌﾞﾙのフィルターパネル動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_filter_above_productnum_Click(object sender, EventArgs e)
        {

            string text = textBox_filter_above_productnum.Text;
            int filter = int.Parse(text);

            int original_rownum = Zaiko_ComponentList_Table_afterFilter.Rows.Count;
            int row_cnt = 0;
            for(int i = 0; i < original_rownum; i ++)  //forループの中でDatatableの行を削除していくので、index番号がずれていく。⇒別に行用のカウンターを作って行を削除したときはカウンターを上げないようにした。
            {
                DataRow row = Zaiko_ComponentList_Table_afterFilter.Rows[row_cnt];
                Dictionary<string, float> dic = (Dictionary<string, float>)row["使用製品群"];
                if (dic.Count < filter) //使用製品群がfilter(int)よりも大きければ。
                {
                    Zaiko_ComponentList_Table_afterFilter.Rows.Remove(row);
                    row_cnt--;
                }
                row_cnt++;
            }

            dataGridView_ZaikoComponentList.DataSource = Zaiko_ComponentList_Table_afterFilter; 
        }

        private void button_filter_below_productnum_Click(object sender, EventArgs e)
        {

        }

        private void button_filter_equal_productnum_Click(object sender, EventArgs e)
        {

        }

        private void button_filter_usedproductname_Click(object sender, EventArgs e)
        {

        }

        private void button_querry_ZaikoComponentList_Click(object sender, EventArgs e)
        {

        }

        private void button_release_filter_zaikocomponent_Click(object sender, EventArgs e)
        {
            Zaiko_ComponentList_Table_afterFilter = Zaiko_ComponentList_Table.Copy();
            dataGridView_ZaikoComponentList.DataSource = Zaiko_ComponentList_Table_afterFilter;
        }
        ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// 製品とそれに使う材料に関するﾃｰﾌﾞﾙの関数たち
        /// </summary>
        /// aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        public void create_ProductZaikoList()
        {
            Product_ZaikoList_Table = new DataTable();

            Product_ZaikoList_Table.Columns.Add("選択品目ＣＤ", typeof(string));
            Product_ZaikoList_Table.Columns.Add("製造可能数", typeof(int));
            Product_ZaikoList_Table.Columns.Add("現在在庫数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("現在仕掛数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("使用材料群", typeof(Dictionary<distinct_zairyo, zaiko_info>)); //dictionaryには材料名と材料情報（構造体で型宣言）を入れる。
            //Product_ZaikoList_Table.Columns.Add("使用材料群", typeof(Dictionary<string, float>)); //dictionaryには材料名と現在在庫を入れる。

            //抽出した在庫を含む製品をコレクションに格納する。
            List<string> Product_List = new List<string>();

            foreach(DataRow row_zaiko in Zaiko_Data_Display_Table.Rows)
            {
                foreach(DataRow row_comp in Component_Data_Original_Table.Rows)
                {
                    if (row_zaiko["品目ＣＤ"].ToString() == row_comp["子品目コード"].ToString() && row_zaiko["保管場所"].ToString() == row_comp["標準出庫保管場所"].ToString())
                    {
                        if (Product_List.Contains(row_comp["選択品目ＣＤ"]) != true) //もしまだリストに製品ＣＤが存在しなければ追加する。
                        {
                            Product_List.Add(row_comp["選択品目ＣＤ"].ToString());
                        }
                       
                    }
                }
                
            }

            foreach(string product_name in Product_List)
            {
                //それぞれの製品CD毎にDataRowとzaiko_infoを作成していく。
                DataRow ProductZaiko_row = Product_ZaikoList_Table.NewRow();
                ProductZaiko_row["選択品目ＣＤ"] = product_name;

                string product_name_modified_sixletters = product_name.PadLeft(6,'0'); ;
                //product_name_modified_sixletters =Text.PadLeft(6, '0');
                DataTable genzai_zaiko_sikakari = Zaiko_Data_Original_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == product_name_modified_sixletters).CopyToDataTable();
                ProductZaiko_row["現在仕掛数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在仕掛数"]; //０行目固定。1つの製品品目CDに二つ以上の行があると適切に動かない。
                ProductZaiko_row["現在在庫数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在在庫数"];

                ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                ///使用材料軍列を作成する処理。dic_zairyougun（Dictionay）を作成するための処理
                ///
                Dictionary<distinct_zairyo, zaiko_info> dic_zairyougun = new Dictionary<distinct_zairyo, zaiko_info>();

                //それぞれの製品が使用する構成部品リストを製品毎に作成する。
                List<zairyou_info> Component_List = new List<zairyou_info>();

                foreach (DataRow row in Component_Data_Original_Table.Rows)
                {
                   

                    if(product_name == row["選択品目ＣＤ"].ToString())
                    {
                        //if(Component_List.Contains(item.))
                        zairyou_info zairyou = new zairyou_info();
                        zairyou.zairyou_code = row["子品目コード"].ToString();
                        zairyou.zairyou_hokan_basyo = row["標準出庫保管場所"].ToString();
                        zairyou.zairyou_siyousou = (float)row["数量"];

                        

                        Component_List.Add(zairyou);
                    }
                }

                //同じ製品の中で同じ材料、保管場所のものが二回以上使われているパターンがある。⇒重複した材料の数量を足し合わせる。
                List<zairyou_info> Component_List_notDoublicated = new List<zairyou_info>();
                bool first_flag = true;
                bool doublicated_flag = false;
                float sum = 0;
                foreach(zairyou_info each_zaryou1 in Component_List)
                {
                    foreach(zairyou_info each_zairyou2 in Component_List)
                    {
                        if(each_zaryou1.zairyou_code == each_zairyou2.zairyou_code && each_zaryou1.zairyou_hokan_basyo == each_zairyou2.zairyou_hokan_basyo)
                        {
                            if(first_flag == false)
                            {
                                doublicated_flag = true;
                            }
                            if (first_flag)
                            {
                                first_flag = false;
                            }

                            sum += each_zairyou2.zairyou_siyousou;
                            
                        }
                    }

                    zairyou_info notDoublicated_zairyou = new zairyou_info();
                    notDoublicated_zairyou = each_zaryou1;
                    notDoublicated_zairyou.zairyou_siyousou = sum;

                    if (doublicated_flag == false)
                    {
                        Component_List_notDoublicated.Add(notDoublicated_zairyou);
                    }
                    else
                    {
                        bool already_exist_flag = false;
                        foreach(zairyou_info exisit_zairyou in Component_List_notDoublicated)
                        {
                            if (exisit_zairyou.Equals(notDoublicated_zairyou))
                            {
                                already_exist_flag = true;
                            }
                        }
                        if(already_exist_flag != false)
                        {
                            Component_List_notDoublicated.Add(notDoublicated_zairyou);
                        }

                    }

                    
                    first_flag = true;
                    doublicated_flag = false;
                }

                

                //Dictionaryに格納するためのzaiko_infor構造体を作成するための処理。

                foreach(zairyou_info each_zairyou in Component_List_notDoublicated)
                {
                    zaiko_info z_info = new zaiko_info();
                    z_info.siyou_suu = each_zairyou.zairyou_siyousou; //使用数だけ部品構成リストからの情報を使わないといけない。

                    foreach (DataRow row in Zaiko_Data_Display_Table.Rows)
                    {
                        if(each_zairyou.zairyou_code == row["品目ＣＤ"].ToString() && each_zairyou.zairyou_hokan_basyo == row["保管場所"].ToString())
                        {
                            z_info.zairyou_name = row["品目ＣＤ"].ToString();
                           // z_info.tani = row["単位"].ToString();
                            z_info.hokan_basyo = row["保管場所"].ToString();
                            z_info.gennzai_zaiko = (float)row["現在在庫数"];
                           
                        }
                    }

                    //Dictionaryに各対象部品を追加する。
                    distinct_zairyo d_zairyou = new distinct_zairyo() { zairyou_code = each_zairyou.zairyou_code, zairyou_hokan_basyo = each_zairyou.zairyou_hokan_basyo };
                    dic_zairyougun.Add(d_zairyou, z_info);
                }

                ProductZaiko_row["使用材料群"] = dic_zairyougun;

                ProductZaiko_row["製造可能数"] = calculate_production_num(dic_zairyougun);
                
                Product_ZaikoList_Table.Rows.Add(ProductZaiko_row);

            }

            dataGridView_ProductZaikoList.DataSource = Product_ZaikoList_Table;

        }

        public float calculate_production_num(Dictionary<distinct_zairyo, zaiko_info> target_dic)
        {
            float max_product_num = 0;
            bool first_flag = true;

            foreach (zaiko_info each_zaiko in target_dic.Values)
            {
                if (first_flag)
                {
                    max_product_num = each_zaiko.gennzai_zaiko / each_zaiko.siyou_suu;
                    first_flag = false;
                }
                if(first_flag  == false)
                {
                    if (max_product_num > each_zaiko.gennzai_zaiko / each_zaiko.siyou_suu) //注意；最小の値が生産可能最大数になる。
                    {
                        max_product_num = each_zaiko.gennzai_zaiko / each_zaiko.siyou_suu;
                    }

                }

            }

            return max_product_num;
        }

        private void button_createProductZaikoListTable_Click(object sender, EventArgs e)
        {
            create_ProductZaikoList();
        }

        public void init_cell_component_zaiko_table()
        {
            cell_component_zaiko_table = new DataTable();
            cell_component_zaiko_table.Columns.Add("品目ＣＤ", typeof(string));
            cell_component_zaiko_table.Columns.Add("現在在庫数", typeof(float));
            cell_component_zaiko_table.Columns.Add("使用数", typeof(float));
            cell_component_zaiko_table.Columns.Add("保管場所", typeof(string));
        }


        private void dataGridView_ProductZaikoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            init_cell_component_zaiko_table();
            if (e.ColumnIndex == 4)
            {
                DataRow select_row = Product_ZaikoList_Table.Rows[e.RowIndex];
                Dictionary<distinct_zairyo, zaiko_info> dic = (Dictionary<distinct_zairyo, zaiko_info>)select_row["使用材料群"];
                //Dictionary<string, float> dic = Dictionary<string, float>)select_row["使用製品群"];

                foreach (KeyValuePair<distinct_zairyo, zaiko_info> kvp in dic)
                {
                    DataRow row = cell_component_zaiko_table.NewRow();
                    row["品目ＣＤ"] = kvp.Key.zairyou_code;
                    row["現在在庫数"] = kvp.Value.gennzai_zaiko;
                    row["使用数"] = kvp.Value.siyou_suu;
                    row["保管場所"] = kvp.Value.hokan_basyo;

                    cell_component_zaiko_table.Rows.Add(row);
                }

                dataGridView_cellComponentZaikoTable.DataSource = cell_component_zaiko_table;

            }
        }
    }
}
