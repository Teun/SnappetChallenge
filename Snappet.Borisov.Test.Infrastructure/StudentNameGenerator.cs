using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Snappet.Borisov.Test.Domain;

namespace Snappet.Borisov.Test.Infrastructure
{
    public class StudentNameGenerator : IGenerateStudentNames
    {
        private readonly JsonSerializer _serializer;
        private List<string> _names;

        public StudentNameGenerator()
        {
            _serializer = new JsonSerializer();
        }

        public string Generate()
        {
            EnsureNames();
            var name = _names[0];
            _names.RemoveAt(0);
            return name;
        }

        private void EnsureNames()
        {
            if ((_names != null) && (_names.Count > 0)) return;
            var stream = WebRequest.Create("https://randomuser.me/api/?results=50").GetResponse().GetResponseStream();
            var streamReader = new StreamReader(stream);
            var jsonTextReader = new JsonTextReader(streamReader);
            var model = _serializer.Deserialize<dynamic>(jsonTextReader);
            _names = new List<string>();
            for (var i = 0; i < model["results"].Count; i++)
            {
                var firstName = model["results"][i]["name"]["first"];
                var lastName = model["results"][i]["name"]["last"];
                var name = $"{firstName} {lastName}";
                _names.Add(name);
            }
        }
    }
}