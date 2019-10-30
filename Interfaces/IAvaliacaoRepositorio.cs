using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<Avaliacao>> Get();
        Task<Avaliacao> Get(int id);
        Task<Avaliacao> Post(Avaliacao avaliacao);
        Task<Avaliacao> Put(Avaliacao avaliacao);
        Task<Avaliacao> Delete(Avaliacao avaliacao);
    }
}