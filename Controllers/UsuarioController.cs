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
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario){
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