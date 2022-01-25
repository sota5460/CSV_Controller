using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;

namespace MicosController
{
    class DataTableController
    {
        public DataTable MMB_Table { get; set; }
        public DataTable ICB_Table { get; set; }

        public DataTable Zaiko_Table_afterFilter_Current { get; set; }
        public DataTable Zaiko_Table_manufactureProduct { get; set; }
        //public DataTable Zaiko_Table_afterFilter_Previous { get; set; }

        public DataTable ICB_Sim_Table_current { get; set; }
        public DataTable ICB_Sim_Table_temp { get; set; }

        public string[] ASSY_oyakoutei = { "750", "751" };

        public DataTable Extract_Row { get; set; }

        /// <summary>
        /// 部品構成データMMBから外注に送る部品だけを抽出する。（Zコードの除去とYコード部品（外注自弁）を取り除く）
        /// </summary>
        public void Extract_Only_ASSY_MMB()
        {
            ADD_Oyakoutei_Datatable();

            Extract_byOyakoutei(ASSY_oyakoutei);

            Remove_ZandYcode_fromMMBtable();

        }
        /// <summary>
        /// 親工程がブランクだったら一個上の親工程をコピーして埋める。
        /// </summary>
        public void ADD_Oyakoutei_Datatable()
        {
            for(int i = 0; i < MMB_Table.Rows.Count; i++)
            {
                if (MMB_Table.Rows[i]["親工程"].ToString() == "")
                {
                    MMB_Table.Rows[i]["親工程"] = MMB_Table.Rows[i - 1]["親工程"];
                }
            }
        }
        /// <summary>
        /// 特定の親工程を含む行だけMMBﾃｰﾌﾞﾙに残す。親工程は文字列配列で渡す。MMBﾃｰﾌﾞﾙは親工程が埋まっていないといけない。（先にADD_Oyakoutei_Datatable()を使う。）
        /// </summary>
        /// <param name="target_oyakoutei"></param>
        public void Extract_byOyakoutei(string[] target_oyakoutei)
        {
            int max_row_num = MMB_Table.Rows.Count;
            int cnt = 0;

            for (int i = 0; i < max_row_num; i++)
            {

                if (target_oyakoutei.Contains(MMB_Table.Rows[cnt]["親工程"]) == false)
                {
                    MMB_Table.Rows[cnt].Delete();
                    cnt--;
                }
                cnt++;
            }
        }
        /// <summary>
        /// Zで始まる材料とYで始まる材料を取り除く。（ZとYは外注に送る部品じゃないから。YYJIBENも消える。）
        /// </summary>
        public void Remove_ZandYcode_fromMMBtable()
        {
            int max_row_num = MMB_Table.Rows.Count;
            int cnt = 0;

            for (int i =0; i < max_row_num; i++)
            {
                string product_code = MMB_Table.Rows[cnt]["子品目コード"].ToString();
                char initial_word = product_code[0]; //子品目コードの一文字目を取り出す。

               if (initial_word == 'Z' || initial_word == 'Y')　//一文字目がZかYじゃなかったら列を消す。
                {
                    MMB_Table.Rows[cnt].Delete();
                    cnt--;
                }

                cnt++;
            }
        }
        /// <summary>
        /// 対象製品名とシミュレーション用ﾃｰﾌﾞﾙから、使用材料の在庫情報用のﾃｰﾌﾞﾙを作成する。シミュレーション用ﾃｰﾌﾞﾙにオリジナルＩＣＢﾃｰﾌﾞﾙをコピーしてから使わないと使えない。（Set_OriginMMB_toSimTable()を使って初期化しておく。）
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="Product_Num"></param>
        public void Create_Zaiko_Table_with_ProductName_ProductNum (string ProductName, float Product_Num)
        {

            Zaiko_Table_afterFilter_Current = new DataTable();
            Zaiko_Table_afterFilter_Current.Columns.Add("経費",typeof(string));　//from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("品目ＣＤ", typeof(string)); //from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("品名", typeof(string)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("保管場所", typeof(string)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("現在在庫数", typeof(float)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("一つの製品に使う数", typeof(float)); // from MMB
            Zaiko_Table_afterFilter_Current.Columns.Add("合計使用数", typeof(float)); // from MMB
            Zaiko_Table_afterFilter_Current.Columns.Add("残り在庫数", typeof(float)); // from ICB

            if(MMB_Table.AsEnumerable().Where(x => (string)x["選択品名"].ToString() == ProductName).Any() != true)
            {
                MessageBox.Show("品名が一致する製品が存在しません。");
                return;
            }

            DataTable temp_Table = MMB_Table.AsEnumerable().Where(x => (string)x["選択品名"].ToString() == ProductName).CopyToDataTable();　//選択品名を変更すれば品目ＣＤとかで検索できる。

            foreach(DataRow row in temp_Table.Rows)
            {
                foreach(DataRow row_icb in ICB_Sim_Table_current.Rows) //ここをシミュレーション用在庫ﾃｰﾌﾞﾙにすればシミュレーションができる。
                {
                    if (row["子品目コード"].ToString() == row_icb["品目ＣＤ"].ToString() && row["標準出庫保管場所"].ToString() == row_icb["保管場所"].ToString())
                    {
                        DataRow newrow = Zaiko_Table_afterFilter_Current.NewRow();
                        newrow["経費"] = row_icb["経費"];
                        newrow["品目ＣＤ"] = row_icb["品目ＣＤ"];
                        newrow["品名"] = row_icb["品名"];
                        newrow["保管場所"] = row_icb["保管場所"];
                        newrow["現在在庫数"] = row_icb["現在在庫数"];
                        newrow["一つの製品に使う数"] = (float)row["数量"];

                        float total_num_to_use = (float)row["数量"] * Product_Num;
                        float Zaiko_Left = (float)row_icb["現在在庫数"] - total_num_to_use;

                        newrow["合計使用数"] = total_num_to_use;
                        newrow["残り在庫数"] = Zaiko_Left;

                        Zaiko_Table_afterFilter_Current.Rows.Add(newrow);
                    }
                }
               
            }

        }
        /// <summary>
        /// 部品構成ﾃｰﾌﾞﾙの選択品目CDから使用材料ﾃｰﾌﾞﾙを作成する。
        /// </summary>
        /// <param name="ProductCD"></param>
        /// <param name="Product_Num"></param>
        public void Create_Zaiko_Table_with_ProductCD_ProductNum(string ProductCD, float Product_Num)
        {

            Zaiko_Table_afterFilter_Current = new DataTable();
            Zaiko_Table_afterFilter_Current.Columns.Add("経費", typeof(string));　//from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("品目ＣＤ", typeof(string)); //from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("品名", typeof(string)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("保管場所", typeof(string)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("現在在庫数", typeof(float)); // from ICB
            Zaiko_Table_afterFilter_Current.Columns.Add("一つの製品に使う数", typeof(float)); // from MMB
            Zaiko_Table_afterFilter_Current.Columns.Add("合計使用数", typeof(float)); // from MMB
            Zaiko_Table_afterFilter_Current.Columns.Add("残り在庫数", typeof(float)); // from ICB

            if (MMB_Table.AsEnumerable().Where(x => (string)x["選択品目ＣＤ"].ToString() == ProductCD).Any() != true)
            {
                MessageBox.Show("品目ＣＤが一致する製品が存在しません。");
                return;
            }

            DataTable temp_Table = MMB_Table.AsEnumerable().Where(x => (string)x["選択品目ＣＤ"].ToString() ==ProductCD).CopyToDataTable();　//選択品名を変更すれば品目ＣＤとかで検索できる。

            foreach (DataRow row in temp_Table.Rows)
            {
                foreach (DataRow row_icb in ICB_Sim_Table_current.Rows) //ここをシミュレーション用在庫ﾃｰﾌﾞﾙにすればシミュレーションができる。
                {
                    if (row["子品目コード"].ToString() == row_icb["品目ＣＤ"].ToString() && row["標準出庫保管場所"].ToString() == row_icb["保管場所"].ToString())
                    {
                        DataRow newrow = Zaiko_Table_afterFilter_Current.NewRow();
                        newrow["経費"] = row_icb["経費"];
                        newrow["品目ＣＤ"] = row_icb["品目ＣＤ"];
                        newrow["品名"] = row_icb["品名"];
                        newrow["保管場所"] = row_icb["保管場所"];
                        newrow["現在在庫数"] = row_icb["現在在庫数"];
                        newrow["一つの製品に使う数"] = (float)row["数量"];

                        float total_num_to_use = (float)row["数量"] * Product_Num;
                        float Zaiko_Left = (float)row_icb["現在在庫数"] - total_num_to_use;

                        newrow["合計使用数"] = total_num_to_use;
                        newrow["残り在庫数"] = Zaiko_Left;

                        Zaiko_Table_afterFilter_Current.Rows.Add(newrow);
                    }
                }

            }

        }
        /// <summary>
        /// シミュレーション用ﾃｰﾌﾞﾙを更新する。この時、更新する前の情報を別ﾃｰﾌﾞﾙに保存する。
        /// </summary>
        public void Update_Zaiko_Sim_Table()
        {
            ICB_Sim_Table_temp = new DataTable();
            ICB_Sim_Table_temp = ICB_Sim_Table_current.Copy(); //ﾃｰﾌﾞﾙを更新する前に一つ前の状態にもどれる用に現在のﾃｰﾌﾞﾙをコピーして保存しておく。


            foreach(DataRow row_zaiko in Zaiko_Table_afterFilter_Current.Rows)
            {
                foreach(DataRow row_icb in ICB_Sim_Table_current.Rows)
                {
                    if(row_zaiko["品目ＣＤ"].ToString() == row_icb["品目ＣＤ"].ToString() && row_zaiko["保管場所"].ToString() == row_icb["保管場所"].ToString())
                    {
                        float gennzaizaiko = (float)row_icb["現在在庫数"]; //あくまで現在在庫数しか変更されない。現在在庫額とかは更新されない。
                        float siyousou = (float)row_icb["合計使用数"];

                        row_icb["現在在庫数"] = gennzaizaiko - siyousou;
                    }
                }
            }

            
        }
        /// <summary>
        /// シミュレーション用在庫ﾃｰﾌﾞﾙにオリジナルのICBﾃｰﾌﾞﾙをコピーする。使用材料の在庫情報を出す前に使う必要ある。
        /// </summary>
        public void Set_OriginMMB_toSimTable()
        {
            ICB_Sim_Table_current = new DataTable();
            ICB_Sim_Table_current = ICB_Table.Copy();
        }
        /// <summary>
        /// シミュレーション用ﾃｰﾌﾞﾙを一つ前の状態に戻す。一つ前しかできない。保存ﾃｰﾌﾞﾙを増やしただけ増やすことはできる。
        /// </summary>
        public void BacktoPreviousZaiko()
        {
            ICB_Sim_Table_current = new DataTable();
            ICB_Sim_Table_current = ICB_Sim_Table_temp.Copy();
        }
        /// <summary>
        /// ICBﾃｰﾌﾞﾙから品名列が一致する行を抜き出して、ExtractRowﾃｰﾌﾞﾙに格納する。
        /// </summary>
        /// <param name="ProductName"></param>
        public void Extract_Row_withProductName_fromICB(string ProductName, string target_col)
        {
            Extract_Row = new DataTable();

            if(ICB_Sim_Table_current.AsEnumerable().Where(x => x[target_col].ToString() == ProductName).Any())
            {
                Extract_Row = ICB_Sim_Table_current.AsEnumerable().Where(x => x[target_col].ToString() == ProductName).CopyToDataTable();
            }


        }
        /// <summary>
        /// 製品単体の在庫情報をﾃｰﾌﾞﾙに格納する。
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="ProductNum"></param>
        public void Create_ZaikoManufacutureProductTable_fromProductName(string ProductName, float ProductNum)
        {
            string target_col = "品名";
            Extract_Row_withProductName_fromICB(ProductName,target_col);

            Zaiko_Table_manufactureProduct = new DataTable();
            Zaiko_Table_manufactureProduct.Columns.Add("経費", typeof(string));　//from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("品目ＣＤ", typeof(string)); //from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("品名", typeof(string)); // from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("保管場所", typeof(string)); // from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("現在在庫数", typeof(float)); // from ICB
           　Zaiko_Table_manufactureProduct.Columns.Add("現在仕掛数", typeof(float)); // from ICB
            //Zaiko_Table_manufactureProduct.Columns.Add("生産数", typeof(float)); // from ICB
            //Zaiko_Table_manufactureProduct.Columns.Add("生産後在庫", typeof(float)); // from ICB


            foreach(DataRow row in Extract_Row.Rows)
            {
                DataRow newrow = Zaiko_Table_manufactureProduct.NewRow();
                newrow["経費"] = row["経費"];
                newrow["品目ＣＤ"] = row["品目ＣＤ"];
                newrow["品名"] = row["品名"];
                newrow["保管場所"] = row["保管場所"];
                newrow["現在在庫数"] = (float)row["現在在庫数"];
                newrow["現在仕掛数"] = (float)row["現在仕掛数"];

                //newrow["生産数"] = ProductNum;
                //newrow["生産後在庫"] = (float)row["現在在庫数"] + (float)row["現在仕掛数"] + ProductNum;

                Zaiko_Table_manufactureProduct.Rows.Add(newrow);

            }
        }

