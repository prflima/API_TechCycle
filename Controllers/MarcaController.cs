using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
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

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get(){

            try{

                return await repositorio.Get();
            }catch(Exception){

                throw;
            }
        }

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

        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca){

            try{

                await repositorio.Post(marca);
            
            }catch(Exception){
                throw;
            }

            return marca;
        }

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