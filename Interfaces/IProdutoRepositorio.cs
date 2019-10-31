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
    }
}