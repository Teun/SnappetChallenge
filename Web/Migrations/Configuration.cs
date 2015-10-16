using System.Data.Entity.Migrations;

namespace Web.Migrations
{

	internal sealed class Configuration : DbMigrationsConfiguration<Web.Data.SnappetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Web.Data.SnappetContext";
        }

        protected override void Seed(Web.Data.SnappetContext context)
        {
        }
    }
}
