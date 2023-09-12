using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BAGG202309.Registro.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatrículaController : ControllerBase
    {
        static List<Matricula> data = new List<Matricula>();

        [HttpPost]
        public IActionResult Post([FromBody] Matricula matricula)
        {
            data.Add(matricula);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Matricula matricula)
        {
            var existingMatricula = data.FirstOrDefault(x => x.Id == id);
            if (existingMatricula != null)
            {
                existingMatricula.Alumno = matricula.Alumno;
                existingMatricula.Matriculado = matricula.Matriculado;

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public Matricula Get(int id)
        {
            var matricula = data.FirstOrDefault(x => x.Id == id);
            return matricula;
        }


    }

}

