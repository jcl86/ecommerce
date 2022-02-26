﻿using Ecommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System.Text;

namespace Ecommerce.FunctionalTests
{
    public static class RequestBuilderExtensions
    {
        public static Task<HttpResponseMessage> PutAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Put);
        }

        public static Task<HttpResponseMessage> PatchAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Patch);
        }

        public static Task<HttpResponseMessage> DeleteAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Delete);
        }

        public static RequestBuilder WithJsonBody<TModel>(this RequestBuilder builder, TModel content, string contentType = "application/json")
        {
            var json = content.Serialize();

            return builder.And(message =>
            {
                message.Content = new StringContent(json, Encoding.UTF8, contentType);
            });
        }
    }
}
