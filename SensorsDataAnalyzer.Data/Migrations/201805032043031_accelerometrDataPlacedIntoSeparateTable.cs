namespace SensorsDataAnalyzer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accelerometrDataPlacedIntoSeparateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccelerometerDataRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Z = c.Double(nullable: false),
                        SensorsDataRecordId = c.Int(nullable: false),
                        IMEI = c.String(maxLength: 128),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SensorsDataRecords", t => new { t.SensorsDataRecordId, t.IMEI })
                .Index(t => new { t.SensorsDataRecordId, t.IMEI });
            
            DropColumn("dbo.SensorsDataRecords", "AccelerometerXCoord");
            DropColumn("dbo.SensorsDataRecords", "AccelerometerYCoord");
            DropColumn("dbo.SensorsDataRecords", "AccelerometerZCoord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SensorsDataRecords", "AccelerometerZCoord", c => c.Double());
            AddColumn("dbo.SensorsDataRecords", "AccelerometerYCoord", c => c.Double());
            AddColumn("dbo.SensorsDataRecords", "AccelerometerXCoord", c => c.Double());
            DropForeignKey("dbo.AccelerometerDataRecords", new[] { "SensorsDataRecordId", "IMEI" }, "dbo.SensorsDataRecords");
            DropIndex("dbo.AccelerometerDataRecords", new[] { "SensorsDataRecordId", "IMEI" });
            DropTable("dbo.AccelerometerDataRecords");
        }
    }
}
