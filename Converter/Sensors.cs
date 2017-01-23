using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public class Sensors : IComparable
    {
        int L;
        public string KKS_Name { get; set; }
        public string haracteristica { get; set; }
        public List<Record> MyListRecordsForOneKKS;
        public Sensors()
        {
            this.MyListRecordsForOneKKS = new List<Record>();
            L = this.MyListRecordsForOneKKS.Count;

        }
        public Sensors(string sss)
        {
            Record OneRecord = new Record();
            this.MyListRecordsForOneKKS = new List<Record>();
            this.KKS_Name = sss.Split('\t')[1];
            this.MyListRecordsForOneKKS.Add(OneRecord);
        }

        public int CompareTo(object other)
        {
            var oth = other as Sensors;
            return this.KKS_Name.CompareTo(oth.KKS_Name);
        }
        public Sensors getSensorByKKSName(string kks, List<Sensors> oppa)
        {
            foreach (Sensors item in oppa)
            {
                if (item.KKS_Name == kks)
                {
                    return item;
                }
            }
            return null;
        }

        public Sensors getOneKKSByIndex(int index, List<Sensors> MyList)
        {
            return MyList[index];
        }

    }
}
