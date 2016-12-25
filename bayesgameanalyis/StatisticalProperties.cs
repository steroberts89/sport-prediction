using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bayesgameanalyis
{

    class StatisticalProperty
    {
        string name;
        protected List<int> values { get; set; }
        public double mean { get; protected set; }
        public double variance { get; protected set; }

        public StatisticalProperty(string newName,List<int> values)
        {
            name = newName;
            this.values = values;
            mean = getMean();
            variance = calculateVariance();
        }

        public double getMean()
        {
            if(values.Count==0)
            {
                return 0.0;
            }
            return values.Average();
        }

        /// <summary>
        /// varijanca je kvadrat standardne devijacije
        /// </summary>
        /// <returns></returns>
        public double calculateVariance()
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = ((sum) / (values.Count() - 1));
            }
            if (Double.IsNaN(ret))
            {
                return 0.0;
            }
            return ret;
        }
    }
}
