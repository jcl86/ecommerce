using Ecommerce.Model;
using FluentAssertions;
using System.Net;

namespace Ecommerce.Core.FunctionalTests
{
    public static class TestExtensions
    {
        public static async Task<TModel> ReadJsonResponse<TModel>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return json.Deserialize<TModel>();
        }

        public static async Task ShouldBe(this HttpResponseMessage response, int statusCode)
        {
            response.StatusCode.Should().Be((HttpStatusCode)statusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
