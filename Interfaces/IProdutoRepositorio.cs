using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> Get();
        Task<Produto> Get(int id);
        Task<Produto> Post(Produto produto);
        Task<Produto> Put(Produto produto);
        Task<Produto> Delete(Produto produto);
        Task<List<Produto>> BuscaPorProcessador(string processador);
        Task<List<Produto>> BuscaPorMemoria(int memoria);
        Task<List<Produto>> BuscaPorCategoria(int categoria);
        Task<List<Produto>> BuscaPorMarca(int marca);
        Task<List<Produto>> BuscaProcessadorEMemoria(string processador, int memoria);
        Task<List<Produto>> BuscaProcessadorMemoriaCategoria(string processador, int memoria, int categoria);
        Task<List<Produto>> BuscaProcessadorMemoriaMarca(string processador, int memoria, int marca);
        Task<List<Produto>> BuscaProcessadorMemoriaCategoriaMarca(string processador, int memoria , int categoria, int marca);
        Task<List<Produto>> BuscaMemoriaCategoria(int memoria , int categoria);
        Task<List<Produto>> BuscaMemoriaMarca(int memoria, int marca);
        Task<List<Produto>> BuscaMemoriaMarcaCategoria(int memoria, int marca, int categoria);
        Task<List<Produto>> BuscaCategoriaMarca(int categoria, int marca);
    }
}