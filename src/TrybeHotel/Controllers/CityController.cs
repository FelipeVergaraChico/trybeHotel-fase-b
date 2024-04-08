using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCities(){
            var res = _repository.GetCities();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City city){
            var res = _repository.AddCity(city);
            return Created("", res);
        }
    }
}