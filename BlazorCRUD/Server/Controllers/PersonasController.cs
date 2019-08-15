﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Server.Data;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetPersonas() => await _context.Personas.ToListAsync();

        [HttpGet("{id}", Name = "ObtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int id) => await _context.Personas.FirstOrDefaultAsync(x => x.Id.Equals(id));
        

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObtenerPersona",  new { id = persona.Id },persona);
        }


       
    }
}