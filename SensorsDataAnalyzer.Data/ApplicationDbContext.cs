using System.Data.Entity;

namespace SensorsDataAnalyzer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }   

        public DbSet<SensorsDataRecord> SensorDataRecords { get; set; }
        public DbSet<AccelerometerDataRecord> AccelerometerDataRecords { get; set; }
        public DbSet<GyroscopeDataRecord> GyroscopeDataRecords { get; set; }
        public DbSet<MagnetometerDataRecord> MagnetometerDataRecords { get; set; }
    }
}
