using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IAnuncioRepositorio
    {
         Task<List<Anuncio>> Get();

         Task<Anuncio> Get(int id);

         Task<Anuncio> Post(Anuncio anuncio);

         Task<Anuncio> Put(Anuncio anuncio);

         Task<Anuncio> Delete(Anuncio anuncio);
         Task<List<Anuncio>> BuscaPorPreco(decimal preco);

        //  Filtros por Memoria
         Task<List<Anuncio>> BuscaPorMemoria(int memoria);

         Task<List<Anuncio>> BuscarPorMemoriaEProcessador(int memoria, string processador);

         Task<List<Anuncio>> BuscarPorMemoriaECategoria(int memoria, int categoria);

         Task<List<Anuncio>> BuscarPorMemoriaEMarca(int memoria, int marca);

         Task<List<Anuncio>> BuscarPorMemoriaCategoriaEProcessador(int memoria, int categoria, string processador);

         Task<List<Anuncio>> BuscarPorMemoriaCategoriaEMarca(int memoria, int categoria, int marca);

         Task<List<Anuncio>> BuscarPorMemoriaProcessadorEMarca(int memoria, string processador, int marca);

        /////////////////////////////////////////////////////

        // Filtros por Processador
         Task<List<Anuncio>> BuscaPorProcessador(string processador);

         Task<List<Anuncio>> BuscarPorProcessadorECategoria(string processador, int categoria);
         Task<List<Anuncio>> BuscarPorProcessadorEMarca(string processador, int marca);
         Task<List<Anuncio>> BuscarPorProcessadorCategoriaEMarca(string processador, int categoria, int marca);

        ///////////////////////////////////////////////////////////////////////////////
        
        // Filtro por Categoria

         Task<List<Anuncio>> BuscaPorCategoria(int categoria);

         Task<List<Anuncio>> BuscaPorCategoriaEMarca(int categoria, int marca);

    }
}