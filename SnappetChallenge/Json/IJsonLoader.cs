using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Json
{
    public interface IJsonLoader
    {
        List<Answer> LoadJson(string path);
    }
}