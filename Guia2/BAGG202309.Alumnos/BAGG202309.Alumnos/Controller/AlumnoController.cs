using Microsoft.AspNetCore.Mvc;
using BAGG202309.Alumnos.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Alumnos.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(x => x.Id == id);
            return alumno;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alumno client)
        {
            alumnos.Add(client);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(x => x.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Name = alumno.Name;
                existingAlumno.Salon = alumno.Salon;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(x => x.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
