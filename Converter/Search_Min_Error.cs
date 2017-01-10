using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Converter
{
    class Search_Min_Error:PowerEffect
    {
        //нужно для того чтобы отоброжалось наконец то в форме для label1 для времени
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
        public static void Cursor_Value(int NumberSeries, List<Sensors> Value, double PixelPositionToValue, Chart t, DataTable u, List<DateTime> ddd)
        {
            try
            {
                // MessageBox.Show(NumberSeries.ToString());
                double r = 0;
                DateTime q = new DateTime();
                List<double> er = new List<double>();
                for (int ii = 0; ii < NumberSeries; ii++)
                {
                    er.Clear();
                    for (int j = 0; j < Value.Count; j++)
                    {
                        //  MessageBox.Show(t.Series[ii].LegendText);
                        if (t.Legends[ii].ToString().Remove(0, 7) == Value[j].KKS_Name)
                        {
                            //    MessageBox.Show(t.Series[ii].LegendText);
                            for (int jj = 0; jj < Value[j].MyListRecordsForOneKKS.Count; jj++)
                            {

                                double w = Value[j].MyListRecordsForOneKKS[jj].DateTime.ToOADate() - PixelPositionToValue;
                                w = Math.Abs(w);
                                er.Add(w);
                            }

                            er.IndexOf(er.Min());

                            r = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value;
                            q = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].DateTime;
                        }

                        //  t.Series[ii].LegendText
                    }
                    u.Rows.Add(t.Legends[ii].ToString().Remove(0, 7), q.ToString("dd.MM.yy HH:mm:ss.fff"), r);
                    //   ddd.Add(q)
                }//for
                ddd.Add(q);
            }
            catch
            {
                
            }

        }// Конец метода
        public static void Cursor_Value1(List<Sensors> Value, double PixelPositionToValue, Chart t, string Combobox1, string Combobox2)
        {
            
            PowerEffect main = new PowerEffect();
            //   double r = 0;

        
            //  DateTime q = new DateTime();
            List<double> er = new List<double>();
            List<double> er1 = new List<double>();
          //  MessageBox.Show(Combobox1);
               er.Clear();
               er1.Clear();
            for (int j = 0; j < Value.Count; j++)
            {
                if (Combobox1 == Value[j].KKS_Name)
                {
                    //MessageBox.Show(Value[j].MyListRecordsForOneKKS.Count.ToString());
                    for (int jj = 0; jj < Value[j].MyListRecordsForOneKKS.Count; jj++)
                    {
                        double w = Value[j].MyListRecordsForOneKKS[jj].DateTime.ToOADate() - PixelPositionToValue;
                        w = Math.Abs(w);
                        er.Add(w);
                    }
                    //    return PixelPositionToValue;
                    er.IndexOf(er.Min());
                   // MessageBox.Show(Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value.ToString());
                    Search_Min_Error.help2 = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value.ToString();
                    Search_Min_Error.help1 = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].DateTime.ToString();
                   // MessageBox.Show(main.label1.Text);

                }
                if (Combobox2 == Value[j].KKS_Name)
                {
                  //  MessageBox.Show(Value[j].KKS_Name.ToString() + " " + Combobox2.ToString());
                //    //MessageBox.Show(Value[j].MyListRecordsForOneKKS.Count.ToString());
                 for (int jj = 0; jj < Value[j].MyListRecordsForOneKKS.Count; jj++)
                 {
                       double w = Value[j].MyListRecordsForOneKKS[jj].DateTime.ToOADate() - PixelPositionToValue;
                      w = Math.Abs(w);
                      er1.Add(w);
                   }
                //    //    return PixelPositionToValue;
                   er1.IndexOf(er1.Min());
                //    // MessageBox.Show(Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value.ToString());
                 Search_Min_Error.help3 = Value[j].MyListRecordsForOneKKS[er1.IndexOf(er1.Min())].Value.ToString();
                 Search_Min_Error.help1 = Value[j].MyListRecordsForOneKKS[er1.IndexOf(er1.Min())].DateTime.ToString();
                //    // MessageBox.Show(main.label1.Text);

                }

                //   u.Rows.Add(t.Series[ii].LegendText, q.ToString("dd.MM.yy hh:mm:ss.fff"), r);
                //   ddd.Add(q)
            }
        }//for
        public static void Cursor_Value2(List<Sensors> Value, double PixelPositionToValue, Chart t, string Combobox1)
        {

            PowerEffect main = new PowerEffect();
            //   double r = 0;


            //  DateTime q = new DateTime();
            List<double> er = new List<double>();
         //   List<double> er1 = new List<double>();
            //  MessageBox.Show(Combobox1);
            er.Clear();
          //  er1.Clear();
            for (int j = 0; j < Value.Count; j++)
            {
                if (Combobox1 == Value[j].KKS_Name)
                {
                    //MessageBox.Show(Value[j].MyListRecordsForOneKKS.Count.ToString());
                    for (int jj = 0; jj < Value[j].MyListRecordsForOneKKS.Count; jj++)
                    {
                        double w = Value[j].MyListRecordsForOneKKS[jj].DateTime.ToOADate() - PixelPositionToValue;
                        w = Math.Abs(w);
                        er.Add(w);
                    }
                    //    return PixelPositionToValue;
                    er.IndexOf(er.Min());
                    // MessageBox.Show(Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value.ToString());
                    Search_Min_Error.help2 = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].Value.ToString();
                    Search_Min_Error.help1 = Value[j].MyListRecordsForOneKKS[er.IndexOf(er.Min())].DateTime.ToString();
                    // MessageBox.Show(main.label1.Text);

                }
              
                //   u.Rows.Add(t.Series[ii].LegendText, q.ToString("dd.MM.yy hh:mm:ss.fff"), r);
                //   ddd.Add(q)
            }
        }//for
          //  ddd.Add(q);

        // Конец метода
        public static void Cursor_Value_Average(int NumberSeries, List<Sensors> Value, double PixelPositionToValue, Chart t, DataTable u, int AmountPoint)
        {
            double r = 0;
            double sum = 0;
            DateTime q = new DateTime();
            int tre = 0;

            List<double> er = new List<double>();
            for (int ii = 0; ii < NumberSeries; ii++)
            {
                er.Clear();
                for (int j = 0; j < Value.Count; j++)
                {
                    if (t.Series[ii].LegendText == Value[j].KKS_Name)
                    {
                        for (int jj = 0; jj < Value[j].MyListRecordsForOneKKS.Count; jj++)
                        {

                            double w = Value[j].MyListRecordsForOneKKS[jj].DateTime.ToOADate() - PixelPositionToValue;
                            w = Math.Abs(w);
                            er.Add(w);
                        }

                        tre = er.IndexOf(er.Min());

                        r = Value[j].MyListRecordsForOneKKS[tre].Value;
                        q = Value[j].MyListRecordsForOneKKS[tre].DateTime;
                        sum = 0;
                        if (tre >= AmountPoint)
                        {
                            for (int jjj = tre - AmountPoint; jjj < tre + 1; jjj++)
                            {
                                sum = (sum + Value[j].MyListRecordsForOneKKS[jjj].Value);
                            }
                        }
                        if (tre < AmountPoint)
                        {
                            for (int jjj = 0; jjj < tre + 1; jjj++)
                            {
                                sum = (sum + Value[j].MyListRecordsForOneKKS[jjj].Value);
                            }
                        }
                    }
                }

                if (tre >= AmountPoint)
                {

                    double aver = sum / (AmountPoint + 1);
                    u.Rows.Add(t.Series[ii].LegendText, q, aver);
                }

                if (tre < AmountPoint)
                {

                    double aver = sum / tre;
                    u.Rows.Add(t.Series[ii].LegendText, q, aver);
                }

            }//for
        }// Конец метод
    }
}
