using System.Threading.Tasks;
using Xunit;

namespace Neoflix.Challenges
{
    public class _01_ConnectToNeo4j : Neo4jChallengeTests
    {
        public override Task InitializeAsync() => Task.CompletedTask;

        [Fact]
        public async Task InitDriverAsync_should_create_driver_and_connect_to_server()
        {
            var (uri, username, password) = Config.UnpackNeo4jConfig();

            Assert.NotNull(uri);
            Assert.NotNull(username);
            Assert.NotNull(password);

            await Neo4j.InitDriverAsync(uri, username, password);
        }

        [Fact]
        public void Driver_should_have_been_instantiated()
        {
            var driver = Neo4j.Driver;

            Assert.NotNull(driver);
        }

        [Fact]
        public async Task Driver_should_be_able_to_verify_connectivity()
        {
            var driver = Neo4j.Driver;

            Assert.NotNull(driver);

            await driver.VerifyConnectivityAsync();
        }
    }
}
