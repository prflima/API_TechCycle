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
    public class AvaliacaoController : ControllerBase
    {
        AvaliacaoRepositorio repositorio = new AvaliacaoRepositorio();
        /// <summary>
        /// Tem a função de listar uma avaliação.
        /// </summary>
        /// <returns>Retorna uma lista de avaliação.</returns>
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Avaliacao>>> Get()
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
        /// Tem a função de buscar uma avaliação na lista.
        /// </summary>
        /// <param name="id">passa um id de uma avaliação.</param>
        /// <returns>Retorna uma avaliação.</returns>

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> get(int id)
        {
            Avaliacao avaliacao = await repositorio.Get(id);
            if(avaliacao == null)
                return NotFound();
            
            return avaliacao;
        }
        /// <summary>
        /// Tem a função de cadastra uma avaliação.
        /// </summary>
        /// <param name="avaliacao">Passa uma avaliação.</param>
        /// <returns>Retorna uma avaliação.</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> Post(Avaliacao avaliacao)
        {
            try
            {
                await repositorio.Post(avaliacao);
            }
            catch(Exception)
            {
                throw;
            }

            return avaliacao;
        }
        /// <summary>
        /// Tem a função de atualizar uma avaliação.
        /// </summary>
        /// <param name="id">Passa um id de uma avaliação.</param>
        /// <param name="avaliacao">Passa uma avaliação.</param>
        /// <returns>Retorna a avaliação atualizada.</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Avaliacao>> Put(int id, Avaliacao avaliacao)
        {
            if(id == avaliacao.IdAvaliacao)
                return BadRequest();
            
            try
            {
                await repositorio.Post(avaliacao);
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarAvaliacao = await repositorio.Get(id);
                if(validarAvaliacao == null)
                    return NotFound("Avaliação não existe");
                else
                    throw;
            }

            return avaliacao;
        }      
        /// <summary>
        /// Tem a função de excluír uma avaliação.
        /// </summary>
        /// <param name="id">Passa um id de uma avaliação.</param>
        /// <returns>Retorna a avaliação excluída.</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Avaliacao>> Delete(int id)
        {
            Avaliacao avaliacao = await repositorio.Get(id);
            if(avaliacao == null)
                return NotFound("Avaliação não existe");
            
            await repositorio.Delete(avaliacao);
            return Ok(avaliacao);
        }
    }
}