using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorsDataAnalyzer.Models
{
    public class SensorsDataViewModel
    {
        public int? Id { get; set; }
        public string IMEI { get; set; }

        public double? LightSensor { get; set; }
        public double? Proximity { get; set; }

        public string Location { get; set; }
        public string Position { get; set; }

        public DateTime SentDate { get; set; }
    }
}