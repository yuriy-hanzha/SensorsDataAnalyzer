using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsDataAnalyzer.Data
{
    public class AccelerometerDataRecord: BaseEntity, ICoorinateContainer
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
