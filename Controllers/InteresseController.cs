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
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();
        
        /// <summary>
        /// Tem a função de listar um interesse.
        /// </summary>
        /// <returns>Retorna uma lista de interesse.</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de buscar um interesse na lista.
        /// </summary>
        /// <param name="id">Passa um id de um interesse</param>
        /// <returns>Retorna um interesse</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de cadastrar um novo interesse na lista.
        /// </summary>
        /// <param name="interesse">Passa um interesse.</param>
        /// <returns>Retorna um interesse.</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de buscar na lista um interesse.
        /// </summary>
        /// <param name="id">Passa um id de um interesse.</param>
        /// <param name="interesse">Passa um interesse para identificação.</param>
        /// <returns>Retorna um interesse.</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de exclúir um interesse na lista.
        /// </summary>
        /// <param name="id">Passa um id de um interesse.</param>
        /// <returns>Retorna um interesse.</returns>
        
        [Authorize]
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

        /// <summary>
        /// Tem a função de buscar os interesses de um anúncio.
        /// </summary>
        /// <param name="idAnuncio">Passa o id de um anúncio.</param>
        /// <returns>Retorna uma lista de interesses em relação a um determinado anúncio.</returns>

        [Authorize(Roles = "Administrador")]
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
  
        /// <summary>
        /// Tem a função de trazer a lista de aprovados.
        /// </summary>
        /// <param name="aprovacao">Passa uma Aprovação</param>
        /// <returns>Retorna um pedido aprovado.</returns>
        
        [Authorize]
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