using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetTest.Data.Attributes
{
   public class MongoAttributes
    {
        public string Database { get; set; }
        public string Connection { get; set; }
        public string SubmittedAnswersCollection { get; set; }
    }
}
