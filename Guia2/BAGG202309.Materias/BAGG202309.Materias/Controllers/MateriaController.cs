using Microsoft.AspNetCore.Mvc;
using BAGG202309.Materias.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Materias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        static List<Materia> materias = new List<Materia>();

        [HttpPost]
        public IActionResult Post([FromBody] Materia client)
        {
            materias.Add(client);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existingMateria = materias.FirstOrDefault(x => x.Id == id);
            if (existingMateria != null)
            {
                materias.Remove(existingMateria);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return materias;
        }

    }
}
