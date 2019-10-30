using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();

        public async Task<List<Avaliacao>> Get()
        {
            return await context.Avaliacao.ToListAsync();
        }

        public async Task<Avaliacao> Get(int id)
        {
            return await context.Avaliacao.FindAsync(id);
        }

        public async Task<Avaliacao> Post(Avaliacao avaliacao)
        {
            await context.Avaliacao.AddAsync(avaliacao);
            await context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<Avaliacao> Put(Avaliacao avaliacao)
        {
            context.Entry(avaliacao).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return avaliacao;
        }
        public async Task<Avaliacao> Delete(Avaliacao avaliacao)
        {
            context.Avaliacao.Remove(avaliacao);
            await context.SaveChangesAsync();

            return avaliacao;
        }
    }
}