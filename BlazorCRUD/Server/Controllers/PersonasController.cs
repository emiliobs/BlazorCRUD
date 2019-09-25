using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Server.Data;
using BlazorCRUD.Server.Helpers;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Persona>>> GetPersonas([FromQuery] Paginacions paginacion)
        {

            var queryable = _context.Personas.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable,paginacion.CantidadAMostrar);



            return await queryable.Paginar(paginacion).ToListAsync();
        
        } 

        [AllowAnonymous]
        [HttpGet("{id}", Name = "ObtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int id) => await _context.Personas.FirstOrDefaultAsync(x => x.Id.Equals(id));
        

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObtenerPersona",  new { id = persona.Id },persona);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var persona = new Persona { Id = id };
            _context.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }
       
    }
}