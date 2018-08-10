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
    public class CompaniesController : ControllerBase
    {
        private readonly IRepository repository;

        public CompaniesController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/companies
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return repository.GetAll<Company>().ToList();
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            return repository.GetById<Company>(id);
        }

        // POST api/companies
        [HttpPost]
        public void Post([FromBody] Company company)
        {
            repository.Create(company);
            repository.Save();
        }

        // PUT api/companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company company)
        {
            repository.Update(company);
            repository.Save();
        }

        // DELETE api/companies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete<Company>(id);
            repository.Save();
        }
    }
}
