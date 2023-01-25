using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Amaranto.Data;
using SWProvincias_Amaranto.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Amaranto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DBPaisContext context;

        public CiudadController(DBPaisContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        [HttpPost]
        public ActionResult<Ciudad> Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Ciudad> Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudadOriginal = (from c in context.Ciudades
                                     where c.IdCiudad == id
                                     select c).SingleOrDefault();

            if (ciudadOriginal == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudadOriginal);
            context.SaveChanges();
            return ciudadOriginal;
        }
    }
}

