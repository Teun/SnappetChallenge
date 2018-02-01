namespace SnappetChallenge.WebApi.Helpers
{
    using System.IO;

    public interface IFileOpener
    {
        Stream OpenJsonData();
    }
}
