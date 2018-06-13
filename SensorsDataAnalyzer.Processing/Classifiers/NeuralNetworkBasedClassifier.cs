using System;
using System.Linq;
using Accord.Neuro;
using Accord.Neuro.Learning;
using System.Text;

namespace SensorsDataAnalyzer.Processing.Classifiers
{
    public class NeuralNetworkBasedClassifier : BaseCoordinatesClassifier
    {
        private static int INPUTS_COUNT = 1000;
        private static int OUTPUTS_COUNT = 6;
        private static double ALPHA = 1;

        private static NeuralNetworkBasedClassifier instance;
        private ActivationNetwork classifer;

        public static NeuralNetworkBasedClassifier GetInstance()
        {
            if (instance == null)
                instance = new NeuralNetworkBasedClassifier();

            return instance;
        }

        public override void Train()
        {
            var (inputs, outputs) = GetTrainData();

            classifer = new ActivationNetwork(new SigmoidFunction(ALPHA), INPUTS_COUNT, 425, 181, 77, 33, 14, OUTPUTS_COUNT);
            BackPropagationLearning teacher = new BackPropagationLearning(classifer);

            classifer.Randomize();

            StringBuilder sb = new StringBuilder();
            for (int epoch = 0; epoch < 500; epoch++)
            {
                var err = teacher.RunEpoch(inputs.Select(r => r.Select(UseSigmoigFunc).ToArray()).ToArray(),
                                           outputs.Select(ConvertToBooleanVector).ToArray());
                sb.Append($"Epoch = {epoch}, Error = {err};");
            }
        }

        protected override SmartphonePositions ClassifyMove(double[] dataToClassify)
        {
            double[] outNeuronValues = classifer.Compute(dataToClassify.Select(UseSigmoigFunc).ToArray());

            return (SmartphonePositions)GetMaxIndex(outNeuronValues);
        }

        private double[] ConvertToBooleanVector(int output)
        {
            double[] result = new double[OUTPUTS_COUNT];
            result[output] = 1;

            return result;
        }

        private double UseSigmoigFunc(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        private int GetMaxIndex(double[] array)
        {
            return Array.IndexOf(array, array.Max());
        }
    }
}
