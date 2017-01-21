using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Converter
{

    static class Zone
    {
        private static int _numberSeries = 0;
        public static void CreateChart(SplitterPanel N, Chart chart, System.Windows.Forms.DataVisualization.Charting.Cursor B)
        {
            // Помещаем его на форму

            chart.Parent = N;

            // Задаём размеры элемента
            chart.Dock = DockStyle.Fill;

            // Создаём новую область для построения графика
            ChartArea area = new ChartArea();
            // Даём ей имя (чтобы потом добавлять графики)
            area.Name = "myGraph";

            chart.ChartAreas.Add(area);
            // Создаём объект для первого графика
            Series series1 = new Series();
            //  // Ссылаемся на область для построения графика
            series1.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series1.ChartType = SeriesChartType.FastLine;
            // Указываем ширину линии графика
            series1.BorderWidth = 2;
            // Название графика для отображения в легенде
            // series1.LegendText = "гистограмма";
            // Добавляем в список графиков диаграммы
            chart.Series.Add(series1);
            // Аналогичные действия для второго графика
            Series series2 = new Series();
            series2.ChartArea = "myGraph";
            series2.ChartType = SeriesChartType.FastLine;
            series2.BorderWidth = 2;
            // series2.LegendText = "//////";
            chart.Series.Add(series2);

            Series series3 = new Series();
            series3.ChartArea = "myGraph";
            series3.ChartType = SeriesChartType.FastLine;
            series3.BorderWidth = 2;
            chart.Series.Add(series3);

            Series series4 = new Series();
            series4.ChartArea = "myGraph";
            series4.ChartType = SeriesChartType.FastLine;
            series4.BorderWidth = 2;
            chart.Series.Add(series4);

            chart.Series[0].Color = Color.Red;
            chart.Series[1].Color = Color.Blue;
            chart.Series[2].Color = Color.Green;
            chart.Series[3].Color = Color.Purple;


            for (int i = 1; i < 5; i++)
            {
                chart.Series["Series" + i].IsVisibleInLegend = false;
            }

            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);

          
           B = chart.ChartAreas[0].CursorX;
           B.LineDashStyle = ChartDashStyle.DashDot;
           B.LineColor = Color.Red;
           B.SelectionColor = Color.Yellow;
        }


        public static void AddGraph(List<Sensors> N, TreeView M, Chart L)
        {
            for (int k = 0; k < N.Count; k++)
            {
                if (M.SelectedNode.Text == N[k].KKS_Name)

                    for (int i = 0; i < N[k].MyListRecordsForOneKKS.Count; i++)
                    {
                        L.Series[_numberSeries].Points.AddXY(N[k].MyListRecordsForOneKKS[i].DateTime,
                            N[k].MyListRecordsForOneKKS[i].Value);
                    }
            }
          //  L.Series[_numberSeries].LegendText = N[k].KKS_Name;
          //  L.Series[_numberSeries].IsVisibleInLegend = true;

            //   Zone.Charts[0].Legends.Add(chart1.Series[NumberSeries].LegendText);
            //   Zone.Charts[0].Series[_numberSeries].BorderWidth = 2;
            //   Zone.Charts[0].Legends[0].Docking = Docking.Bottom;
            _numberSeries++; 
        }
    }
}
