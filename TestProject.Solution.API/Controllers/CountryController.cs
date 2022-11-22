using Microsoft.AspNetCore.Mvc;
using TestProject.Solution.DTO;
using TestProject.Solution.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public ResultDto Get()
        {
            return _service.GetCountryList();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public ResultDto Get(int id)
        {
            return _service.GetCountryById(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public ResultDto Post(CountryDto country)
        {
            return _service.AddOrUpdateCountry(country);
        }

        

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            return _service.DeleteCountry(id);
        }
    }
}
