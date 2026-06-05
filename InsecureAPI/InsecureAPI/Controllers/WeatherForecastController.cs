using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace InsecureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get(string name)
        {
            var connectionString = "Server=db;Database=Demo;User Id=admin;Password=admin;";
            using var connection = new SqlConnection(connectionString);

            var sql = $"SELECT * FROM WeatherForecasts WHERE Name = '{name}'";
            using var command = new SqlCommand(sql, connection);

            connection.Open();

            var result = command.ExecuteScalar();

            return result?.ToString() ?? "No results";
        }

        [HttpGet("file")]
        public string GetFile(string fileName)
        {
            var path = Path.Combine("C:\\temp", fileName);

            return System.IO.File.ReadAllText(path);
        }

        [HttpGet("redirect")]
        public IActionResult RedirectTo(string url)
        {
            return Redirect(url); 
        }
    }
}
