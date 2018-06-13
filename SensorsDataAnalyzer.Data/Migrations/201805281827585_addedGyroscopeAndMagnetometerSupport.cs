namespace SensorsDataAnalyzer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGyroscopeAndMagnetometerSupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GyroscopeDataRecords",
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
            
            CreateTable(
                "dbo.MagnetometerDataRecords",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MagnetometerDataRecords", new[] { "SensorsDataRecordId", "IMEI" }, "dbo.SensorsDataRecords");
            DropForeignKey("dbo.GyroscopeDataRecords", new[] { "SensorsDataRecordId", "IMEI" }, "dbo.SensorsDataRecords");
            DropIndex("dbo.MagnetometerDataRecords", new[] { "SensorsDataRecordId", "IMEI" });
            DropIndex("dbo.GyroscopeDataRecords", new[] { "SensorsDataRecordId", "IMEI" });
            DropTable("dbo.MagnetometerDataRecords");
            DropTable("dbo.GyroscopeDataRecords");
        }
    }
}
