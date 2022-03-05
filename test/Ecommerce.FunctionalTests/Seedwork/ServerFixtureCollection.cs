using Xunit;

namespace Ecommerce.Core.FunctionalTests
{
    [CollectionDefinition(nameof(ServerFixtureCollection))]
    public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
    {
    }
}
