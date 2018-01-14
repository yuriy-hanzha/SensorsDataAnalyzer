using System.Data.Entity;

namespace SensorsDataAnalyzer.Data
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }   

        public DbSet<SensorsDataRecord> SensorDataRecords { get; set; }
    }
}
