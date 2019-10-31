using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();


        public async Task<List<Marca>> Get()
        {
            return await context.Marca.ToListAsync();
        }

        public async Task<Marca> Get(int id)
        {
            return await context.Marca.FindAsync(id);
        }

        public async Task<Marca> Post(Marca marca)
        {
            await context.Marca.AddAsync(marca);
            await context.SaveChangesAsync();

            return marca;
        }

        public async Task<Marca> Put(Marca marca)
        {
            context.Entry(marca).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return marca;
        }

        public async Task<Marca> Delete(Marca marca)
        {
            context.Marca.Remove(marca);
            await context.SaveChangesAsync();

            return marca;
        }
    }
}