        public void Create_ZaikoManufacutureProductTable_fromProductCD(string ProductCD, float ProductNum)
        {
            string target_col = "品目ＣＤ";
            Extract_Row_withProductName_fromICB(ProductCD, target_col);

            Zaiko_Table_manufactureProduct = new DataTable();
            Zaiko_Table_manufactureProduct.Columns.Add("経費", typeof(string));　//from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("品目ＣＤ", typeof(string)); //from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("品名", typeof(string)); // from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("保管場所", typeof(string)); // from ICB
            Zaiko_Table_manufactureProduct.Columns.Add("現在在庫数", typeof(float)); // from ICB
           　Zaiko_Table_manufactureProduct.Columns.Add("現在仕掛数", typeof(float)); // from ICB
            //Zaiko_Table_manufactureProduct.Columns.Add("生産数", typeof(float)); // from ICB
            //Zaiko_Table_manufactureProduct.Columns.Add("生産後在庫", typeof(float)); // from ICB


            foreach (DataRow row in Extract_Row.Rows)
            {
                DataRow newrow = Zaiko_Table_manufactureProduct.NewRow();
                newrow["経費"] = row["経費"];
                newrow["品目ＣＤ"] = row["品目ＣＤ"];
                newrow["品名"] = row["品名"];
                newrow["保管場所"] = row["保管場所"];
                newrow["現在在庫数"] = (float)row["現在在庫数"];
                newrow["現在仕掛数"] = (float)row["現在仕掛数"];

                //newrow["生産数"] = ProductNum;
                //newrow["生産後在庫"] = (float)row["現在在庫数"] + (float)row["現在仕掛数"] + ProductNum;

                Zaiko_Table_manufactureProduct.Rows.Add(newrow);

            }
        }

    }
}
