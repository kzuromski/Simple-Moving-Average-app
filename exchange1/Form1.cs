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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            FileHandler file = new FileHandler();
            Operations ope = new Operations();
            var records = ope.simpleAverageMethod(file.ReadFromFile());
            file.WriteToFile(records);
            chart1.Series["average"].ChartType = SeriesChartType.Candlestick;
            chart1.Series.Add("data");
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
            button1.Enabled = true;
        }
    }
}
