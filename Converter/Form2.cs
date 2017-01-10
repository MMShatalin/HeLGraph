using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using System.Reflection;
using System.Collections;

namespace Converter
{
    public partial class Form2 : Form
    {
        //public string app = Application.StartupPath;
        public Form2()
        {
            InitializeComponent();
            comboBox8.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox7.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox6.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox5.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox1.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox2.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            //public string app = Application.StartupPath;
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yy HH:mm:ss";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yy HH:mm:ss";
            dateTimePicker1.Value = DateTime.FromOADate(main.chart1.ChartAreas[0].AxisX.Minimum);
            dateTimePicker2.Value = DateTime.FromOADate(main.chart1.ChartAreas[0].AxisX.Maximum);
         //   MessageBox.Show(main.chart1.ChartAreas[0].AxisX.Maximum.ToString());
     //       main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);
            main.comboBox1.Enabled = false;
           // textBox1.Text = main.chart1.ChartAreas[0].AxisX.Minimum.ToString();
          //  textBox3.Text = main.chart1.ChartAreas[0].AxisX.Maximum.ToString();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
          //  Form1 main = this.Owner as Form1;
           // main.chart1.Series[0].XValueType = ChartValueType.Time;

            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = 20;
            numericUpDown1.Minimum = 6;
            numericUpDown2.Value = 1;
            numericUpDown2.Maximum = 20;
            numericUpDown2.Minimum = 6;
            numericUpDown3.Value = 1;
            numericUpDown3.Maximum = 20;
            numericUpDown3.Minimum = 6;
            numericUpDown4.Value = 1;
            numericUpDown4.Maximum = 20;
            numericUpDown4.Minimum = 6;
            numericUpDown5.Value = 1;
            numericUpDown5.Maximum = 20;
            numericUpDown5.Minimum = 6;
            numericUpDown6.Value = 1;
            numericUpDown6.Maximum = 20;
            numericUpDown6.Minimum = 6;
            numericUpDown7.Value = 1;
            numericUpDown7.Maximum = 20;
            numericUpDown7.Minimum = 6;
            numericUpDown8.Value = 1;
            numericUpDown8.Maximum = 20;
            numericUpDown8.Minimum = 6;

            comboBox3.Items.Add("Y1");
            comboBox3.Items.Add("Y2");
            comboBox3.Items.Add("Y3");
            comboBox3.Items.Add("Y4");

          //  comboBox4.Items.Add("Экспоненциальный вид");
            comboBox4.Items.Add("Числовой/Экспоненциальный");

      
           textBox2.Text = main.chart1.ChartAreas[0].AxisY.Minimum.ToString();
           textBox4.Text = main.chart1.ChartAreas[0].AxisY.Maximum.ToString();
      
            textBox5.Text = main.chart1.ChartAreas[0].AxisX.Interval.ToString();
       //     textBox6.Text = main.chart1.ChartAreas[0].AxisY.Interval.ToString();
            if (main.checkBox2.Checked == true)
            {
                if (main.t.Count == 1)
                {
                   // textBox23.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum.ToString();
                    //textBox24.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum.ToString();


                    textBox10.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Interval.ToString();

                  textBox12.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum.ToString();
                    textBox11.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum.ToString();
                }

                if (main.t.Count == 2)
                {
                    textBox10.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Interval.ToString();
                    textBox13.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Interval.ToString();

                    textBox12.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum.ToString();
                    textBox11.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum.ToString();
                    textBox14.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum.ToString();
                    textBox15.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum.ToString();
                }

                if (main.t.Count==3)
                {                   
                textBox10.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Interval.ToString();
                textBox13.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Interval.ToString();
                textBox21.Text = main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Interval.ToString();

                textBox12.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum.ToString();
                textBox11.Text = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum.ToString();
                textBox14.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum.ToString();
                textBox15.Text = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum.ToString();
                textBox19.Text = main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Minimum.ToString();
                textBox20.Text = main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Maximum.ToString();
                }             
            }
            
            textBox7.Text = "";
            textBox8.Text = main.chart1.ChartAreas[0].AxisY.Title;
            textBox9.Text = main.chart1.ChartAreas[0].AxisX.Title;        
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.chart1.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = (int)numericUpDown5.Value;
            }
            catch
            {

            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                //    main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);
                 main.chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", (int)numericUpDown3.Value, FontStyle.Regular);

             //   main.chart1.Titles[0].Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
            }
            catch
            {

            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                 main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);
               //  main.chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", (int)numericUpDown3.Value, FontStyle.Regular);

