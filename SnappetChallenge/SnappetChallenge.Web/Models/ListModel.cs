using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Web.Models
{
    public class ListModel
    {
        public List<Server> ServerNames { get; set; }

        public int SelectedServerId { get; set; }
    }


    public class Server
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}