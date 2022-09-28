using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using VisitorManagementStudent2022.DTO;

using static VisitorManagementStudent2022.Enum.SweetAlertEnum;

namespace VisitorManagementStudent2022.Services
{
    public class API : Controller, IAPI
    {

        private readonly ISweetAlert _sweetAlert;
        public API(ISweetAlert sweetAlert)
        {
            _sweetAlert = sweetAlert;
        }



        //https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=8827252724a06575e5be376a09a53736


        public async Task<Root> WeatherAPI()
        {
            Root root = null;
            try
            {

                HttpClient client = new HttpClient();
                string responseBody = null;
                string apiKey = "8827252724a06575e5be376a09a537369";
                string URL = "https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=" + apiKey;

                responseBody = await client.GetStringAsync(URL);
                root = JsonConvert.DeserializeObject<Root>(responseBody);

            }

            catch (Exception ex)
            {


                switch (root.cod)
                {
                    case 200:
                        TempData["aPIResponse"] = _sweetAlert.AlertPopup("Working as expected", "Happy Days!", NotificationType.s);
                        break;
                    case 401:
                        TempData["aPIResponse"] = _sweetAlert.AlertPopup("Unauthorized 401", "The API is not working returning a 401.", NotificationType.error);
                        break;

                    default:
                        //   Statement
                        break;
                }





            }




            //catch (HttpRequestException httpRequestException)
            //{
            //    if ((int)httpRequestException.StatusCode == 401)
            //    {
            //       
            //    }
            //    else
            //    {
            //        root = null;

            //    }
            //}






            // root.main.temp

            return root;
        }





    }





    //{"coord":{"lon":172.6333,"lat":-43.5333},"weather":[{"id":500,"main":"Rain","description":"light rain","icon":"10d"}],"base":"stations","main":{"temp":16.07,"feels_like":15.56,"temp_min":15.11,"temp_max":16.62,"pressure":1010,"humidity":70},"visibility":10000,"wind":{"speed":2.57,"deg":10},"rain":{"1h":0.12},"clouds":{"all":99},"dt":1664397617,"sys":{"type":2,"id":2017931,"country":"NZ","sunrise":1664388420,"sunset":1664433175},"timezone":46800,"id":2192362,"name":"Christchurch","cod":200}




}
