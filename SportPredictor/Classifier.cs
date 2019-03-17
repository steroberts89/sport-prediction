using System;
using Microsoft.ML.Data;
using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using System.Collections.Generic;
using SportPredictor.Models;

namespace SportPredictor
{
    public class Classifier
    {
        private static MLContext _mlContext;
        private static DataHandler _dataHandler;
        private static ITransformer _trainedModel;

        public Classifier()
        {
            _dataHandler = new DataHandler(PredictionTypes.Multiclass);
            Train();
        }

        public static void Train()
        {
            // STEP 2: Create a ML.NET environment  
            _mlContext = new MLContext();

            // Reading the data from the api
            IDataView trainingDataView = _mlContext.Data.ReadFromEnumerable(_dataHandler.GetGames("2018-01-01", "2018-12-31"));

            // STEP 3: Transform your data and add a learner
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training.
            // Add a learning algorithm to the pipeline. e.g.(What outcome of game is this?)
            // Convert the Label back into original text (after converting to number in step 3)
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(_mlContext.Transforms.Concatenate("Features",
                "HomeWins", "HomeLosses", "HomeOT", "AwayWins", "AwayLosses", "AwayOT"))
                .Append(_mlContext.MulticlassClassification.Trainers.StochasticDualCoordinateAscent(labelColumn: "Label", featureColumn: "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // STEP 4: Train your model based on the data set
            Console.WriteLine("Training the model...");
            _trainedModel = pipeline.Fit(trainingDataView);
        }

        public string Check()
        {
            var prediction = _trainedModel.CreatePredictionEngine<GameData, GamePrediction>(_mlContext).Predict(
                new GameData()
                {
                    Home = "20",
                    Away = "25",
                    HomeWins = 1,
                    HomeLosses = 1,
                    HomeOT = 1,
                    AwayWins = 1,
                    AwayLosses = 1,
                    AwayOT = 1
                });

            return ($"Predicted outcome: {prediction.PredictedLabels}");
        }

        public string[] PredictDailyGames(string startDate, string endDate)
        {
            List<string> predictions = new List<string>();
            var games = _dataHandler.GetGames(startDate, endDate);
            foreach (var game in games)
            {
                predictions.Add(_trainedModel.CreatePredictionEngine<GameData, GamePrediction>(_mlContext).Predict(game).PredictedLabels);
            }
            return predictions.ToArray();
        }

        public Metrics Evaluate()
        {
            //Load the test dataset into the IDataView
            var testDataView = _mlContext.Data.ReadFromEnumerable(_dataHandler.GetGames("2017-01-01", "2017-12-31"));

            //Evaluate the model on a test dataset and calculate metrics of the model on the test data.
            var testMetrics = _mlContext.MulticlassClassification.Evaluate(_trainedModel.Transform(testDataView));

            return new Metrics
            {
                MicroAccuracy = testMetrics.AccuracyMicro,
                MacroAccuracy = testMetrics.AccuracyMacro,
                LogLoss = testMetrics.LogLoss,
                LogLossReduction = testMetrics.LogLossReduction
            };
        }
    }
}
