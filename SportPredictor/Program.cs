using System;

namespace SportPredictor
{
    class Program
    {

        static void Main(string[] args)
        {
            Classifier classifier = new Classifier();
            classifier.Evaluate();
            Console.ReadLine();
        }
    }
}
