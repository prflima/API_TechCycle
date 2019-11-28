using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Tem a função de listar uma categoria.
        /// </summary>
        /// <returns>Retorna uma lista de categoria.</returns>
        
        [Authorize]
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

        /// <summary>
        /// Tem a função de buscar uma categoria na lista.
        /// </summary>
        /// <param name="id">passa um id de uma categoria.</param>
        /// <returns>Retorna uma categoria.</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de cadastra uma categoria.
        /// </summary>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <returns>Retorna uma categoria.</returns>
        
        [Authorize(Roles = "Administrador")]
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
    
        [Authorize(Roles = "Administrador")]
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

        /// <summary>
        /// Tem a função de excluír uma categoria.
        /// </summary>
        /// <param name="id">Passa um id de uma categoria.</param>
        /// <returns>Retorna a categoria excluída.</returns>
    
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            Categoria categoria = await repositorio.Get(id);

            if(categoria == null)
                return NotFound("Categoria não existe!");
            try
            {
                await repositorio.Delete(categoria);
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(categoria);
        }
    }
}