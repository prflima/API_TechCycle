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
        /// <summary>
        /// Tem a função de trazer uma lista de produto.
        /// </summary>
        /// <returns>Retorna uma lista de produto</returns>
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
        /// <summary>
        /// Tem a função de buscar um produto na lista.
        /// </summary>
        /// <param name="id">Passa um id de um produto</param>
        /// <returns>Retorna um Produto</returns>
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
        /// <summary>
        /// Tem a função de cadastrar um novo produto na lista.
        /// </summary>
        /// <param name="produto">Passa um produto.</param>
        /// <returns>Retorna um produto.</returns>
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
        /// <summary>
        /// Tem a função de buscar na lista um produto.
        /// </summary>
        /// <param name="id">Passa um id de um produto.</param>
        /// <param name="produto">Passa um Produto para identificação.</param>
        /// <returns>Retorna um produto.</returns>
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
        /// <summary>
        /// Tem a função excluír um produto da lista.
        /// </summary>
        /// <param name="id">Passa um id do produto.</param>
        /// <returns>Retorna um produto</returns>
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
        /// <summary>
        /// Tem a função de filtrar por memória.
        /// </summary>
        /// <param name="memoria">Passa uma quantidade de memória.</param>
        /// <returns>Retorna todos os produtos com a memória desejada.</returns>
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
        /// <summary>
        /// Tem a função de filtrar por processador.
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <returns>Retorna todos os Produtos com o processador desejado.</returns>
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