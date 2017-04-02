using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exchange1
{
    class FileHandler
    {
        public List<Record> ReadFromFile()
        {
            try
            {
                StreamReader sr = File.OpenText("WIG20.txt");
            }
            catch (FileNotFoundException error)
            {
                MessageBox.Show("Can not open file, please check if file exist.", "Error");
                Environment.Exit(0);
            }
            using (StreamReader reader = new StreamReader("WIG20.txt"))
            {
                string line = String.Empty;
                reader.ReadLine();
                List<Record> records = new List<Record>();
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> columns = new List<string>(line.Split(','));
                    Record record = new Record(columns);
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
}
