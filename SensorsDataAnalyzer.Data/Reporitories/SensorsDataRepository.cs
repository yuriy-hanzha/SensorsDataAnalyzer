using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsDataAnalyzer.Data
{
    public class SensorsDataRepository : GenericRepository<SensorsDataRecord>
    {
        public SensorsDataRecord GetByPK(string IMEI, int id)
        {
            return FirstOrDefault(r => r.IMEI.Equals(IMEI) && r.Id == id);
        }

        public IQueryable<SensorsDataRecord> GetByIMEI(string IMEI)
        {
            return FindBy(r => r.IMEI.Equals(IMEI));
        }

        public IQueryable<SensorsDataRecord> GetByDate(string IMEI, DateTime date)
        {
            return GetByIMEI(IMEI).Where(r => r.SentDate.Date == date.Date);
        }

        public IQueryable<SensorsDataRecord> GetInTimeRange(string IMEI, DateTime from, DateTime to)
        {
            return GetByIMEI(IMEI).Where(r => r.SentDate > from && r.SentDate < to);
        }

        public IQueryable<AccelerometerDataRecord> GetAccelerometerData(SensorsDataRecord entity)
        {
            return GetAccelerometerData(entity.IMEI, entity.Id);
        }

        public IQueryable<AccelerometerDataRecord> GetAccelerometerData(string IMEI, int id)
        {
            return _context.AccelerometerDataRecords.Where(r => r.IMEI.Equals(IMEI) && r.Id == id);
        }
    }
}
