using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using System;

namespace SportPredictor
{
    class Program
    {
        private static MLContext _mlContext;

        private static ITransformer _trainedModel;

        static void Main(string[] args)
        {
            // STEP 2: Create a ML.NET environment  
            _mlContext = new MLContext();

            // If working in Visual Studio, make sure the 'Copy to Output Directory'
            // property of data.txt is set to 'Copy always'
            IDataView trainingDataView = _mlContext.Data.ReadFromTextFile<GameData>(path: "ana.txt", hasHeader: false, separatorChar: ',');

            // STEP 3: Transform your data and add a learner
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training.
            // Add a learning algorithm to the pipeline. e.g.(What outcome of game is this?)
            // Convert the Label back into original text (after converting to number in step 3)
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(_mlContext.Transforms.Concatenate("Features",
                "TeamShots", "OpponentShots", "TeamPPG", "OpponentPPG",
                "TeamSHG", "OpponentSHG", "TeamPP", "OpponentPP", "TeamPIM", "OpponentPIM"))
                .Append(_mlContext.MulticlassClassification.Trainers.StochasticDualCoordinateAscent(labelColumn: "Label", featureColumn: "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // STEP 4: Train your model based on the data set  
            _trainedModel = pipeline.Fit(trainingDataView);

            // STEP 5: Use your model to make a prediction
            // You can change these numbers to test different predictions
            var prediction = _trainedModel.CreatePredictionEngine<GameData, GamePrediction>(_mlContext).Predict(
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
            Evaluate();
        }

        public static void Evaluate()
        {
            //Load the test dataset into the IDataView
            var testDataView = _mlContext.Data.ReadFromTextFile<GameData>(path: "eval.txt", hasHeader: false, separatorChar: ',');

            //Evaluate the model on a test dataset and calculate metrics of the model on the test data.
            var testMetrics = _mlContext.MulticlassClassification.Evaluate(_trainedModel.Transform(testDataView));

            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {testMetrics.AccuracyMicro:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {testMetrics.AccuracyMacro:0.###}");
            Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");
        }
    }
}
