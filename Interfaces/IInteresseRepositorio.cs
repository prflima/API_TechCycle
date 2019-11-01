using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IInteresseRepositorio
    {
        Task<List<Interesse>> Get();
        Task<Interesse> Get(int id);
        Task<Interesse> Post(Interesse interesse);
        Task<Interesse> Put(Interesse interesse);
        Task<Interesse> Delete(Interesse interesse);
        Task<List<Interesse>> BuscarInteressePorAnuncio(int idAnuncio);
        Task<List<Interesse>> BuscarInteresseAprovado(string aprovacao);
    }
}