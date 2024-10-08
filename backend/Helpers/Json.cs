using Newtonsoft.Json;

namespace backend.Helpers;

public static class Json
{
    public static List<T> LoadJson<T>(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            List<T>? data = JsonConvert.DeserializeObject<List<T>>(json);
            return data ?? new List<T>();
        }
    }
}