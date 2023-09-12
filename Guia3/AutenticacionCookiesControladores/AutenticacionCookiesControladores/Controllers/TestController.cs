using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutenticacionCookiesControladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return data;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(String name, String lastName)
        {
            data.Add(new { name, lastName });

            return Ok();
        }

       [Authorize]
       [HttpDelete]
        public IActionResult Delete()
        {
            data = new List<object>();
            return Ok();
        }
    }
}
