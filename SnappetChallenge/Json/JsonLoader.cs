using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Json
{
    public class JsonLoader : IJsonLoader
    {        
        public List<Answer> LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Answer> items = JsonConvert.DeserializeObject<List<Answer>>(json);
                return items;
            }
        }

    }
}