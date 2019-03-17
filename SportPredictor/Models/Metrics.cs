using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor.Models
{
    public class Metrics
    {
        public double MicroAccuracy { get; set; }
        public double MacroAccuracy { get; set; }
        public double LogLoss { get; set; }
        public double LogLossReduction { get; set; }
    }
}
