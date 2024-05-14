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
            Console.WriteLine(">>> Find");
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

            Console.WriteLine(">>> Retrieve");
            var retrieve = Loqate.Retrieve(narrow.First().Id)
                .GetResponse();

            Assert.IsNotNull(retrieve);
                Console.WriteLine(JsonSerializer.Serialize(retrieve));

            Console.WriteLine(">>> Geolocation");
            var geolocate = Loqate.Geolocation(-0.12, 51.5, 1, 100)
                .GetResponse().Result;

            Assert.IsNotNull(geolocate);
            Assert.IsTrue(geolocate.Items.Length > 0);

            Console.WriteLine(JsonSerializer.Serialize(geolocate));

        }
    }
}