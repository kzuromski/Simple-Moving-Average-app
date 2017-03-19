using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            FileHandler file = new FileHandler();
            Operations ope = new Operations();
            var records = ope.simpleAverageMethod(file.ReadFromFile());
            file.WriteToFile(records);

            chart1.Series["average"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            foreach (var variable in records)
            {
                chart1.Series["average"].Points.AddXY(variable.getDate(), variable.getAverage());
            }
        }
    }
}
