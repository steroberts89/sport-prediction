using Microsoft.ML;
using Microsoft.ML.Data;
using System;

namespace myApp
{
    class Program
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

        static void Main(string[] args)
        {
            // STEP 2: Create a ML.NET environment  
            var mlContext = new MLContext();

            // If working in Visual Studio, make sure the 'Copy to Output Directory'
            // property of data.txt is set to 'Copy always'
            var reader = mlContext.Data.CreateTextReader<GameData>(separatorChar: ',', hasHeader: false);
            IDataView trainingDataView = reader.Read("ana.txt");

            // STEP 3: Transform your data and add a learner
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training.
            // Add a learning algorithm to the pipeline. e.g.(What outcome of game is this?)
            // Convert the Label back into original text (after converting to number in step 3)
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate("Features",
                "TeamShots", "OpponentShots", "TeamPPG", "OpponentPPG",
                "TeamSHG", "OpponentSHG", "TeamPP", "OpponentPP", "TeamPIM", "OpponentPIM"))
                .Append(mlContext.MulticlassClassification.Trainers.StochasticDualCoordinateAscent(labelColumn: "Label", featureColumn: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // STEP 4: Train your model based on the data set  
            var model = pipeline.Fit(trainingDataView);

            // STEP 5: Use your model to make a prediction
            // You can change these numbers to test different predictions
            var prediction = model.CreatePredictionEngine<GameData, GamePrediction>(mlContext).Predict(
                new GameData()
                {
                    TeamShots = 12,
                    TeamPPG = 2,
                    TeamPIM = 6,
                    TeamPP = 3,
                    TeamSHG = 0,
                    OpponentShots = 60,
                    OpponentPPG = 0,
                    OpponentPIM = 6,
                    OpponentPP = 3,
                    OpponentSHG = 1
                });

            Console.WriteLine($"Predicted outcome: {prediction.PredictedLabels}");
        }
    }
}
