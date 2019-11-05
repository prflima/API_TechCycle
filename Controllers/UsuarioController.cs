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
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();

        /// <summary>
        /// Tem a função de trazer uma lista de usuário.
        /// </summary>
        /// <returns>Retorna uma lista de usuário</returns>

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar um usuário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um usuário</param>
        /// <returns>Retorna um usuário</returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id){

            try
            {
                Usuario usuario = await repositorio.Get(id);
                if(usuario == null){
                    return NotFound();
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            } 
        }

<<<<<<< HEAD

=======
>>>>>>> e77da677b7482d3def4e2d4adedcb8dca11d5d13
        /// <summary>
        /// Tem a função de cadastrar um novo usuário na lista.
        /// </summary>
        /// <param name="usuario">Passa um usuário.</param>
        /// <returns>Retorna um usuário.</returns>
        
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            Usuario validarUsuario = await repositorio.VerificarEmail(usuario.Email);
            if(validarUsuario != null)
                return BadRequest("Esse e-mail já está em uso!");

            try
            {
               await repositorio.Post(usuario);
            }
            catch (System.Exception)
            {   
                throw;
            }
            return usuario;
        }

        /// <summary>
        /// Tem a função de buscar na lista um usuário.
        /// </summary>
        /// <param name="id">Passa um id de um usuário.</param>
        /// <param name="usuario">Passa um usuário para identificação.</param>
        /// <returns>Retorna um usuário.</returns>
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id , Usuario usuario){
             if(id != usuario.IdUsuario){
                 return BadRequest();
             }
             try
             {
                await repositorio.Put(usuario);
             }
             catch (DbUpdateConcurrencyException)
             {
                 var validarUsuario = repositorio.Get(id);
                 if(validarUsuario == null)
                     return NotFound("Usuário não existe");  
                 else
                    throw;
                }
             return usuario;
             }

            /// <summary>
            /// Tem a função excluír um usuário da lista.
            /// </summary>
            /// <param name="id">Passa um id do usuário.</param>
            /// <returns>Retorna um usuário</returns>
            
            [HttpDelete("{id}")]
            public async Task<ActionResult<Usuario>> Delete(int id){
                Usuario usuario = await repositorio.Get(id);
                if(usuario == null)
                return NotFound("Usuário Não Existe");

                await repositorio.Delete(usuario);
                return usuario;

            }
        }
    }