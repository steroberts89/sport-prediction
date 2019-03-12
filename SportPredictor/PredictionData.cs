using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor
{
    // STEP 1: Define your data structures
    // GameData is used to provide training data, and as
    // input for prediction operations
    // - First 4 properties are inputs/features used to predict the label
    // - Label is what you are predicting, and is only set when training
    public class GameData
    {

        public string Home { get; set; }
        public float HomeWins { get; set; }
        public float HomeLosses { get; set; }
        public float HomeOT { get; set; }
        public string Away { get; set; }
        public float AwayWins { get; set; }
        public float AwayLosses { get; set; }
        public float AwayOT { get; set; }
        public string Label { get; set; }
    }

    // GamePrediction is the result returned from prediction operations
    public class GamePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
