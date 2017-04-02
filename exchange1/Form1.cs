using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace exchange1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileHandler file = new FileHandler();
        MathOperations operations = new MathOperations();
        List<Record> records;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            records = operations.simpleAverageMethod(file.ReadFromFile());
            file.WriteToFile(records);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            try
            {
                if (records == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Can not draw chart, data was not loaded.", "Error");
                Environment.Exit(0);
            }
            chart1.Series["average"].ChartType = SeriesChartType.Candlestick;
            chart1.Series["data"].ChartType = SeriesChartType.Line;
            foreach (var record in records)
            {
                int index = record.getDate().ToString().IndexOf("2016");
                if (index != -1)
                {
                    chart1.Series["average"].Points.AddXY(record.getDate(), record.getAverage());
                    chart1.Series["data"].Points.AddXY(record.getDate(), record.getClose());
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
