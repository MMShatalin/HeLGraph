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
    public partial class Передвинуть_график : Form
    {
        public Передвинуть_график()
        {
            InitializeComponent();
        }

        private void Передвинуть_график_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0,001";
         //   numericUpDown1.
            Form1 main = this.Owner as Form1;

            for (int i = 0; i < main.MyKKSonChart.Count; i++)
            {
                comboBox1.Items.Add(main.MyKKSonChart[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double t = double.Parse(textBox1.Text);
                Form1.popravka = Form1.popravka + t;
                Form1 main = this.Owner as Form1;

                Сглаживание_скользящим_средним.NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                //    Сглаживание_скользящим_средним.NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                main.chart1.Series[Сглаживание_скользящим_средним.NowSeries].Points.Clear();
                //    main.chart1.Legends.RemoveAt(Сглаживание_скользящим_средним.NowLegend);
                //    main.chart1.Series[Сглаживание_скользящим_средним.NowSeries].IsVisibleInLegend = false;


                //    main.NumberSeries--;
                main.TERT(comboBox1.Text, Сглаживание_скользящим_средним.NowSeries, Form1.popravka);
                //  
                button1.Click += main.button5_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double t = double.Parse(textBox1.Text);
                Form1.popravka = Form1.popravka-t;
                Form1 main = this.Owner as Form1;

                Сглаживание_скользящим_средним.NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                //    Сглаживание_скользящим_средним.NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                main.chart1.Series[Сглаживание_скользящим_средним.NowSeries].Points.Clear();
                //    main.chart1.Legends.RemoveAt(Сглаживание_скользящим_средним.NowLegend);
                //    main.chart1.Series[Сглаживание_скользящим_средним.NowSeries].IsVisibleInLegend = false;


                //    main.NumberSeries--;
                main.TERT(comboBox1.Text, Сглаживание_скользящим_средним.NowSeries, Form1.popravka);
                //  
                button2.Click += main.button5_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
