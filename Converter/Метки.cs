using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class Метки : Form
    {
        public Метки()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 9;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             Form1 main = this.Owner as Form1;
           //  main.Metka1.Text = "Метка1";
             if (main.IndexMetki == 1)
             {
                 main.Metka1.Text =textBox1.Text;
                 main.Metka1.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 2)
             {
                 main.label4.Text = textBox1.Text;
                 main.label4.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 3)
             {
                 main.label5.Text = textBox1.Text;
                 main.label5.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 4)
             {
                 main.label6.Text = textBox1.Text;
                 main.label6.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 5)
             {
                 main.label7.Text = textBox1.Text;
                 main.label7.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 6)
             {
                 main.label8.Text = textBox1.Text;
                 main.label8.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
             if (main.IndexMetki == 7)
             {
                 main.label9.Text = textBox1.Text;
                 main.label9.Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
        }

        private void Метки_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("\u03c1");
            comboBox1.Items.Add("\u2103");
            comboBox1.Items.Add("\u03B1");
            comboBox1.Items.Add("\u03B2");
            comboBox1.Items.Add("\u0394");
            comboBox1.Items.Add("\u03B4");
            comboBox1.Items.Add("\u018D");
            comboBox1.Items.Add("\u03C3");
            comboBox1.Items.Add("\u03B5");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + comboBox1.Text;
        }
    }
}
