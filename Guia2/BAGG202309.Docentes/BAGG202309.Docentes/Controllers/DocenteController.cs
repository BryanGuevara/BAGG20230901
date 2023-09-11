using Microsoft.AspNetCore.Mvc;
using BAGG202309.Docentes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        static List<Docente> docentes = new List<Docente>();

        [HttpPost]
        public IActionResult Post([FromBody] Docente docente)
        {
            docentes.Add(docente);
            return Ok();
        }

        [HttpGet("{id}")]
        public Docente Get(int id)
        {
            var alumno = docentes.FirstOrDefault(x => x.Id == id);
            return alumno;
        }

    }
}
