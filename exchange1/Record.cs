using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace exchange1
{
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

        public Record(List<string> record)
        {
            this.name = record[0];
            this.date = Int32.Parse(record[1]);
            this.open = Double.Parse(record[2], CultureInfo.InvariantCulture);
            this.high = Double.Parse(record[3], CultureInfo.InvariantCulture);
            this.low = Double.Parse(record[4], CultureInfo.InvariantCulture);
            this.close = Double.Parse(record[5], CultureInfo.InvariantCulture);
            this.volume = Double.Parse(record[6], CultureInfo.InvariantCulture);
            this.average = 0;
        }

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
        public double getOpen()
        {
            return open;
        }
        public double getHigh()
        {
            return high;
        }
        public double getLow()
        {
            return low;
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
}
