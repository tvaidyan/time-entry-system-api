using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeEntryApi.Core;

namespace TimeEntryApi.Controllers
{
    [Route("api/time-entries")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly IRepository repository;

        public TimeEntriesController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/time-entries
        [HttpGet]
        public ActionResult<IEnumerable<TimeEntry>> Get()
        {
            return repository.GetAll<TimeEntry>().ToList();
        }

        // GET api/time-entries/5
        [HttpGet("{id}")]
        public ActionResult<TimeEntry> Get(int id)
        {
            return repository.GetById<TimeEntry>(id);
        }

        // POST api/time-entries
        [HttpPost]
        public void Post([FromBody] TimeEntry project)
        {
            repository.Create(project);
            repository.Save();
        }

        // PUT api/time-entries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeEntry project)
        {
            repository.Update(project);
            repository.Save();
        }

        // DELETE api/time-entries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete<TimeEntry>(id);
            repository.Save();
        }
    }
}
