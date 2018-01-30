using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SnappetChallenge.Data;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var answersRepository = new SubmittedAnswersRepository();
            var users = answersRepository.Query()
                .ToArray()
                .GroupBy(a => a.UserId)
                .Select(ag => ag.Key)
                .Zip(new []
                {
                    "Virgilio Hamman",
                    "Sparkle Clukey",
                    "Hattie Ewell",
                    "Carina Karnes",
                    "Giovanna Delman",
                    "Alberto Massenburg",
                    "Alona Carrell",
                    "Barbie Davies",
                    "Mara Blanc",
                    "Allan Kervin",
                    "Babara Kocsis",
                    "Allen Benz",
                    "Clayton Roderick",
                    "Kraig Chery",
                    "Tatiana Bankhead",
                    "Linda Marland",
                    "Niki Barrows",
                    "Angela Crase",
                    "Nancie Achenbach",
                    "Cordia Brey"
                }, (i, n) => new
                {
                    UserId = i,
                    Name = n,
                    ImageId = 1
                })
                .ToArray();
            var usersJson = JsonConvert.SerializeObject(users);
            File.WriteAllText("users.json", usersJson);
        }
    }
}
