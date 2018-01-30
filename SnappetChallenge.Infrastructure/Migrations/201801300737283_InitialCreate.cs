namespace SnappetChallenge.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessment",
                c => new
                    {
                        SubmittedAnswerId = c.Long(nullable: false),
                        SubmitDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Correct = c.Boolean(nullable: false),
                        Progress = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        ExerciseId = c.Long(nullable: false),
                        Difficulty = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Domain = c.String(maxLength: 50),
                        LearningObjective = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.SubmittedAnswerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assessment");
        }
    }
}
