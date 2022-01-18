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

        

        public 部品在庫管理()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void init_checkbox_filter_ZaikoOrigin()
        {
            DataTable notDoublicated_table;
            DataView dtView = new DataView(Zaiko_Data_Otiginal);

            notDoublicated_table= dtView.ToTable(true, "保管場所"); //"保管場所"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_hokan.Items.Add(row["保管場所"]); //"保管場所"列の重複してないものをチェックボックスに追加する。
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Otiginal);

            notDoublicated_table = dtView.ToTable(true, "経費"); //"経費"列の重複を取り除く

            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_keihi.Items.Add(row["経費"]); //"経費"列の重複してないものをチェックボックスに追加する。
            }

            notDoublicated_table = new DataTable();
            dtView = new DataView(Zaiko_Data_Otiginal);

            notDoublicated_table = dtView.ToTable(true, "工程"); //"工程"列の重複を取り除く
            foreach (DataRow row in notDoublicated_table.Rows)
            {
                checkedListBox_ZaikoOrigin_koutei.Items.Add(row["工程"]); //"工程"列の重複してないものをチェックボックスに追加する。
            }
        }


        public void create_Zaiko_ComponentList_Table()
        {
            Zaiko_ComponentList_Table.Columns.Add("品目ＣＤ", typeof(string));
            Zaiko_ComponentList_Table.Columns.Add("現在在庫数", typeof(float));
            Zaiko_ComponentList_Table.Columns.Add("使用製品群", typeof(Dictionary<string,float>)); //dictionaryには製品名と<材料使用数,現在在庫だと何個つくれるか＞を入れる。



            foreach (DataRow Zaikorow in Zaiko_Data_Display_Table.Rows)
            {
                foreach(DataRow Componentrow in Component_Data_Original_Table.Rows)
                {
                    if (Zaikorow["品目ＣＤ"].ToString()==Componentrow["子品目コード"].ToString() && Zaikorow["保管場所"].ToString()==Componentrow["標準出庫保管場所"].ToString())
                    {
                        Componentrow["選択品目ＣＤ"].ToString();
                    }
                }
            }
        }
    }
}
