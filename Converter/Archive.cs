using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Converter
{
   public class Archive
    {
        public static Sensors getSensorByKKSName(string kks , List<Sensors> oppa)
        {
            foreach (Sensors item in oppa)
            {
                if (item.KKS_Name  == kks)
                {
                    return item;
                }
            }
            return null;
        }
  
             private static int DetectType(string filename)
        {
            string[] temp = filename.Split('.');
            switch (temp[1])
            {
                case "txt":
                    return 1;
                    break;
                case "rsa":
                    return 2;
                    break;
                case "dat":
                    return 3;
                    break;
                case "txtAOP":
                    return 4;
                    break;
                case "txtPCA":
                   return 5;
                    break;
                case "txtSVBUap":
                    return 6;
                    break;
                case "txtSVBU":
                    return 7;
                    break;
                case "txtSVRK":
                    return 8;
                    break;
                default:
                    return -1;
                    break;
            }
            return -1;
        }
        int i = 1;
        public static void LoadSVRKtxt(string filename, List<Sensors> y)
        {

            List<Sensors> MyList = new List<Sensors>();
                System.IO.StreamReader streamReader;
                streamReader = new System.IO.StreamReader(filename, Encoding.GetEncoding("Windows-1251"));

 
                List<string> kk = new List<string>();
           

                //   checkedListBox1.Items.Add("START");
                //ДОБАВИМ В КОЛЛЕКЦИЮ ЧЕКБОКСОВ 
             
                    string line;

                    for (int i = 0; i < 4; i++)
                    {
                        streamReader.ReadLine();
                    }

                    line = streamReader.ReadLine();
               //     MessageBox.Show(line);
                    List<string> origkks = new List<string>();
                    origkks = line.Split('|').ToList();

                    int p = 0;
                    foreach (string item in origkks)
                    {
                        p++;
                        if (p > 1)
                        {
                            Sensors myonekks = new Sensors();
                            myonekks.MyListRecordsForOneKKS = new List<Record>();
                            myonekks.KKS_Name = item;
                            MyList.Add(myonekks);
                        }
                    }

                    string[] massiv_znacheniy_postrochno = new string[origkks.Count + 1];
                    while (line != null)
                    {
                        line = streamReader.ReadLine();
                        if (line != null)
                        {
                            massiv_znacheniy_postrochno = line.Split('|').ToArray();
                            for (int i = 1; i < massiv_znacheniy_postrochno.Length - 1; i++)
                            {
                                Record onerec = new Record();
                                try
                                {
                                 //   Record onerec = new Record();
                                    onerec.DateTime = Convert.ToDateTime(massiv_znacheniy_postrochno[0].Replace(".000", "").Trim());
                                    onerec.Value = double.Parse(massiv_znacheniy_postrochno[i].Replace('.', ',').Trim());
                                }
                                catch
                                {

                                }
                                MyList[i - 1].MyListRecordsForOneKKS.Add(onerec);
                            }
                        }// if
                    } //whilr пока не конец файла
                    MyList.RemoveAt(MyList.Count - 1);
                   y.AddRange(MyList);
                    MyList.Clear();
                streamReader.Close();
             // if openFIle Dialog

        }

        //public void LoadSVBU(string filename, MyListOfSensors y)
        //{
        //    StreamReader MyFileTXT = new StreamReader(filename);
        //    MyListOfSensors MyList = new MyListOfSensors();

        //    StreamWriter MyParametrs = new StreamWriter("D:\\МОИ ПАРАМЕТРЫ для АКПМ.txt");
        //    MyList.Clear();

        //    for (int i = 0; i < 4; i++)
        //        MyFileTXT.ReadLine();

        //    string line;

        //    while ((line = MyFileTXT.ReadLine()) != null)
        //    {
        //        if (MyList.getSensorByKKSName(line.Split('\t')[1], MyList) != null)
        //        {
        //            Record OneRecord = new Record();
        //            if (line.Split('\t')[0].Trim() != "")
        //            {
        //                OneRecord.DateTime = Convert.ToDateTime(line.Split('\t')[0].Replace('.', '/').Replace(',', '.').Trim());
        //            }
        //            OneRecord.Value = double.Parse(  line.Split('\t')[2].Replace('.',','));
        //     //     OneRecord.
        //            MyList.getSensorByKKSName(line.Split('\t')[1],MyList).MyListRecordsForOneKKS.Add(OneRecord);
        //        }
        //        else
        //        {
        //            Sencors myoneKKS = new Sencors(line, "");
        //            MyList.Add(myoneKKS);
        //        } //else
        //    } //while
        //    foreach(var item in MyList)
        //    {
        //        item.MyListRecordsForOneKKS.RemoveAt(0);
        //    }

        //    //for (int i = 0; i < MyList.Count; i++)
        //    //{
        //    //    MyList[i].KKS_Name = MyList[i].KKS_Name + " " + MyList[i].haracteristica;
        //    //    MyParametrs.WriteLine(MyList[i].KKS_Name);
        //    //}

        //    for (int i = 1; i < MyList.Count; i++)
        //    {
        //        for (int j = 0; j < MyList[0].MyListRecordsForOneKKS.Count; j++)
        //        {
        //            MyList[i].MyListRecordsForOneKKS[j].DateTime = MyList[0].MyListRecordsForOneKKS[j].DateTime;
        //        }
        //    }
        //    MyParametrs.Close();
        //    y.AddRange(MyList);
        //    MyList.Clear();
        //    MyFileTXT.Close();

        //}
        public static void LoadAOP(string filename, List<Sensors> y)
        {

            List<Sensors> MyList = new List<Sensors>();
            StreamReader MyFileAOP = new StreamReader(filename, Encoding.GetEncoding("Windows-1251"));
            MyList.Clear();
            string Line;
            Line = MyFileAOP.ReadLine();
            List<string> origkks = new List<string>();
            origkks = Line.Split(' ').ToList();

            int p = 0;
            foreach (string item in origkks)
            {
                p++;
                if (p > 0)
                {
                    Sensors myonekks = new Sensors();
                    myonekks.MyListRecordsForOneKKS = new List<Record>();
                    myonekks.KKS_Name = item;
                    MyList.Add(myonekks);
                }
            }
           while ((Line = MyFileAOP.ReadLine()) != null)
            {
                for (int i = 2; i <  MyList.Count; i++)
                {
                    Record MyRec = new Record();
                    MyRec.DateTime = Convert.ToDateTime(Line.Split(' ')[0].Trim().ToString() + " " + Line.Split(' ')[1].Trim().ToString());
                    MyRec.Value = double.Parse(Line.Split(' ')[i].Replace('.', ',').Trim().ToString());
                    MyList[i].MyListRecordsForOneKKS.Add(MyRec);             
                }
           }
           MyList.RemoveAt(0);
           MyList.RemoveAt(0);
           y.AddRange(MyList);
           MyList.Clear();
            MyFileAOP.Close();
        }
        public static void LoadFromFile(string filename, List<Sensors> y)
        {
            if (DetectType(filename) != -1)
            {
                switch (DetectType(filename))
                {
                    case 1:
                   
                            LoadAPIK(filename, y);
                            break;
                        
                        
                    case 2:
                        LoadRSAnvaes2(filename, y);
                        break;
                    //редактировать
                    case 3:
                        ReadDATformat(filename, y);
                        break;
                    case 4:
                        LoadAOP(filename, y);
                        break;
                    case 5:
                        LoadPCAFormat(filename, y);
                        break;
             //       case 6:
                     //   this.LoadSVBU(filename, y);
                      //  break;
             //       case 7:
               //         this.LoadTXTnvaes2(filename, y);
                 //       break;
                    case 8:
                        LoadSVRKtxt(filename, y);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void LoadAPIK(string filename, List<Sensors> p)
        {
            string line = "";
            StreamReader mysr = new StreamReader(filename, Encoding.GetEncoding("Windows-1251"));
            List<Sensors> MyList = new List<Sensors>();
            MyList.Clear();

            List<string> strarray = new List<string>();
            List<string> strarray1 = new List<string>();
            line = mysr.ReadLine();

            strarray1 = line.Split('\t').ToList();
            strarray1.RemoveAt(0);
            strarray.Add("Время реальное");
            strarray.Add("Время СКУД");
            strarray.AddRange(strarray1);
            strarray.RemoveAt(2);

            int i2 = 0;
            foreach (string item in strarray)
            {
                // i2++;
                if (i2 >= 0)
                {
                    Sensors myonekks = new Sensors();
                    myonekks.KKS_Name = item;
                    MyList.Add(myonekks);
                }
                i2++;

            }
            int N = strarray.Count() - 1;
            double[] mytempdouble = new double[strarray.Count];
            while (line != null)
            {
                line = mysr.ReadLine();
                if (line != null)
                {
                    mytempdouble = line.Replace('.', ',').Split('\t').Select(n => double.Parse(n)).ToArray();
                    //MessageBox.Show(mytempdouble[mytempdouble.Count()-1].ToString());

                    for (int i = 0; i < mytempdouble.Length; i++)
                    {
                        Record OneRec = new Record();

                        OneRec.DateTime = DateTime.FromOADate(mytempdouble[1]);
                        OneRec.Value = mytempdouble[i];

                        MyList[MyList.Count - N + i - 1].MyListRecordsForOneKKS.Add(OneRec);
                    }
                }
            }
            p.AddRange(MyList);
            MyList.Clear();
            //Закрытие потока
            mysr.Close();
        }

        private static void LoadRSAnvaes2(string filename, List<Sensors> y)
        {


            List<Sensors> MyList = new List<Sensors>();
            StreamReader MyFileRSA = new StreamReader(filename);
            MyList.Clear();

            for (int i = 0; i < 18; i++)
            {
                MyFileRSA.ReadLine();
            }

            List<string> MyListKKS = new List<string>();

            string Line;
            string All_Line = null;
            while ((Line = MyFileRSA.ReadLine()) != "MaxRowCnt=1000")
            {
                Line = Line.Remove(0, 13);
                All_Line = All_Line + Line;

                MyListKKS = All_Line.Split(';').ToList();
            }
            MyListKKS.RemoveAt(MyListKKS.Count - 1);

            for (int i = 0; i < MyListKKS.Count; i++)
            {
                Sensors MyOneSensors = new Sensors();
                MyOneSensors.KKS_Name = MyListKKS[i]; ;

                //возможно ошибка
                MyList.Add(MyOneSensors);
            }

            int Length_MyFile = System.IO.File.ReadAllLines(filename).Length;

            Line = null;

            while ((Line != "RsaData"))
            {
                Line = MyFileRSA.ReadLine();
                // Console.WriteLine(Line);
                string Identificator_Start_Read = Line.Split('=')[0].Trim();
                if (Identificator_Start_Read == "RsaData")
                {
                    break;
                }
            }
            List<DateTime> mydate = new List<DateTime>();
            List<string> Helper = new List<string>();
            while ((Line = MyFileRSA.ReadLine()) != null)
            {


                Helper.Clear();
                Line = Line.Remove(0, 8);
                Helper = Line.Split(';').ToList();
                for (int i = 0; i < MyList.Count + 1; i++)
                {
                    Record MyRecord = new Record();
                    if (i == 0)
                    {
                        mydate.Add(Convert.ToDateTime(Helper[i]));
                    }
                    if (i == 1)
                    {
                        Helper[i] = Helper[i].Split(' ')[2];
                        MyRecord.Value = double.Parse(Helper[i].Replace('.', ','));
                        MyRecord.DateTime = mydate[mydate.Count - 1];

                        MyList[i - 1].MyListRecordsForOneKKS.Add(MyRecord);
                    }
                    if (i > 1)
                    {
                        Helper[i] = Helper[i].Split(' ')[1];
                        MyRecord.Value = double.Parse(Helper[i].Replace('.', ','));
                        MyRecord.DateTime = mydate[mydate.Count - 1];
                        MyList[i - 1].MyListRecordsForOneKKS.Add(MyRecord);
                    }

                }


            }

            MyFileRSA.Close();


            y.AddRange(MyList);
        }//End LoadRSAnvaes2
        public static void LoadPCAFormat(string filename, List<Sensors> p)
        {
            StreamReader MyFileTXT = new StreamReader(filename, Encoding.GetEncoding("Windows-1251"));
            List<Sensors> MyList = new List<Sensors>();
            MyList.Clear();

            for (int i = 0; i < 4; i++)
                MyFileTXT.ReadLine();

            List<string> strarray = new List<string>();
            string line  =  MyFileTXT.ReadLine();;

            strarray = line.Split('|').ToList();

            for (int i = 1; i < strarray.Count - 1; i++)
            {
                Sensors myonekks = new Sensors();
                myonekks.KKS_Name = strarray[i];
                MyList.Add(myonekks);
            }
           int h = 0;
           while ((line = MyFileTXT.ReadLine()) != null)
           {
               List<string> t1 = new List<string>();
               t1.Clear();
               t1 = line.Split('|').ToList();

               for (int k = 1; k < t1.Count-1; k++)
               {
                   try
                   {
                       Record OneRecord = new Record();
                       string m = t1[0];
                       OneRecord.DateTime = Convert.ToDateTime(m);
                       OneRecord.Value = double.Parse(t1[k].Trim().Replace('.', ','));
                       MyList[k-1].MyListRecordsForOneKKS.Add(OneRecord);
                   }
                   catch
                   {

                   }
               }
               }
           MyFileTXT.Close();
        }
        public void LoadTXTnvaes2_new(string filename, List<Sensors> p)
        {
           
            StreamReader MyFileTXT = new StreamReader(filename);
            List<Sensors> MyList = new List<Sensors>();
            MyList.Clear();
            for (int i = 0; i < 4; i++)
                MyFileTXT.ReadLine();

            string line;
         //   MessageBox.Show("");
            while ((line = MyFileTXT.ReadLine()) != null)
            {
           //     MessageBox.Show(line);
               //  MessageBox.Show(line.Split('\t')[1]);
                if (Archive.getSensorByKKSName(line.Split('\t')[1],MyList) != null)
                {
                    Record OneRecord = new Record();
                    OneRecord.DateTime = Convert.ToDateTime(line.Split('\t')[0].Replace('.', '/').Replace(',', '.').Trim());
                    OneRecord.Value = double.Parse(line.Split('\t')[2].Replace('.', ',').Replace('-', '0').Trim());
                    Archive.getSensorByKKSName(line.Split('\t')[1], MyList).MyListRecordsForOneKKS.Add(OneRecord);
                }
                else
                {
                    Sensors myoneKKS = new Sensors();
                   MyList.Add(myoneKKS);
                } //else
            } //while

         //   MessageBox.Show(MyList[0].KKS_Name);
           //
            MyFileTXT.Close();
            p.AddRange(MyList);
        }

  //      public void LoadTXTnvaes2(string filename, MyListOfSensors p)
  //      {

  //          StreamReader MyFileTXT = new StreamReader(filename);
  //          MyListOfSensors MyList = new MyListOfSensors();
  //          MyList.Clear();


  ////          int y = System.IO.File.ReadAllLines(filename).Length;

  //          for (int i = 0; i < 4; i++)
  //              MyFileTXT.ReadLine();

  //          string line;

  //          while ((line = MyFileTXT.ReadLine()) != null)
  //          {
  //              if (MyList.getSensorByKKSName(line.Split('\t')[1], MyList) != null)
  //              {
  //                  Record OneRecord = new Record();
            
  //                      DateTime date = DateTime.ParseExact((Convert.ToDateTime(line.Split('\t')[0].Replace('.', '/').Replace(',', '.').Trim())).ToString("dd.MM.yy HH:mm:ss.fff"), "dd.MM.yy HH:mm:ss.fff", CultureInfo.InvariantCulture);
  //                      OneRecord.DateTime = date;
                    
  //                  string help = line.Split('\t')[2].Replace('.', ',').Trim();
  //                //  MessageBox.Show(help.Split('\t')[0].ToString());
  //                  OneRecord.Value = double.Parse(help.Split(' ')[0].ToString());
  //                  MyList.getSensorByKKSName(line.Split('\t')[1], MyList).MyListRecordsForOneKKS.Add(OneRecord);
  //              }
  //              else
  //              {
  //                  Sencors myoneKKS = new Sencors(line);
  //                  MyList.Add(myoneKKS);
  //              } //else
  //              //MyProgressBar.Value++;

  //          }
  //          for (int i = 0; i < MyList.Count; i++)
  //          {
  //              MyList[i].MyListRecordsForOneKKS.RemoveAt(0);
  //          }

  //        //  p.AddRange(MyList);

  //          MyFileTXT.Close();
  //          p.AddRange(MyList);

  //      }//End LoadTXTnvaes2

        public static void ReadDATformat(string filename, List<Sensors> p)
        {
            System.IO.StreamReader MyFile;
            MyFile = new System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("Windows-1251"));
            List<Sensors> MyList = new List<Sensors>();
            List<string> OriginalKKS = new List<string>();

            string line = MyFile.ReadLine();
            //     textBox1.Text = openFileDialog1.FileName;
            OriginalKKS = line.Split('\t').ToList();

            for (int i = 1; i < OriginalKKS.Count; i++)
            {
                Sensors myonekks = new Sensors();
                myonekks.KKS_Name = OriginalKKS[i];
                myonekks.MyListRecordsForOneKKS = new List<Record>();
                MyList.Add(myonekks);
            }

            string[] massiv_znacheniy_postrochno = new string[OriginalKKS.Count + 1];
            while (line != null)
            {
                line = MyFile.ReadLine();
                if (line != null)
                {
                    // MessageBox.Show(line.ToString());
                    massiv_znacheniy_postrochno = line.Split('\t').ToArray();
                    for (int i = 1; i < massiv_znacheniy_postrochno.Length - 1; i++)
                    {
                        Record onerec = new Record();
                        onerec.Value = double.Parse(massiv_znacheniy_postrochno[i].Replace('.', ',').Trim());
                     //   onerec.value1 = double.Parse(massiv_znacheniy_postrochno[0].Replace('.', ',').Trim());
                        double timestamp = double.Parse(massiv_znacheniy_postrochno[0].Replace('.', ',').Trim());
                        DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
                        //  DateTime WindowsTime = new DateTime(1970, 1, 1,1,1,1).AddSeconds(double.Parse(massiv_znacheniy_postrochno[0].Replace('.', ',').Trim()));
                        onerec.DateTime = date;
                        //  DateTime date1 = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(15902905.800);
                        //   MessageBox.Show(       date1.ToString());
                        MyList[i - 1].MyListRecordsForOneKKS.Add(onerec);
                    }
                }// if
            } //whilr пока не конец ф
         //   p.AddRange(MyList);
         //   MyList.Clear();
            //Закрытие потока
        //    mysr.Close();
            MyList.RemoveAt(MyList.Count - 1);
            p.AddRange(MyList);
            MyList.Clear();
            MyFile.Close();

        }
        public List<double> getХvaluesByIndexStartEnd(int len)
        {
            List<double> temp = new List<double>();

            for (int i = 0; i < len; i++)
            {
                temp.Add((double)i);
            }

            return temp;

        }
        public List<double> getYvaluesByIndexStartEnd(int index, int start, int end, List<Sensors> MyList)
        {
            List<double> temp = new List<double>();

            for (int i = start; i < end; i++)
            {
                temp.Add(MyList[index].MyListRecordsForOneKKS[i].Value);
            }

            return temp;

        }
    }

  

    
}
