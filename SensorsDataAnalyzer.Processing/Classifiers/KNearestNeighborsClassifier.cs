using Accord.MachineLearning;
namespace SensorsDataAnalyzer.Processing.Classifiers
{
    public class KNearestNeighborsClassifier : BaseCoordinatesClassifier
    {
        private static KNearestNeighborsClassifier instance;
        private KNearestNeighbors classifer;

        public static KNearestNeighborsClassifier GetInstance()
        {
            if (instance == null)
                instance = new KNearestNeighborsClassifier();

            return instance;
        }

        private KNearestNeighborsClassifier()
        {
            classifer = new KNearestNeighbors(1);
        }

        public override void Train()
        {
            var (inputs, outputs) = GetTrainData();
            classifer.Learn(inputs, outputs);
        }

        protected override SmartphonePositions ClassifyMove(double[] dataToClassify)
        {
            return (SmartphonePositions)classifer.Decide(dataToClassify);
        }
    }
}