using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendAPI.Controllers
{
    //public class WeatherData 
    //{
    //    public int Id { get; set; }
    //    public string Date { get; set; }
    //    public int Degree { get; set; }
    //    public string Location { get; set; }
    //}

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //public static List<WeatherData> weatherDatas = new() 
        //{ 
        //    new WeatherData() { Id = 1, Date = "21.01.2022", Degree = 10, Location = "Мурманск" },
        //    new WeatherData() { Id = 23, Date = "10.08.2019", Degree = 20, Location = "Пермь" },
        //    new WeatherData() { Id = 24, Date = "05.11.2020", Degree = 15, Location = "Омск" },
        //    new WeatherData() { Id = 25, Date = "07.02.2021", Degree = 10, Location = "Томск" },
        //    new WeatherData() { Id = 30, Date = "30.05.2022", Degree = 3, Location = "Калининград" }
        //};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Введённый вами индекс неверен!";
            }

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int GetByName(string name)
        {
            int j = 0;
            for (int i=0; i<Summaries.Count; i++) 
            {
                if (Summaries[i] == name)
                j++;
            }
            return j;
        }

        [HttpGet("GetAll")]
        public List<string> GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
                return Summaries;
            if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Summaries;
            }
            if (sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Summaries;
            }
            return Summaries;
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    for (int i = 0; i< weatherDatas.Count; i++)
        //    {
        //        if (weatherDatas[i].Id == id)
        //        {
        //            return Ok(weatherDatas[i]);
        //        }
        //    }
        //    return BadRequest("Такая запись не обнаружена!");
        //}

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Введённый вами индекс неверен!");
            }


            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index) 
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Введённый вами индекс неверен!");
            }


            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}