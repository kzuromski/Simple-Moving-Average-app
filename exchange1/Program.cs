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
        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader("WIG20.txt"))
            {
                string line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    line.Split(',');
                }
            }
        }
    }
    class Record
    {
        string name;
        int date;
        float open;
        float high;
        float low;
        float close;
        float volume;
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
