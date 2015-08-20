using SnappetChallenge.DAL.DataImport;

namespace SnappetChallenge.DAL
{
    using System.Data.Entity;

    /// <summary>
    /// We use the SnappetChallengeDbInitializer to seed the sample data on creation of the database
    /// </summary>
    public class SnappetChallengeDbInitializer : CreateDatabaseIfNotExists<SnappetChallengeContext>
    {
        protected override void Seed(SnappetChallengeContext context)
        {
            var jsonImporter = new NewtonSoftJsonImporter();
            jsonImporter.Import(context);

            var datatransformer = new DataTransformer(context);
            datatransformer.PerformTransformation();

            base.Seed(context);
        }
    }
}
