using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exchange1
{
    class FileHandler
    {
        public List<Record> ReadFromFile()
        {
            using (StreamReader reader = new StreamReader("WIG20.txt"))
            {
                string line = String.Empty;
                List<Record> records = new List<Record>();
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> columns = new List<string>(line.Split(','));
                    Record record = new Record(float.Parse(columns[5]));
                    records.Add(record);
                }
                return records;
            }
        }
        public void WriteToFile(string fileName)
        {

        }
    }
    class Record
    {
        private string name;
        private int date;
        private float open;
        private float high;
        private float low;
        private float close;
        private float volume;
        private float average;

        public Record(float close)
        {
            this.close = close;
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
