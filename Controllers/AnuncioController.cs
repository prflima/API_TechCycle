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
    public class AnuncioController : ControllerBase
    {
        AnuncioRepositorio repositorio = new AnuncioRepositorio();

        /// <summary>
        /// Tem a função de listar um anúncio.
        /// </summary>
        /// <returns>Retorna uma lista de anúncio.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Anuncio>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){
                throw;
            }
        }
        /// <summary>
        /// Tem a função de buscar um anúncio na lista.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio</param>
        /// <returns>Retorna um anúncio</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> Get(int id){

            try{

                return await repositorio.Get(id);
            }catch(Exception){
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo anúncio na lista.
        /// </summary>
        /// <param name="anúncio">Passa um anúncio.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpPost]
        public async Task<ActionResult<Anuncio>> Post(Anuncio anuncio){

            if(anuncio == null){
                return NotFound();
            }

            try{

                await repositorio.Post(anuncio);
            }catch(Exception){
                throw;
            }

            return anuncio;
        }   
        /// <summary>
        /// Tem a função de buscar na lista um anúncio.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio.</param>
        /// <param name="anuncio">Passa um anúncio para identificação.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Anuncio>> Put(int id, Anuncio anuncio){

            if(id != anuncio.IdAnuncio){

                return BadRequest();
            }

            try{

                await repositorio.Put(anuncio);
            }catch(DbUpdateConcurrencyException){

                var validarAnuncio = await repositorio.Get(id);

                if(validarAnuncio == null){
                    return NotFound("Anuncio não existe");
                }else{
                    throw;
                }
            }

            return anuncio;
        }
        /// <summary>
        /// Tem a função de exclúir um anúncio na lista.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio.</param>
        /// <returns>Retorna um anúncio.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anuncio>> Delete(int id){

            Anuncio anuncio = await repositorio.Get(id);

            if(anuncio == null){
                return NotFound();
            }

            try{

                await repositorio.Delete(anuncio);
            }catch(Exception){
                throw;
            }

            return anuncio;
        }

        [HttpGet("buscarpreco/{preco}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorPreco(decimal preco){

            try{

                return await repositorio.BuscaPorPreco(preco);
            }catch(Exception){
                throw;
            }
        }

        [HttpGet("buscarmemoria/{memoria}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoria(int memoria)
        {
            try
            {
                return await repositorio.BuscaPorMemoria(memoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("buscarprocessador/{processador}")]
        public async Task<ActionResult<List<Anuncio>>> BuscaPorProcessador(string processador){

            try{

                return await repositorio.BuscaPorProcessador(processador);
            }catch(Exception){
                throw;
            }
        }
    }
}