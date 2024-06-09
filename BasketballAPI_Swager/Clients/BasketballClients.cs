using BasketballAPI_Swager.Model;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace BasketballAPI_Swager.Clients
{
    public class BasketballClients
    {
        private static string _address;
        private static string _apikey;
        private static string _apihost;
        private HttpClient _client;

        public BasketballClients()
        {
            _address = Constant.Address;
            _apikey = Constant.ApiKey;
            _apihost = Constant.ApiHost;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apikey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _apihost);
        }
        public async Task<Response> GetTeamById(int id)
        {
            var response = await _client.GetAsync($"/teams?id={id}");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var team = JsonConvert.DeserializeObject<BasketballTeam>(body);

            return team.response[0];
        }
        public async Task<Response> GetTeamByName(string name)
        {
            var response = await _client.GetAsync($"/teams?name={name}");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var team = JsonConvert.DeserializeObject<BasketballTeam>(body);
            return team.response[0];
        }
        public async Task<Response1> GetLeagueByName(string name)
        {
            var response = await _client.GetAsync($"/leagues?name={name}");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var league = JsonConvert.DeserializeObject<BasketballLeague>(body);

            return league.Response[0];
        }
        public class ApiResponse
        {
            [JsonProperty("response")]
            public List<BasketballTeam> Teams { get; set; }
            public List<BasketballLeague> League { get; set; }
        }
    }
}
