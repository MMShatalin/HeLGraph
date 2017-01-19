using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Word;
using System.Drawing.Printing;


//псевдонимы
using SD = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using GNos.Windows.Forms;


namespace Converter
{
    public struct OneRec
    {
        public DateTime dt;
        public double value;
    }

    public partial class Form1 : Form
    {
     
        List<twoPoint> twoPoint = new List<twoPoint>();
        bool isClicked = false;
        int X = 0;
        int Y = 0;

        int X1 = 0;
        int Y1 = 0;

        private System.Collections.ArrayList customers = new System.Collections.ArrayList();
        private MyVirtualClass customerInEdit;
        private int rowInEdit = -1;
        private bool rowScopeCommit = true;
        List<Label> MyLabels = new List<Label>();
        public Label Metka1;
        public Label label4;
        public Label label5;
        public Label label6;
        public Label label7;
        public Label label8;
        public Label label9;

       // Graphics graphics = e.Graphics;
        private ScrollEngine scrollEngine;

        public Form1()
        {
            InitializeComponent();
            chart1.MouseUp += this.chart1_MouseUp;
            chart1.Paint += this.chart1_Paint;
        }

        private void scrollEngine_Scroll(object sender, ScrollEngine.ScrollEventArgs e)
        {

            Metka1.Location += e.Offset;

        }
        private void scrollEngine_Scroll1(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label4.Location += e.Offset;

        }
        private void scrollEngine_Scroll2(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label5.Location += e.Offset;

        }
        private void scrollEngine_Scroll3(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label6.Location += e.Offset;

        }
        private void scrollEngine_Scroll4(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label7.Location += e.Offset;

        }
        private void scrollEngine_Scroll5(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label8.Location += e.Offset;

        }
        private void scrollEngine_Scroll6(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label9.Location += e.Offset;

        }

        private void scrollEngine_Scroll10(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label10.Location += e.Offset;

        }

        private void scrollEngine_Scroll11(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label11.Location += e.Offset;

        }
        private void scrollEngine_Scroll12(object sender, ScrollEngine.ScrollEventArgs e)
        {

            label12.Location += e.Offset;

        }


