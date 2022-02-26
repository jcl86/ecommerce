using Xunit;

namespace Ecommerce.FunctionalTests
{
    [CollectionDefinition(nameof(ServerFixtureCollection))]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
    }
}
