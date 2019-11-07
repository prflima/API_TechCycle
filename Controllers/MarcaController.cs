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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MarcaController : ControllerBase
    {

        MarcaRepositorio repositorio = new MarcaRepositorio();

        /// <summary>
        /// Tem a função de listar uma marca.
        /// </summary>
        /// <returns>Retorna uma lista de marca.</returns>
        /// 
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){

                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar uma marca na lista.
        /// </summary>
        /// <param name="id">passa um id de uma marca.</param>
        /// <returns>Retorna uma marca.</returns>
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> Get(int id){

            try{

                Marca marca = await repositorio.Get(id);

                if(marca == null){
                    return NotFound();
                }

                return marca;
            }catch(Exception){

                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastra uma marca.
        /// </summary>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna uma marca.</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca){

            try{

                await repositorio.Post(marca);
            
            }catch(Exception){
                throw;
            }

            return marca;
        }

        /// <summary>
        /// Tem a função de atualizar uma marca.
        /// </summary>
        /// <param name="id">Passa um id de uma marca.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna a marca atualizada.</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> Put(int id, Marca marca){

            if(id != marca.IdMarca){
                return BadRequest();

            }

            try{

                await repositorio.Put(marca);
            }catch(DbUpdateConcurrencyException){

                var validarMarca = repositorio.Get(id);

                if(validarMarca == null){
                    return NotFound();
                }else{
                    throw;
                }
            }

            return marca;
        }

        /// <summary>
        /// Tem a função de excluír uma marca.
        /// </summary>
        /// <param name="id">Passa um id de uma marca.</param>
        /// <returns>Retorna a marca excluída.</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marca>> Delete(int id){

            Marca marca = await repositorio.Get(id);

            if(marca == null){

                return NotFound();
            }

            await repositorio.Delete(marca);
            return marca;
        }
    }
}