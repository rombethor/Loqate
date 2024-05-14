using Loqate.Find;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Loqate.Tests
{
    [TestClass]
    public class FindAndRetrieveTests
    {
        [TestInitialize]
        public void Initialise()
        {
            //Provide Key for tests in settings file
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection()
                .AddJsonFile("settings.json")
                .Build();

            Loqate.Configure(config["apikey"] ?? string.Empty);
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            FindItem[]? find = null;
            try
            {
                find = await Loqate.Find("PO6 3EN").GetResponse();
            }
            catch (LoqateException ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.ErrorTable));
            }

            Assert.IsNotNull(find);

            var narrow = Loqate.Find("PO6 3EN").Container(find.First().Id).GetResponse().Result;

            Assert.IsNotNull(narrow);
                Console.WriteLine(JsonSerializer.Serialize(narrow));

            var retrieve = Loqate.Retrieve(narrow.First().Id);

            Assert.IsNotNull(retrieve);
                Console.WriteLine(JsonSerializer.Serialize(retrieve));
        }
    }
}