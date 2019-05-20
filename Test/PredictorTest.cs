using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportPredictor;

namespace Test
{
    [TestClass]
    public class PredictorTest : Test
    {
        private Classifier _classifier;

        public PredictorTest()
        {
            _classifier = new Classifier();
        }

        [TestMethod]
        public void TestDailyPrediction()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var prediction = _classifier.PredictDailyGames("2019-03-15", "2019-03-15");
            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < TimeLimit);
            Assert.IsTrue(prediction.Length >= 6);
        }

        [TestMethod]
        public void TestSeasonPrediction()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var prediction = _classifier.PredictSeason("2018-09-15", "2019-05-15");
            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < TimeLimit);
        }

        [TestMethod]
        public void TestEvaluationTimeAndPrecision()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var prediction = _classifier.Evaluate();
            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < TimeLimit);
            Assert.IsTrue(prediction.MacroAccuracy > 0.3);
        }
    }
}
