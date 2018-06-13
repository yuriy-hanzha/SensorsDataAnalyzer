
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using System;

namespace SensorsDataAnalyzer.Processing.Classifiers
{
    public class SupportVectorMachineClassifier : BaseCoordinatesClassifier
    {
        private static SupportVectorMachineClassifier instance;
        private MulticlassSupportVectorMachine<Linear> classifer;

        public static SupportVectorMachineClassifier GetInstance()
        {
            if (instance == null)
                instance = new SupportVectorMachineClassifier();

            return instance;
        }

        public override void Train()
        {
            var (inputs, outputs) = GetTrainData();

            var teacher = new MulticlassSupportVectorLearning<Linear>()
            {
                Learner = (p) => new SequentialMinimalOptimization<Linear>()
                {
                    //Complexity = 10000.0 // Create a hard SVM
                    UseComplexityHeuristic = true
                }
            };

            classifer = teacher.Learn(inputs, outputs);
        }

        protected override SmartphonePositions ClassifyMove(double[] dataToClassify)
        {
            int answer = classifer.Decide(dataToClassify);
            return (SmartphonePositions)answer;
        }
    }
}
