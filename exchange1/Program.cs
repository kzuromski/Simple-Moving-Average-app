using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace exchange1
{
    class FileHandler
    {
        public List<Record> ReadFromFile()
        {
            using (StreamReader reader = new StreamReader("WIG20.txt"))
            {
                string line = String.Empty;
                reader.ReadLine();
                List<Record> records = new List<Record>();
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> columns = new List<string>(line.Split(','));
                    Record record = new Record(columns[0], Int32.Parse(columns[1]), double.Parse(columns[2], CultureInfo.InvariantCulture), double.Parse(columns[3], CultureInfo.InvariantCulture),
                    double.Parse(columns[4], CultureInfo.InvariantCulture), double.Parse(columns[5], CultureInfo.InvariantCulture), double.Parse(columns[6], CultureInfo.InvariantCulture), 0);
                    records.Add(record);
                }
                return records;
            }
        }
        public void WriteToFile(List<Record> records)
        {
            int k = 0;
            string fileName = "WIG20_" + k + ".txt";
            while (File.Exists(fileName))
            {
                k++;
                fileName = "WIG20_" + k + ".txt";
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Name,Date,Open,High,Low,Close,Volume,Average");
                for (int i = 0; i < records.Count(); i++)
                {
                    string line = records.ElementAt(i).toString();
                    writer.WriteLine(line);
                }
            }
        }
    }

    class Operations
    {
        public List<Record> simpleAverageMethod(List<Record> records)
        {
            int numberOfElements = records.Count();
            int counter = 1;
            int period = 15;
            double sum = 0;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (counter < period)
                {
                    sum += records.ElementAt(i).getClose();
                    records.ElementAt(i).setAverage(sum / counter);
                }
                else
                {
                    sum = 0;
                    for (int j = counter; j > counter - period; j--)
                    {
                        sum += records.ElementAt(j - 1).getClose();
                    }
                    records.ElementAt(i).setAverage(sum / period);
                }
                counter++;
                Console.WriteLine(records.ElementAt(i).getAverage());
            }
            return records;
        }
    }

    class Record
    {
        private string name;
        private int date;
        private double open;
        private double high;
        private double low;
        private double close;
        private double volume;
        private double average;

        public Record(string name, int date, double open, double high, double low, double close, double volume, double average)
        {
            this.name = name;
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
            this.average = average;
        }
        public int getDate()
        {
            return date;
        }
        public double getClose()
        {
            return close;
        }
        public void setAverage(double average)
        {
            this.average = average;
        }
        public double getAverage()
        {
            return average;
        }
        public string toString()
        {
            string record = name + ',' + date + ',' + high + ',' + low + ',' + open + ',' + close + ',' + volume + ',' + average;
            return record;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
