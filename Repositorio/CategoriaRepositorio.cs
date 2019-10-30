using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();
        public async Task<List<Categoria>> Get()
        {
            return await context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await context.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Post(Categoria categoria)
        {
            await context.Categoria.AddAsync(categoria);
            await context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> Put(Categoria categoria)
        {
            context.Entry(categoria).State =EntityState.Modified;
            await context.SaveChangesAsync();

            return categoria;
        }
        public async Task<Categoria> Delete(Categoria categoria)
        {
            context.Categoria.Remove(categoria);
            await context.SaveChangesAsync();

            return categoria;
        }
    }
}