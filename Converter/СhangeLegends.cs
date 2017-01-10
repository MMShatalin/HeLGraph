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
    public partial class СhangeLegends : Form
    {
        public СhangeLegends()
        {
            InitializeComponent();
        }

        private void СhangeLegends_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            
            for (int i = 0; i < main.NumberSeries; i++)
            {
                comboBox1.Items.Add(main.chart1.Legends[i].ToString().Remove(0, 7));
            }
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            for (int i = 0; i < main.chart1.Legends.Count; i++)
            {
                if(comboBox1.Text == main.chart1.Legends[i].ToString().Remove(0, 7))
                {
                  //  main.chart1.Legends[i].Name = textBox1.Text;
                    main.chart1.Series[1].LegendText = textBox1.Text;
                }
            }
        }
    }
}
