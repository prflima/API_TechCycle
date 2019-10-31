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
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
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
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                Categoria categoria = await repositorio.Get(id);
                if(categoria == null)
                    return NotFound();    

                return categoria;        
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                await repositorio.Post(categoria);
            }
            catch(Exception)
            {
                throw;
            }

            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if(id != categoria.IdCategoria)
                return BadRequest();
            
            try
            {
                await repositorio.Put(categoria);
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarCategoria = repositorio.Get(id);
                if(validarCategoria == null)
                    return NotFound("Categoria não existe");
                else
                    throw;
            }

            return categoria;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            Categoria categoria = await repositorio.Get(id);

            if(categoria == null)
                return NotFound("Categoria não existe!");
            
            await repositorio.Delete(categoria);
            return Ok("Categoria Apagada");
        }
    }
}