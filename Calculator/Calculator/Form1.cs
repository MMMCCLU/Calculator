using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string term;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + '+';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + '-';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + '/';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + '*';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + '.';
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string example = textBox1.Text;
            string numbers = "";
            string operators = "";
            string index = "";
            List<float> decimals = new List<float>();

            for (int i = 0; i < example.Length; ++i)
            {
                if ((example[i] != '+') && (example[i] != '*') && (example[i] != '-') && (example[i] != '/'))
                {
                    numbers = numbers + example[i];
                }
                else if (i != example.Length - 1)
                {
                    decimals.Add(float.Parse(numbers));
                    operators = operators + example[i];
                    numbers = "";
                }
                if (i == example.Length - 1)
                {
                    decimals.Add(float.Parse(numbers));
                    numbers = "";
                }
            }

            index = FindOperator(operators, '/');
            for (int i = 0; i < index.Length; ++i)
            {
                float hold = decimals[(int)(index[i] - '0')] / decimals[(int)(index[i] - '0') + 1];
                decimals[(int)(index[i] - '0')] = hold;
            }
            for (int i = 0; i < index.Length; ++i)
            {
                decimals.RemoveAt((int)(index[i] - '0') + 1 - i);
            }

            operators = DeleteOperators(operators, index);

            index = FindOperator(operators, '*');
            for (int i = 0; i < index.Length; ++i)
            {
                float hold = decimals[(int)(index[i] - '0')] * decimals[(int)(index[i] - '0') + 1];
                decimals[(int)(index[i] - '0')] = hold;
            }
            for (int i = 0; i < index.Length; ++i)
            {
                decimals.RemoveAt((int)(index[i] - '0') + 1 - i);
            }

            operators = DeleteOperators(operators, index);

            index = FindOperator(operators, '+');
            for (int i = 0; i < index.Length; ++i)
            {
                float hold = decimals[(int)(index[i] - '0')] + decimals[(int)(index[i] - '0') + 1];
                decimals[(int)(index[i] - '0')] = hold;
            }
            for (int i = 0; i < index.Length; ++i)
            {
                decimals.RemoveAt((int)(index[i] - '0') + 1 - i);
            }

            operators = DeleteOperators(operators, index);

            index = FindOperator(operators, '-');
            for (int i = 0; i < index.Length; ++i)
            {
                float hold = decimals[(int)(index[i] - '0')] - decimals[(int)(index[i] - '0') + 1];
                decimals[(int)(index[i] - '0')] = hold;
            }
            for (int i = 0; i < index.Length; ++i)
            {
                decimals.RemoveAt((int)(index[i] - '0') + 1 - i);
            }

            textBox1.Text = decimals[0].ToString();
        }

        private static string FindOperator(string operators, char target)
        {
            string index = "";
            for (int i = 0; i < operators.Length; ++i)
            {
                if (operators[i] == target)
                {
                    index = index + i;
                }
            }
            return index;
        }

        private static string DeleteOperators(string operators, string index)
        {
            for (int i = 0; i < index.Length; ++i)
            {
                operators = operators.Remove((int)(index[i] - '0'), 1);
            }

            return operators;
        }
    }
}
