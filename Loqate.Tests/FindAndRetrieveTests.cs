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

            Loqate.ApiKey = config["apikey"]
                ?? throw new NotImplementedException("An API Key must be provided in the settings.json file as 'apikey'");
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var loqate = new Loqate();

            FindItem[]? find = null;
            try
            {
                find = await loqate.Find("PO6 3EN").GetResponse();
            }
            catch (LoqateException ex)
            {
                Console.WriteLine(JsonSerializer.Serialize(ex.ErrorTable));
            }

            Assert.IsNotNull(find);

            var narrow = loqate.Find("PO6 3EN").Container(find.First().Id).GetResponse().Result;

            Assert.IsNotNull(narrow);
                Console.WriteLine(JsonSerializer.Serialize(narrow));

            var retrieve = loqate.Retrieve(narrow.First().Id);

            Assert.IsNotNull(retrieve);
                Console.WriteLine(JsonSerializer.Serialize(retrieve));
        }
    }
}