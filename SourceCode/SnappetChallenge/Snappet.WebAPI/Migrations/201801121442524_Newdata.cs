namespace Snappet.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Works", "SubmittedAnswerId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Works", new[] { "Id" });
            AddPrimaryKey("dbo.Works", "SubmittedAnswerId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Works", new[] { "SubmittedAnswerId" });
            AddPrimaryKey("dbo.Works", "Id");
            AlterColumn("dbo.Works", "SubmittedAnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Works", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
