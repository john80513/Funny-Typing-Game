using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));//65~90對應鍵盤上A~Z的英文字母
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game Over!");
                timer1.Stop();
                button1.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))//驗證是否有鍵盤輸入得值
            {
                listBox1.Items.Remove(e.KeyCode);//移除玩家輸入正確的值
                //listBox1.Refresh();

                //增加字母出現速度
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                else if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                else if (timer1.Interval > 100)
                {
                    timer1.Interval -= 2;
                }
                toolStripProgressBar1.Value = 800 - timer1.Interval;
                stats.Update(true);
            }
            else {
                stats.Update(false);
            }

            CorrctLabel.Text = "Correct:" + stats.Correct;
            MissedLabel.Text = "Missed:" + stats.Missed;
            TotalLabel.Text = "Total:" + stats.Total;
            AccuracyLabel.Text = "Accuracy:" + stats.Accuracy+"%";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            timer1.Interval = 800;
            toolStripProgressBar1.Value = 800- timer1.Interval;
            timer1.Start();
        }
    }
}
