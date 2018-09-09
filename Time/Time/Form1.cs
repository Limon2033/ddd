using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class Form1 : Form
    {
        int timemsec, timesec;
        bool stop = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timesec == 0 && timemsec == 0)
            {
                timer1.Stop();
                label3.Text = "Время вышло";
                Activate();
                Reset();
                textBox1.Enabled = true;
            }
            else
            {
                if (timemsec == 0)
                {
                    DrawTime();
                    timesec--;
                    timemsec = 99;
                }
                else
                {
                    DrawTime();
                    timemsec--;
                }
            }
        }

        private void DrawTime()
        {
            sec.Text = String.Format("{0:00}", timesec);
            msec.Text = String.Format("{0:00}", timemsec);
        }

        private void Reset()
        {
            sec.Text = "00";
            msec.Text = "00";          
            textBox1.Text = "";
            textBox1.Enabled = true;
            stop = false;
        }

        private void Activate()
        {
            Pause.Enabled = false;
            Stop.Enabled = false;
        }

        public Form1()
        {
            InitializeComponent();
            Activate();
            textBox1.MaxLength = 2;
            Start.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (stop)
            {
                timer1.Enabled = true;
                Start.Text = "Старт";
            }
            else
            {
                timesec = Int32.Parse(textBox1.Text);
                timemsec = 0;
                textBox1.Enabled = false;
                timer1.Start();
            }
            Start.Enabled = false;
            Pause.Enabled = true;
            Stop.Enabled = true;
            label3.Text = "";
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Start.Enabled = true;
            Pause.Enabled = false;
            stop = true;
            Start.Text = "Продолжить";
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Activate();
            Start.Text = "Старт";
            msec.Text = "";
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                Start.Enabled = true;
            }
            else
            {
                Start.Enabled = false;
            }
        }
    }
}
