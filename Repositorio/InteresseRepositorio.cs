using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class InteresseRepositorio : IInteresseRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();

        public async Task<List<Interesse>> Get()
        {
            List<Interesse> listaInteresse= await context.Interesse.Include(us => us.IdUsuarioNavigation)
                                                                   .Include(an => an.IdAnuncioNavigation)
                                                                   .ToListAsync();

            foreach(var interesse in listaInteresse)
            {
                interesse.IdUsuarioNavigation.Interesse = null;
                interesse.IdAnuncioNavigation.Interesse = null;
            }

            return listaInteresse;
        }

        public async Task<Interesse> Get(int id)
        {
            Interesse interesse = await context.Interesse.Include(us => us.IdUsuarioNavigation)
                                                         .Include(an => an.IdAnuncioNavigation)
                                                         .FirstOrDefaultAsync(inte => inte.IdInteresse == id);
            
            return interesse;
        }

        public async Task<Interesse> Post(Interesse interesse)
        {
            await context.Interesse.AddAsync(interesse);
            await context.SaveChangesAsync();

            return interesse;
        }

        public async Task<Interesse> Put(Interesse interesse)
        {
            context.Entry(interesse).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return interesse;
        }
        public async Task<Interesse> Delete(Interesse interesse)
        {
            context.Interesse.Remove(interesse);
            await context.SaveChangesAsync();

            return interesse;
        }

        public async Task<List<Interesse>> BuscarInteressePorAnuncio(int idAnuncio)
        {
            List<Interesse> listaInteresses = await context.Interesse.Where(inte => inte.IdAnuncioNavigation.IdAnuncio == idAnuncio)
                                                                     .Include(us => us.IdUsuarioNavigation)
                                                                     .Include(anu => anu.IdAnuncioNavigation)
                                                                     .ToListAsync();
            
            foreach(var interesse in listaInteresses)
            {
                interesse.IdUsuarioNavigation.Interesse = null;
                interesse.IdAnuncioNavigation.Interesse = null;
            }

            return listaInteresses;
        }

        public async Task<List<Interesse>> BuscarInteresseAprovado(string aprovacao)
        {
            List<Interesse> listaInteresse = await context.Interesse.Where(inte => inte.Aprovado == aprovacao)
                                                                    .Include(us => us.IdUsuarioNavigation)
                                                                    .Include(anu => anu.IdAnuncioNavigation)
                                                                    .ToListAsync();
            
            foreach(var interesse in listaInteresse)
            {
                interesse.IdUsuarioNavigation.Interesse = null;
                interesse.IdAnuncioNavigation.Interesse = null;
            }

            return listaInteresse;
        }
    }
}