using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchange1
{
    class MathOperations
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
            }
            return records;
        }
    }
}
