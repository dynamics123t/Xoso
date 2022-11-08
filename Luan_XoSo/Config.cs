using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luan_XoSo
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
            if (automation) {
                radioButton1.Checked = true;
                //radioButton2.Checked = false;

            }
            else { 
                radioButton2.Checked = true;
            }
            comboBox1.SelectedIndex = kenh;
            comboBox2.SelectedIndex = speed;
        }
        public static bool automation = false;
        public static int speed = 0;
        public static int kenh = 0;
        public static DateTime dateTime = DateTime.Now;

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked) automation = true;
            else automation = false;
            kenh = comboBox1.SelectedIndex;
            speed = comboBox2.SelectedIndex;
            dateTime = dateTimePicker1.Value;
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
        }

       
    }
}
