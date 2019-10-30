using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;

namespace API_TechCycle.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        
        public Task<List<Avaliacao>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Avaliacao> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Avaliacao> Post(Avaliacao avaliacao)
        {
            throw new System.NotImplementedException();
        }

        public Task<Avaliacao> Put(Avaliacao avaliacao)
        {
            throw new System.NotImplementedException();
        }
        public Task<Avaliacao> Delete(Avaliacao avaliacao)
        {
            throw new System.NotImplementedException();
        }
    }
}