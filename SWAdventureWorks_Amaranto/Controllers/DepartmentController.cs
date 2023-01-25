using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPut("{id}")]
        public ActionResult<Department> Put(short id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(short id)
        {
            var departmentOriginal = (from d in context.Departments
                                 where d.DepartmentId == id
                                 select d).SingleOrDefault();

            if (departmentOriginal == null)
            {
                return NotFound();
            }
            context.Departments.Remove(departmentOriginal);
            context.SaveChanges();
            return departmentOriginal;
        }
    }



}
