using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [Produces ("application/json")]
    public class AnuncioController : ControllerBase {
        AnuncioRepositorio repositorio = new AnuncioRepositorio ();

        UploadController _upload = new UploadController();

        /// <summary>
        /// Tem a função de listar um anúncio.
        /// </summary>
        /// <returns>Retorna uma lista de anúncio.</returns>
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Anuncio>>> Get () {

            try {

                return await repositorio.Get ();
            } catch (Exception) {
                throw;
            }
        }
        /// <summary>
        /// Tem a função de buscar um anúncio na lista.
        /// </summary>
        /// <param name="id">Passa um id de um anúncio</param>
        /// <returns>Retorna um anúncio</returns>

        // [Authorize]
        [HttpGet ("{id}")]
        public async Task<ActionResult<Anuncio>> Get (int id) {

            try {

                Anuncio anuncio = await repositorio.Get (id);
                if (anuncio == null) {
                    return NotFound ();
                }

                return anuncio;
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo anúncio na lista.
        /// </summary>
        /// <param name="anuncio">Passa um anúncio.</param>
        /// <returns>Retorna um anúncio.</returns>

        // [Authorize(Roles = "Administrador")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Anuncio>> Post([FromForm]Anuncio anuncio) {

            if (anuncio == null) {
                return NotFound ();
            }

            try {
                var file = Request.Form.Files[0];

                anuncio.Foto = _upload.Upload(file, "Resources/Anuncio");

                await repositorio.Post (anuncio);
            } catch (Exception) {
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

        [Authorize(Roles = "Administrador")]
        [HttpPut ("{id}")]
        public async Task<ActionResult<Anuncio>> Put (int id, Anuncio anuncio) {

            if (id != anuncio.IdAnuncio) {

                return BadRequest ();
            }

            try {

                await repositorio.Put (anuncio);
            } catch (DbUpdateConcurrencyException) {

                var validarAnuncio = await repositorio.Get (id);

                if (validarAnuncio == null) {
                    return NotFound ("Anuncio não existe");
                } else {
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

        // [Authorize (Roles = "Administrador")]
        [HttpDelete ("{id}")]
        public async Task<ActionResult<Anuncio>> Delete (int id) {

            Anuncio anuncio = await repositorio.Get (id);

            if (anuncio == null) {
                return NotFound ();
            }

            try {

                await repositorio.Delete (anuncio);
            } catch (Exception) {
                throw;
            }

            return anuncio;
        }

        /// <summary>
        /// Tem a função de filtrar por preço.
        /// </summary>
        /// <param name="preco">Passa um valor para o anúncio.</param>
        /// <returns>Retorna todos os anúncios com o valor desejada.</returns>

        [Authorize]
        [HttpGet ("buscarpreco/{preco}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorPreco (decimal preco) {

            try {

                return await repositorio.BuscaPorPreco (preco);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar por memório.
        /// </summary>
        /// <param name="memoria">Passa uma quantidade de memória.</param>
        /// <returns>Retorna todos os produtos com a memória desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmemoria/{memoria}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoria (int memoria) {
            try {
                return await repositorio.BuscaPorMemoria (memoria);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por memoria e categoria.
        /// </summary>
        /// <param name="memoria">Passa a memória.</param>
        /// <param name="categoria">Passa a categoria</param>
        /// <returns>Retorna todos os anúncios que contenha a memória e categoria desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmemoriacategoria/{memoria}/{categoria}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoriaECategoria (int memoria, int categoria) {
            try {
                return await repositorio.BuscarPorMemoriaECategoria (memoria, categoria);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem função de filtrar anúncios por memória e processador.
        /// </summary>
        /// <param name="memoria">Passa a memória.</param>
        /// <param name="processador">Passa o processador.</param>
        /// <returns>Retorna todos os anúncios que contenham memória e processador desejado. </returns>

        [Authorize]
        [HttpGet ("buscarmemoriaprocessador/{memoria}/{processador}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoriaEProcessador (int memoria, string processador) {
            try {
                return await repositorio.BuscarPorMemoriaEProcessador (memoria, processador);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por memória e marca.
        /// </summary>
        /// <param name="memoria">Passa a memória</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os anúncios que contenham a memória e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmemoriamarca/{memoria}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoriaEMarca (int memoria, int marca) {
            try {
                return await repositorio.BuscarPorMemoriaEMarca (memoria, marca);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por memória,categoria e marca.
        /// </summary>
        /// <param name="memoria">Passa a memória.</param>
        /// <param name="categoria">Passa a categoria.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os anúncios que contenham a memória,categoria e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmemoriacategoriamarca/{memoria}/{categoria}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarMemoriaCategoriaEMarca (int memoria, int categoria, int marca) {

            try {
                return await repositorio.BuscarPorMemoriaCategoriaEMarca (memoria, categoria, marca);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por processador e categoria.
        /// </summary>
        /// <param name="processador">Passa o processador.</param>
        /// <param name="categoria">Passa a categoria</param>
        /// <returns>Retorna todos os anúncios que contenham o processador e categoria desejada.</returns>

        [Authorize]
        [HttpGet ("buscaprocessadorcategoria/{processador}/{categoria}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorProcessadorECategoria (string processador, int categoria) {

            try {
                return await repositorio.BuscarPorProcessadorECategoria (processador, categoria);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por procesador e marca. 
        /// </summary>
        /// <param name="processador">Passa um processador.</param>
        /// <param name="marca">Passa uma marca</param>
        /// <returns>Retorna todos os anúncios que contenham o processador e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscaprocessadormarca/{processador}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorProcessadorEMarca (string processador, int marca) {

            try {
                return await repositorio.BuscarPorProcessadorEMarca (processador, marca);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por processador,categoria e marca.
        /// </summary>
        /// <param name="processador">Passa processador.</param>
        /// <param name="categoria">Passa categoria.</param>
        /// <param name="marca">Passa marca.</param>
        /// <returns>Retorna todos os anúncios que contenham o processador,categoria e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscaprocessadorcategoriamarca/{processador}/{categoria}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorProcessadorCategoriaEMarca (string processador, int categoria, int marca) {

            try {
                return await repositorio.BuscarPorProcessadorCategoriaEMarca (processador, categoria, marca);
            } catch (Exception) {
                throw;
            }
        }


        /// <summary>
        /// Tem a função de filtrar os anúncios por memória,processador e marca.
        /// </summary>
        /// <param name="memoria">Passa memória.</param>
        /// <param name="processador">Passa processador.</param>
        /// <param name="marca">Passa marca.</param>
        /// <returns>Retorna todos os anúncios que contenham a memória,processador e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmemoriaprocessadormarca/{memoria}/{processador}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoriaProcessadorEMarca (int memoria, string processador, int marca) {

            try {
                return await repositorio.BuscarPorMemoriaProcessadorEMarca (memoria, processador, marca);
            } catch (Exception) {
                throw;
            }
        }


        /// <summary>
        /// Tem a função de filtrar os anúncios por memória,categoria e processador.
        /// </summary>
        /// <param name="memoria">Passa a memória</param>
        /// <param name="categoria">Passa a categoria</param>
        /// <param name="processador">Passa o processador</param>
        /// <returns>Retorna todos os anúncios que contenham a memória,categoria e processador desejado.</returns>

        [Authorize]
        [HttpGet ("buscarmemoriacategoriaprocessador/{memoria}/{categoria}/{processador}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorMemoriaCategoriaEProcessador (int memoria, int categoria, string processador) {
            try {
                return await repositorio.BuscarPorMemoriaCategoriaEProcessador (memoria, categoria, processador);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar pelo o processador o anúncio.
        /// </summary>
        /// <param name="processador">Passa o processador.</param>
        /// <returns>Retorna lista de anúncios que possui esse processador.</returns>

        [Authorize]
        [HttpGet ("buscarprocessador/{processador}")]
        public async Task<ActionResult<List<Anuncio>>> BuscaPorProcessador (string processador) {

            try {

                return await repositorio.BuscaPorProcessador (processador);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por categoria.
        /// </summary>
        /// <param name="categoria">Passa a categoria.</param>
        /// <returns>Retorna todos os anúncios que contenham a categoria desejada.</returns>

        [Authorize]
        [HttpGet ("buscarcategoria/{categoria}")]
        public async Task<ActionResult<List<Anuncio>>> BuscarPorCategoria (int categoria) {

            try {

                return await repositorio.BuscaPorCategoria (categoria);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar os anúncios por categoria e marca.
        /// </summary>
        /// <param name="categoria">Passa uma categoria.</param>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham a categoria e marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscacategoriamarca/{categoria}/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscaPorCategoriaEMarca (int categoria, int marca) {

            try {

                return await repositorio.BuscaPorCategoriaEMarca (categoria, marca);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de filtrar anúncios por marca.
        /// </summary>
        /// <param name="marca">Passa uma marca.</param>
        /// <returns>Retorna todos os produtos que contenham a marca desejada.</returns>

        [Authorize]
        [HttpGet ("buscarmarca/{marca}")]
        public async Task<ActionResult<List<Anuncio>>> BuscaPorMarca (int marca) {

            try {

                return await repositorio.BuscarPorMarca (marca);
            } catch (Exception) {
                throw;
            }
        }
    }
}