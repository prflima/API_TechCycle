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

        [HttpGet]
        public async Task<ActionResult<List<Anuncio>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> Get(int id){

            try{

                return await repositorio.Get(id);
            }catch(Exception){
                throw;
            }
        }


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
    }
}