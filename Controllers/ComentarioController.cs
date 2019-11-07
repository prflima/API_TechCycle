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
    public class ComentarioController : ControllerBase
    {

        ComentarioRepositorio repositorio = new ComentarioRepositorio();

        /// <summary>
        /// Tem a função de listar um comentário.
        /// </summary>
        /// <returns>Retorna uma lista de comentário.</returns>
    
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar um Comentário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um Comentário</param>
        /// <returns>Retorna um Comentário</returns>
    
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> Get(int id){

            try{

                Comentario comentario =  await repositorio.Get(id);
                if(comentario == null){

                    return NotFound();
                }

                return comentario;
            }catch(Exception){
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo comentário na lista.
        /// </summary>
        /// <param name="comentario">Passa um comentário.</param>
        /// <returns>Retorna um comentário.</returns>
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario comentario){

            try{

                await repositorio.Post(comentario);
            }catch(Exception){
                throw;
            }

            return comentario;
        }

        /// <summary>
        /// Tem a função de buscar na lista um comentário.
        /// </summary>
        /// <param name="id">Passa um id de um comentário.</param>
        /// <param name="comentario">Passa um comentário para identificação.</param>
        /// <returns>Retorna um comentário.</returns>

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Comentario>> Put(int id, Comentario comentario){

            if(id != comentario.IdComentario){
                return BadRequest();
            }
            
            try{

                await repositorio.Put(comentario);
            }catch(DbUpdateConcurrencyException){

                var validarComentario = repositorio.Get(id);

                if(validarComentario == null){
                return NotFound("Comentario não encontrado");
                }
            }

            return comentario;
        }

        /// <summary>
        /// Tem a função de exclúir um comentário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um comentário.</param>
        /// <returns>Retorna um comentário.</returns>
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> Delete(int id){

            Comentario comentario = await repositorio.Get(id);

            if(comentario == null){
                return NotFound("Comentário não encontrado");
            }

            try{

                await repositorio.Delete(comentario);
            }catch(Exception){
                throw;
            }
            
            return comentario;
        }
    }
}