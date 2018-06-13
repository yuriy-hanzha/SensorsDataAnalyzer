using System.ComponentModel.DataAnnotations.Schema;

namespace SensorsDataAnalyzer.Data
{
    public class GyroscopeDataRecord : BaseEntity, ICoorinateContainer
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public int SensorsDataRecordId { get; set; }
        public string IMEI { get; set; }

        [ForeignKey("SensorsDataRecordId, IMEI")]
        public virtual SensorsDataRecord SensorsDataRecord { get; set; }
    }
}
