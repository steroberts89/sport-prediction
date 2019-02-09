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

        [LoadColumn(9)]
        public float TeamShots;

        [LoadColumn(10)]
        public float TeamPIM;

        [LoadColumn(11)]
        public float TeamPPG;

        [LoadColumn(12)]
        public float TeamPP;

        [LoadColumn(13)]
        public float TeamSHG;

        [LoadColumn(15)]
        public float OpponentShots;

        [LoadColumn(16)]
        public float OpponentPIM;

        [LoadColumn(17)]
        public float OpponentPPG;

        [LoadColumn(18)]
        public float OpponentPP;

        [LoadColumn(19)]
        public float OpponentSHG;

        [LoadColumn(6)]
        public string Label;
    }

    // GamePrediction is the result returned from prediction operations
    public class GamePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
