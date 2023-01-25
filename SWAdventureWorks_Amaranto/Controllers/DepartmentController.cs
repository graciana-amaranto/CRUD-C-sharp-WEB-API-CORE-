using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAdventureWorks_Amaranto.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Amaranto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(short id)
        {
            Department department = (from d in context.Departments
                           where d.DepartmentId == id
                           select d).SingleOrDefault();
            return department;
        }

        [HttpGet("name/{name}")]
        public ActionResult<Department> GetByName(string name)
        {
            Department department = (from d in context.Departments
                           where d.Name == name
                           select d).SingleOrDefault();
            return department;
        }

        [HttpPost]
        public ActionResult<Department> Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok();
        }
    }



}
