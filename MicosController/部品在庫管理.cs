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
        public DataTable Product_ZaikoList_Table_afterFitler { get; set; }

        public DataTable cell_component_zaiko_table { get; set; }

        ///<summary>
        /// シュミレーション用のﾃｰﾌﾞﾙ
        /// </summary>
        public DataTable zaiko_sim_table { get; set; }
        public DataTable Current_Zaiko_Data_SimulationTable { get; set; }
        public DataTable Previous_Zaiko_Data_SimulationTable { get; set; }

        bool exisit_previoustable_flag = false;


        public struct zaiko_info
        {
            public string zairyou_name;　//部品構成リスト、在庫リストから抽出 品目CD
            public string zairyou_hinmei;
            public float gennzai_zaiko; //在庫リストから抽出
            public float siyou_suu;　//部品構成リストから抽出
            public string oyakoutei;      //部品構成リスト、在庫リストから抽出
            public string level;
            public string hokan_basyo;　//部品構成リスト、在庫リストから抽出
        }

        public struct zairyou_info //部品構成リストの材料情報格納用。
        {
            public string zairyou_code;
            public string zairyou_hinmei;
            public string zairyou_hokan_basyo;
            public float zairyou_siyousou;
            public string zairyou_oyakoutei;
            public string zairyou_level;
        }

        public struct distinct_zairyo
        {
            public string zairyou_code;
            public string zairyou_hokan_basyo;
        }

        public struct hinmei_cd_set
        {
            public string cd;
            public string hinmei;
        }

        public DataTable notDoublicated_Component_Table { get; set; }

        
        

        public 部品在庫管理()
        {
            InitializeComponent();
            init_form();

            
        }

        public void init_form()
        {
            
        }


        /// <summary>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// 一番左の在庫リストに関する関数
        /// </summary>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        public void init_Zaiko_Data_Display_Table()
        {
            Zaiko_Data_Display_Table = Zaiko_Data_Original_Table.Copy();
            dataGridView_ZaikoDataDisplayTable.DataSource = Zaiko_Data_Display_Table;
            

            init_checkbox_filter_ZaikoOrigin();
            create_checkbox_fromTableColumn(Zaiko_Data_Original_Table, checkedListBox_Display_ZaikoOriginCol);

        }
        /// <summary>
        /// フィルター用チェックボックスの生成
        /// </summary>
        public void init_checkbox_filter_ZaikoOrigin()　
        {
            DataTable notDoublicated_table;
            DataView dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table= dtView.ToTable(true, "保管場所"); //"保管場所"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_hokan.Items.Add(row["保管場所"]); //"保管場所"列の重複してないものをチェックボックスに追加する。
            }

            for(int i = 0; i < checkedListBox_ZaikoOrigin_hokan.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_hokan.SetItemChecked(i, true);
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table = dtView.ToTable(true, "経費"); //"経費"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
            }

            for (int i = 0; i < checkedListBox_ZaikoOrigin_keihi.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_keihi.SetItemChecked(i, true);
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Original_Table);

            notDoublicated_table = dtView.ToTable(true, "工程"); //"工程"列の重複を取り除く
            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_koutei.Items.Add(row["工程"]); //"工程"列の重複してないものをチェックボックスに追加する。
            }

            for (int i = 0; i < checkedListBox_ZaikoOrigin_koutei.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_koutei.SetItemChecked(i, true);
            }
        }

        private void button_DisplayZaikoOriginCol_Click(object sender, EventArgs e)
        {
            Select_Grid_Column(dataGridView_ZaikoDataDisplayTable,checkedListBox_Display_ZaikoOriginCol);
        }

        private void button_filter_zaikodisplay_Click(object sender, EventArgs e)
        {
            extract_by_keihi_koutei_hokan(0);
        }

        public void extract_by_keihi_koutei_hokan(int mode) //チェックボックス抽出処理最終版。チェックボックス３つを監視して、チェックあるやつだけグリッドに表示する。
        {

           Zaiko_Data_Display_Table = new DataTable();


            int i = 0;

            string temp_querry_keihi = "";
            string temp_querry_hokan = "";
            string temp_querry_koutei = "";


            foreach (string selected_keihi in  checkedListBox_ZaikoOrigin_keihi.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_keihi = querry_maker_fullmatch(0, "経費", selected_keihi, "");
                }
                else
                {
                    temp_querry_keihi = querry_maker_fullmatch(2, "経費", selected_keihi, temp_querry_keihi);
                }
                i++;
            }

            if (temp_querry_keihi == "")
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }

            if (Zaiko_Data_Original_Table.Select(temp_querry_keihi).Length > 0)
            {
                Zaiko_Data_Display_Table = Zaiko_Data_Original_Table.Select(temp_querry_keihi).CopyToDataTable();
            }
            else
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }

             

            i = 0;

            foreach (string selected_hokan in checkedListBox_ZaikoOrigin_hokan.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_hokan = querry_maker_fullmatch(0, "保管場所", selected_hokan, "");
                }
                else
                {
                    temp_querry_hokan = querry_maker_fullmatch(2, "保管場所", selected_hokan, temp_querry_hokan);
                }
                i++;
            }

            if (temp_querry_hokan == "")
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }
            if (Zaiko_Data_Display_Table.Select(temp_querry_hokan).Length>0)
            {
                Zaiko_Data_Display_Table = Zaiko_Data_Display_Table.Select(temp_querry_hokan).CopyToDataTable();
            }
            else
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }
             

            i = 0;

            foreach (string selected_koutei in checkedListBox_ZaikoOrigin_koutei.CheckedItems)
            {
                if (i == 0)
                {
                    temp_querry_koutei = querry_maker_fullmatch(0, "工程", selected_koutei, "");
                }
                else
                {
                    temp_querry_koutei = querry_maker_fullmatch(2, "工程", selected_koutei, temp_querry_koutei);
                }
                i++;
            }

            if (temp_querry_koutei == "")
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }

            if (Zaiko_Data_Display_Table.Select(temp_querry_koutei).Length>0)
            {
                Zaiko_Data_Display_Table = Zaiko_Data_Display_Table.Select(temp_querry_koutei).CopyToDataTable();
            }
            else
            {
                dataGridView_ZaikoDataDisplayTable.DataSource = null;
                return;
            }

             


            dataGridView_ZaikoDataDisplayTable.DataSource = Zaiko_Data_Display_Table;

        }

        public string querry_maker_fullmatch(int and_or, string column_name, string target, string combine_querry) //querry作成関数。 第一引数 0: 結合なし　1: ANDで結合 2:ORで結合
        {
            string Querry = "";
            switch (and_or)
            {
                case (0):
                    Querry = column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
                case (1):
                    Querry = combine_querry + " " + "AND" + " " + column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
                case (2):
                    Querry = combine_querry + " " + "OR" + " " + column_name + " " + "LIKE" + " " + "'" + target + "'";
                    break;
            }
            return Querry;
        }
        /// <summary>
        /// 抽出フィルタのチェックをまとめてつけるボタンまとめ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ZaikoOrigin_keihi_allcheck_Click(object sender, EventArgs e)
        {
            for(int i = 0;i <  checkedListBox_ZaikoOrigin_keihi.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_keihi.SetItemChecked(i, true);
            }
            
        }

        private void button_ZaikoOrigin_keihi_alluncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_ZaikoOrigin_keihi.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_keihi.SetItemChecked(i, false);
            }
        }

        private void button_ZaikoOrigin_hokan_allcheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_ZaikoOrigin_hokan.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_hokan.SetItemChecked(i, true);
            }
        }

        private void button_ZaikoOrigin_hokan_alluncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_ZaikoOrigin_hokan.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_hokan.SetItemChecked(i, false);
            }
        }

        private void button_ZaikoOrigin_kouteiallcheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_ZaikoOrigin_koutei.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_koutei.SetItemChecked(i, true);
            }
        }

        private void button_ZaikoOrigin_kouteialluncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_ZaikoOrigin_koutei.Items.Count; i++)
            {
                checkedListBox_ZaikoOrigin_koutei.SetItemChecked(i, false);
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
            Product_ZaikoList_Table.Columns.Add("選択品名", typeof(string));
            Product_ZaikoList_Table.Columns.Add("製造可能数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("現在在庫数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("現在仕掛数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("使用材料群", typeof(Dictionary<distinct_zairyo, zaiko_info>)); //dictionaryには材料名と材料情報（構造体で型宣言）を入れる。
            //Product_ZaikoList_Table.Columns.Add("使用材料群", typeof(Dictionary<string, float>)); //dictionaryには材料名と現在在庫を入れる。

            //抽出した在庫を含む製品をコレクションに格納する。
            List<string> Product_List = new List<string>();
            List<hinmei_cd_set> Product_List_withHinmei = new List<hinmei_cd_set>();
            //List<distinct_zairyo> Product_List = new List<distinct_zairyo>();

            foreach(DataRow row_zaiko in Zaiko_Data_Display_Table.Rows)
            {
                foreach(DataRow row_comp in Component_Data_Original_Table.Rows)
                {
                    if (row_zaiko["品目ＣＤ"].ToString() == row_comp["子品目コード"].ToString() && row_zaiko["保管場所"].ToString() == row_comp["標準出庫保管場所"].ToString())
                    {
                        
                        if (Product_List.Contains(row_comp["選択品目ＣＤ"]) != true) //もしまだリストに製品ＣＤが存在しなければ追加する。
                        {
                            Product_List.Add(row_comp["選択品目ＣＤ"].ToString());
                            hinmei_cd_set hinmei_cd = new hinmei_cd_set() { cd = row_comp["選択品目ＣＤ"].ToString(), hinmei = row_comp["選択品名"].ToString() };
                            Product_List_withHinmei.Add(hinmei_cd);
                        }
                       
                    }
                }
                
            }

            foreach(hinmei_cd_set product_name_cd in Product_List_withHinmei)
            {
                //それぞれの製品CD毎にDataRowとzaiko_infoを作成していく。
                DataRow ProductZaiko_row = Product_ZaikoList_Table.NewRow();
                ProductZaiko_row["選択品目ＣＤ"] = product_name_cd.cd;
                ProductZaiko_row["選択品名"] = product_name_cd.hinmei;

                string product_name_modified_sixletters = product_name_cd.cd.PadLeft(6,'0'); ;
                //在庫数が０だと在庫リストに表示されないから条件分岐する。
                if(Zaiko_Data_Original_Table.AsEnumerable().Any(x => x["品目ＣＤ"].ToString() == product_name_modified_sixletters) == false) // //product_nameが在庫リストに存在しないパターン
                {
                    ProductZaiko_row["現在仕掛数"] = 0;
                    ProductZaiko_row["現在在庫数"] = 0;
                } else
                {
                    DataTable genzai_zaiko_sikakari = Zaiko_Data_Original_Table.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == product_name_modified_sixletters).CopyToDataTable();
                    ProductZaiko_row["現在仕掛数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在仕掛数"]; //０行目固定。1つの製品品目CDに二つ以上の行があると適切に動かない。
                    ProductZaiko_row["現在在庫数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在在庫数"];
                }

                //if (product_name_cd.cd == "071419")
                //{
                //    Console.WriteLine("a");
                //}

                ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                ///使用材料軍列を作成する処理。dic_zairyougun（Dictionay）を作成するための処理
                ///
                Dictionary<distinct_zairyo, zaiko_info> dic_zairyougun = new Dictionary<distinct_zairyo, zaiko_info>();

                //それぞれの製品が使用する構成部品リストを製品毎に作成する。
                List<zairyou_info> Component_List = new List<zairyou_info>();

                foreach (DataRow row in Component_Data_Original_Table.Rows)
                {
                   

                    if(product_name_cd.cd == row["選択品目ＣＤ"].ToString())
                    {
                        //if(Component_List.Contains(item.))
                        zairyou_info zairyou = new zairyou_info();
                        zairyou.zairyou_code = row["子品目コード"].ToString();
                        zairyou.zairyou_hinmei = row["子品名"].ToString();
                        zairyou.zairyou_hokan_basyo = row["標準出庫保管場所"].ToString();
                        zairyou.zairyou_siyousou = (float)row["数量"];
                        zairyou.zairyou_level = row["レベル"].ToString();

                        if(row["親工程"].ToString() == "")
                        {
                            int list_num = Component_List.Count;
                            zairyou.zairyou_oyakoutei = Component_List[list_num - 1].zairyou_oyakoutei;
                        }
                        else
                        {
                            zairyou.zairyou_oyakoutei = row["親工程"].ToString();
                        }

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
                    sum = 0; 

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
                    z_info.siyou_suu = each_zairyou.zairyou_siyousou; //使用数は部品構成リストからの情報を使わないといけない。
                    z_info.zairyou_hinmei = each_zairyou.zairyou_hinmei; //品名も部品構成リストから取り出さないといけない。在庫数が0のものは在庫リストに表示されないから。
                    z_info.oyakoutei = each_zairyou.zairyou_oyakoutei;
                    z_info.level = each_zairyou.zairyou_level;
                    //foreach (DataRow row in Zaiko_Data_Display_Table.Rows)
                    foreach(DataRow row in Zaiko_Data_Original_Table.Rows)
                    {
                        if(each_zairyou.zairyou_code == row["品目ＣＤ"].ToString() && each_zairyou.zairyou_hokan_basyo == row["保管場所"].ToString())
                        {
                            z_info.zairyou_name = row["品目ＣＤ"].ToString();
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
            Product_ZaikoList_Table_afterFitler = Product_ZaikoList_Table.Copy();

            create_checkbox_fromTableColumn(Product_ZaikoList_Table_afterFitler, checkedListBox_Display_ProductCol);

        }

        public float calculate_production_num(Dictionary<distinct_zairyo, zaiko_info> target_dic)
        {
            float max_product_num = 0;
            bool first_flag = true;

            foreach (zaiko_info each_zaiko in target_dic.Values)
            {
                if (each_zaiko.gennzai_zaiko < 0 || each_zaiko.siyou_suu < 0)
                {
                    break;
                }
                if (first_flag)
                {
                    
                    max_product_num =each_zaiko.gennzai_zaiko / each_zaiko.siyou_suu;
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
            cell_component_zaiko_table.Columns.Add("品名", typeof(string));
            cell_component_zaiko_table.Columns.Add("親工程", typeof(string));
            cell_component_zaiko_table.Columns.Add("現在在庫数", typeof(float));
            cell_component_zaiko_table.Columns.Add("使用数", typeof(float));
            cell_component_zaiko_table.Columns.Add("保管場所", typeof(string));
        }

        /// <summary>
        /// 使用材料群表示用関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_ProductZaikoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            init_cell_component_zaiko_table();
            if (e.ColumnIndex == 5) 
            {

                
                //DataRow select_row = Product_ZaikoList_Table_afterFitler.Rows[dataGridView_ProductZaikoList.SelectedCells[0].RowIndex];
                DataRow select_row = Product_ZaikoList_Table_afterFitler.Rows[e.RowIndex];
                Dictionary<distinct_zairyo, zaiko_info> dic = (Dictionary<distinct_zairyo, zaiko_info>)select_row["使用材料群"];
                //Dictionary<string, float> dic = Dictionary<string, float>)select_row["使用製品群"];

                foreach (KeyValuePair<distinct_zairyo, zaiko_info> kvp in dic)
                {
                    DataRow row = cell_component_zaiko_table.NewRow();
                    row["品目ＣＤ"] = kvp.Key.zairyou_code;
                    row["品名"] = kvp.Value.zairyou_hinmei;
                    row["親工程"] = kvp.Value.oyakoutei;
                    row["現在在庫数"] = kvp.Value.gennzai_zaiko;
                    row["使用数"] = kvp.Value.siyou_suu;
                    row["保管場所"] = kvp.Value.hokan_basyo;

                    cell_component_zaiko_table.Rows.Add(row);
                }

                dataGridView_cellComponentZaikoTable.DataSource = cell_component_zaiko_table;

                create_checkbox_fromTableColumn(cell_component_zaiko_table, checkedListBox_Display_ZaikoCol);



            }

            //使用材料群を表示すると同時に使用材料に含まれる工程をチェックボックスに表示する。

            DataTable notDoublicated_table;
            DataView dtView = new DataView(cell_component_zaiko_table);
            checkedListBox_cellComponentZaiko_koutei.Items.Clear();

            notDoublicated_table = dtView.ToTable(true, "親工程"); //"保管場所"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_cellComponentZaiko_koutei.Items.Add(row["親工程"]); //"保管場所"列の重複してないものをチェックボックスに追加する。
            }

            for (int i = 0; i < checkedListBox_cellComponentZaiko_koutei.Items.Count; i++)
            {
                checkedListBox_cellComponentZaiko_koutei.SetItemChecked(i, true);
            }


        }
        ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// ProductZaikoList　フィルター操作関係
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        private void btn_HinmeiFilter_ProductZaikoList_Click(object sender, EventArgs e)
        {
            string target = textBox_ProductZaikoList_HinmeiFilter.Text;
            string querry = "選択品名" + " " + "LIKE" + " " + "'" + target + "'";

           
            //検索対象なかったらエラーでるから条件分岐かtry文入れる。
            if (Product_ZaikoList_Table_afterFitler.Select(querry).Length > 0)
            {
                Product_ZaikoList_Table_afterFitler = Product_ZaikoList_Table_afterFitler.Select(querry).CopyToDataTable();
                dataGridView_ProductZaikoList.DataSource = Product_ZaikoList_Table_afterFitler;
            }
            else
            {
                MessageBox.Show("選択した品名が見つかりません。");
            }

 
        }

        private void btn_CDFilter_ProductZaikoList_Click(object sender, EventArgs e)
        {
            string target = textBox_CDFilter_ProductZaikoList.Text;
            string querry = "選択品目ＣＤ" + " " + "LIKE" + " " + "'" + target + "'";


            //検索対象なかったらエラーでるから条件分岐かtry文入れる。
            if (Product_ZaikoList_Table_afterFitler.Select(querry).Length > 0)
            {
                Product_ZaikoList_Table_afterFitler = Product_ZaikoList_Table_afterFitler.Select(querry).CopyToDataTable();
                dataGridView_ProductZaikoList.DataSource = Product_ZaikoList_Table_afterFitler;
            }
            else
            {
                MessageBox.Show("選択した品目ＣＤが見つかりません。");
            }
        }

        private void button_FileterClear_ProductZaikoList_Click(object sender, EventArgs e)
        {
            Product_ZaikoList_Table_afterFitler = Product_ZaikoList_Table.Copy();
            dataGridView_ProductZaikoList.DataSource =Product_ZaikoList_Table_afterFitler;
        }
        /// <summary>
        /// データﾃｰﾌﾞﾙとチェックボックスを引数に渡すと、チェックボックスにカラムを追加してくれる。ついでにチェックボックスは全部チェック済みにする。
        /// </summary>
        /// <param name="target_table"></param>
        /// <param name="checkedListBox"></param>
        public void create_checkbox_fromTableColumn(DataTable target_table, CheckedListBox checkedListBox) 
        {
            foreach(DataColumn col in target_table.Columns)
            {
                checkedListBox.Items.Add(col.ColumnName);
            }

            for(int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        public void Select_Grid_Column(DataGridView target_datagridview,CheckedListBox checkedListBox)
        {
            for(int i = 0; i < target_datagridview.Columns.Count; i++)
            {
                target_datagridview.Columns[i].Visible = false;
            }

            foreach(string col in checkedListBox.CheckedItems)
            {
                target_datagridview.Columns[col].Visible = true;
            }
        }

        private void button_DisplayProductCol_Click(object sender, EventArgs e)
        {
            Select_Grid_Column(dataGridView_ProductZaikoList, checkedListBox_Display_ProductCol);
        }

        private void button_DisplayZaikoCol_Click(object sender, EventArgs e)
        {
            Select_Grid_Column(dataGridView_cellComponentZaikoTable, checkedListBox_Display_ZaikoCol);
        }
        /// <summary>
        /// アッセイ工程のみ抽出するボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_includeASSYproduct_Click(object sender, EventArgs e)
        {
            string[] a = { "750", "751" };
            filter_Product_Zaiko_Table_koutei(a);
            dataGridView_ProductZaikoList.DataSource = Product_ZaikoList_Table_afterFitler;
        }

        private void filter_Product_Zaiko_Table_koutei(string[] selected_koutei)
        {


            int init_row_count = Product_ZaikoList_Table_afterFitler.Rows.Count;
            int row_cnt = 0;

            for (int i = 0; i < init_row_count; i++)
            {
                Dictionary<distinct_zairyo, zaiko_info> dic =(Dictionary<distinct_zairyo, zaiko_info>) Product_ZaikoList_Table_afterFitler.Rows[row_cnt]["使用材料群"]; //一つずつデータﾃｰﾌﾞﾙの使用材料群列にあるDictionaryを取り出して、さらにそのDictionaryを精査する。
                int dic_cnt = dic.Count;
                int cnt = 0;

                foreach(KeyValuePair<distinct_zairyo,zaiko_info> kvp in dic)
                {
                    cnt++;
                    if(selected_koutei.Contains(kvp.Value.oyakoutei))
                    {
                        break;
                    }
                    if(cnt == dic_cnt)
                    {
                        Product_ZaikoList_Table_afterFitler.Rows[row_cnt].Delete();
                        row_cnt--;
                        break;
                    }
                    
                }

                row_cnt++;
            }


        }

       /// <summary>
       /// 材料群ﾃｰﾌﾞﾙを工程の種類で抽出する。
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_Filter_ProductZaiko_koutei_Click(object sender, EventArgs e)
        {
            int i = 0;
            string querry = "";

            foreach (string selected_koutei in checkedListBox_cellComponentZaiko_koutei.CheckedItems)
            {
                if (i == 0)
                {
                    querry = querry_maker_fullmatch(0, "親工程", selected_koutei, "");
                }
                else
                {
                    querry = querry_maker_fullmatch(2, "親工程", selected_koutei, querry);
                }
                i++;
            }

            if (querry == "")
            {
                dataGridView_cellComponentZaikoTable.DataSource = null;
                return;
            }

            if (cell_component_zaiko_table.Select(querry).Length > 0)
            {
                cell_component_zaiko_table = cell_component_zaiko_table.Select(querry).CopyToDataTable();
                dataGridView_cellComponentZaikoTable.DataSource = cell_component_zaiko_table;
            }
            else
            {
                dataGridView_cellComponentZaikoTable.DataSource = null;
                return;
            }
        }
        //////aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        ///simulation関連の関数たち
        /// aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        ///　製品と個数を入力して在庫データに反映してシミュレーションする。
        /// </summary>
        /// <param name="target_product"></param>
        /// <param name="num_to_use"></param>
        private void culculate_deficit_zaiko(string target_product, float num_to_use)
        {
            zaiko_sim_table = new DataTable();
            zaiko_sim_table.Columns.Add("品目ＣＤ", typeof(string));
            zaiko_sim_table.Columns.Add("品名", typeof(string));
            zaiko_sim_table.Columns.Add("親工程", typeof(string));
            zaiko_sim_table.Columns.Add("現在在庫数", typeof(float));
            zaiko_sim_table.Columns.Add("使用数", typeof(float));
            zaiko_sim_table.Columns.Add("保管場所", typeof(string));

            zaiko_sim_table.Columns.Add("残り数量", typeof(float));


            string querry = querry_maker_fullmatch(0, "選択品名",target_product,""); //製品の抽出方法変えたいときはここを変える。

            if (Product_ZaikoList_Table_afterFitler.Select(querry).Length > 0)
            {
                DataTable target_table = Product_ZaikoList_Table_afterFitler.Select(querry).CopyToDataTable();

                Dictionary<distinct_zairyo, zaiko_info> target_dic = (Dictionary<distinct_zairyo, zaiko_info>)Product_ZaikoList_Table_afterFitler.Rows[0]["使用材料群"];

                foreach (KeyValuePair<distinct_zairyo, zaiko_info> kvp in target_dic)
                {
                    DataRow row = zaiko_sim_table.NewRow();
                    row["品目ＣＤ"] = kvp.Key.zairyou_code;
                    row["品名"] = kvp.Value.zairyou_hinmei;
                    row["親工程"] = kvp.Value.oyakoutei;
                    row["現在在庫数"] = kvp.Value.gennzai_zaiko;
                    row["保管場所"] = kvp.Value.hokan_basyo;

                    float genzai_zaiko = kvp.Value.gennzai_zaiko;
                    float siyousou = kvp.Value.siyou_suu * num_to_use;

                    row["使用数"] = siyousou; //一個製品に使う数×製品数

                    row["残り数量"] = genzai_zaiko - siyousou;

                    zaiko_sim_table.Rows.Add(row);

                }
            }
        }
        /// <summary>
        /// simulation用ﾃｰﾌﾞﾙに出荷在庫を反映する。シミュレーション用の在庫オリジナルデータを作成する。
        /// </summary>
        private void reflect_simulation_to_ZaikoTable()
        {

            if(exisit_previoustable_flag == false)
            {
                Previous_Zaiko_Data_SimulationTable = Zaiko_Data_Original_Table.Copy();
                exisit_previoustable_flag = true;
            }
            Current_Zaiko_Data_SimulationTable = new DataTable();
            Current_Zaiko_Data_SimulationTable = Previous_Zaiko_Data_SimulationTable.Copy();

            foreach(DataRow row_sellProduct in zaiko_sim_table.Rows)
            {
                foreach(DataRow row_simulationZaiko in Current_Zaiko_Data_SimulationTable.Rows)
                {
                    if(row_sellProduct["品目ＣＤ"].ToString()==row_simulationZaiko["品目ＣＤ"].ToString() && row_sellProduct["保管場所"].ToString() == row_simulationZaiko["保管場所"].ToString())
                    {
                        float sim_zaiko = (float)row_simulationZaiko["現在在庫数"];
                        sim_zaiko -= (float)row_sellProduct["使用数"];
                        row_simulationZaiko["現在在庫数"] = (float)sim_zaiko;
                    }
                }
            }

            Previous_Zaiko_Data_SimulationTable = Current_Zaiko_Data_SimulationTable.Copy();


        }

        private void create_Product_ZaikoList_from_simulationTable()
        {
            Product_ZaikoList_Table = new DataTable();

            Product_ZaikoList_Table.Columns.Add("選択品目ＣＤ", typeof(string));
            Product_ZaikoList_Table.Columns.Add("選択品名", typeof(string));
            Product_ZaikoList_Table.Columns.Add("製造可能数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("現在在庫数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("現在仕掛数", typeof(float));
            Product_ZaikoList_Table.Columns.Add("使用材料群", typeof(Dictionary<distinct_zairyo, zaiko_info>)); //dictionaryには材料名と材料情報（構造体で型宣言）を入れる。

            //抽出した在庫を含む製品をコレクションに格納する。
            List<string> Product_List = new List<string>();
            List<hinmei_cd_set> Product_List_withHinmei = new List<hinmei_cd_set>();
            //List<distinct_zairyo> Product_List = new List<distinct_zairyo>();

            foreach (DataRow row_zaiko in Zaiko_Data_Display_Table.Rows)
            {
                foreach (DataRow row_comp in Component_Data_Original_Table.Rows)
                {
                    if (row_zaiko["品目ＣＤ"].ToString() == row_comp["子品目コード"].ToString() && row_zaiko["保管場所"].ToString() == row_comp["標準出庫保管場所"].ToString())
                    {

                        if (Product_List.Contains(row_comp["選択品目ＣＤ"]) != true) //もしまだリストに製品ＣＤが存在しなければ追加する。
                        {
                            Product_List.Add(row_comp["選択品目ＣＤ"].ToString());
                            hinmei_cd_set hinmei_cd = new hinmei_cd_set() { cd = row_comp["選択品目ＣＤ"].ToString(), hinmei = row_comp["選択品名"].ToString() };
                            Product_List_withHinmei.Add(hinmei_cd);
                        }

                    }
                }

            }

            foreach (hinmei_cd_set product_name_cd in Product_List_withHinmei)
            {
                //それぞれの製品CD毎にDataRowとzaiko_infoを作成していく。
                DataRow ProductZaiko_row = Product_ZaikoList_Table.NewRow();
                ProductZaiko_row["選択品目ＣＤ"] = product_name_cd.cd;
                ProductZaiko_row["選択品名"] = product_name_cd.hinmei;

                string product_name_modified_sixletters = product_name_cd.cd.PadLeft(6, '0'); ;
                //在庫数が０だと在庫リストに表示されないから条件分岐する。
                if (Current_Zaiko_Data_SimulationTable.AsEnumerable().Any(x => x["品目ＣＤ"].ToString() == product_name_modified_sixletters) == false) // //product_nameが在庫リストに存在しないパターン
                {
                    ProductZaiko_row["現在仕掛数"] = 0;
                    ProductZaiko_row["現在在庫数"] = 0;
                }
                else
                {
                    DataTable genzai_zaiko_sikakari = Current_Zaiko_Data_SimulationTable.AsEnumerable().Where(x => x["品目ＣＤ"].ToString() == product_name_modified_sixletters).CopyToDataTable();
                    ProductZaiko_row["現在仕掛数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在仕掛数"]; //０行目固定。1つの製品品目CDに二つ以上の行があると適切に動かない。
                    ProductZaiko_row["現在在庫数"] = (float)genzai_zaiko_sikakari.Rows[0]["現在在庫数"];
                }

                //if (product_name_cd.cd == "071419")
                //{
                //    Console.WriteLine("a");
                //}

                ///aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                ///使用材料軍列を作成する処理。dic_zairyougun（Dictionay）を作成するための処理
                ///
                Dictionary<distinct_zairyo, zaiko_info> dic_zairyougun = new Dictionary<distinct_zairyo, zaiko_info>();

                //それぞれの製品が使用する構成部品リストを製品毎に作成する。
                List<zairyou_info> Component_List = new List<zairyou_info>();

                foreach (DataRow row in Component_Data_Original_Table.Rows)
                {


                    if (product_name_cd.cd == row["選択品目ＣＤ"].ToString())
                    {
                        //if(Component_List.Contains(item.))
                        zairyou_info zairyou = new zairyou_info();
                        zairyou.zairyou_code = row["子品目コード"].ToString();
                        zairyou.zairyou_hinmei = row["子品名"].ToString();
                        zairyou.zairyou_hokan_basyo = row["標準出庫保管場所"].ToString();
                        zairyou.zairyou_siyousou = (float)row["数量"];
                        zairyou.zairyou_level = row["レベル"].ToString();

                        if (row["親工程"].ToString() == "")
                        {
                            int list_num = Component_List.Count;
                            zairyou.zairyou_oyakoutei = Component_List[list_num - 1].zairyou_oyakoutei;
                        }
                        else
                        {
                            zairyou.zairyou_oyakoutei = row["親工程"].ToString();
                        }

                        Component_List.Add(zairyou);
                    }
                }

                //同じ製品の中で同じ材料、保管場所のものが二回以上使われているパターンがある。⇒重複した材料の数量を足し合わせる。
                List<zairyou_info> Component_List_notDoublicated = new List<zairyou_info>();
                bool first_flag = true;
                bool doublicated_flag = false;
                float sum = 0;
                foreach (zairyou_info each_zaryou1 in Component_List)
                {
                    foreach (zairyou_info each_zairyou2 in Component_List)
                    {
                        if (each_zaryou1.zairyou_code == each_zairyou2.zairyou_code && each_zaryou1.zairyou_hokan_basyo == each_zairyou2.zairyou_hokan_basyo)
                        {
                            if (first_flag == false)
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
                    sum = 0;

                    if (doublicated_flag == false)
                    {
                        Component_List_notDoublicated.Add(notDoublicated_zairyou);
                    }
                    else
                    {
                        bool already_exist_flag = false;
                        foreach (zairyou_info exisit_zairyou in Component_List_notDoublicated)
                        {
                            if (exisit_zairyou.Equals(notDoublicated_zairyou))
                            {
                                already_exist_flag = true;
                            }
                        }
                        if (already_exist_flag != false)
                        {
                            Component_List_notDoublicated.Add(notDoublicated_zairyou);
                        }

                    }


                    first_flag = true;
                    doublicated_flag = false;
                }



                //Dictionaryに格納するためのzaiko_infor構造体を作成するための処理。

                foreach (zairyou_info each_zairyou in Component_List_notDoublicated)
                {
                    zaiko_info z_info = new zaiko_info();
                    z_info.siyou_suu = each_zairyou.zairyou_siyousou; //使用数は部品構成リストからの情報を使わないといけない。
                    z_info.zairyou_hinmei = each_zairyou.zairyou_hinmei; //品名も部品構成リストから取り出さないといけない。在庫数が0のものは在庫リストに表示されないから。
                    z_info.oyakoutei = each_zairyou.zairyou_oyakoutei;
                    z_info.level = each_zairyou.zairyou_level;
                    //foreach (DataRow row in Zaiko_Data_Display_Table.Rows)
                    foreach (DataRow row in Current_Zaiko_Data_SimulationTable.Rows)
                    {
                        if (each_zairyou.zairyou_code == row["品目ＣＤ"].ToString() && each_zairyou.zairyou_hokan_basyo == row["保管場所"].ToString())
                        {
                            z_info.zairyou_name = row["品目ＣＤ"].ToString();
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
            Product_ZaikoList_Table_afterFitler = Product_ZaikoList_Table.Copy();

            create_checkbox_fromTableColumn(Product_ZaikoList_Table_afterFitler, checkedListBox_Display_ProductCol);
        }

        private void button_sim_Click(object sender, EventArgs e)
        {
            string product = textBox_sim_productCD.Text;
            string num = textBox_sell_num.Text;
            float num_float = float.Parse(num);

            culculate_deficit_zaiko(product,num_float);

            dataGridView_simZaiko.DataSource = zaiko_sim_table;
        }
    }
}
