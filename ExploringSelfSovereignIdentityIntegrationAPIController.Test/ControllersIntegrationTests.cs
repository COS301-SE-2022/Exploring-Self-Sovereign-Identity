namespace ExploringSelfSovereignIdentityIntegrationAPIController.Test
{
    [TestClass]
    public class ControllersIntegrationTests
    {
        [TestMethod]

        
        public async Task DefaultRouteTest()

        {

            var webAppFactory = new WebApplicationFactory<>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync(GetUserData);
            var userResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(, userResult); 

        }
    }
}