using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace FamousQuotesConsumer
{
    public static class FamousQuotesAppServiceExtensions
    {
        public static FamousQuotes CreateFamousQuotes(this IAppServiceClient client)
        {
            return new FamousQuotes(client.CreateHandler());
        }

        public static FamousQuotes CreateFamousQuotes(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new FamousQuotes(client.CreateHandler(handlers));
        }

        public static FamousQuotes CreateFamousQuotes(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new FamousQuotes(uri, client.CreateHandler(handlers));
        }

        public static FamousQuotes CreateFamousQuotes(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new FamousQuotes(rootHandler, client.CreateHandler(handlers));
        }
    }
}
