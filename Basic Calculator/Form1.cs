using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
    public partial class Form1 : Form
    {

        int firstnum;
        int stored;

        char operation;

        bool resclicked = false;
        bool doubleclick = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Num(int N)
        {
            if (resclicked)
            {
                stored = 0;
                doubleclick = false;
            }
            if (doubleclick == false)
            {
                textBox1.Text = N.ToString();
                doubleclick = true;
                firstnum = N;
            }
            else
            {
                firstnum = N + firstnum * 10;
                textBox1.Text = firstnum.ToString();
            }
            resclicked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Num(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Num(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Num(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Num(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Num(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Num(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Num(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Num(9);
        }
        private void button0_Click(object sender, EventArgs e)
        {
            Num(0);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            operation = '+';
            Operation(operation);
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            operation = '*';
            Operation(operation);
        }

        private void Operation(char O)
        {
            if (resclicked == false)
            {
                if ((stored != 0) && (resclicked == false))
                {
                    if (O=='+')
                    {
                        stored = stored + firstnum;
                    }
                    if (O == '*')
                    {
                        stored = stored * firstnum;
                    }
                    firstnum = 0;
                }
                else { stored = firstnum; firstnum = 0; }
            }

            doubleclick = false;
            resclicked = false;
        }
        private void Store(char O)
        {
            if (operation == '+')
            {
                stored = stored + firstnum;
            }
            if (operation == '*')
            {
                stored = stored * firstnum;
            }
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            Store(operation);
            textBox1.Text = (stored).ToString();
            resclicked = true;
        }
        bool fool = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = (int.Parse(label1.Text)*10 + 1).ToString();
        }

        private void buttonLAL_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled==false)
            {
                timer1.Enabled = true;
            }
            else { timer1.Enabled = false; }
            
        }
    }
}
