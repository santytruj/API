using DataAccessLayer;
using Newtonsoft.Json;
using Servicios;

namespace BusinessLayer
{
    public class CovidService : ICovidService
    {
        private readonly HttpClient _httpClient;

        public CovidService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<StateData>> GetStateDataAsync()
        {
            List<StateData> stateDataList = new List<StateData>();
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("https://api.covidtracking.com/v1/states/daily.json");
                if (response.IsSuccessStatusCode)
                {
                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    {
                        var result = await streamReader.ReadToEndAsync();
                        stateDataList = JsonConvert.DeserializeObject<List<StateData>>(result, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                    }
                }
                else
                {
                    throw new Exception("Error obteniendo los datos de los estados");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return stateDataList;
        }

        public async Task<IEnumerable<CovidCase>> GetCovidCaseAsync()
        {
            List<CovidCase> covidCases = new List<CovidCase>();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://api.covidtracking.com/v1/us/daily.json");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        covidCases = JsonConvert.DeserializeObject<List<CovidCase>>(result, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Covid cases: {ex.Message}");
            }
            return covidCases;
        }
    }
}