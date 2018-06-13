using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using SensorsDataAnalyzer.Data;
using SensorsDataAnalyzer.Processing.Classifiers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsDataAnalyzer.Processing
{
    public class TestProcessor
    {
        public static string RunTest()
        {
            string res;

            //var fn = @"train.csv";
            //var f = File.ReadLines(fn);

            //var data = from z in f.Skip(1)
            //           let zz = z.Split(',').Select(int.Parse)
            //           select new
            //           {
            //               Label = zz.First(),
            //               Image = zz.Skip(1).ToArray()
            //           };


            //var classefier = new MuliclassSupportVectorLearning<Linear>();
            //classefier.Learn(,)

            //var testData = new TestDataFileReader().GetTestData()
            //    .OrderBy(a => Guid.NewGuid()).ToList(); // shuffle

            //SensorsDataModel model = new SensorsDataModel();
            //StringBuilder res = new StringBuilder();

            //foreach (var test in testData)
            //{
            //    SmartphonePositions position = model.AnalyzeAccelerometerData(test.AccelerometerDataRecords
            //        .Select(d => new AccelerometerDataRecord { X = d.X, Y = d.Y, Z = d.Z }).ToList());

            //    res.Append($"{test.SmartphonePosition} -> {position} </br>");
            //}

            var testDataReader = new TestDataFileReader();
            var testDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "learning_data", "test", "sample.out");

            var coordinates = testDataReader.ParseCoordinatesFromString(File.ReadAllText(testDataPath));

            var move = KNearestNeighborsClassifier.GetInstance().DefineMove(coordinates);

            res = move.ToString();

            return res;
        }
    }
}
