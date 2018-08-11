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
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepository repository;

        public DepartmentsController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return repository.GetAll<Department>().ToList();
        }

        // GET api/departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            return repository.GetById<Department>(id);
        }

        // POST api/departments
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            repository.Create(department);
            repository.Save();
        }

        // PUT api/departments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department department)
        {
            repository.Update(department);
            repository.Save();
        }

        // DELETE api/departments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete<Department>(id);
            repository.Save();
        }
    }
}
