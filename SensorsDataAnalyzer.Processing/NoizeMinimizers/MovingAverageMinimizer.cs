using System;
using System.Collections.Generic;
using System.Linq;

 namespace SensorsDataAnalyzer.Processing.Minimizers
{
    public class MovingAverageMinimizer : INoizeMinimizer
    {
        private int step;

        /// <summary>
        /// Noise minimization algorithm Moving Average 
        /// </summary>
        /// <param name="step">index of minimization (from 1 to 10)</param>
        public MovingAverageMinimizer(int step)
        {
            if (step < 2 || step > 10)
                throw new ArgumentException("Moving Average step has invalid format", "step");

            this.step = step;
        }

        public List<double> Minimize(IEnumerable<double> data)
        {
            List<double> rawData = data.ToList();
            List<double> resultData = new List<double>(rawData.Take(step));

            for (int i = step; i < rawData.Count(); i++)
                resultData.Add(rawData.Skip(i - step).Take(step).Sum() / step);

            return resultData;
        }
    }
}