using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return data;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(string alumno, string nota, string grado)
        {
            data.Add(new { alumno, nota, grado });
            return Ok();
        }
    }
}
