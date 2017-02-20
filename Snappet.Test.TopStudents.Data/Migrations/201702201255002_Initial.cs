namespace Snappet.Test.TopStudents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaySummary",
                c => new
                    {
                        RecordDate = c.DateTime(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 200),
                        StudentIdsCsv = c.String(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        NumberOfStudents = c.Int(nullable: false),
                        NumberOfAnswers = c.Int(nullable: false),
                        MaxProgress = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinProgress = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageProgress = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.RecordDate, t.Subject });
            
            CreateTable(
                "dbo.TopStudentsRecord",
                c => new
                    {
                        RecordDate = c.DateTime(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Type = c.Int(nullable: false),
                        Top1StudentId = c.Int(),
                        Top1Difficulty = c.Decimal(precision: 18, scale: 2),
                        Top2StudentId = c.Int(),
                        Top2Difficulty = c.Decimal(precision: 18, scale: 2),
                        Top3StudentId = c.Int(),
                        Top3Difficulty = c.Decimal(precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.RecordDate, t.Subject, t.Type });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TopStudentsRecord");
            DropTable("dbo.DaySummary");
        }
    }
}
