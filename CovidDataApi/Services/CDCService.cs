using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using CovidDataApi.Models;

namespace CovidDataApi.Services{
    public class CdcService
    {
        private readonly HttpClient _httpClient;

        public CdcService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CovidData>> GetCovidDeathDataAsync()
        {
            var response = await _httpClient.GetAsync("https://data.cdc.gov/resource/9bhg-hcku.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CovidData>>(content);
            return data;
        }
    }
}