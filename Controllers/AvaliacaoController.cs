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
    public class AvaliacaoController : ControllerBase
    {
        AvaliacaoRepositorio repositorio = new AvaliacaoRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Avaliacao>>> Get()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> get(int id)
        {
            Avaliacao avaliacao = await repositorio.Get(id);
            if(avaliacao == null)
                return NotFound();
            
            return avaliacao;
        }

        [HttpPost]
        public async Task<ActionResult<Avaliacao>> Post(Avaliacao avaliacao)
        {
            try
            {
                await repositorio.Post(avaliacao);
            }
            catch(Exception)
            {
                throw;
            }

            return avaliacao;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Avaliacao>> Put(int id, Avaliacao avaliacao)
        {
            if(id == avaliacao.IdAvaliacao)
                return BadRequest();
            
            try
            {
                await repositorio.Post(avaliacao);
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarAvaliacao = await repositorio.Get(id);
                if(validarAvaliacao == null)
                    return NotFound("Avaliação não existe");
                else
                    throw;
            }

            return avaliacao;
        }      

        [HttpDelete("{id}")]
        public async Task<ActionResult<Avaliacao>> Delete(int id)
        {
            Avaliacao avaliacao = await repositorio.Get(id);
            if(avaliacao == null)
                return NotFound("Avaliação não existe");
            
            await repositorio.Delete(avaliacao);
            return Ok("Deletado");
        }
    }
}