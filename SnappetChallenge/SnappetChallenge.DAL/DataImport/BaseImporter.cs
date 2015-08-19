namespace SnappetChallenge.DAL.DataImport
{
    public abstract class BaseImporter
    {
        public abstract void Import(SnappetChallengeContext context);
    }
}
