﻿using Ecommerce.Core.FunctionalTests;
using Ecommerce.Sales.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Ecommerce.Sales.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class ProductShould
    {
        private readonly ServerFixture Given;

        public ProductShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_found_after_created()
        {
            var product = await Given.ProductInDatabase();

            var response = await Given.Server
               .CreateRequest(Endpoints.Products.Get(product.Id))
               .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var searched = await response.ReadJsonResponse<Product>();
            searched.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async Task Be_created()
        {
            var dto = ProductMother.Create();

            var response = await Given
            .Server
                .CreateRequest(Endpoints.Products.Create)
                .WithJsonBody(dto)
                .PostAsync();

            await response.ShouldBe(StatusCodes.Status201Created);

            var searched = await response.ReadJsonResponse<Product>();

            searched.Id.Should().NotBeEmpty();
            searched.Name.Should().Be(dto.Name);
            searched.Description.Should().Be(dto.Description);
            searched.Price.Should().Be(dto.Price);
        }

        [Fact]
        public async Task Be_updated()
        {
            var product = await Given.ProductInDatabase();

            var dto = ProductMother.Update();

            var response = await Given
            .Server
                .CreateRequest(Endpoints.Products.Update(product.Id))
                .WithJsonBody(dto)
                .PatchAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            response = await Given.Server
               .CreateRequest(Endpoints.Products.Get(product.Id))
               .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var searched = await response.ReadJsonResponse<Product>();

            searched.Should().NotBeEquivalentTo(product);

            searched.Id.Should().NotBeEmpty();
            searched.Name.Should().Be(dto.Name);
            searched.Description.Should().Be(dto.Description);
            searched.Price.Should().Be(dto.Price);
        }

        [Fact]
        public async Task Fail_to_update_when_does_not_exist()
        {
            var nonExistingEntityId = Guid.NewGuid().ToString();
            var dto = ProductMother.Update();

            var response = await Given.Server
               .CreateRequest(Endpoints.Products.Update(nonExistingEntityId))
               .WithJsonBody(dto)
               .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);

        }

        [Fact]
        public async Task Be_deleted()
        {
            var product = await Given.ProductInDatabase();

            var response = await Given.Server
               .CreateRequest(Endpoints.Products.Delete(product.Id))
               .DeleteAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            response = await Given.Server
               .CreateRequest(Endpoints.Products.Get(product.Id))
               .GetAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Fail_to_delete_when_does_not_exist()
        {
            var nonExistingEntityId = Guid.NewGuid().ToString();

            var response = await Given.Server
               .CreateRequest(Endpoints.Products.Delete(nonExistingEntityId))
               .DeleteAsync();

            await response.ShouldBe(StatusCodes.Status404NotFound);

        }
    }
}
