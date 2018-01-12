namespace Snappet.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmittedAnswerId = c.Int(nullable: false),
                        SubmitDateTime = c.DateTime(nullable: false),
                        Correct = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Difficulty = c.String(),
                        Subject = c.String(),
                        Domain = c.String(),
                        LearningObjective = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Works");
        }
    }
}