  //      MyListOfSensors allSensors = new MyListOfSensors();
      //  MyListOfSensors Sensors1 = new MyListOfSensors();
      //  MyListOfSensors Sensors2 = new MyListOfSensors();
      //  MyListOfSensors Sensors3 = new MyListOfSensors();
      //  MyListOfSensors Sensors4 = new MyListOfSensors();
      //  MyListOfSensors Sensors1 = new MyListOfSensors();
       //  List<MyListOfSensors> MyListSensors = new List<MyListOfSensors>();
        List<Sensors> ListForTreeViesNode = new List<Sensors>();
      //  int index;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int NumberNode = 0;
                foreach (var item in openFileDialog1.FileNames)
                {
                    Archive.LoadFromFile(item, ListForTreeViesNode);
                    treeView1.Nodes.Add("MyFiles", item);
                    for (int i = 0; i < ListForTreeViesNode.Count; i++)
                    {
                        ListForTreeViesNode[i].KKS_Name = ListForTreeViesNode[i].KKS_Name + " [" + NumberNode + "]";
                        treeView1.Nodes[NumberNode].Nodes.Add(ListForTreeViesNode[i].KKS_Name);
                    }
                    NumberNode++;
                    MyAllSensors.AddRange(ListForTreeViesNode);
                    ListForTreeViesNode.Clear();
                }
            }
            добавитьНаОсьXToolStripMenuItem.Enabled = true;

        }
        public List<Sensors> MyAllSensors = new List<Sensors>();
        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
     
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void очиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 main = this.Owner as Form2;

            //chart1.ChartAreas[0].AxisX = null;
           // Y.Clear();
            //  chart1.ChartAreas.Clear();
            NumberSeries = 0;
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].LegendText = "";
            }

            //убирает все галочки с чеклистбоксов
       //     for (int i = 0; i < checkedListBox1.Items.Count; i++)
          //  {
            ////    checkedListBox1.SetItemChecked(i, false);
          //  }
            chart1.Titles.Clear();

            for (int i = 1; i < chart1.Series.Count - 2; i++)
            {
                chart1.Series["Series" + i].IsVisibleInLegend = false;
                chart1.Series["Series" + i].Points.Clear();
                //  chart1.Series["Series" + i].Points.Clear();
            }
            //button1.Enabled = false;
            //ОЧИСТКА ПОДПИСЕЙ ПАРАМЕТРОВ ОСЕЙ
            chart1.Annotations.Clear();
            listaver.Clear();
            t.Clear();
            добавитьНаОсьXToolStripMenuItem.Enabled = true;
            checkBox2.Enabled = true;
          //  очиститьГрафикToolStripMenuItem.Enabled = false;
            jToolStripMenuItem.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {

          

            
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (isClicked)
                {
                    X1 = e.X;
                    Y1 = e.Y;
                    chart1.Invalidate();
                }
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                isClicked = false;
                twoPoint.Add(new twoPoint(new Point(X, Y), new Point(X1, Y1)));
            }
        }
   //     PaintEventArgs tert;
        private void chart1_Paint(object sender, PaintEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Pen pen = new Pen(Color.Black,2);
                e.Graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
                foreach (var item in twoPoint)
                {
                   e.Graphics.DrawLine(pen, item.X, item.Y);
                }

            }
        }
        Graphics graphics =null;
        public void ReDraw(PaintEventArgs e)
        {
            graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
          //  Pen pen1 = new Pen(Color.White, 2);
            graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
            foreach (var item in twoPoint)
            {
                graphics.DrawLine(pen, item.X, item.Y);
            }
        }

        private void добатьбToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        System.Windows.Forms.DataVisualization.Charting.ChartArea newchar = new System.Windows.Forms.DataVisualization.Charting.ChartArea();


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
      //  public List<int> IndecatorAcex = new List<int>();
  //      List<double> Y = new List<double>();
        private void добавитьНаОсьXToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //  MessageBox.Show(chart1.ChartAreas.Count.ToString());
           chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(6, 12, 90, 80);
          //  chart1.ChartAreas[0].Position.Auto = true;
       //    try
         //  {
               AddGrafAnotherVremeni();
         //      chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(6, 12, 90, 80);
         //      chart1.ChartAreas[0].AxisX.Interval = 1;
             //  chart1.ChartAreas[0].AxisX.Minimum = 42511.999999456;
         //      IndecatorAcex.Add(0);
          // }
          // catch
           //{
            //   MessageBox.Show("Нажмите <Вкл. дополнительные оси Y> и добавляйте параметры на необходимые оси!");
            //   NumberSeries--;      
          // }
              //chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(6, 12, 100, 80);
           if (NumberSeries >= 1)
           {
               checkBox2.Enabled = true;
           }
           if (NumberSeries >0)
           {
               comboBox1.Enabled = true;
           }
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.Black;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.Black;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;
            chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
                           
        }
        List<double> listaver = new List<double>();
        private void добавитьНаОсьYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            приветToolStripMenuItem.Visible = false;
            иToolStripMenuItem.Visible = false;
            yyuyuyiToolStripMenuItem.Visible = false;
            //IndexDeleteGraf = NumberSeries;
            comboBox1.Enabled = false;
            dfsdToolStripMenuItem.Visible = false;
            добавитьНаОсьXToolStripMenuItem.Enabled = false;
      //      правкаToolStripMenuItem.Visible = false;
            jToolStripMenuItem1.Visible = false;



     //       правкаToolStripMenuItem.Visible = true;
            jToolStripMenuItem.Visible = false;
        //    очиститьВсеToolStripMenuItem.Visible = false;
            изменитьТолщинуToolStripMenuItem.Visible = false;
            легендаToolStripMenuItem.Visible = false;
            логарифмическаяШкалаToolStripMenuItem.Visible = true;
            показатьВсеЛегендыToolStripMenuItem.Visible = false;
            добавитьНаОсьYToolStripMenuItem.Visible = false;
            показатьКоличествоГрафиковToolStripMenuItem.Visible = false;
            показатьНомерToolStripMenuItem.Visible = false;
            checkBox2.Enabled = false;
            добавитьНаY1JnDhtvtyToolStripMenuItem.Visible = false;
            добавитьНаОсьY2JnDhtvtyToolStripMenuItem.Visible = false;
            добавитьНаОсьY3ОтВремениToolStripMenuItem.Visible = false;
            lkToolStripMenuItem.Visible = false;
            //  toolTip1.Show("Для начала откройте файл данных (Файл->Открыть)", this.menuStrip1);



            логарифмическаяШкалаToolStripMenuItem.Visible = false;
           // ZedGraph.GraphPane pane = zedGraphControl1.GraphPane;
            CreateChart();
         //   chart1.ChartAreas[0].AxisY.Maximum = 1;
            tabPage1.Text = "Зона построения";
            tabPage2.Text = "Данные";
            tabPage3.Text = "Показатели";
         //   tabPage1.Text = "от";
        //    tabPage2.Text = "Графики ZedGraph";

            for (int i = 1; i < 5; i++)
            {
                chart1.Series["Series" + i].IsVisibleInLegend = false;
            }
            dataGridView2.DataSource = TochkaDannih;

            TochkaDannih.Columns.Add("KKS");
            TochkaDannih.Columns.Add("Время");
            TochkaDannih.Columns.Add("Значение");

            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 200;

            comboBox1.Items.Add("Время");
            comboBox1.Items.Add("Дата");        
            comboBox1.Items.Add("Дата-Время");
          //  comboBox1.Items.Add("Число");


            chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);

            this.dataGridView1.VirtualMode = true;
        //    this.dataGridView3.VirtualMode = true;

            DataGridViewTextBoxColumn companyNameColumn = new DataGridViewTextBoxColumn();
            companyNameColumn.HeaderText = "Время";
            companyNameColumn.Name = "Время";
            this.dataGridView1.Columns.Add(companyNameColumn);

            DataGridViewTextBoxColumn companyNameColumn1 = new DataGridViewTextBoxColumn();
            companyNameColumn1.HeaderText = "Значение";
            companyNameColumn1.Name = "Значение";
            this.dataGridView1.Columns.Add(companyNameColumn1);

            DataGridViewTextBoxColumn companyNameColumn2 = new DataGridViewTextBoxColumn();
            companyNameColumn2.HeaderText = "Время";
            companyNameColumn2.Name = "Время";
         //   this.dataGridView3.Columns.Add(companyNameColumn2);

            DataGridViewTextBoxColumn companyNameColumn3 = new DataGridViewTextBoxColumn();
            companyNameColumn3.HeaderText = "Значение";
            companyNameColumn3.Name = "Значение";
          //  this.dataGridView3.Columns.Add(companyNameColumn3);





            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;

            //dataGridView3.Columns[0].Width = 200;
            //dataGridView3.Columns[1].Width = 200;

           // ZedGraph.PointPairList n1 = new ZedGraph.PointPairList();
         //   ZedGraph.PointPairList n2 = new ZedGraph.PointPairList();
           // ZedGraph.PointPairList n3 = new ZedGraph.PointPairList();
           // ZedGraph.PointPairList n4 = new ZedGraph.PointPairList();
           // ZedGraph.PointPairList n5 = new ZedGraph.PointPairList();
            //ZedGraph.PointPairList n6 = new ZedGraph.PointPairList();
        //    MyList.Add(n1);
          //  MyList.Add(n2);
           // MyList.Add(n3);
           // MyList.Add(n4);
           // MyList.Add(n5);
           // MyList.Add(n6);
        }
        private void dataGridView3_CellValueNeeded(object sender,
        System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            //this.dataGridView1.RowCount = 1;
            // If this is the row for new records, no values are needed.
          //  if (e.RowIndex == this.dataGridView3.RowCount - 1) return;
            //   if (e.RowIndex == this.dataGridView3.RowCount - 1) return;

            MyVirtualClass customerTmp = null;

            // Store a reference to the Customer object for the row being painted.
            if (e.RowIndex == rowInEdit)
            {
                customerTmp = this.customerInEdit;
            }
            else
            {
                customerTmp = (MyVirtualClass)this.customers[e.RowIndex];
            }

            // Set the cell value to paint using the Customer object retrieved.
            //switch (this.dataGridView3.Columns[e.ColumnIndex].Name)
            //{
            //    case "Время":
            //        e.Value = customerTmp.time;
            //        break;

            //    case "Значение":
            //        e.Value = customerTmp.value;
            //        break;
            //}
        }
        private void dataGridView1_CellValueNeeded(object sender,
        System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            //this.dataGridView1.RowCount = 1;
            // If this is the row for new records, no values are needed.
            if (e.RowIndex == this.dataGridView1.RowCount - 1) return;
         //   if (e.RowIndex == this.dataGridView3.RowCount - 1) return;

            MyVirtualClass customerTmp = null;

            // Store a reference to the Customer object for the row being painted.
            if (e.RowIndex == rowInEdit)
            {
                customerTmp = this.customerInEdit;
            }
            else
            {
                customerTmp = (MyVirtualClass)this.customers[e.RowIndex];
            }

            // Set the cell value to paint using the Customer object retrieved.
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Время":
                    e.Value = customerTmp.time;
                    break;

                case "Значение":
                    e.Value = customerTmp.value;
                    break;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        double value;
        List<DateTime> fff = new List<DateTime>();
        SD.DataTable TochkaDannih = new SD.DataTable();
        public double pixel;
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                isClicked = true;
                X = e.X;
                Y = e.Y;
                chart1.MouseMove += this.chart1_MouseMove;
               // chart1.MouseUp += this.chart1_MouseUp;
             //   chart1.Paint += this.chart1_Paint;
            }

            if (e.Button == MouseButtons.Right)
            {
                chart1.ContextMenuStrip = contextMenuStrip2;
            }

               if (e.Button == MouseButtons.Left)
               {
                   if (checkBox1.Checked == false)
                   {
                       chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                       //  chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                       chart1.ChartAreas[0].CursorX.LineColor = Color.Black;

                       chart1.ChartAreas[0].CursorX.Interval = 0.000000001;
                       // chart1.ChartAreas[0].CursorX.SelectionColor = Color.Yellow;
                       chart1.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;
                       chart1.ChartAreas[0].CursorX.LineWidth = 2;
                   }
                   if (checkBox1.Checked == true)
                   {
                       chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
                   }
               }
      
            TochkaDannih.Clear();
           pixel = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            value = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            Search_Min_Error.Cursor_Value(NumberSeries, MyAllSensors, chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X), chart1, TochkaDannih, fff);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
                chart1.DrawToBitmap(bmp, chart1.DisplayRectangle);
                bmp.Save(saveFileDialog1.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                //    chart1.SaveImage(saveFileDialog1.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void параметрыГрафикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ChangeParametrImage = new Form2();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void добавитьНаВспомагательнуюОсьYToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьНаОсновнуюОсьYToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        int uslovie = 0;
        public int NumberSeries;
       public  List<string> MyKKSonChart = new List<string>();

       // private void AddGrafAnotherVremeniAfterDELETE()
       //{
       //    for (int j = 0; j < MyAllSensors.Count; j++)
       //    {
       //        if (checkedListBox1.Text == MyAllSensors[j].KKS_Name)
       //        {

       //         //   MessageBox.Show(Сглаживание_скользящим_средним.IndexDeleteGraf.ToString());
                   
       //                MessageBox.Show("privet");
       //               // MessageBox.Show();
       //                for (int i = 0; i < MyAllSensors[j].MyListRecordsForOneKKS.Count; i++)
       //                {

       //                    chart1.Series[Сглаживание_скользящим_средним.NowSeries].Points.AddXY(MyAllSensors[j].MyListRecordsForOneKKS[i].DateTime, MyAllSensors[j].MyListRecordsForOneKKS[i].Value);
       //                }
       //                MyKKSonChart.Add(MyAllSensors[j].KKS_Name);
       //                chart1.Series[Сглаживание_скользящим_средним.NowSeries].LegendText = MyAllSensors[j].KKS_Name;
       //                chart1.Series[Сглаживание_скользящим_средним.NowSeries].IsVisibleInLegend = true;
       //                chart1.Legends.Add(chart1.Series[Сглаживание_скользящим_средним.NowSeries].LegendText);
       //                chart1.Series[Сглаживание_скользящим_средним.NowSeries].BorderWidth = 2;
       //                chart1.Legends[0].Docking = Docking.Bottom;
       //                Сглаживание_скользящим_средним.IndexDeleteGraf = 0;
       //                NumberSeries++;
       //            }
               
       //    }
       bool m = true;
       private void DoubleGraf()
       {
           // return m=true;
           for (int i = 0; i < MyKKSonChart.Count; i++)
           {
               // return true;
               if (myOneKKS.KKS_Name == MyKKSonChart[i])
               {
                   m = false;
               }
           }
           //    MessageBox.Show(m.ToString());
       }
        private void AddGrafAnotherVremeni()
        {
            Сглаживание_скользящим_средним main = this.Owner as Сглаживание_скользящим_средним;
            try
            {
                DoubleGraf();
                //   MessageBox.Show(m.ToString());
                // myOneKKS = MyListSensors[0].getOneKKSByIndex(treeView1.SelectedNode.Index);
                if (m == true)
                {
                    if (checkBox5.Checked == true || checkBox4.Checked == true)
                    {

                        for (int i = 0; i < myOneKKS.MyListRecordsForOneKKS.Count; i++)
                        {
                            if (myOneKKS.MyListRecordsForOneKKS[i].Value > 0)
                            {
                                chart1.Series[NumberSeries].Points.AddXY(myOneKKS.MyListRecordsForOneKKS[i].DateTime, myOneKKS.MyListRecordsForOneKKS[i].Value);
                            }
                        }

                    }
                    if (checkBox5.Checked == false)
                    {

                        for (int i = 0; i < myOneKKS.MyListRecordsForOneKKS.Count; i++)
                        {
                            if (myOneKKS.MyListRecordsForOneKKS[i].Value<=0)
                            {
                                checkBox4.Enabled = false;
                            }
                            chart1.Series[NumberSeries].Points.AddXY(myOneKKS.MyListRecordsForOneKKS[i].DateTime, myOneKKS.MyListRecordsForOneKKS[i].Value);
                            //   checkBox4.Enabled = false;
                        }

                    }
                    MyKKSonChart.Add(myOneKKS.KKS_Name);
                    chart1.Series[NumberSeries].LegendText = myOneKKS.KKS_Name;
                    chart1.Series[NumberSeries].IsVisibleInLegend = true;

                    chart1.Legends.Add(chart1.Series[NumberSeries].LegendText);
                    chart1.Series[NumberSeries].BorderWidth = 2;
                    chart1.Legends[0].Docking = Docking.Bottom;
                    NumberSeries++;



                }
                if (m == false)
                {
                    MessageBox.Show("Этот параметр уже присутствует графике!");
                    m = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //   NumberSeries--;
            }
            
          
        }
        private bool YesNo()
        {
           return true;
            for (int i = 0; i < MyKKSonChart.Count; i++)
            {              
                if (chart1.Series[NumberSeries].LegendText == MyKKSonChart[i])
                    return false;           
            }
       
              //  return true;
           // return null;     
        }
        private void ReGrafOnOneAxisY(List<string> MyKKSonChart)
        {
            //     NumberSeries = 0;
            //   chart1.Series.Clear();
            //  try
            {
                for (int i = 1; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].IsVisibleInLegend = false;
                    chart1.Series[i].Points.Clear();
                    // chart2.Series["Series" + i].IsVisibleInLegend = false;
                }
                //  chart1.Series.Clear();
                chart1.Legends.Clear();
            //    MessageBox.Show(MyKKSonChart.Count.ToString());
                for (int k = 0; k < 4; k++)
                {
                    for (int j = 0; j < MyAllSensors.Count; j++)
                    {
                        if (MyKKSonChart[k] == MyAllSensors[j].KKS_Name)
                        {
                     //       MessageBox.Show(MyKKSonChart[k]);
                            for (int i = 0; i < MyAllSensors[j].MyListRecordsForOneKKS.Count; i++)
                            {
                                chart1.Series[NumberSeries].Points.AddXY(MyAllSensors[j].MyListRecordsForOneKKS[i].DateTime.ToOADate(), MyAllSensors[j].MyListRecordsForOneKKS[i].Value);
                            }
                            chart1.Series[NumberSeries].LegendText = MyAllSensors[j].KKS_Name;
                            chart1.Series[NumberSeries].IsVisibleInLegend = true;
                         //   MessageBox.Show(NumberSeries.ToString());
                            //   NumberSeries++;
                      //      if()
                        //    {
                            chart1.Legends.Add(MyAllSensors[j].KKS_Name);
                            chart1.Legends[0].Docking = Docking.Bottom;
                        }

                    }

                    NumberSeries++;
                }
            }
            // }
            //  catch(Exception ex)
            // {
            //      MessageBox.Show(ex.Message);
            //  }
        }

        private void убратьПодписиКривыхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Legends["Legend1"].Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void добавитьНаВспомогательнуюОсьXToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        public List<System.Windows.Forms.DataVisualization.Charting.ChartArea> t = new List<System.Windows.Forms.DataVisualization.Charting.ChartArea>();
        public System.Windows.Forms.DataVisualization.Charting.ChartArea areaAxis;
        public System.Windows.Forms.DataVisualization.Charting.ChartArea areaSeries;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
        public System.Windows.Forms.DataVisualization.Charting.ChartArea area;
        public void CreateYAxis(System.Windows.Forms.DataVisualization.Charting.Chart chart, System.Windows.Forms.DataVisualization.Charting.ChartArea area, System.Windows.Forms.DataVisualization.Charting.Series series, float axisOffset, float labelsSize)
        {
            // Create new chart area for original series
            areaSeries = chart.ChartAreas.Add("ChartArea_" + series.Name);

            areaSeries.BackColor = Color.Transparent;
            areaSeries.BorderColor = Color.Transparent;
            areaSeries.Position.FromRectangleF(area.Position.ToRectangleF());
            areaSeries.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
            areaSeries.AxisX.MajorGrid.Enabled = false;
            areaSeries.AxisX.MajorTickMark.Enabled = false;
            areaSeries.AxisX.LabelStyle.Enabled = false;
            areaSeries.AxisY.MajorGrid.Enabled = false;
            areaSeries.AxisY.MajorTickMark.Enabled = false;
            areaSeries.AxisY.LabelStyle.Enabled = false;

            series.ChartArea = areaSeries.Name;

            // Create new chart area for axis
            areaAxis = chart.ChartAreas.Add("AxisY_" + series.ChartArea);
            areaAxis.BackColor = Color.Transparent;
            areaAxis.BorderColor = Color.Transparent;
            areaAxis.Position.FromRectangleF(chart.ChartAreas[series.ChartArea].Position.ToRectangleF());
            areaAxis.InnerPlotPosition.FromRectangleF(chart.ChartAreas[series.ChartArea].InnerPlotPosition.ToRectangleF());
            t.Add(areaAxis);

            // Create a copy of specified series
            System.Windows.Forms.DataVisualization.Charting.Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
            seriesCopy.ChartType = series.ChartType;

            foreach (DataPoint point in series.Points)
            {
                seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
            }

            // Hide copied series
            seriesCopy.IsVisibleInLegend = false;
            seriesCopy.Color = Color.Transparent;
            seriesCopy.BorderColor = Color.Transparent;
            seriesCopy.ChartArea = areaAxis.Name;

            areaAxis.AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
            areaAxis.AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum; 
            // Disable drid lines & tickmarks
            areaAxis.AxisX.LineWidth = 0;

            for (int i = 1; i < chart.ChartAreas.Count; i++)
            {
                areaAxis.AxisX.MajorGrid.Enabled = false;
                areaAxis.AxisX.MajorTickMark.Enabled = false;
            }

           // areaAxis.AxisX.MajorGrid.Enabled = false;
          //  areaAxis.AxisX.MajorTickMark.Enabled = false;



            areaAxis.AxisX.LabelStyle.Enabled = false;
            areaAxis.AxisY.MajorGrid.Enabled = false;
            areaAxis.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            areaAxis.AxisY.LabelStyle.Font = area.AxisY.LabelStyle.Font;
            areaAxis.AxisY.IsLabelAutoFit = true;
            areaAxis.AxisX.IsLabelAutoFit = true;

            // Adjust area position
            chart1.ChartAreas[0].Position.Auto = false;

          areaAxis.Position.X -= labelsSize - 50;
            areaAxis.InnerPlotPosition.X += labelsSize + 50;

        }
        public Chart chart1 = new Chart();
        System.Windows.Forms.DataVisualization.Charting.Cursor cursor = null;
        System.Windows.Forms.DataVisualization.Charting.Cursor cursor1 = null;
        System.Windows.Forms.DataVisualization.Charting.Cursor cursor2 = null;
        System.Windows.Forms.DataVisualization.Charting.Cursor cursor3 = null;
        Legend legend = new Legend();
        public void CreateChart()
        {
            // Создаём новый элемент управления Chart
           // chart1 = new Chart();
            // Помещаем его на форму
            chart1.Parent = splitContainer4.Panel1;

            // Задаём размеры элемента
            chart1.Dock = DockStyle.Fill;

            // Создаём новую область для построения графика
            ChartArea area = new ChartArea();
            // Даём ей имя (чтобы потом добавлять графики)
            area.Name = "myGraph";

            chart1.ChartAreas.Add(area);
            // Создаём объект для первого графика
            Series series1 = new Series();
            //  // Ссылаемся на область для построения графика
            series1.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series1.ChartType = SeriesChartType.FastLine;
            // Указываем ширину линии графика
            series1.BorderWidth =2;
            // Название графика для отображения в легенде
           // series1.LegendText = "гистограмма";
            // Добавляем в список графиков диаграммы
            chart1.Series.Add(series1);
            // Аналогичные действия для второго графика
            Series series2 = new Series();
            series2.ChartArea = "myGraph";
            series2.ChartType = SeriesChartType.FastLine;
            series2.BorderWidth = 2;
           // series2.LegendText = "//////";
            chart1.Series.Add(series2);

            Series series3 = new Series();
            series3.ChartArea = "myGraph";
            series3.ChartType = SeriesChartType.FastLine;
            series3.BorderWidth = 2;
            chart1.Series.Add(series3);

            Series series4 = new Series();
            series4.ChartArea = "myGraph";
            series4.ChartType = SeriesChartType.FastLine;
            series4.BorderWidth = 2;
            chart1.Series.Add(series4);

            //Series series5 = new Series();
            //series5.ChartArea = "myGraph";
            //series5.ChartType = SeriesChartType.FastLine;
            //series5.BorderWidth = 2;
            //chart1.Series.Add(series5);

            //Series series6 = new Series();
            //series6.ChartArea = "myGraph";
            //series6.ChartType = SeriesChartType.FastLine;
            //series6.BorderWidth = 2;
            //chart1.Series.Add(series6);

            //Series series7 = new Series();
            //series7.ChartArea = "myGraph";
            //series7.ChartType = SeriesChartType.FastLine;
            //series7.BorderWidth = 2;
            //chart1.Series.Add(series7);


          

            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[2].Color = Color.Green;
            chart1.Series[3].Color = Color.Purple;
            //chart1.Series[4].Color = Color.Red;
            //chart1.Series[5].Color = Color.Blue;
            //chart1.Series[6].Color = Color.Green;
            //chart1.Series[7].Color = Color.Purple;
            //chart1.Series[8].Color = Color.Purple;
          //  System.Windows.Forms.DataVisualization.Charting.Cursor cursor = null;
            cursor = chart1.ChartAreas[0].CursorX;
        //    cursor1 = chart1.ChartAreas[1].CursorX;
        //    cursor.LineWidth = 2;
            cursor.LineDashStyle = ChartDashStyle.DashDot;
            cursor.LineColor = Color.Red;
            cursor.SelectionColor = Color.Yellow;
            //chart1.Series[4].Color = Color.Olive;
            // Создаём легенду, которая будет показывать названия
           //  Legend legend = new Legend();
             // chart1.Legends.Add(legend);
            //  legend.BackImageAlignment = ChartImageAlignmentStyle.BottomLeft;
        }
        private void добавитьНаВспомогательнуюОсьXToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {

        }
        List<string> MyKKS = new List<string>();
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Form2 main = this.Owner as Form2;

           
       //     (4, 12, 90, 80)
            //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorX.LineColor = Color.Black;

            //chart1.ChartAreas[0].CursorX.Interval = 0.000000001;
            //chart1.ChartAreas[0].CursorX.SelectionColor = Color.Yellow;
            //chart1.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.DashDot;
            //chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(4, 12, 81, 80);
           // MessageBox.Show(NumberSeries.ToString());
            if (checkBox2.Checked == true)
            {
                button5.BackColor = Color.Yellow;
                label2.Text = "";
                //  MessageBox.Show(NumberSeries.ToString());
                if (NumberSeries == 2)
                {
      
                    добавитьНаY1JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьY2JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьXToolStripMenuItem.Visible = false;
                 //   добавитьНаОсьY3ОтВремениToolStripMenuItem.Visible = false;
                  //  lkToolStripMenuItem.Visible = false;
                    chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(4, 12, 81, 80);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series2"], 22, 32);


                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = true;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = true;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.LineColor = Color.Black;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.Interval = 0.000000001;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.SelectionColor = Color.Yellow;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.LineDashStyle = ChartDashStyle.DashDot;

                    t[0].AxisY.LabelStyle.Format = "F";
                    t[0].AxisY.LineColor = chart1.Series["Series2"].Color;
              //      t[1].


                }
                if (NumberSeries == 3)
                {
        

                    chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(4, 12, 81, 80);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series2"], 22, 29);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series3"], 50, 37);
                    добавитьНаY1JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьY2JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьXToolStripMenuItem.Visible = false;
                    //   добавитьНаОсьY3ОтВремениToolStripMenuItem.Visible = false;
                    lkToolStripMenuItem.Visible = true;
                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = true;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserEnabled = true;

                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = true;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserSelectionEnabled = true;

                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.LineColor = Color.Black;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.LineColor = Color.Black;

                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.SelectionColor = Color.Yellow;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.SelectionColor = Color.Yellow;

                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.LineDashStyle = ChartDashStyle.DashDot;

                    //chart1.ChartAreas["ChartArea_Series2"].CursorX.Interval = 0.000000001;
                    //chart1.ChartAreas["ChartArea_Series3"].CursorX.Interval = 0.000000001;

                    t[0].AxisY.LabelStyle.Format = "F";
                    t[1].AxisY.LabelStyle.Format = "F";
                    t[0].AxisY.LineColor = chart1.Series["Series2"].Color;
                    t[1].AxisY.LineColor = chart1.Series["Series3"].Color;
                 

                }

                if (NumberSeries == 4)
                {
     

                    chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(4, 12, 81, 80);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series2"], 22, 22);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series3"], 50, 30);
                    CreateYAxis(chart1, chart1.ChartAreas[0], chart1.Series["Series4"], 7, 40);
                    добавитьНаY1JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьY2JnDhtvtyToolStripMenuItem.Visible = true;
                    добавитьНаОсьXToolStripMenuItem.Visible = false;
                    добавитьНаОсьY3ОтВремениToolStripMenuItem.Visible = true;
                    lkToolStripMenuItem.Visible = true;


                    t[0].AxisY.LabelStyle.Format = "F";
                    t[1].AxisY.LabelStyle.Format = "F";
                    t[2].AxisY.LabelStyle.Format = "F";
                    t[0].AxisY.LineColor = chart1.Series["Series2"].Color;
                    t[1].AxisY.LineColor = chart1.Series["Series3"].Color;
                    t[2].AxisY.LineColor = chart1.Series["Series4"].Color;

                }
               
            

             

                осьY2ToolStripMenuItem.Enabled = true;

                chart1.ChartAreas[0].AxisY.Title = "";
                contextMenuStrip1.Items[1].Enabled = true;
             //   очиститьГрафикToolStripMenuItem.Enabled = false;



                //   this.dataGridView1.CellValueNeeded += new
                //  DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
                //   private void dataGridView1_CellValueNeeded(object sender,
                //System.Windows.Forms.DataGridViewCellValueEventArgs e)

            }
                if (checkBox2.Checked == false)
                {
                    for (int i = 4; i < MyKKSonChart.Count; i++)
                    {
                        MyKKSonChart.RemoveAt(i);
                    }

           

                    checkBox3.Checked = false;
                    button5.BackColor = Color.LightGray;
                    chart1.Legends.Clear();
                    t.Clear();
                    chart1.ChartAreas.Clear();
                    chart1.Series.Clear();
                    CreateChart();
                    NumberSeries = 0;

                    try
                    {

                        ReGrafOnOneAxisY(MyKKSonChart);
                    }
               //     ReGrafOnOneAxisY(MyKKSonChart);
                    catch
                    {

                    }
                    добавитьНаY1JnDhtvtyToolStripMenuItem.Visible = false;
                    добавитьНаОсьY2JnDhtvtyToolStripMenuItem.Visible = false;
                    добавитьНаОсьXToolStripMenuItem.Visible = true;
                    добавитьНаОсьY3ОтВремениToolStripMenuItem.Visible = false;
                    lkToolStripMenuItem.Visible = false;
                 //   MyKKSonChart.Clear();
                    //      chart1.ChartAreas[0].Position.Auto = true;(4, 12, 90, 80)
                    chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(4, 12, 90, 80);
                    chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
                    chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Gray;


                    chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                    chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                    chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Gray;
                    chart1.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.Black;
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
                    chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Gray;
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisY.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                    chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chart1.ChartAreas[0].AxisX.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;

                    chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;
                    chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
                }
            
        }
        private void Mes()
        {
            for (int i = 0; i < MyKKSonChart.Count; i++)
            {
                MessageBox.Show(MyKKSonChart[i].ToString());
            }
        }
        private void инструкцияПоПрименениюToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        //Word.Application word = new Word.Application();
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            //Excel.Application excel = new Excel.Application();
            // fileExcel = excel.Workbooks.Open(saveFileDialog3.FileName + ".xlsx");
            //Excel._Workbook fileExcel;
            //  Microsoft.Office.Interop.Word.Document t;
            //t = word.Documents.Open("D:\\Инструкция.docx");
            //word.Visible = true;
            System.Diagnostics.Process.Start("D:\\Инструкция.docx");

        }

        private void очиститьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void осьY1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void осьY2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t[0].AxisY.LabelStyle.Format = "G";
        }

        private void осьY3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t[1].AxisY.LabelStyle.Format = "G";
        }

        private void осьY4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t[2].AxisY.LabelStyle.Format = "G";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void форматВремениДоСекундToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {



        }

        private void поменятьФорматОсиXНаВременнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].XValueType = ChartValueType.Time;
            добавитьНаОсьYToolStripMenuItem.Enabled = true;
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
        public int NumberPoints;
        private void copySelectedRowsToClipboard(DataGridView dgv)
        {
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            Clipboard.Clear();
            if (dgv.GetClipboardContent() != null)
            {
                Clipboard.SetDataObject(dgv.GetClipboardContent());
                Clipboard.GetData(DataFormats.Text);
                IDataObject dt = Clipboard.GetDataObject();
                if (dt.GetDataPresent(typeof(string)))
                {
                    string tb = (string)(dt.GetData(typeof(string)));
                    Encoding encoding = Encoding.GetEncoding(1251);
                    byte[] dataStr = encoding.GetBytes(tb);
                    Clipboard.SetDataObject(encoding.GetString(dataStr));
                }
            }
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
        }
        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {



        }

        private void wxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                if (((DataGridView)sender).SelectedCells.Count > 0)
                {
                    copySelectedRowsToClipboard((DataGridView)sender);
                }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                if (((DataGridView)sender).SelectedCells.Count > 0)
                {
                    copySelectedRowsToClipboard((DataGridView)sender);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ChangeParametrImage = new Form2();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                if (comboBox1.Text == "Время")
                {
                    chart1.Series[0].XValueType = ChartValueType.Time;
                 chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                }
                if (comboBox1.Text == "Дата")
                {
                    chart1.Series[0].XValueType = ChartValueType.Date;
                 chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.mm.yy";
                }
                if (comboBox1.Text == "Дата-Время")
                {
                    chart1.Series[0].XValueType = ChartValueType.Time;
              chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yy" + "\n" + "HH:mm:ss";
                }
              

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            cursor.Position = cursor.Position - 0.00069444444;
            TochkaDannih.Clear();
            Search_Min_Error.Cursor_Value(NumberSeries, MyAllSensors, cursor.Position, chart1, TochkaDannih, fff);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cursor.Position = cursor.Position + 0.00069444444;
            TochkaDannih.Clear();
            Search_Min_Error.Cursor_Value(NumberSeries, MyAllSensors, cursor.Position, chart1, TochkaDannih, fff);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox4.Enabled = true;
            chart1.Titles.Clear();
        //    IndecatorAcex.Clear();
            chart1.Controls.Remove(Metka1);
            chart1.Controls.Remove(label4);
            chart1.Controls.Remove(label5);
            chart1.Controls.Remove(label6);
            chart1.Controls.Remove(label7);
            chart1.Controls.Remove(label8);
            chart1.Controls.Remove(label9);
             //      NumberSeries = 0;
           //MyKKSonChart.Clear();
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
            MyKKSonChart.Clear();
            t.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
         //   MyKKSonChart.Clear();
            CreateChart();
            for (int i = 1; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].IsVisibleInLegend = false;
            }
            NumberSeries = 0;
            NumberLabel= 0;
            try
            {
                for (int i = twoPoint.Count - 1; i >= 0; i--)
                {
                    twoPoint.RemoveAt(i);
                }
            //    twoPoint.RemoveAt(twoPoint.Count - 1);
                X = Y = X1 = Y1 = 0; // *
                chart1.Invalidate(); //перерисовываем чарт 
            }
              //   treeView1.Nodes.Clear();
        ///    MyAllSensors.Clear();
         //   MyListSensors.Clear();
            
            catch (Exception ex)
            {

            }
          //  добавитьНаОсьXToolStripMenuItem.Enabled = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void checkedListBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int NumberSeries1 = 0;
        Color[] MyColor = { Color.Red,Color.Blue, Color.Green, Color.Violet, Color.Orange, Color.DarkBlue};
        int NumberColor = 0;

        private void построитьГрафикНаОсновнойОсиYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Grafic_on_oneAxisY();
            NumberSeries1++;
        }
        private void Add_Grafic_on_oneAxisY()
        {

        }

        private void построитьГрафикНаДополнительнойОсиYToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightGray;
            label2.Text = "\u2714";
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas[0].AxisY.Interval = 0;

            if (checkBox2.Checked == true)
            {
                if (t.Count == 1)
                {
                    t[0].AxisY.Interval = 0;
                    t[0].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    t[0].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Interval = 0;
                }
                if (t.Count == 2)
                {
                    t[0].AxisY.Interval = 0;
                    t[0].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    t[0].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Interval = 0;
                    t[1].AxisY.Interval = 0;
                    t[1].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum;
                    t[1].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Interval = 0;
                }
                if (t.Count==3)
                {
                    t[0].AxisY.Interval = 0;
                    t[0].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Minimum;
                    t[0].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series2"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series2"].AxisX.Interval = 0;
                    t[1].AxisY.Interval = 0;
                    t[1].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series3"].AxisY.Minimum;
                    t[1].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series3"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series3"].AxisX.Interval = 0;
                    t[2].AxisY.Interval = 0;
                    t[2].AxisY.Minimum = chart1.ChartAreas["ChartArea_Series4"].AxisY.Minimum;
                    t[2].AxisY.Maximum = chart1.ChartAreas["ChartArea_Series4"].AxisY.Maximum;
                    chart1.ChartAreas["ChartArea_Series4"].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum;
                    chart1.ChartAreas["ChartArea_Series4"].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum;
                    chart1.ChartAreas["ChartArea_Series4"].AxisX.Interval = 0;
                }

            }

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
         //   button5.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MyAllSensors.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int NumberNode = treeView1.Nodes.Count;
                foreach (var item in openFileDialog1.FileNames)
                {
                    Archive.LoadFromFile(item, ListForTreeViesNode);
                    treeView1.Nodes.Add("MyFiles", item);
                    for (int i = 0; i < ListForTreeViesNode.Count; i++)
                    {
                        ListForTreeViesNode[i].KKS_Name = ListForTreeViesNode[i].KKS_Name + " [" + NumberNode + "]";
                        treeView1.Nodes[NumberNode].Nodes.Add(ListForTreeViesNode[i].KKS_Name);
                    }
                    NumberNode++;
                    MyAllSensors.AddRange(ListForTreeViesNode);
                    ListForTreeViesNode.Clear();
                }
            }
         //   MessageBox.Show(MyAllSensors[0].KKS_Name);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chart1.Titles.Clear();
            добавитьНаОсьXToolStripMenuItem.Enabled = false;
            chart1.Controls.Remove(Metka1);
            chart1.Controls.Remove(label4);
            chart1.Controls.Remove(label5);
            chart1.Controls.Remove(label6);
            chart1.Controls.Remove(label7);
            chart1.Controls.Remove(label8);
            chart1.Controls.Remove(label9);
            checkBox4.Enabled = true;
            открытьToolStripMenuItem.Enabled = true;
            treeView1.Nodes.Clear();
            MyAllSensors.Clear();
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
            t.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            CreateChart();
            MyKKSonChart.Clear();
            for (int i = 1; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].IsVisibleInLegend = false;
                chart1.Series[i].Points.Clear();
            }
            NumberSeries = 0;
            NumberLabel = 0;
            try
            {
                for (int i = twoPoint.Count - 1; i >= 0; i--)
                {
                    twoPoint.RemoveAt(i);
                }
                X = Y = X1 = Y1 = 0; // *
                chart1.Invalidate(); //перерисовываем чарт 
            }
            catch (Exception ex)
            {

            }
        }

        private void убратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Legends[0].Enabled = false;
        }

        private void поставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Legends[0].Enabled = true;
        }

        private void изменитьТолщинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Толщина ChangeParametrImage = new Толщина();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void логарифмическаяШкалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.IsLogarithmic = true;
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void найтиМКРToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PowerEffect main = this.Owner as PowerEffect;
            PowerEffect SearchPower = new PowerEffect();
            SearchPower.Owner = this;
            SearchPower.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CreateMyLabel();
            NumberLabel++;
        }
        int NumberLabel = 0;
        public int IndexMetki;
        public void CreateMyLabel()
        {
            // Create an instance of a Label.
            if (NumberLabel == 0)
            {
                Metka1 = new Label();
                Metka1.MouseDown += this.Metka1_MouseDown;
                scrollEngine = new ScrollEngine(Metka1);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll);

                Metka1.Parent = chart1;
                Metka1.Text = "Метка1";
                Metka1.TextAlign = ContentAlignment.MiddleCenter;
                Metka1.AutoSize = true;
                Metka1.ImageAlign = ContentAlignment.TopLeft;
                Metka1.BackColor = System.Drawing.Color.Transparent;

                //   MessageBox.Show(MyLabels.Count.ToString());

            }
            if (NumberLabel == 1)
            {
                label4 = new Label();
                label4.MouseDown += this.label4_MouseDown;
             //   MyLabels.Add(label4);
                scrollEngine = new ScrollEngine(label4);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll1);

                label4.Parent = chart1;

                label4.ImageAlign = ContentAlignment.TopLeft;
                label4.Text = "Метка2";
                label4.TextAlign = ContentAlignment.MiddleCenter;
                label4.AutoSize = true;
                label4.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 2)
            {
                label5 = new Label();
                label5.MouseDown += this.label5_MouseDown;
                //MyLabels.Add(label5);
                scrollEngine = new ScrollEngine(label5);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll2);

                label5.Parent = chart1;

                label5.ImageAlign = ContentAlignment.TopLeft;
                label5.Text = "Метка3";
                label5.TextAlign = ContentAlignment.MiddleCenter;
                label5.AutoSize = true;
                label5.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 3)
            {
                label6 = new Label();
                label6.MouseDown += this.label6_MouseDown;
            //    MyLabels.Add(label6);
                scrollEngine = new ScrollEngine(label6);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll3);

                label6.Parent = chart1;

                label6.ImageAlign = ContentAlignment.TopLeft;
                label6.Text = "Метка4";
                label6.TextAlign = ContentAlignment.MiddleCenter;
                label6.AutoSize = true;
                label6.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 4)
            {
                label7 = new Label();
                label7.MouseDown += this.label7_MouseDown;
           //     MyLabels.Add(label7);
                scrollEngine = new ScrollEngine(label7);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll4);

                label7.Parent = chart1;

                label7.ImageAlign = ContentAlignment.TopLeft;
                label7.Text = "Метка5";
                label7.TextAlign = ContentAlignment.MiddleCenter;
                label7.AutoSize = true;
                label7.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 5)
            {
                label8 = new Label();
                label8.MouseDown += this.label8_MouseDown;
              //  MyLabels.Add(label8);
                scrollEngine = new ScrollEngine(label8);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll5);

                label8.Parent = chart1;

                label8.ImageAlign = ContentAlignment.TopLeft;
                label8.Text = "Метка6";
                label8.TextAlign = ContentAlignment.MiddleCenter;
                label8.AutoSize = true;
                label8.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 6)
            {
                label9 = new Label();
                label9.MouseDown += this.label9_MouseDown;
           //     MyLabels.Add(label9);
                scrollEngine = new ScrollEngine(label9);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll6);

                label9.Parent = chart1;

                label9.ImageAlign = ContentAlignment.TopLeft;
                label9.Text = "Метка7";
                label9.TextAlign = ContentAlignment.MiddleCenter;
                label9.AutoSize = true;
                label9.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 7)
            {
                label10 = new Label();
                label10.MouseDown += this.label10_MouseDown;
                //     MyLabels.Add(label7);
                scrollEngine = new ScrollEngine(label10);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll10);

                label10.Parent = chart1;

                label10.ImageAlign = ContentAlignment.TopLeft;
                label10.Text = "Метка8";
                label10.TextAlign = ContentAlignment.MiddleCenter;
                label10.AutoSize = true;
                label10.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 8)
            {
                label11 = new Label();
                label11.MouseDown += this.label11_MouseDown;
                //  MyLabels.Add(label8);
                scrollEngine = new ScrollEngine(label11);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll11);

                label11.Parent = chart1;

                label11.ImageAlign = ContentAlignment.TopLeft;
                label11.Text = "Метка9";
                label11.TextAlign = ContentAlignment.MiddleCenter;
                label11.AutoSize = true;
                label11.BackColor = System.Drawing.Color.Transparent;
            }
            if (NumberLabel == 9)
            {
                label12 = new Label();
                label12.MouseDown += this.label12_MouseDown;
                //     MyLabels.Add(label9);
                scrollEngine = new ScrollEngine(label12);
                scrollEngine.Scroll += new EventHandler<ScrollEngine.ScrollEventArgs>(scrollEngine_Scroll12);

                label12.Parent = chart1;

                label12.ImageAlign = ContentAlignment.TopLeft;
                label12.Text = "Метка10";
                label12.TextAlign = ContentAlignment.MiddleCenter;
                label12.AutoSize = true;
                label12.BackColor = System.Drawing.Color.Transparent;
            }
        }



        private void Metka1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
 
                Metka1.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 1;
            }
        }
        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label4.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 2;
            }
        }
        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label5.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 3;
            }
        }
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label6.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 4;
            }
        }
        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label7.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 5;
            }
        }
        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label8.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 6;
            }
        }
        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label9.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 7;
            }
        }
        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label10.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 7;
            }
        }
        private void label11_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label11.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 7;
            }
        }
        private void label12_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                label12.ContextMenuStrip = contextMenuStrip5;
                IndexMetki = 7;
            }
        }
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
       
        }

        private void изменитьТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Метки ChangeParametrImage = new Метки();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(IndexMetki.ToString());
            if (IndexMetki == 1)
             {
               chart1.Controls.Remove(Metka1);
               NumberLabel = 0;
            }
            if (IndexMetki == 2)
            {
                chart1.Controls.Remove(label4);
                NumberLabel = 1;
            }
            if (IndexMetki == 3)
            {
                chart1.Controls.Remove(label5);
                NumberLabel = 2;
            }
            if (IndexMetki == 4)
            {
                chart1.Controls.Remove(label6);
                NumberLabel = 3;
            }
            if (IndexMetki == 5)
            {
                chart1.Controls.Remove(label7);
                NumberLabel = 4;
            }
            if (IndexMetki == 6)
            {
                chart1.Controls.Remove(label8);
                NumberLabel = 5;
            }
            if (IndexMetki == 7)
            {
                chart1.Controls.Remove(label9);
                NumberLabel = 6;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {

                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorX.LineColor = Color.Black;

                chart1.ChartAreas[0].CursorX.Interval = 0.000000001;
                chart1.ChartAreas[0].CursorX.SelectionColor = Color.Yellow;
                chart1.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                if (t.Count == 1)
                {
                    if (checkBox2.Checked == true)
                    {
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = true;
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = true;
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineColor = Color.Black;
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.Interval = 0.000000001;
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.SelectionColor = Color.Yellow;
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                    }
                }
                if (t.Count == 2)
                {
                    if (checkBox2.Checked == true)
                    {
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = true;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserEnabled = true;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = true;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserSelectionEnabled = true;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineColor = Color.Black;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.LineColor = Color.Black;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.SelectionColor = Color.Yellow;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.SelectionColor = Color.Yellow;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.LineDashStyle = ChartDashStyle.DashDot;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.Interval = 0.000000001;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.Interval = 0.000000001;
                    }
                }
                if (t.Count == 3)
                {
                    if (checkBox2.Checked == true)
                    {
                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = true;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserEnabled = true;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.IsUserEnabled = true;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = true;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserSelectionEnabled = true;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.IsUserSelectionEnabled = true;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineColor = Color.Black;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.LineColor = Color.Black;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.LineColor = Color.Black;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.SelectionColor = Color.Yellow;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.SelectionColor = Color.Yellow;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.SelectionColor = Color.Yellow;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.LineDashStyle = ChartDashStyle.DashDot;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.LineDashStyle = ChartDashStyle.DashDot;

                        chart1.ChartAreas["ChartArea_Series2"].CursorX.Interval = 0.000000001;
                        chart1.ChartAreas["ChartArea_Series3"].CursorX.Interval = 0.000000001;
                        chart1.ChartAreas["ChartArea_Series4"].CursorX.Interval = 0.000000001;

                    }
                }
            }
                

                if (checkBox3.Checked == false)
                {
                    chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;

                    if (t.Count == 1)
                    {
                        if (checkBox2.Checked == true)
                        {
                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = false;
                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = false;
                        }
                    }
                    if (t.Count == 2)
                    {
                        if (checkBox2.Checked == true)
                        {
                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = false;
                            chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserEnabled = false;

                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = false;
                            chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserSelectionEnabled = false;
                        }
                    }
                    if (t.Count == 3)
                    {
                        if (checkBox2.Checked == true)
                        {
                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserEnabled = false;
                            chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserEnabled = false;
                            chart1.ChartAreas["ChartArea_Series4"].CursorX.IsUserEnabled = false;

                            chart1.ChartAreas["ChartArea_Series2"].CursorX.IsUserSelectionEnabled = false;
                            chart1.ChartAreas["ChartArea_Series3"].CursorX.IsUserSelectionEnabled = false;
                            chart1.ChartAreas["ChartArea_Series4"].CursorX.IsUserSelectionEnabled = false;
                        }
                    }
                }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                twoPoint.RemoveAt(twoPoint.Count - 1);
                X = Y = X1 = Y1 = 0; // *
                chart1.Invalidate(); //перерисовываем чарт 
            }
            catch(Exception ex)
            {
             
            }
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void lkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naAxis123("ChartArea_Series3");
          //  IndecatorAcex.Add(3);
          //  chart1.Legends[0].Docking = Docking.Bottom;
         //   MessageBox.Show(NumberSeries.ToString());
         //  NumberSeries++;         
        }

        private void показатьНомерToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    for (int j = 0; j < MyAllSensors.Count; j++)
           // {
            //    if (checkedListBox1.Text == MyAllSensors[j].KKS_Name)
             //   {
             //       MessageBox.Show(j.ToString());
              //  }
           // }
        }

        private void добавитьНаОсьY3ОтВремениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naAxis123("ChartArea_Series4");
           // IndecatorAcex.Add(4);
         //   chart1.Legends[0].Docking = Docking.Bottom;
          //  NumberSeries++;
        }
        public int MySeriesNumber;
        //for (int i = 0; i < main.MyKKSonChart.Count; i++)
        //    {
        //        comboBox1.Items.Add(main.MyKKSonChart[i]);
        //    }
        public int SeriesNumberAtTheMoment(string mycombotext)
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                if (mycombotext == chart1.Series[i].LegendText)
                {
                    MySeriesNumber = i;
                }
            }
            return MySeriesNumber;
        }
        public int MyLegendNumber;
        public int lEGENDNumberAtTheMoment(string mycombotext)
        {
            for (int i = 0; i < chart1.Legends.Count; i++)
            {
                if (mycombotext == chart1.Legends[i].ToString().Remove(0,7))
                {
                    MyLegendNumber = i;
                }
            }
            return MyLegendNumber;
        }
        public string MyOb(string mycomboboxtext)
        {
            string p1 = "";
            for (int j = 0; j < MyAllSensors.Count; j++)
            {
                if (mycomboboxtext == MyAllSensors[j].KKS_Name)
                {
                    p1 = MyAllSensors[j].MyListRecordsForOneKKS.Count.ToString();
                }
            }
            return p1;
        }
        public int All_point_Graf;
        public string PointsInGraf(string mycomboboxtext, int numeric)
        {

           string p2 = "";
        //    for (int j = 0; j < MyAllSensors.Count; j++)
        //    {
        //        if (mycomboboxtext == MyAllSensors[j].KKS_Name)
        //        {

        //          //  All_point_Graf = 0;
               
        //                for (int i = int.Parse(label2.ToString().Trim()); i < MyAllSensors[j].MyListRecordsForOneKKS.Count; i++)
        //                {
        //                    All_point_Graf++;
        //                }

                 


        //        }
        //    }
           return p2 = All_point_Graf.ToString();
        }
        private void графикиВТочкахToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьНаY1JnDhtvtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naAxis123("myGraph");
        //    IndecatorAcex.Add(1);
            
        }

        private void показатьКоличествоГрафиковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NumberSeries.ToString());
        }

        private void показатьВсеЛегендыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chart1.Legends.Count; i++)
            {
                MessageBox.Show(chart1.Legends[i].ToString());
            }
        }
        public void TERT(string MyComboBoxText, int series, double popravka)
        {
            try
            {
                Series ser1 = new Series();
                ser1.ChartType = SeriesChartType.FastLine;
                ser1.BorderWidth = 2;
                ser1 = chart1.Series[series];

               for (int j = 0; j < MyAllSensors.Count; j++)
                {
                    if (MyComboBoxText == MyAllSensors[j].KKS_Name)
                    {
                        foreach (var point in myOneKKS.MyListRecordsForOneKKS)
                        {
                            ser1.Points.AddXY(point.DateTime.ToOADate()-popravka, point.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void naAxis123(string nameChartorey)
        {
            try
            {
               
                    Series ser1 = new Series();
                    //  // Ссылаемся на область для построения графика
                    ser1.ChartArea = nameChartorey;

                    ser1.ChartType = SeriesChartType.FastLine;
                    ser1.BorderWidth = 2;
                    chart1.Series.Add(ser1);

                 
                      
                            MyKKSonChart.Add(myOneKKS.KKS_Name);

                            if (checkBox5.Checked == true || checkBox4.Checked == true)
                            {
                                foreach (var point in myOneKKS.MyListRecordsForOneKKS)
                                {
                                    if (point.Value > 0)
                                    {
                                        ser1.Points.AddXY(point.DateTime, point.Value);
                                    }
                                }
                            }
                            if (checkBox5.Checked == false)
                            {
                                foreach (var point in myOneKKS.MyListRecordsForOneKKS)
                                {                                  
                                        ser1.Points.AddXY(point.DateTime, point.Value);                              
                                }
                            }
                            //   }
                            ser1.LegendText = myOneKKS.KKS_Name;
                            ser1.IsVisibleInLegend = true;
                            //   MessageBox.Show(ser1.LegendText);
                            try
                            {
                                chart1.Legends.Add(ser1.LegendText);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            chart1.Legends[0].Docking = Docking.Bottom;
                            NumberSeries++;
                        
                    
                
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //   NumberSeries--;
            }
        }
        public static double popravka = 0;
        public void SdvigGRAF(string MyComboBoxText, int series, double popravka)
        {
            //Series ser1 = new Series();
            //  // Ссылаемся на область для построения графика
          //  ser1.ChartArea = nameChartorey;

            // Задаём тип графика - сплайны
        //    ser1.ChartType = SeriesChartType.FastLine;
            Series ser1 = chart1.Series[series];
            ser1.ChartArea = chart1.ChartAreas[3].Name;

            ser1.ChartType = SeriesChartType.FastLine;
            ser1.BorderWidth = 2;

            for (int j = 0; j < MyAllSensors.Count; j++)
            {
                if (MyComboBoxText == MyAllSensors[j].KKS_Name)
                {
                  //  MyKKSonChart.Add(MyAllSensors[j].KKS_Name);

                    for (int i = 0; i < MyAllSensors[j].MyListRecordsForOneKKS.Count; i++)
                    {                    
                            ser1.Points.AddXY(MyAllSensors[j].MyListRecordsForOneKKS[i].DateTime.ToOADate()- popravka, MyAllSensors[j].MyListRecordsForOneKKS[i].Value);
                    }
               //     ser1.IsVisibleInLegend = true;
                }
            }
        }

        public void REnaAxis123(string MyComboBoxText, int c, int series)
        {
         
            double sum;
            double MyTochka;

            Series ser1 = chart1.Series[series];
            //  // Ссылаемся на область для построения графика
         //   ser1.ChartArea = "ChartArea_Series4";

            // Задаём тип графика - сплайны
            ser1.ChartType = SeriesChartType.FastLine;
            // Указываем ширину линии графика
            ser1.BorderWidth = 2;
            // Название графика для отображения в легенде
            // series1.LegendText = "гистограмма";
            // Добавляем в список графиков диаграммы
       //     chart1.Series.Add(ser1);

            for (int j = 0; j < MyAllSensors.Count; j++)
            {
                if (MyComboBoxText == MyAllSensors[j].KKS_Name)
                {
                //    MyKKSonChart.Add(MyAllSensors[j].KKS_Name);

                    for (int i = c; i < MyAllSensors[j].MyListRecordsForOneKKS.Count; i++)
                    {
                        sum = 0;
                        if (c != 0)
                        {
                          //  MessageBox.Show("");
                            for (int k = 0; k < c; k++)
                            {

                                sum = sum + MyAllSensors[j].MyListRecordsForOneKKS[i - k].Value;

                                //yTochka = sum / c;
                            }
                            MyTochka = sum / c;
                            ser1.Points.AddXY(MyAllSensors[j].MyListRecordsForOneKKS[i].DateTime, MyTochka);
                        }
                        if (c == 0)
                        {
                            //  MessageBox.Show("");
                            chart1.Series[series].Points.AddXY(MyAllSensors[j].MyListRecordsForOneKKS[i].DateTime, MyAllSensors[j].MyListRecordsForOneKKS[i].Value);

                        }
                    }

                 //   ser1.LegendText = MyAllSensors[j].KKS_Name;
                    ser1.IsVisibleInLegend = true;
                    //   MessageBox.Show(ser1.LegendText);
                 //   chart1.Legends.Add(ser1.LegendText);
                    //       ser1.Color = Color.Red;
                    // chart1.Legends[0].Docking = Docking.Bottom; 
                }
            }           
        }
      
        private void добавитьНаОсьY2JnDhtvtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            naAxis123("ChartArea_Series2");
           // chart1.Legends[0].Docking = Docking.Bottom;
          //  IndecatorAcex.Add(2);
           // NumberSeries++;
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void скользяцееСреднееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Сглаживание_скользящим_средним ChangeParametrImage = new Сглаживание_скользящим_средним();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void иToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СhangeLegends ChangeParametrImage = new СhangeLegends();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void dfsdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.IsLogarithmic = true;
        }

        private void jToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "G";
        }

        private void правкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yyuyuyiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // AddGrafAnotherVremeniAfterDELETE();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   MessageBox.Show("gdf");
        }

        private void найтиПоказателиПараметраНаУчасткеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Параметры_на_участке ChangeParametrImage = new Параметры_на_участке();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void логарифмиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (checkBox4.Checked == true)
                {
                    checkBox5.Checked = true;
                 //  for (int i = 0; i < chart1.ChartAreas.Count; i++)
                //  {
                // //   MessageBox.Show(chart1.ChartAreas.Count.ToString());
                     chart1.ChartAreas[0].AxisY.IsLogarithmic = true;
                  // }
                }
                if (checkBox4.Checked == false)
                {
                    checkBox5.Checked = false;
                
                        chart1.ChartAreas[0].AxisY.IsLogarithmic = false;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Среди значений есть отрицательные или нулевые! Перестройте график предварительно включив логарифмические оси! ");
            }
        }

        private void передвинутьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Передвинуть_график ChangeParametrImage = new Передвинуть_график();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void приветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mes();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("sdfsd");
        }
     private void SearchCharacteristic(Sensors MyNowSensors)
     {
         List<double> MyParametr = new List<double>();
         foreach (Record item in MyNowSensors.MyListRecordsForOneKKS)
         {
             MyParametr.Add(item.Value);
             //   dt.Rows.Add(item.dt, item.value);
         }
         label10.Text = MyParametr.Min().ToString();
         label12.Text = MyParametr.Max().ToString();
         label14.Text = MyParametr.Average().ToString();
         //  }
         //   }

         double sum = 0;
         double sr = MyParametr.Average();
         for (int i = 0; i < MyParametr.Count; i++)
         {

             sum = sum + Math.Pow(MyParametr[i] - sr, 2);
         }

         double standOtklon = Math.Sqrt(sum / MyParametr.Count);

         label15.Text = standOtklon.ToString();
         //   dataGridView1.DataSource = dt;
         MyParametr.Clear();
     }
    
        Sensors myOneKKS;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                dataGridView1.Visible = false;
                myOneKKS = new Sensors();
                for (int i = 0; i < MyAllSensors.Count; i++)
                {
                    if (treeView1.SelectedNode.Text == MyAllSensors[i].KKS_Name)
                    {
                        myOneKKS = MyAllSensors[i];
                        break;
                    }
                    else
                    {
                        myOneKKS = null;
                    }
                }
                SearchCharacteristic(myOneKKS);
               
                this.dataGridView1.CellValueNeeded += new
                    DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);

                dataGridView1.Rows.Clear();
                customers.Clear();

                for (int i = 0; i < myOneKKS.MyListRecordsForOneKKS.Count; i++)
                {
                    this.customers.Add(new MyVirtualClass(myOneKKS.MyListRecordsForOneKKS[i].DateTime.ToString("dd.MM.yy HH:mm:ss.fff"), myOneKKS.MyListRecordsForOneKKS[i].Value.ToString()));
                }
                if (this.dataGridView1.RowCount == 0)
                {
                    this.dataGridView1.RowCount = 1;
                }

                this.dataGridView1.RowCount = myOneKKS.MyListRecordsForOneKKS.Count;
                dataGridView1.Visible = true;
            }
            catch 
            {
              //  MessageBox.Show(ex0.Message);
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
 
         
  
           // myOneKKS = new Sencors();
         //   myOneKKS = MyListSensors[0].getOneKKSByIndex(treeView1.SelectedNode.Index);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {

        
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

       
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                this.contextMenuStrip1.Show(treeView1, e.Location);
            }
        }

        private void найтиМКРToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void памяткаПоФорматамОткрытияФайловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Памятка_по_форматам ChangeParametrImage = new Памятка_по_форматам();
            ChangeParametrImage.Owner = this;
            ChangeParametrImage.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                StreamWriter TOFTONEED = new StreamWriter(saveFileDialog4.FileName + ".txt");

                TOFTONEED.Write("Время" + "\t");
                for (int i = 0; i < MyAllSensors.Count; i++)
                {
                    TOFTONEED.Write(MyAllSensors[i].KKS_Name + "\t");
                }
                TOFTONEED.WriteLine();

                for (int i = 0; i < MyAllSensors[0].MyListRecordsForOneKKS.Count; i++)
                {
                    TOFTONEED.Write(MyAllSensors[0].MyListRecordsForOneKKS[i].DateTime.ToOADate() + "\t");
                    for (int j = 0; j < MyAllSensors.Count; j++)
                    {
                        TOFTONEED.Write(MyAllSensors[j].MyListRecordsForOneKKS[i].Value + "\t");
                    }
                    TOFTONEED.WriteLine();
                }
                TOFTONEED.Close();
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(6, 12, 120, 80);
            button11.Text = "Кнопка";
        }



        private void извлечьПараметрыВТXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           StreamWriter MyRecord = new StreamWriter("D:\\1231.txt");
          //  Extract MyOb = new Extract(MyAllSensors);
            Extract.SelectedCheckedNodes(treeView1.Nodes);
            Extract.MWriter(MyAllSensors,MyRecord);
          //  MyRecord.Close();
     //      List<TreeNode> t = new List<TreeNode>();
       //  MessageBox.Show( Extract.SelectedCheckedNodes(treeView1.Nodes)[0].Text);

          // MessageBox.Show(t[0].ToString());
            //   MessageBox.Show(MyAllSensors.Count.ToString());
            //List<TreeNode> checkedNodes = new List<TreeNode>();


            //   MessageBox.Show(Extract.SelectedCheckedNodes(treeView1.Nodes).Count.ToString());

            //     MyOb.Begin(Extract.SelectedCheckedNodes(treeView1.Nodes));
            //Extract MyOb = new Extract(MyAllSensors,);


         //   Extract.Begin(Extract.SelectedCheckedNodes(treeView1.Nodes));

        }
            //   treeView1.ContextMenuStrip = ContextMenuStrip1;
        
                
    }

    public class OneSensor
    {
        /// <summary>
        /// индивидуальный идентификатор
        /// </summary>
        public string KksName;
        public string haracteristica;

        public OneSensor(string sss)
        {
            OneRec OneRecord = new OneRec();
            OneRecord.dt = Convert.ToDateTime(sss.Split('\t')[0].Replace('.', '/').Replace(',', '.').Trim());//line.Split('\t')[0]//для вывода с милисекундами
            OneRecord.value = double.Parse(sss.Split('\t')[2].Replace('.', ',').Replace('-', '0').Trim());//line.Split('\t')[2]//и прочерками, но в стрингах

            this.values = new List<OneRec>();
            this.KksName = sss.Split('\t')[1];
            this.haracteristica = sss.Split('\t')[5];
            this.values.Add(OneRecord);
        }

        public OneSensor(string sss, double ttt)
        {
            OneRec OneRecord = new OneRec();
            OneRecord.dt = Convert.ToDateTime(sss.Split('\t')[0].Replace('.', '/').Replace(',', '.').Trim());//line.Split('\t')[0]//для вывода с милисекундами
            OneRecord.value = ttt;
            this.values = new List<OneRec>();
            this.KksName = sss.Split('\t')[1];
            this.values.Add(OneRecord);
        }

        public OneSensor()
        {
        }
        /// <summary>
        /// Его наборы значений
        /// </summary>
        public List<OneRec> values;
    }

}
