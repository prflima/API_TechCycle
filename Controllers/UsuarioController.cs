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
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();

        /// <summary>
        /// Tem a função de trazer uma lista de usuário.
        /// </summary>
        /// <returns>Retorna uma lista de usuário</returns>

        [Authorize]
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
        
        [Authorize]
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

        /// <summary>
        /// Tem a função de cadastrar um novo usuário na lista.
        /// </summary>
        /// <param name="usuario">Passa um usuário.</param>
        /// <returns>Retorna um usuário.</returns>
        
        [Authorize] /*Fiquei na duvida porque o proprio usuario a principio tem o direito 
                      de se cadastrar */
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            Usuario validarEmail = await repositorio.VerificarEmail(usuario.Email);
            if(validarEmail != null)
                return BadRequest("Esse e-mail já está em uso!");

            Usuario validarLogin = await repositorio.VerificarLogin(usuario.LoginUsuario);
                if(validarLogin != null)
                    return BadRequest("Esse login já está em uso!");

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
        
        [Authorize] /*Porque o proprio usuario pode atualizar seu perfil */
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
            
            [Authorize] /*O proprio usuario poderia excluir sua conta */
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