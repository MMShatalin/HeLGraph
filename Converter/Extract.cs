using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    /// <summary>
    /// Это класс, реализующий статические методы селекции выбранных пользователем параметров и извлечение их в отдельный файл
    /// </summary>
    public class Extract
    {
        //список всех параметров
        public static List<Sensors> NecessaryParams { get; set; }
        //список индексов отмеченных параметров в __necessaryParams
      //  private static List<int> MyIndexesCheckedSensors { get; set; }

        //передаем конструктором через объект созданный в обработчике Form1
        public Extract(List<Sensors> necessaryParams)
        {  
            NecessaryParams = necessaryParams;
        }

        static List<string> _myNameKks = new List<string>();
        public static void SelectedCheckedNodes(TreeNodeCollection nodes)
        {
            List<TreeNode> CheckedNodes = new List<TreeNode>();
            CheckedNodes.Clear();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    CheckedNodes.Add(node);
                    _myNameKks.Add(node.Text);
                }
                else
                {
                    SelectedCheckedNodes(node.Nodes);
                }
            }
        }

        public static void MWriterChecked(List<Sensors> MyAllSensors,
            StreamWriter MyRecord)
        {
            List<int> mycount = new List<int>();
            List<Sensors> mSensorses = new List<Sensors>();
            for (int i = 0; i < _myNameKks.Count; i++)
            {
                for (int j = 0; j < MyAllSensors.Count; j++)
                {
                    if (_myNameKks[i] == MyAllSensors[j].KKS_Name)
                    {
                      //  MessageBox.Show("привет!");
                        mycount.Add(MyAllSensors[j].MyListRecordsForOneKKS.Count);
                        mSensorses.Add(MyAllSensors[j]);
                    }
                }
            }
            for (int i = 0; i < _myNameKks.Count; i++)
            {
                MyRecord.Write(_myNameKks[i] + ";;");
            }
            MyRecord.WriteLine();
            int max = mycount.Max();
     
            for (int j = 0; j < max; j++)
           {
              for (int i = 0; i < mSensorses.Count; i++)
               {
                 if(j<=mSensorses[i].MyListRecordsForOneKKS.Count-1)
                  {
                       MyRecord.Write(mSensorses[i].MyListRecordsForOneKKS[j].DateTime +";"+ mSensorses[i].MyListRecordsForOneKKS[j].Value + ";");
                   }
                 else
                   {
                       MyRecord.Write(";;");
                    }
               }
                MyRecord.WriteLine();
             }

            MyRecord.Close();
        }//конец метода

        public static void MWriterAll(List<Sensors> MyAllSensors,
            StreamWriter MyRecord)
        {
            List<int> mycount = new List<int>();
        
            for (int j = 0; j < MyAllSensors.Count; j++)
            {
                mycount.Add(MyAllSensors[j].MyListRecordsForOneKKS.Count);
            }

            for (int i = 0; i < MyAllSensors.Count; i++)
            {
                MyRecord.Write(MyAllSensors[i].KKS_Name + ";;");
            }
            MyRecord.WriteLine();
            int max = mycount.Max();

            for (int j = 0; j < max; j++)
            {
                for (int i = 0; i < MyAllSensors.Count; i++)
                {
                    if (j <= MyAllSensors[i].MyListRecordsForOneKKS.Count - 1)
                    {
                        MyRecord.Write(MyAllSensors[i].MyListRecordsForOneKKS[j].DateTime + ";" + MyAllSensors[i].MyListRecordsForOneKKS[j].Value + ";");
                    }
                    else
                    {
                        MyRecord.Write(";;");
                    }
                }
                MyRecord.WriteLine();
            }

            MyRecord.Close();
        }//конец метода
    }
}
