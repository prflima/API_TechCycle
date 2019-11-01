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
    public class ComentarioController : ControllerBase
    {

        ComentarioRepositorio repositorio = new ComentarioRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){
                throw;
            }
        }

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

        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario comentario){

            try{

                await repositorio.Post(comentario);
            }catch(Exception){
                throw;
            }

            return comentario;
        }

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