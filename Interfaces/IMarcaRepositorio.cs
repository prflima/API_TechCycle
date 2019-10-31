using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IMarcaRepositorio
    {
        Task<List<Marca>> Get();
        Task<Marca> Get(int id);
        Task<Marca> Post(Marca marca);
        Task<Marca> Put(Marca marca);
        Task<Marca> Delete(Marca marca);
         
    }
}