namespace SensorsDataAnalyzer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorsDataRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IMEI = c.String(nullable: false, maxLength: 128),
                        LightSensor = c.Double(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        AccelerometerXCoord = c.Double(),
                        AccelerometerYCoord = c.Double(),
                        AccelerometerZCoord = c.Double(),
                        Proximity = c.Double(),
                        SentDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.IMEI });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SensorsDataRecords");
        }
    }
}
