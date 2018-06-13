using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorsDataAnalyzer.Data
{
    public class SensorsDataRecord : BaseEntity, ISensorsDataContainer<AccelerometerDataRecord>
    {
        [Key, Column(Order = 1)]
        public string IMEI { get; set; }

        public double? LightSensor { get; set; } // in lux

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? Proximity { get; set; } // in cm

        [Required]
        public DateTime SentDate { get; set; }

        public virtual ICollection<AccelerometerDataRecord> AccelerometerDataRecords { get; set; }
        public virtual ICollection<GyroscopeDataRecord> GyroscopeDataRecords { get; set; }
        public virtual ICollection<MagnetometerDataRecord> MagnetometerDataRecords { get; set; }
    }
}
