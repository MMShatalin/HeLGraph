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
    public partial class Параметры_на_участке : Form
    {
        public Параметры_на_участке()
        {
            InitializeComponent();
        }
        public static string help1;
        public static string help2;
        public static string help3;
        public string HELP1(string help1)
        {
            return help1;
        }
        public string HELP2(string help2)
        {
            return help2;
        }
        public string HELP3(string help3)
        {
            return help3;
        }
        private void Параметры_на_участке_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            for (int i = 0; i < main.MyKKSonChart.Count; i++)
            {
                comboBox1.Items.Add(main.MyKKSonChart[i]);
            }
        }
        string OnePoint;
        string TwoPoint;
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value2(main.MyAllSensors, main.pixel, main.chart1, comboBox1.Text);
            OnePoint =n.HELP1(Search_Min_Error.help1);
            label1.Text = OnePoint + "\n" + n.HELP2(Search_Min_Error.help2);
       //     OnePoint = 
     //       label2.Text = n.HELP2(Search_Min_Error.help2);
          //  label3.Text = n.HELP3(Search_Min_Error.help3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Min_Error n = new Search_Min_Error();
            Form1 main = this.Owner as Form1;
            Search_Min_Error.Cursor_Value2(main.MyAllSensors, main.pixel, main.chart1, comboBox1.Text);
            TwoPoint = n.HELP1(Search_Min_Error.help1);
            label2.Text = n.HELP1(Search_Min_Error.help1) + "\n" + n.HELP2(Search_Min_Error.help2);

            try
            {
                AddOtrezok(OnePoint, TwoPoint);
                label6.Text = myOtrezok.Min().ToString();
                label8.Text = myOtrezok.Max().ToString();
                double sr = myOtrezok.Average();
                label10.Text = sr.ToString();
                double sum = 0;

                for (int i = 0; i < myOtrezok.Count; i++)
                {

                    sum = sum + Math.Pow(myOtrezok[i] - sr, 2);
                }

                double standOtklon = Math.Sqrt(sum / myOtrezok.Count);
                label12.Text = standOtklon.ToString();
                myOtrezok.Clear();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
        List<double> myOtrezok = new List<double>();
        private void AddOtrezok(string OnePoint, string TwoPoint)
        {
            int indexBegin=0;
            int indexEnd=0;
            Form1 main = this.Owner as Form1;
            for (int i = 0; i < main.MyAllSensors.Count; i++)
            {
                if(comboBox1.Text == main.MyAllSensors[i].KKS_Name)
                {
                  //   MessageBox.Show((Convert.ToDateTime(OnePoint).ToOADate().ToString() + " " +main.MyAllSensors[i].MyListRecordsForOneKKS[7].DateTime.ToOADate().ToString()));
                    for (int j = 0; j < main.MyAllSensors[i].MyListRecordsForOneKKS.Count; j++)
                    {

                        if (OnePoint == main.MyAllSensors[i].MyListRecordsForOneKKS[j].DateTime.ToString())
                        {
                            indexBegin = j;
                        }
                        if (TwoPoint == main.MyAllSensors[i].MyListRecordsForOneKKS[j].DateTime.ToString())
                        {
                            indexEnd = j;
                        }
                    }
                }
            }
            for (int i = 0; i < main.MyAllSensors.Count; i++)
            {
                if (comboBox1.Text == main.MyAllSensors[i].KKS_Name)
                {
                    //   MessageBox.Show((Convert.ToDateTime(OnePoint).ToOADate().ToString() + " " +main.MyAllSensors[i].MyListRecordsForOneKKS[7].DateTime.ToOADate().ToString()));
                    for (int j = indexBegin; j < indexEnd; j++)
                    {
                        myOtrezok.Add(main.MyAllSensors[i].MyListRecordsForOneKKS[j].Value);
                    }
                }
            }
          //  MessageBox.Show(myOtrezok.Average().ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    AddOtrezok(OnePoint, TwoPoint);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtrezok(OnePoint, TwoPoint);
                label6.Text = myOtrezok.Min().ToString();
                label8.Text = myOtrezok.Max().ToString();
                double sr = myOtrezok.Average();
                label10.Text = sr.ToString();
                double sum = 0;

                for (int i = 0; i < myOtrezok.Count; i++)
                {

                    sum = sum + Math.Pow(myOtrezok[i] - sr, 2);
                }

                double standOtklon = Math.Sqrt(sum / myOtrezok.Count);
                label12.Text = standOtklon.ToString();
                myOtrezok.Clear();
            }
            catch
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label6.Text = null;
            label8.Text = null;
            label10.Text = null;        
            label12.Text = null;
             label1.Text = null;        
            label2.Text = null;
        }
    }
}
