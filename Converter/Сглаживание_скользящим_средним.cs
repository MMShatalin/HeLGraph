using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Converter
{
    public partial class Сглаживание_скользящим_средним : Form
    {
        public Сглаживание_скользящим_средним()
        {
            InitializeComponent();
            comboBox2.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            //public int IndexDeleteGraf = 0;
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Сглаживание_скользящим_средним_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            button2.Enabled = false;
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 1000;

            trackBar2.Minimum = 1;
            trackBar2.Maximum = 20;

          //  numericUpDown1.Maximum = 10000;

      //      numericUpDown1.Value = main.My_Step;

            for (int i = 0; i < main.MyKKSonChart.Count; i++)
            {
                comboBox1.Items.Add(main.MyKKSonChart[i]);
            }
            comboBox3.Items.Add("Линейный");
            comboBox3.Items.Add("Точечный");
            label2.Text = "0";
            label4.Text = "1";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
          
                    main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].Color = Color.FromName(comboBox2.Text);
          
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X + 20, rect.Top);
                g.FillRectangle(b, rect.X, rect.Y, 20, 20);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
       
            label11.Text = main.MyOb(comboBox1.Text);
            button2.Enabled = true;
            if(comboBox1.Text == main.chart1.Series[0].LegendText)
            {
                button2.Enabled = false;
            }
        //    label10.Text = main.PointsInGraf(comboBox1.Text, (int)numericUpDown1.Value).ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
            Form1 main = this.Owner as Form1;
            if (main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].ChartType == SeriesChartType.FastLine)
            {
                main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].BorderWidth = trackBar2.Value;
            }

            if (comboBox3.Text == "Точечный")
            {
                main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].MarkerSize = trackBar2.Value;
            }
        }
        public List<int> IndecatorAcex = new List<int>();
        int d;
        private void button1_Click(object sender, EventArgs e)
        {
            int r;
            if (label2.Text == "")
            {
                label2.Text = "0";
                r = int.Parse(label2.Text.ToString().Trim());
            }
            else
            {
                r = int.Parse(label2.Text.ToString().Trim());
            }

            Form1 main = this.Owner as Form1;
            main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].Points.Clear();
            main.REnaAxis123(comboBox1.Text, r, main.SeriesNumberAtTheMoment(comboBox1.Text));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (comboBox3.Text == "Линейный")
            {
                main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].ChartType = SeriesChartType.FastLine;
            }
            if (comboBox3.Text == "Точечный")
            {
                main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].ChartType = SeriesChartType.Point;
            }
        }
        public static int NowSeries;
        public static int NowLegend;
        public static int IndexDeleteGraf;
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
       

            if (main.chart1.ChartAreas.Count == 7)
            {
                NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                main.chart1.Series[NowSeries].Points.Clear();
                main.chart1.Legends.RemoveAt(NowLegend);
                main.chart1.Series[NowSeries].IsVisibleInLegend = false;
                for (int i = 0; i < main.MyKKSonChart.Count; i++)
                {
                    if (comboBox1.Text == main.MyKKSonChart[i])
                    {
                        main.MyKKSonChart.RemoveAt(i);
                    }
                }

                main.NumberSeries--;
            }
            if (main.chart1.ChartAreas.Count == 5)
            {
                NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                main.chart1.Series[NowSeries].Points.Clear();
                main.chart1.Legends.RemoveAt(NowLegend);
                main.chart1.Series[NowSeries].IsVisibleInLegend = false;
                for (int i = 0; i < main.MyKKSonChart.Count; i++)
                {
                    if (comboBox1.Text == main.MyKKSonChart[i])
                    {
                        main.MyKKSonChart.RemoveAt(i);
                    }
                }

                main.NumberSeries--;
            }

            if (main.chart1.ChartAreas.Count == 3)
            {
                    NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                    NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                    main.chart1.Series[NowSeries].Points.Clear();
                    main.chart1.Legends.RemoveAt(NowLegend);
                    main.chart1.Series[NowSeries].IsVisibleInLegend = false;
        
                    for (int i = 0; i < main.MyKKSonChart.Count; i++)
                    {
                        if (comboBox1.Text == main.MyKKSonChart[i])
                        {
                            main.MyKKSonChart.RemoveAt(i);
                        }
                    }

                    main.NumberSeries--;
            }

                if (main.chart1.ChartAreas.Count == 1)
                {

                    NowSeries = main.SeriesNumberAtTheMoment(comboBox1.Text);
                    NowLegend = main.lEGENDNumberAtTheMoment(comboBox1.Text);
                    main.chart1.Series[NowSeries].Points.Clear();
                    main.chart1.Legends.RemoveAt(NowLegend);
                    main.chart1.Series[NowSeries].IsVisibleInLegend = false;
                    for (int i = 0; i < main.MyKKSonChart.Count; i++)
                    {
                        if (comboBox1.Text == main.MyKKSonChart[i])
                        {
                            main.MyKKSonChart.RemoveAt(i);
                        }
                    }

                    main.NumberSeries--;
                }

               comboBox1.Items.Clear();
               if (main.chart1.Legends.Count >= 1)
               {
                   for (int i = 0; i < main.MyKKSonChart.Count; i++)
                   {
                       comboBox1.Items.Add(main.MyKKSonChart[i]);
                   }
               }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Form1 main = this.Owner as Form1;
           // MessageBox.Show(main.chart1.Series[main.SeriesNumberAtTheMoment(comboBox1.Text)].ChartType.ToString());
        }
    }
}
// chart1.Series[NumberSeries - 1].Points.Clear();