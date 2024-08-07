using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestioneHotelApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Sunny", "Cloudy", "Rainy" };
        }
    }
}
