using System;
using System.Collections.Generic;

namespace SensorsDataAnalyzer.Models
{
    public class SensorsDataBindingModel 
    {
        public string IMEI { get; set; }
        public double? LightSensor { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Proximity { get; set; }
        public DateTime SentDate { get; set; }

        public IEnumerable<CoordinatesDataBindingModel> AccelerometerDataArray { get; set; }
        public IEnumerable<CoordinatesDataBindingModel> GyroscopeDataArray { get; set; }
        public IEnumerable<CoordinatesDataBindingModel> MagnetometerDataArray { get; set; }
    }
}
