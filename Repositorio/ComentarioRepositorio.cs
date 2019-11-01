using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {

        TECHCYCLEContext context = new TECHCYCLEContext();

        public async Task<List<Comentario>> Get()
        {
            return await context.Comentario.ToListAsync(); 
        }

        public async Task<Comentario> Get(int id)
        {
            return await context.Comentario.FindAsync(id);
        }

        public async Task<Comentario> Post(Comentario comentario)
        {
            await context.Comentario.AddAsync(comentario);
            await context.SaveChangesAsync();

            return comentario;
        }

        public async Task<Comentario> Put(Comentario comentario)
        {
            context.Entry(comentario).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return comentario;
        }
        public async Task<Comentario> Delete(Comentario comentario)
        {
            context.Comentario.Remove(comentario);
            await context.SaveChangesAsync();

            return comentario;
        }
    }
}