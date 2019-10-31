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
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();   

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> get()
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
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                return await repositorio.Get(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            if(produto == null)
                return NotFound();

            try
            {
                await repositorio.Post(produto);
            }
            catch(Exception)
            {
                throw;
            }
            return produto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if(id != produto.IdProduto)
                return BadRequest();
            
            try
            {
                await repositorio.Put(produto);
            }
            catch(DbUpdateConcurrencyException)
            {
                var validarProduto = await repositorio.Get(id);
                if(validarProduto == null)
                    return NotFound("Produto não existe");
                else
                    throw;
            }
            return produto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            Produto produto = await repositorio.Get(id);
            if(produto == null)
                return NotFound();
            
            try
            {
                await repositorio.Delete(produto);
            }
            catch(Exception)
            {
                throw;
            }

            return produto;
        }

        [HttpGet("buscarmemoria/{memoria}")]
        public async Task<ActionResult<List<Produto>>> BuscaPorMemoria(int memoria)
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
        public async Task<ActionResult<List<Produto>>> BuscaPorProcessador(string processador)
        {
            try
            {
                return await repositorio.BuscaPorProcessador(processador);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}