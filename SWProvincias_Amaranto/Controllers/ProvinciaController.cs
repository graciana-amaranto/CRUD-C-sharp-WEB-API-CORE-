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
    public class ProvinciaController : ControllerBase
    {
        private readonly DBPaisContext context;

        public ProvinciaController(DBPaisContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        [HttpPost]
        public ActionResult<Provincia> Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provinciaOriginal = (from p in context.Provincias
                                     where p.IdProvincia == id
                                     select p).SingleOrDefault();

            if (provinciaOriginal == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provinciaOriginal);
            context.SaveChanges();
            return provinciaOriginal;
        }
    }
}
