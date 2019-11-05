using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get()
        {
            try
            {
                return await repositorio.Get(); 
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Interesse>> Get(int id)
        {
            try
            {
                return await repositorio.Get(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(Interesse interesse)
        {
            try
            {
                await repositorio.Post(interesse);
            }
            catch(Exception)
            {
                throw;
            }

            return interesse;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)
        {
            if(id != interesse.IdInteresse)
                return BadRequest();
            
            try
            {
                await repositorio.Put(interesse);
            }
            catch(DbUpdateConcurrencyException)
            {   
                var validarInteresse = await repositorio.Get(id);
                if(validarInteresse == null)
                    return NotFound();
                else
                    throw;
            }

            return interesse;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Interesse>> Delete(int id)
        {
            Interesse interesse = await repositorio.Get(id);
            if(interesse == null)
                return NotFound();

            try
            {
                await repositorio.Delete(interesse);
            }
            catch(Exception)
            {
                throw;
            }

            return interesse;
        }

        [HttpGet("buscarinteresseanuncio/{idAnuncio}")]
        public async Task<ActionResult<List<Interesse>>> BuscarInteressePorAnuncio(int idAnuncio)
        {
            try
            {
                return await repositorio.BuscarInteressePorAnuncio(idAnuncio);
            }
            catch(Exception)
            {
                throw;
            }
        } 

        [HttpGet("buscaraprovados/{aprovacao}")]
        public async Task<ActionResult<List<Interesse>>> BuscarInteresseAprovado(string aprovacao)
        {
            try
            {
                return await repositorio.BuscarInteresseAprovado(aprovacao);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}