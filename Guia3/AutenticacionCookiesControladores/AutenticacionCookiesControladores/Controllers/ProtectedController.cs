using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutenticacionCookiesControladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post(string name, string lastName)
        {
            data.Add(new {name,lastName});
            return Ok();
        }
    }
}
