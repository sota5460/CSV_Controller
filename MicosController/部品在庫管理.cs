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

        public DataTable Zaiko_ComponentList_Table { get; set; }

        public DataTable notDoublicated_Component_Table { get; set; }
        

        public 部品在庫管理()
        {
            InitializeComponent();

            
        }

        private void label7_Click(object sender, EventArgs e)
        {

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
        }

        public DataTable Sum_and_DeleteDoublicated_Table(DataTable TargetTable,string groupby_col, string sum_col_name,int sum_col_num, string doublicated_col) //TargetTableを指定した列（groupby_col）で分けたあとで、sum_col_name列の重複を消して、合計値を代わりにだす。計算値はfloat
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
                bool first_flag = true;
                bool doublicated_flag = false;
                float sum = 0;

                foreach(DataRow row1 in each_list_table.Rows)
                {
                    DataRow DistinctComponent_Row = each_list_table_modified.NewRow();
                    foreach (DataRow row2 in each_list_table.Rows)
                    {
                        if (row1[doublicated_col].ToString() == row2[doublicated_col].ToString()) //もし重複項目二つあればここに追加する。 && row1[doublicated_col2].ToString() == row2[doublicated_col2].ToString()
                        {
                            if (first_flag==false)
                            {
                                sum += (float)row2[sum_col_name];
                                doublicated_flag = true;
                            }

                            if(first_flag) //初回の重複はフラグを立てて、初期値を代入する。
                            {
                                first_flag = false;
                                sum += (float)row2[sum_col_name];
                            }

                        }
                    }

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
                        }
                        else
                        {
                            DistinctComponent_Row[i] = row1[i].ToString();
                        }

                    }

                    each_list_table_modified.Rows.Add(DistinctComponent_Row); //とりあえず重複しているデータもデータﾃｰﾌﾞﾙに格納する。
                    //each_list_table_modified.

                }

                DataView dt = new DataView(each_list_table_modified);
                each_list_table_modified = dt.ToTable(true, doublicated_col); //重複列を消去する。

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

        private void button_create_ZaikoComponentListTable_Click(object sender, EventArgs e)
        {
            notDoublicated_Component_Table = Sum_and_DeleteDoublicated_Table(Component_Data_Original_Table, "選択品目ＣＤ", "数量",10 ,"子品目コード");
            
            create_Zaiko_ComponentList_Table();
        }
    }
}
