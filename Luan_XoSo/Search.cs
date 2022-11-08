using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Luan_XoSo
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                DateTime date = dateTimePicker1.Value;
                int dai = comboBox1.SelectedIndex;
                String number = textBox1.Text;
                int a = int.Parse(number);
                frmLuan.search_prize(date, dai, number);
            
            
            
            
        }

        
    }
}
