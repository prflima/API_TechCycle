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
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();
           
        /// <summary>
        /// Tem a função de trazer uma lista de produto.
        /// </summary>
        /// <returns>Retorna uma lista de produto</returns>
        [Authorize]
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

        [Authorize]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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
        
        [Authorize(Roles = "Administrador")]
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
        /// <returns>Retorna todos os produtos que contenham a memória desejada.</returns>
        
        [Authorize]
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
        /// <returns>Retorna todos os produtos que contenham o processador desejado.</returns>

        [Authorize]
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

        /// <summary>
        /// Tem a função de filtrar por categoria.
        /// </summary>
        /// <param name="idCategoria">Passa um categoria.</param>
        /// <returns>Retorna todos os produtos que contenham a categoria desejado.</returns>

        [Authorize]
        [HttpGet("buscarcategoria/{idCategoria}")]
        public async Task<ActionResult<List<Produto>>> BuscaPorCategoria(int idCategoria)
        {
            try
            {
                return await repositorio.BuscaPorCategoria(idCategoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar por marca.
        /// </summary>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham a marca desejada.</returns>

        [Authorize]
        [HttpGet("buscarmarca/{marca}")]
        public async Task<ActionResult<List<Produto>>> BuscaPorMarca(int marca)
        {
            try
            {
                return await repositorio.BuscaPorMarca(marca);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar por processdor e memoria.
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <param name="memoria">Passa uma quantidade de memória.</param>
        /// <returns>Retorna todos os produtos que contenham o processador e memória desejada</returns>

        [Authorize]
        [HttpGet("buscarprocessadorememoria/{processador}/{memoria}")]
        public async Task<ActionResult<List<Produto>>> BuscaProcessadorEMemoria(string processador, int memoria)
        {
            try
            {
                return await repositorio.BuscaProcessadorEMemoria(processador, memoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtra por processador,memória e categoria.
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <param name="memoria">Passa a quantidade de memória.</param>
        /// <param name="categoria">Passa a categoria.</param>
        /// <returns>Retorna todos os produtos que contenham o processador,memória e categoria desejada.</returns>

        [Authorize]
        [HttpGet("buscarprocessadormemoriaecategoria/{processador}/{memoria}/{categoria}")]
        public async Task<ActionResult<List<Produto>>> BuscaProcessadorMemoriaCategoria(string processador, int memoria, int categoria)
        {
            try
            {
                return await repositorio.BuscaProcessadorMemoriaCategoria(processador, memoria, categoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar um produto por procesador,memória e categoria.
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <param name="memoria">Passa a quantidade de memória.</param>
        /// <param name="marca">Passa a marca.</param>
        /// <returns>Retorna todos os produtos que contenham o processador,memória e marca desejado.</returns>

        [Authorize]
        [HttpGet("buscarprocessadormemoriamarca/{processador}/{memoria}/{marca}")]
        public async Task<ActionResult<List<Produto>>> BuscaProcessadorMemoriaMarca(string processador, int memoria, int marca)
        {
            try
            {
                return await repositorio.BuscaProcessadorMemoriaMarca(processador, memoria, marca);
            }
            catch(Exception)
            {
                throw;
            }
        }
    
        /// <summary>
        /// Tem a função de filtrar produtos por processador,memória,categoria e marca.
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <param name="memoria">Passa uma quantidade de memória.</param>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham o processador,memória,categoria e marca desejado.</returns>

        [Authorize]
        [HttpGet("buscarprocessadormemoriacategoriamarca/{processador}/{memoria}/{categoria}/{marca}")]
        public async Task<ActionResult<List<Produto>>> BuscaProcessadorMemoriaCategoriaMarca(string processador , int memoria , int categoria , int marca)
        {
            try
            {
                return await repositorio.BuscaProcessadorMemoriaCategoriaMarca(processador , memoria , categoria , marca);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar por memória e categoria.
        /// </summary>
        /// <param name="memoria">Passa a quantidade de uma memória.</param>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <returns>Retorna todos os produtos que contenham a memória e categoria desejada.</returns>

        [Authorize]
        [HttpGet("buscarmemoriacategoria/{memoria}/{categoria}")]
        public async Task<ActionResult<List<Produto>>> BuscarMemoriaCategoria(int memoria , int categoria)
        {
            try
            {
                return await repositorio.BuscaMemoriaCategoria(memoria , categoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar produtos por memória e marca. 
        /// </summary>
        /// <param name="memoria">Passa a quantidade de uma memória.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham a memória e marca desejada.</returns>

        [Authorize]
        [HttpGet("buscarmemoriamarca/{memoria}/{marca}")]
        public async Task<ActionResult<List<Produto>>> BuscarMemoriaMarca(int memoria, int marca)
        {
            try
            {
                return await repositorio.BuscaMemoriaMarca(memoria,marca);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar produtos por memória,marca e categoria.
        /// </summary>
        /// <param name="memoria">Passa a quantidade de memória.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <returns>Retorna todos os produtos que contenham a memória,marca e categoria desejada.</returns>

        [Authorize]
        [HttpGet("buscarmemoriamarcacategoria/{memoria}/{marca}/{categoria}")]
        public async Task<ActionResult<List<Produto>>> BuscaMemoriaMarcaCategoria(int memoria, int marca,int categoria)
        {
            try
            {
                return await repositorio.BuscaMemoriaMarcaCategoria(memoria, marca, categoria);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar produtos por categoria e marca.
        /// </summary>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham a categoria e marca desejada.</returns>

        [Authorize]
        [HttpGet("buscarcategoriamarca/{categoria}/{marca}")]
        public async Task<ActionResult<List<Produto>>> BuscaCategoriaMarca(int categoria, int marca)
        {
            try
            {
                return await repositorio.BuscaCategoriaMarca(categoria, marca);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}