using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data;
using System.IO;
using System;

namespace Testas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ChooseFilePath()
        {
            string Path;
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Path = ofd.FileName;
                return Path;
            }

            throw new NotImplementedException();
        }

        bool DayIsWritten(int day, List<Grybai> List)
        {
            foreach (var item in List)
            {
                if (item.Day == day)
                {
                    return true;
                }
            }

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("select file with the data");
            string FilePath;
            FilePath = ChooseFilePath();

            List<Grybai> DataList = new List<Grybai>();

            string[] dataFromFile = File.ReadAllLines(FilePath);

            int size = Convert.ToInt32(dataFromFile[0]);

            string[] data;

            for (int i = 1; i <= size; i++)
            {
                data = dataFromFile[i].Split(' ');
                int day = Convert.ToInt32(data[0]);
                int mush1 = Convert.ToInt32(data[1]);
                int mush2 = Convert.ToInt32(data[2]);
                int mush3 = Convert.ToInt32(data[3]);

                if (!DayIsWritten(day, DataList))
                {
                    DataList.Add(new Grybai(day, mush1, mush2, mush3));
                }
                else
                {
                    foreach (var item in DataList)
                    {
                        if (item.Day == day)
                        {
                            item.Mushroom1Count += mush1;
                            item.Mushroom2Count += mush2;
                            item.Mushroom3Count += mush3;
                        }
                    }
                }
            }

            DataList.Sort((a, b) => a.Day.CompareTo(b.Day));

            string Result = "";

            foreach (var item in DataList)
            {
                if (item.Mushroom1Count > 0 || item.Mushroom2Count > 0 || item.Mushroom3Count > 0)
                {
                    Result += item.Day + " " + item.Mushroom1Count.ToString() + " " + item.Mushroom2Count.ToString() + " " + item.Mushroom3Count.ToString() + "\n";
                }
            }

            Result += MaxDay(DataList);

            MessageBox.Show("select file where to store the result");
            string path = ChooseFilePath();

            StreamWriter writer = new StreamWriter(path);
            writer.Write(Result);
            writer.Close();
        }

        public string MaxDay(List<Grybai> list)
        {
            int sum;
            int day = 0;
            int max = 0;

            foreach (var item in list)
            {
                sum = 0;
                sum += (item.Mushroom1Count + item.Mushroom2Count + item.Mushroom3Count);

                if (sum > max)
                {
                    day = item.Day;
                    max = sum;
                }
            }

            return day.ToString() + " " + max.ToString();

        }
    }
}