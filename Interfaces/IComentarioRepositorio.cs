using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IComentarioRepositorio
    {
        Task<List<Comentario>> Get();

        Task<Comentario> Get(int id);

        Task<Comentario> Post(Comentario comentario);

        Task<Comentario> Put(Comentario comentario);

        Task<Comentario> Delete(Comentario comentario);
    }
}