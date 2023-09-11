using Microsoft.AspNetCore.Mvc;

using MIPrimeraAppWebAPIConControladores.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MIPrimeraAppWebAPIConControladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        static List<Client> clients = new List<Client>();

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return clients;
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var Client = clients.FirstOrDefault(x => x.Id == id);
            return Client;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            clients.Add(client);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Client client)
        {
            var existingClient = clients.FirstOrDefault(x => x.Id == id);
            if(existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.LastName = client.LastName;
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
            var existingClient = clients.FirstOrDefault(x => x.Id == id);
            if (existingClient != null)
            {
                clients.Remove(existingClient);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
