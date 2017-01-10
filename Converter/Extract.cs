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
     
        public static void SelectedCheckedNodes(TreeNodeCollection nodes, List<Sensors> MyAllSensors, StreamWriter MyRecord)
        {
          //StreamWriter mySelectedFile = new StreamWriter("D:\\1234.txt");
        List<TreeNode> CheckedNodes = new List<TreeNode>();
           CheckedNodes.Clear();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    CheckedNodes.Add(node);
                }
                else
                {
                    SelectedCheckedNodes(node.Nodes, MyAllSensors, MyRecord);
                }
            }
            List<int> myIndexesKKS = new List<int>();
            List<int> myCount = new List<int>();
        //    float[] myIndexes = new float[CheckedNodes.Count];
       //     int temp = 0;
            foreach (TreeNode checkedNode in CheckedNodes)
            {
                //можно было бы в будущем завязать checkedNode.Text на KKSName, чтобы не тратить время на сравнение текстов - это бредос!!!!!!!(
                for (int i = 0; i < MyAllSensors.Count; i++)
                {
                    if (checkedNode.Text == MyAllSensors[i].KKS_Name)
                    {
                        myIndexesKKS.Add(i);
                        myCount.Add(MyAllSensors[i].MyListRecordsForOneKKS.Count);

                     //  MessageBox.Show(myIndexes[0].KKS_Name.ToString());
                      //  MessageBox.Show(CheckedNodes.Count.ToString());
                        //MyFileRecord.WriteLine(MyAllSensors[i].KKS_Name);
                        //for (int j = 0; j < MyAllSensors[i].MyListRecordsForOneKKS.Count; j++)
                        //{
                        //    MyFileRecord.WriteLine(MyAllSensors[i].MyListRecordsForOneKKS[j].DateTime + " " + MyAllSensors[i].MyListRecordsForOneKKS[j].Value);
                        //}
                    }
                   // else {}
                }
             //   temp++;
                // MessageBox.Show(checkedNode.Text.ToString());
            }



         







         //   MyFileRecord.Close();
        
        }
    }
}
