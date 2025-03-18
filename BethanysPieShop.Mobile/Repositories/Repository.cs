using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Mobile.Repositories
{
    public class Repository
    {
        protected readonly IHttpClientFactory HttpClientFactory;

        public Repository(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        protected HttpClient CreateHttpClient()
        {
            return HttpClientFactory.CreateClient(MauiProgram.BethanysPieShopApiClient);
        }
    }
}
