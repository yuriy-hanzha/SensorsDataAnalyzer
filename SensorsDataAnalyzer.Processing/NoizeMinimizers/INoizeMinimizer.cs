using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsDataAnalyzer.Processing.Minimizers
{
    public interface INoizeMinimizer
    {
        /// <summary>
        /// Noize minimization method
        /// </summary>
        /// <param name="data">array of double data for noise minimization</param>
        /// <returns>same size array with noise minimized data</returns>
        List<double> Minimize(IEnumerable<double> data);
    }
}