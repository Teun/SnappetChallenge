namespace SnappetChallenge.Services
{
    public interface ICSVReader<T>
    {
        public Task<IEnumerable<T>> ReadCSV(string filePath);
    }
}