using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorsDataAnalyzer.Data
{
    public class SensorsDataRecord : BaseEntity
    {
        [Key, Column(Order = 1)]
        public string IMEI { get; set; }

        public double? LightSensor { get; set; } // in lux

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? AccelerometerXCoord { get; set; }

        public double? AccelerometerYCoord { get; set; }

        public double? AccelerometerZCoord { get; set; }

        public double? Proximity { get; set; } // in cm

        [Required]
        public DateTime SentDate { get; set; }
    }
}
