namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmittedAnswers",
                c => new
                    {
                        SubmittedAnswerId = c.Int(nullable: false),
                        SubmitDateTime = c.DateTime(nullable: false),
                        Correct = c.Double(nullable: false),
                        Progress = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Difficulty = c.String(),
                        Subject = c.String(),
                        Domain = c.String(),
                        LearningObjective = c.String(),
                    })
                .PrimaryKey(t => t.SubmittedAnswerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubmittedAnswers");
        }
    }
}
