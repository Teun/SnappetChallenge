using MongoDB.Driver;
namespace SnappetTest.Data.Abstract
{
   public interface ISnappetFactory
    {
        IMongoDatabase CreateInstance();
    }
}
