using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeEntryApi.Core;

namespace TimeEntryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly UserManager<Employee> userManager;
        private readonly IMapper mapper;

        public EmployeesController(IRepository repository, UserManager<Employee> userManager, IMapper mapper)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return repository.GetAll<Employee>(includeProperties: "Department")
            .ToList();
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return repository.GetById<Employee>(id);
        }

        // POST api/employees
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeViewModel vm)
        {
            var employee = mapper.Map<CreateEmployeeViewModel, Employee>(vm);
            SetPasswordHash(employee, vm.Password);
            await userManager.CreateAsync(employee);
            return Created("", employee);
        }

        private void SetPasswordHash(Employee employee, string password)
        {
            var passwordHasher = new PasswordHasher<Employee>();

            // Hash the Password Secret:
            string passwordHash = passwordHasher.HashPassword(employee, password);

            // And set it for the Password Hash:
            employee.PasswordHash = passwordHash;
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            repository.Update(employee);
            repository.Save();
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return Ok();    
            }
            return NotFound();
        }
    }
}
