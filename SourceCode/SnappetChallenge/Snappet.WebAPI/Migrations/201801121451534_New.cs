namespace Snappet.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "SubmittedAnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Works", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Works", new[] { "SubmittedAnswerId" });
            AddPrimaryKey("dbo.Works", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Works", new[] { "Id" });
            AddPrimaryKey("dbo.Works", "SubmittedAnswerId");
            AlterColumn("dbo.Works", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Works", "SubmittedAnswerId", c => c.Int(nullable: false, identity: true));
        }
    }
}
