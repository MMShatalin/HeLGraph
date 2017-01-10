using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class PowerEffect : Form
    {
        public PowerEffect()
        {
            InitializeComponent();
        }

        private void PowerEffect_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            label13.Text = "\u03C11";
            label14.Text = "\u03C12";
            label17.Text = "\u03C11";
            label20.Text = "\u03C12";

            for (int i = 0; i < main.NumberSeries; i++)
            {
                comboBox1.Items.Add(main.chart1.Series[i].LegendText);
                comboBox2.Items.Add(main.chart1.Series[i].LegendText);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value1(main.MyAllSensors, main.pixel,main.chart1, comboBox1.Text, comboBox2.Text);
            label1.Text = n.HELP1(Search_Min_Error.help1);
            label6.Text = n.HELP2(Search_Min_Error.help2);
            label3.Text = n.HELP3(Search_Min_Error.help3);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
           
          //  Search_Min_Error.Cursor_Value1(main.MyAllSensors, main.chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X), main.chart1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value1(main.MyAllSensors, main.pixel, main.chart1, comboBox1.Text, comboBox2.Text);
            label5.Text = n.HELP1(Search_Min_Error.help1);//
            label4.Text = n.HELP2(Search_Min_Error.help2);//
            label2.Text = n.HELP3(Search_Min_Error.help3);//
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value1(main.MyAllSensors, main.pixel, main.chart1, comboBox1.Text, comboBox2.Text);
            label21.Text = n.HELP1(Search_Min_Error.help1);
            label23.Text = n.HELP2(Search_Min_Error.help2);
            label22.Text = n.HELP3(Search_Min_Error.help3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value1(main.MyAllSensors, main.pixel, main.chart1, comboBox1.Text, comboBox2.Text);
            label24.Text = n.HELP1(Search_Min_Error.help1);
            label26.Text = n.HELP2(Search_Min_Error.help2);
            label25.Text = n.HELP3(Search_Min_Error.help3);
        }
        double Nbeg;
        double dpdT;
        double dT1dt;
        private void button5_Click(object sender, EventArgs e)
        {
            double dT = double.Parse(label2.Text) - double.Parse(label3.Text);
            TimeSpan dt = DateTime.Parse(label5.Text) - DateTime.Parse(label1.Text);
            double dp = double.Parse(label4.Text) - double.Parse(label6.Text);
            dpdT =  (dp / dT) * 0.74;
            double hours = dt.TotalHours;
            dT1dt = dT / hours;
            label27.Text = "dT/dt = " + Math.Round(dT1dt,3).ToString() + " \u2103/ч";
            Nbeg = MC * dT1dt;
            label28.Text = "Nнач = " + Math.Round(Nbeg,3).ToString() + " МВт";
            label31.Text = "d\u03C1/dT = " + dpdT.ToString("E", CultureInfo.InvariantCulture) + " %/ч"; 
        //    DateTime dt = DateTime.FromOADate(double.Parse(label5.Text) - double.Parse(label1.Text));
        //    MessageBox.Show((double.Parse(Datetime.Parse(label5.Text)) - double.Parse(label1.Text)).ToString());
          //  TimeSpan dt = DateTime.Parse(label5.Text) - DateTime.Parse(label1.Text);
         //   MessageBox.Show(dt.ToString());

          //  double seconds = dt.TotalHours;
           // MessageBox.Show(seconds.ToString());
        }
        double MC;
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MC = double.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введите теплоемкость!");
            }
        }
        double Nend;
        double dTdt;
        private void button7_Click(object sender, EventArgs e)
        {
            double dT =double.Parse(label25.Text) - double.Parse(label22.Text);
            TimeSpan dt = DateTime.Parse(label24.Text) - DateTime.Parse(label21.Text);
            double hours = dt.TotalHours;
            if (checkBox1.Checked == false)
            {
               dTdt = dT / hours;
            }

            if (checkBox1.Checked == true)
            {
               dTdt = dT / hours - dT1dt;
            }
            //double dTdt = dT / hours;
            label29.Text = "dT/dt = " + Math.Round(  dTdt,3).ToString() + " \u2103/ч";
            Nend =    MC * dTdt;
            label30.Text = "Nкон = " + Math.Round( Nend,3).ToString() + " МВт";
            double dN = Nend - Nbeg;
            label32.Text = "\u0394N = " + Math.Round( dN,3).ToString() + " МВт";
            double dp1 =double.Parse(label23.Text) - double.Parse(label26.Text);
            double dpN =  - (dp1 * 0.74 + dpdT * dT);
          //  var str = string.Format("{0:0.##}", dpN);

            double da =dpN / dN;
           // var str1 = string.Format("{0:0.##}", da);
         //   label33.Text = "\u03C1N = " + dpN.ToString("E", CultureInfo.InvariantCulture);
            label33.Text = "\u03C1N = " + dpN.ToString("E", CultureInfo.InvariantCulture);
            label34.Text = "\u03B1N = " + da.ToString("E", CultureInfo.InvariantCulture);
          //  var str = string.Format("{0:0.##}", d);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {

            }
        }
    }
}