             //   main.chart1.Titles[0].Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
            }
            catch
            {

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
             Form1 main = this.Owner as Form1;
             try
             {
             //    main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);
               //  main.chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", (int)numericUpDown3.Value, FontStyle.Regular);

                 main.chart1.Titles[0].Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
             }
            catch
             {

             }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.chart1.ChartAreas[0].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown4.Value;
            }
            catch
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
                main.chart1.ChartAreas[0].AxisX.Interval = double.Parse(textBox5.Text);
                main.chart1.ChartAreas["ChartArea_Series3"].AxisX.Interval = double.Parse(textBox5.Text);
                main.chart1.ChartAreas["ChartArea_Series4"].AxisX.Interval = double.Parse(textBox5.Text);
                main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Interval = double.Parse(textBox5.Text);
            }
            catch
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                //   main.chart1.ChartAreas[0].AxisY.Title = textBox8.Text;
                main.chart1.ChartAreas[0].AxisY.Title = textBox8.Text;
                //       main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);

            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   textBox16.Text = textBox16.Text + comboBox1.Text;
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {

          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // textBox17.Text = textBox17.Text + comboBox2.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // textBox18.Text = textBox18.Text + comboBox3.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // textBox22.Text = textBox22.Text + comboBox4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
                main.chart1.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = (int)numericUpDown5.Value;
                main.chart1.ChartAreas[0].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown4.Value;

                if (main.checkBox2.Checked == true)
                {
                    if (main.NumberSeries == 2)
                    {
                        //     MessageBox.Show(main.NumberSeries.ToString());
                        main.chart1.ChartAreas[2].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown6.Value;
                    }
                    if (main.NumberSeries == 3)
                    {
                        main.chart1.ChartAreas[2].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown6.Value;
                        main.chart1.ChartAreas[3].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown7.Value;
                    }
                    if (main.NumberSeries == 4)
                    {
                        main.chart1.ChartAreas[2].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown6.Value;
                        main.chart1.ChartAreas[3].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown7.Value;
                        main.chart1.ChartAreas[4].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown8.Value;

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public TextAnnotation text;
        public TextAnnotation text1;
        public TextAnnotation text2;
        private void button9_Click(object sender, EventArgs e)
        {
          //  Form1 main = this.Owner as Form1;
      
          //  text = new TextAnnotation();
          //  text.Text = textBox16.Text;
          //  text.X = 4;
          //  text.Y = 5;
          //  text.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
          //  main.chart1.Annotations.Add(text);

          //  text1 = new TextAnnotation();
          //  text1.Text = textBox17.Text;
          //  text1.X = 83;
          //  text1.Y = 5;
          //  text1.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
          //  main.chart1.Annotations.Add(text1);

          //  text2 = new TextAnnotation();
          //  text2.Text = textBox18.Text;
          //  text2.X = 87;
          //  text2.Y = 5;
          //  text2.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
          //  main.chart1.Annotations.Add(text2);

          //TextAnnotation  text3 = new TextAnnotation();
          //  text3.Text = textBox22.Text;
          //  text3.X = 92;
          //  text3.Y = 5;
          //  text3.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
          //  main.chart1.Annotations.Add(text3);

           // text.Visible = true;
           // text1.Visible = true;
           // text2.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            main.chart1.Titles.Clear();
            main.chart1.Titles.Add(textBox7.Text);
           // main.chart1.ChartAreas[0].Position.Auto = false;

            main.chart1.ChartAreas[0].AxisY.Title = textBox8.Text;
            main.chart1.ChartAreas[0].AxisX.Title = textBox9.Text;
            
            main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);
            main.chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", (int)numericUpDown3.Value, FontStyle.Regular);
            
            main.chart1.Titles[0].Font = new Font("Times New Roman", (int)numericUpDown1.Value, FontStyle.Regular);
        }

        private void comboBox7_DrawItem(object sender, DrawItemEventArgs e)
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

        private void comboBox6_DrawItem(object sender, DrawItemEventArgs e)
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

        private void comboBox5_DrawItem(object sender, DrawItemEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
          //  main.chart1.Series["Series2"].Color = Color.FromName(comboBox5.Text);
            main.t[0].AxisY.LineColor = Color.FromName(comboBox5.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
        //    main.chart1.Series["Series3"].Color = Color.FromName(comboBox6.Text);         
            main.t[1].AxisY.LineColor = Color.FromName(comboBox6.Text);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //    main.chart1.Series["Series4"].Color = Color.FromName(comboBox7.Text);                     
            main.t[2].AxisY.LineColor = Color.FromName(comboBox7.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
        //    main.chart1.Series["Series4"].Color = Color.FromName(comboBox7.Text);                     
            main.t[2].AxisY.LineColor = Color.FromName(comboBox7.Text);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //   main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
            main.chart1.ChartAreas[1].AxisY.LineColor = Color.FromName(comboBox8.Text);
        }

        private void comboBox8_DrawItem(object sender, DrawItemEventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
        
          //  chart1.Series["Series1"].Color = Color.Red;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if(checkBox1.Checked == true)
            {
                main.chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
                
                main.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                main.chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                main.chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Gray;
                main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.Gray;
            }
            if (checkBox1.Checked == false)
            {
                main.chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
                main.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            main.chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            main.chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dot;
            main.chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            main.chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            main.chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (checkBox2.Checked == true)
            {
                main.chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;

                main.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
                main.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                main.chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                main.chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Gray;
                main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.Gray;
            }
            if (checkBox2.Checked == false)
            {
                main.chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
                main.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            main.chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            main.chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dot;
            main.chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            main.chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            main.chart1.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Form1 main = this.Owner as Form1;
                if (checkBox3.Checked == true)
                {
                    main.chart1.Legends[0].Enabled = true;
                }
                if (checkBox3.Checked == false)
                {
                    main.chart1.Legends[0].Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //   main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
           // main.chart1.BackColor = Color.FromName(comboBox1.Text);
            main.chart1.ChartAreas[0].BackColor = Color.FromName(comboBox1.Text);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
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

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.chart1.ChartAreas[1].AxisY.LineWidth = (int)numericUpDown9.Value;
            main.chart1.ChartAreas[1].AxisY.LineColor = main.chart1.Series["Series1"].Color;
            //main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
            //   main.chart1.ChartAreas[0].AxisY.LineColor = Color.FromName(comboBox8.Text);

            for (int i = 0; i < main.t.Count; i++)
            {
                main.t[i].AxisY.LineWidth = (int)numericUpDown9.Value;
            }
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
            //   main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
            main.chart1.BackColor = Color.FromName(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //   main.chart1.Series["Series1"].Color = Color.FromName(comboBox8.Text);
            // main.chart1.BackColor = Color.FromName(comboBox1.Text);
            main.chart1.ChartAreas[0].BackColor = Color.FromName(comboBox2.Text);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //    main.chart1.Series["Series3"].Color = Color.FromName(comboBox6.Text);         
            main.t[1].AxisY.LineColor = Color.FromName(comboBox6.Text);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //  main.chart1.Series["Series2"].Color = Color.FromName(comboBox5.Text);
            main.t[0].AxisY.LineColor = Color.FromName(comboBox5.Text);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Form1 main = this.Owner as Form1;
                if (comboBox3.Text == "Y1")
                {

                    if (comboBox4.Text == "Числовой/Экспоненциальный")
                    {
                        main.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "G";
                    }
                }
                if (comboBox3.Text == "Y2")
                {
                    if (comboBox4.Text == "Числовой/Экспоненциальный")
                    {
                        //      main.t[0].AxisY.LabelStyle.Format = "E2";
                        main.t[0].AxisY.LabelStyle.Format = "G";
                    }

                }
                if (comboBox3.Text == "Y3")
                {
                    if (comboBox4.Text == "Числовой/Экспоненциальный")
                    {
                        main.t[1].AxisY.LabelStyle.Format = "G";

                    }

                }
                if (comboBox3.Text == "Y4")
                {
                    if (comboBox4.Text == "Числовой/Экспоненциальный")
                    {
                        main.t[2].AxisY.LabelStyle.Format = "G";
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            СhangeLegends ChangeParametrImage = new СhangeLegends();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                Form1 main = this.Owner as Form1;

                try
                {
                   // if (double.Parse(textBox1.Text) < main.chart1.ChartAreas[0].AxisX.Maximum)
                    {
                    //    main.chart1.ChartAreas[0].AxisX.Minimum = double.Parse(textBox1.Text);
                     //   main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = double.Parse(textBox1.Text);
                       // main.chart1.ChartAreas["ChartArea_Series3"].AxisX.Minimum = double.Parse(textBox1.Text);
                       // main.chart1.ChartAreas["ChartArea_Series4"].AxisX.Minimum = double.Parse(textBox1.Text);
                    }
                }
              catch
                {

                }
           
        }

        private void textBox1_TabStopChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Form1 main = this.Owner as Form1;
            //if (double.Parse(textBox1.Text) < double.Parse(textBox3.Text))
            //{
            //    main.chart1.ChartAreas[0].AxisX.Minimum = double.Parse(textBox1.Text);
            //}
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
              //  if// (double.Parse(textBox3.Text) >= main.chart1.ChartAreas[0].AxisX.Minimum)
                {
                 //   main.chart1.ChartAreas[0].AxisX.Maximum = double.Parse(textBox3.Text);
                  //  main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = double.Parse(textBox3.Text);
                  //  main.chart1.ChartAreas["ChartArea_Series3"].AxisX.Maximum = double.Parse(textBox3.Text);
                   // main.chart1.ChartAreas["ChartArea_Series4"].AxisX.Maximum = double.Parse(textBox3.Text);
                }
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
                if (double.Parse(textBox2.Text) < main.chart1.ChartAreas[0].AxisY.Maximum)
                {
                    main.chart1.ChartAreas[0].AxisY.Minimum = double.Parse(textBox2.Text);
                }

            }
            catch
            {

            }
        //    main.chart1.ChartAreas[0].AxisY.Minimum = double.Parse(textBox2.Text);
         //   main.chart1.ChartAreas[0].AxisY.Maximum = double.Parse(textBox4.Text);

           // main.chart1.ChartAreas[0].AxisX.Interval = double.Parse(textBox5.Text);
           // main.chart1.ChartAreas[0].AxisY.Interval = double.Parse(textBox6.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox4.Text) >= main.chart1.ChartAreas[0].AxisY.Minimum)
                {
                    main.chart1.ChartAreas[0].AxisY.Maximum = double.Parse(textBox4.Text);
                }
            }
            catch
            {

            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum = double.Parse(textBox12.Text);
            //main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum = double.Parse(textBox11.Text);

            //main.t[0].AxisY.Interval = double.Parse(textBox10.Text);

            //main.t[0].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
            //main.t[0].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;

            //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = double.Parse(textBox1.Text);
            //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = double.Parse(textBox3.Text);

            //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Interval = double.Parse(textBox5.Text);
            try
            {
                if (double.Parse(textBox12.Text) < main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum)
                {
                    main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum = double.Parse(textBox12.Text);
                    main.t[0].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    //main.t[0].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    //main.t[0].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;

                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = double.Parse(textBox1.Text);
                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = double.Parse(textBox3.Text);
                }

            }
            catch
            {

            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox11.Text) >= main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum)
                {
                    main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum = double.Parse(textBox11.Text);
                    main.t[0].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;
                }
            }
            catch
            {

            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox14.Text) < main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum)
                {
                    main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum = double.Parse(textBox14.Text);
                    main.t[1].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum;
                    //main.t[0].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    //main.t[0].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;

                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = double.Parse(textBox1.Text);
                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = double.Parse(textBox3.Text);
                }

            }
            catch
            {

            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox15.Text) >= main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum)
                {
                    main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum = double.Parse(textBox15.Text);
                    main.t[1].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum;
                }
            }
            catch
            {

            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox19.Text) < main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Maximum)
                {
                    main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Minimum = double.Parse(textBox19.Text);
                    main.t[2].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Minimum;
                    //main.t[0].AxisY.Minimum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    //main.t[0].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;

                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = double.Parse(textBox1.Text);
                    //main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = double.Parse(textBox3.Text);
                }
            }
            catch
            {

            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                if (double.Parse(textBox20.Text) >= main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Minimum)
                {
                    main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Maximum = double.Parse(textBox20.Text);
                    main.t[2].AxisY.Maximum = main.chart1.ChartAreas["ChartArea_Series4"].AxisY.Maximum;
                }
            }
            catch
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.chart1.ChartAreas[0].AxisY.Interval = double.Parse(textBox6.Text);
            }
            catch
            {

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[0].AxisY.Interval = double.Parse(textBox10.Text);
            }
            catch
            {

            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[1].AxisY.Interval = double.Parse(textBox13.Text);
            }
            catch
            {

            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[2].AxisY.Interval = double.Parse(textBox21.Text);
            }
            catch
            {

            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[0].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown6.Value;
            }
            catch
            {

            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[1].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown7.Value;
            }
            catch
            {

            }
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                main.t[2].AxisY.LabelAutoFitMinFontSize = (int)numericUpDown8.Value;
            }
            catch
            {

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
               main.chart1.Titles.Clear();
                main.chart1.Titles.Add(textBox7.Text);
            }
            catch
            {

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
             //   main.chart1.ChartAreas[0].AxisY.Title = textBox8.Text;
                main.chart1.ChartAreas[0].AxisX.Title = textBox9.Text;
         //       main.chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", (int)numericUpDown2.Value, FontStyle.Regular);

            }
            catch
            {

            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.comboBox1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
                if (dateTimePicker1.Value.ToOADate() < main.chart1.ChartAreas[0].AxisX.Maximum)
                
                {
                    main.chart1.ChartAreas[0].AxisX.Minimum = dateTimePicker1.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = dateTimePicker1.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series3"].AxisX.Minimum = dateTimePicker1.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series4"].AxisX.Minimum = dateTimePicker1.Value.ToOADate();
                   //   dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                   //   dateTimePicker1.CustomFormat = "dd.MM.yy HH:mm:ss";
                    //  dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                     // dateTimePicker2.CustomFormat = "dd.MM.yy HH:mm:ss";
                     /// dateTimePicker1.Value = DateTime.FromOADate(main.chart1.ChartAreas[0].AxisX.Minimum);
                      //dateTimePicker2.Value = DateTime.FromOADate(main.chart1.ChartAreas[0].AxisX.Maximum);
                }
            }
            catch
            {

            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            try
            {
                if (dateTimePicker2.Value.ToOADate()  >= main.chart1.ChartAreas[0].AxisX.Minimum)
                {
                    main.chart1.ChartAreas[0].AxisX.Maximum = dateTimePicker2.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = dateTimePicker2.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series3"].AxisX.Maximum = dateTimePicker2.Value.ToOADate();
                    main.chart1.ChartAreas["ChartArea_Series4"].AxisX.Maximum = dateTimePicker2.Value.ToOADate();
                }
            }
            catch
            {

            }
        }





    }
}
