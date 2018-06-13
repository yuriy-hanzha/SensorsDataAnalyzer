using Accord.MachineLearning;
using SensorsDataAnalyzer.Data;
using SensorsDataAnalyzer.Processing.Minimizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SensorsDataAnalyzer.Processing.Classifiers
{
    public abstract class BaseCoordinatesClassifier
    {
        private INoizeMinimizer minimizer;

        protected BaseCoordinatesClassifier()
        {
            minimizer = new LowPassFilterMinimizer(index: 0.1);
        }

        public abstract void Train();
        protected abstract SmartphonePositions ClassifyMove(double[] dataToClassify);

        public SmartphonePositions DefineMove(IEnumerable<ICoorinateContainer> coordinates)
        {
            IEnumerable<double> minimizedData = minimizer.Minimize(coordinates.Select(r => r.X + r.Y + r.Z));

            SmartphonePositions resutPosition;
            try
            {
                resutPosition = ClassifyMove(minimizedData.ToArray());
            }
            catch(IndexOutOfRangeException)
            {
                resutPosition =  SmartphonePositions.Not_Found;
            }

            return resutPosition;
        }

        protected (double[][] inputs, int[] outputs) GetTrainData()
        {
            var testDataReader = new TestDataFileReader();
            IEnumerable<TestDataFileDTO> result = testDataReader
                .GetTestData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "learning_data"));

            IEnumerable<double[]> minimizedData = result.Select(f =>
                minimizer.Minimize(f.AccelerometerDataRecords.Select(r => r.X + r.Y + r.Z)).ToArray());

            return (minimizedData.ToArray(), result.Select(f => (int)f.SmartphonePosition).ToArray());
        }
    }
}