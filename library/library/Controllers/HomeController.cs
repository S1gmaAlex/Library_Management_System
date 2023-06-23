using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using library.Models;


namespace library.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        [HttpPost]
        public String WeatherDetail(string City)
        {   
            //Assign API KEY which received from OPENWEATHERMAP.ORG
            string appId = "411109e34011953db2aebbda7f9d60e3";

            //API path with CITY parameter and other parameters.
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                try
                {
                string json = client.DownloadString(url);
                //     JSON RECIVED 

                //{ "coord":{ "lon":105.8412,"lat":21.0245},
                //"weather":[{ "id":803,"main":"Clouds","description":"broken clouds","icon":"04d"}],
                //"base":"stations",
                //"main":{ "temp":305.15,"feels_like":305.43,"temp_min":305.15,"temp_max":305.15,"pressure":1000,"humidity":40,"sea_level":1000,"grnd_level":998},
                //"visibility":10000,
                //"wind":{ "speed":1.73,"deg":163,"gust":3.49},
                //"clouds":{ "all":70},
                //"dt":1687334812,
               // "sys":{ "type":1,"id":9308,"country":"VN","sunrise":1687299356,"sunset":1687347633},
                //"timezone":25200,"id":1581130,"name":"Hanoi","cod":200}
                //Converting to OBJECT from JSON string.
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json); //hadler error

                //Special VIEWMODEL design to send only required fields not all fields which received from 
                //www.openweathermap.org api
                ResultViewModel rslt = new ResultViewModel();

                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                rslt.WeatherIcon = weatherInfo.weather[0].icon;

                //Converting OBJECT to JSON String 
                var jsonstring = new JavaScriptSerializer().Serialize(rslt);

                //Return JSON string.
                return jsonstring;
                }
                catch(Exception)
                {
                var jsonstring = "301";
                return jsonstring;
                }
            }
        }

    }

}