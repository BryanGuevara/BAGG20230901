using Microsoft.AspNetCore.Mvc;
using BAGG202309.Aulas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAGG202309.Aulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasValuesController : ControllerBase
    {
        static List<Aula> aulas = new List<Aula>
    {
        new Aula { Id = 1, Salon = "1° A", Maestro = "Rosy" },
        new Aula { Id = 2, Salon = "2° B", Maestro = "Cristina" },
        new Aula { Id = 3, Salon = "3° C", Maestro = "Marvin" }
    };

        [HttpGet]
        public IEnumerable<Aula> Get()
        {
            return aulas;
        }

    }
}
