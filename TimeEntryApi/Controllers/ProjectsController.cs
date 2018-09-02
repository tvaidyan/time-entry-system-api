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
    public class ProjectsController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectsController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return repository.GetAll<Project>().ToList();
        }

        // GET api/projects/5
        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            return repository.GetById<Project>(id);
        }

        // POST api/projects
        [HttpPost]
        public void Post([FromBody] Project project)
        {
            repository.Create(project);
            repository.Save();
        }

        // PUT api/projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project project)
        {
            repository.Update(project);
            repository.Save();
        }

        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete<Project>(id);
            repository.Save();
        }

        // Child projects
        // api/projects/5/child-projects
        [HttpGet("{parentProjectId}/child-projects")]
        public ActionResult<IEnumerable<Project>> GetChildProjects(int parentProjectId)
        {
            // if the parentProjectId is something other than 0, check to see
            // if it really exists

            var parentProjectExists = parentProjectId == 0 ||
                repository.GetById<Project>(parentProjectId) != null;

            if (!parentProjectExists)
                return NotFound("project not found");

            return repository.GetAll<Project>(x => x.Where(y => y.ParentId == parentProjectId).OrderBy(z => z.Name)).ToList();
        }
    }
}