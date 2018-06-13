using System;
using System.Collections.Generic;

namespace SensorsDataAnalyzer.Data
{
    public interface ISensorsDataContainer<T> where T: ICoorinateContainer
    {
        ICollection<T> AccelerometerDataRecords { get; set; }
    }

    public interface ICoorinateContainer
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}
