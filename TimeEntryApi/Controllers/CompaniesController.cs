using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeEntryApi.Core;

namespace TimeEntryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IRepository repository;

        public ClientsController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/clients
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return repository.GetAll<Client>().ToList();
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            return repository.GetById<Client>(id);
        }

        // POST api/clients
        [HttpPost]
        public void Post([FromBody] Client client)
        {
            repository.Create(client);
            repository.Save();
        }

        // PUT api/clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client client)
        {
            repository.Update(client);
            repository.Save();
        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete<Client>(id);
            repository.Save();
        }
    }
}
