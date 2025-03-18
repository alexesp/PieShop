using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.Mobile.Models;
using BethanysPieShop.Mobile.Repositories.Interfaces;

namespace BethanysPieShop.Mobile.Repositories
{
    public class PieRepository : IPieRepository
    {

        private readonly IHttpClientFactory _httpClientFactory;
        // private readonly HttpClient _client;


       // public PieRepository(HttpClient client)
        public PieRepository(IHttpClientFactory httpClientFactory)
            :base(httpClientFactory)
        {
            //_httpClientFactory = httpClientFactory;
          // _client = client;
        }
        public Task<List<PieModel>> GetAllPies()
        {
            HttpClient client = CreateHttpClient();
            //HttpClient client = _httpClientFactory.CreateClient("BethanysPieShopApiClient");
            //client.BaseAddress = new Uri("http://localhost:5000");
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public Task<PieDetailModel?> GetPieById(int id)
        {
            HttpClient client = CreateHttpClient();
            //HttpClient client = _httpClientFactory.CreateClient("BethanysPieShopApiClient");
            //client.BaseAddress = new Uri("http://localhost:5000");
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public Task<List<PieModel>> GetPiesOfTheWeek()
        {
            HttpClient client = CreateHttpClient();
            //HttpClient client = _httpClientFactory.CreateClient("BethanysPieShopApiClient");
            //client.BaseAddress = new Uri("http://localhost:5000");
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
