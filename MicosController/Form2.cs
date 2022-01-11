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


        public Form2()
        {
            InitializeComponent();
        }

        public void read_database_column()
        {
            foreach (DataColumn column in Component_Table_ICB.Columns)
            {
                checkedListBox_display_column.Items.Add(column);
            }

            foreach (DataColumn column in Component_Table_MMB.Columns)
            {
                checkedListBox_display_column.Items.Add(column);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
