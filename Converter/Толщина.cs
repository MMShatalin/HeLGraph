using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Толщина : Form
    {
        public Толщина()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            for (int i = 0; i < main.NumberSeries; i++)
            {
                //MessageBox.Show(i.ToString());
               // MessageBox.Show(numericUpDown1.Value.ToString());
                main.chart1.Series[i].BorderWidth = (int)numericUpDown1.Value;
                
            
            
            }
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[1].AxisY.LineWidth = (int)numericUpDown2.Value;
            main.chart1.ChartAreas[1].AxisY.LineColor = main.chart1.Series["Series1"].Color;
            //main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
         //   main.chart1.ChartAreas[0].AxisY.LineColor = Color.FromName(comboBox8.Text);

            for (int i = 0; i < main.t.Count; i++)
            {
                 main.t[i].AxisY.LineWidth = (int)numericUpDown2.Value;
            }
        }
    }
}
