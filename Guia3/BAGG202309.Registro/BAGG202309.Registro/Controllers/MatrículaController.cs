using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrículaController : ControllerBase
    {

        static List<Matricula> data = new List<Matricula>();
        public class Matricula
        {
            public int Id { get; set; }
            public string Alumno { get; set; }
            public string Matriculado { get; set; }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Matricula nuevaMatricula)
        {
            if (nuevaMatricula == null)
            {
                return NotFound();
            }
            data.Add(nuevaMatricula);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {

            if (id < 0)
            {
                return NotFound();
            }

            return Ok(data.FirstOrDefault(i => i.Id == id));
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Matricula matriculaActualizada)
        {
            var matriculaExiste = data.FirstOrDefault(i => i.Id == id);
            if (matriculaExiste != null)
            {
                matriculaExiste.Alumno = matriculaActualizada.Alumno;
                matriculaExiste.Matriculado = matriculaActualizada.Matriculado;
                return Ok(matriculaExiste);
            }
            return BadRequest();
        }

    }
}