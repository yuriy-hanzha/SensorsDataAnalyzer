using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorsDataAnalyzer.Processing.Minimizers
{
    public class LowPassFilterMinimizer : INoizeMinimizer
    {
        private double index;

        /// <summary>
        /// Noise minimization algorithm Low-Pass Filter 
        /// </summary>
        /// <param name="index">index of minimization (from 0.1 to 1.0)</param>
        public LowPassFilterMinimizer(double index)
        {
            if (index < 0.1 || index > 1.0)
                throw new ArgumentException("Low-Pass Filter index has invalid format", "minimizationIndex");

            this.index = index;
        }

        public List<double> Minimize(IEnumerable<double> data)
        {
            List<double> rawData = data.ToList();
            var resultData = new List<double> { rawData.First() };

            for (int i = 1; i < rawData.Count(); i++)
                resultData.Add(resultData[i - 1] + (index * (rawData[i] - resultData[i - 1])));

            return resultData;
        }
    }
}