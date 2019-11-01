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
    }
}