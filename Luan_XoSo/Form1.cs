using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Threading;
using System.Diagnostics;
enum ACTION{RUNNING, WAIT, RAN}
namespace Luan_XoSo
{
    public partial class frmLuan : Form
    {
        private int kenh = 1;
        private List <String> arrHN, arrHP;
        private static List<Label> listLab;
        private int timeRandom=5000;
        private ACTION statusHP = ACTION.WAIT;
        private ACTION statusHN = ACTION.WAIT;

        public void setTimeRandom(int time)
        {
            this.timeRandom = time;
        }

        public frmLuan()
        {
            /*InitializeComponent();*/
            InitializeComponent();
            listLab = new List<Label>();
            arrHN = new List<String>();
            arrHP = new List<String>();
            Label []arr = { label32, label33, label34, label35, label29, label30, label31, label23, label24, label25, label26, label27, label28, label19, label20, label21, label22, label13, label14, label15, label16, label17, label18, label11, label12, label4, label2 };
            foreach (Label item in arr)
            {
                listLab.Add(item);
                arrHN.Add(item.Text);
                arrHP.Add(item.Text);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.timeRandom = (Config.speed + 1) * 5000;
            
            Thread th = new Thread(() =>
            {
                run(1);    
            });

            Thread th1 = new Thread(() =>
            {
                run(2);
            });
            if (Config.kenh == 0  )
            {
                button1.Enabled = false;
                labHN.BackColor = Color.Green;
                labHP.BackColor = Color.WhiteSmoke;
                this.kenh = 1;
                th.Start();
                
            } 
            else if(Config.kenh == 1 )
            {
                
                labHP.BackColor = Color.Green;
                labHN.BackColor = Color.WhiteSmoke;
                this.kenh = 2;
                th1.Start();

            }  
            else
            {

                th.Start();
                th1.Start();
            }
        }
        private void run(int dai)
        {
            for (int i = 0; i < listLab.Count; i++)
            {

                int time = 0;
                while (time < this.timeRandom)
                {
                    Random r = new Random();
                    //int len = arr[tmp].Text.Length;
                    int len = listLab[i].Text.Length;
                    String str = "";
                    while (len > 0)
                    {
                        str += r.Next(10).ToString();
                        len--;
                    }
                    
                    if (dai == 1)
                    {
                        arrHN[i] = str;
                        if (kenh == 1)
                        {
                            listLab[i].Text = str;
                            Thread.Sleep(78);
                        }
                        else
                        {
                            Thread.Sleep(92);
                        }
                    }
                    else
                    {
                        arrHP[i] = str;
                        if (kenh == 2)
                        {
                            listLab[i].Text = str;
                            Thread.Sleep(78);
                        }
                        else
                        {
                            Thread.Sleep(92);
                        }
                    }
                    time += 100;
                }
            }
            string path = "";
            if (dai == 1) {
                statusHN = ACTION.RAN;
                path = Path.GetFullPath(".") + "\\HN\\";
            }

            else{
                statusHP = ACTION.RAN;
                path = Path.GetFullPath(".") + "\\HP\\";
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            String today = System.DateTime.Now.ToString("dd_MM_yyyy");
            //label37.Text = today;
            path += today + ".txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Dispose();
                if(dai==1)  
                File.WriteAllLines(path, arrHN);
                else File.WriteAllLines(path, arrHP);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            String path = Path.GetFullPath(".") + "\\HN\\" + System.DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
            if (File.Exists(path))
            {
                String[] arr = File.ReadAllLines(path);
                this.arrHN.Clear();
                for (int i = 0; i < arr.Length; i++)
                {
                    
                    this.arrHN.Add(arr[i]);
                    if (kenh == 1)
                    {
                        listLab[i].Text = arr[i];
                    }
                }
            }
            timer3 = new System.Windows.Forms.Timer();
            timer3.Interval = 1000;
            timer3.Tick += new EventHandler(updateTime);
            timer3.Start();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(updateTime);
            

        }
        private void updateTime(object o, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            DateTime to = Convert.ToDateTime(labTime.Text);
            DateTime from = Convert.ToDateTime("05:30:00 PM");
            TimeSpan timeSpan = from - to;
            label38.Text = timeSpan.ToString();
        }

        private void labHN_Click(object sender, EventArgs e)
        {
            labHN.BackColor = Color.Green;
            labHP.BackColor = Color.WhiteSmoke ;
            kenh = 1;
            int len = listLab.Count;
            for(int i = 0; i < len; i++)
            {
                listLab[i].Text = arrHN[i];
            }
        }
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            String path = "";
            if (kenh == 1)
            {
                path = Path.GetFullPath(".") + "\\HN\\";
                path += dateTime.ToString("dd_MM_yyyy") + ".txt";
            }
            else
            {
                path = Path.GetFullPath(".") + "\\HP\\";
                path += dateTime.ToString("dd_MM_yyyy") + ".txt";
            }
            
            
            
            if (File.Exists(path))
            {
                String[] arr = File.ReadAllLines(path);
                for(int i = 0; i < arr.Length; i++)
                {
                    listLab[i].Text= arr[i];
                }
            }
            else
            {
                int x = 0;
                for (int i = 2; i <= 5; i++)
                {
                    switch (i)
                    {
                        case 2:

                            for (int j = 0; j < 4; j++)
                            {
                                listLab[x].Text = "XX";
                                x++;
                            }
                            break;

                        case 3:
                            for (int j = 0; j < 3; j++)
                            {
                                listLab[x].Text = "XXX";
                                x++;
                            }
                            break;
                        case 4:
                            for (int j = 0; j < 10; j++)
                            {
                                listLab[x].Text = "XXXX";
                                x++;
                            }
                            break;
                        default:
                            for (int j = 0; j < 10; j++)
                            {
                                listLab[x].Text = "XXXXX";
                                x++;
                            }
                            break;

                    }

                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config frm = new Config();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Search().Show();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }
        public static void search_prize(DateTime date, int dai, string number)
        {
            string path = "";
            
            if (dai == 0)
            {
                path = Path.GetFullPath(".") + "\\HN\\";
            }
            else
            {
                path = Path.GetFullPath(".") + "\\HP\\";
            }
            path += date.ToString("dd_MM_yyyy") + ".txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Ngày này chưa được quay thưởng!");
                return;
            }
            else
            {
                int lenN = number.Length-1;
                String[] arr = File.ReadAllLines(path);
                for(int i= 0; i < arr.Length; i++)
                {
                    listLab[i].Text = arr[i];
                }
                bool trungThuong = false;
                int resGiai=0;
                for(int i = 0; i<arr.Length; i++)
                {
                    int len = arr[i].Length;
                    String sub = number.Substring(5-len);
                    if (sub == arr[i])
                    {
                        listLab[i].BackColor= Color.Red;
                        trungThuong = true;
                        resGiai = i;
                    }
                }
                if (trungThuong)
                {
                    DialogResult d = MessageBox.Show("Chúc mừng bạn đã trúng giải");
                    listLab[resGiai].BackColor = Color.White;
                }  
                else MessageBox.Show("Vé của bạn không trúng giải");
            }

        }

        private void labHP_Click(object sender, EventArgs e)
        {
            labHN.BackColor = Color.WhiteSmoke;
            labHP.BackColor= Color.Green;
            kenh = 2;
            int len = listLab.Count;
            DateTime dateTime = dateTimePicker1.Value;
            DateTime today = DateTime.Today;
            String path1 = Path.GetFullPath(".") + "\\HP\\";
            path1 += dateTime.ToString("dd_MM_yyyy") + ".txt";
            if (File.Exists(path1))
            {
                String[] arr = File.ReadAllLines(path1);
                for(int i =0; i<len; i++)
                {
                    listLab[i].Text = arr[i];
                }
            }
            else if (today.Equals(dateTime))
            {
                for (int i = 0; i < len; i++)
                {
                    listLab[i].Text = arrHP[i];
                }
            }
            else
            {

                int x = 0;
                for (int i = 2; i <= 5; i++)
                {
                    switch (i)
                    {
                        case 2:

                            for (int j = 0; j < 4; j++)
                            {
                                listLab[x].Text = "XX";
                                x++;
                            }
                            break;

                        case 3:
                            for (int j = 0; j < 3; j++)
                            {
                                listLab[x].Text = "XXX";
                                x++;
                            }
                            break;
                        case 4:
                            for (int j = 0; j < 10; j++)
                            {
                                listLab[x].Text = "XXXX";
                                x++;
                            }
                            break;
                        case 5:
                            for (int j = 0; j < 10; j++)
                            {
                                listLab[x].Text = "XXXXX";
                                x++;
                            }
                            break;
                        default:
                            for (int j = 0; j < 10; j++)
                            {
                                listLab[x].Text = "XXXXXX";
                                x++;
                            }
                            break;
                        

                    }

                }
            }
            
        }
    }
}