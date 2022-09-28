using Newtonsoft.Json;

using VisitorManagementStudent2022.DTO;

namespace VisitorManagementStudent2022.Services
{
    public class API : IAPI
    {
        public API()
        {
        }

        public string Message { get; set; } = null;

        //https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=8827252724a06575e5be376a09a53736


        public async Task<Root> WeatherAPI()
        {
            Root root = null;
            try
            {

                HttpClient client = new HttpClient();
                string responseBody = null;
                string apiKey = "8827252724a06575e5be376a09a53736";
                string URL = "https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=" + apiKey;

                responseBody = await client.GetStringAsync(URL);
                root = JsonConvert.DeserializeObject<Root>(responseBody);

            }

            catch (Exception ex)
            {
                Message = ex.Message;

            }

            return root;
        }







        //{"coord":{"lon":172.6333,"lat":-43.5333},"weather":[{"id":500,"main":"Rain","description":"light rain","icon":"10d"}],"base":"stations","main":{"temp":16.07,"feels_like":15.56,"temp_min":15.11,"temp_max":16.62,"pressure":1010,"humidity":70},"visibility":10000,"wind":{"speed":2.57,"deg":10},"rain":{"1h":0.12},"clouds":{"all":99},"dt":1664397617,"sys":{"type":2,"id":2017931,"country":"NZ","sunrise":1664388420,"sunset":1664433175},"timezone":46800,"id":2192362,"name":"Christchurch","cod":200}




    }

}
