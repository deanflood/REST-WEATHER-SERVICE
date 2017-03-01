using CAPreperation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CAPreperation.Controllers
{
    public class WeatherController : ApiController
    {

        static List<Weather> list = new List<Weather>()
        {
            new Weather() { City = "Dublin",Temperature = 20,Condition = Conditions.SUNNY,WindSpeed = 30,WeatherWarning = false },
            new Weather() { City = "London",Temperature = 23,Condition = Conditions.CLOUDY,WindSpeed = 30,WeatherWarning = false },
            new Weather() { City = "Moscow",Temperature = 0,Condition = Conditions.SNOW,WindSpeed = 30,WeatherWarning = true },
            new Weather() { City = "Florida",Temperature = 40,Condition = Conditions.RAIN,WindSpeed = 30,WeatherWarning = true }
        };

        [HttpGet]
        [Route("api/Weather/weatherlist")]
        public List<Weather> weatherlist()
        {
            return list;
        }

        [HttpGet]
        [Route("api/Weather/order")]
        public List<Weather> order()
        {
            return list.OrderBy(w => w.Temperature).ToList<Weather>();
        }

        [HttpGet]
        public List<Weather> city(string city)
        {
            return list.Where(w => w.City == city).ToList();
        }

        [HttpGet]
        public List<Weather> warning()
        {
            return list.Where(w => w.WeatherWarning == true).ToList();
        }

        [HttpPut]
            public void update(Weather weather)
        {
            Weather toUpdate = list.First(w => w.City == weather.City);
            list[list.IndexOf(toUpdate)] = weather;
            
        }

        [HttpPost]
        public void add(Weather weather)
        {
            list.Add(weather);
        }
    }
}
