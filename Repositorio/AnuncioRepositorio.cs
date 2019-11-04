using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class AnuncioRepositorio : IAnuncioRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();


        public async Task<List<Anuncio>> Get()
        {
            List<Anuncio> listaAnuncios = await context.Anuncio.Include(pdt => pdt.IdProdutoNavigation)
                                                                .Include(avl => avl.IdAvaliacaoNavigation)
                                                                .ToListAsync();
        
            foreach(var anuncio in listaAnuncios){
                anuncio.IdProdutoNavigation.Anuncio = null;
                anuncio.IdAvaliacaoNavigation.Anuncio = null;
            }

            return listaAnuncios;
        }     

        public async Task<Anuncio> Get(int id)
        {
            Anuncio anuncio = await context.Anuncio.Include(pdt => pdt.IdProdutoNavigation)
                                                    .Include(avl => avl.IdAvaliacaoNavigation)
                                                    .FirstOrDefaultAsync(anc => anc.IdAnuncio == id); 

            return anuncio;
        }

        public async Task<Anuncio> Post(Anuncio anuncio)
        {
            await context.Anuncio.AddAsync(anuncio);
            await context.SaveChangesAsync();

            return anuncio;
        }

        public async Task<Anuncio> Put(Anuncio anuncio)
        {
            context.Entry(anuncio).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return anuncio;
        }

        public async Task<Anuncio> Delete(Anuncio anuncio)
        {
            context.Anuncio.Remove(anuncio);
            await context.SaveChangesAsync();

            return anuncio;
        }

        public async Task<List<Anuncio>> BuscaPorPreco(decimal preco)
        {
            List<Anuncio> listaAnuncios = await context.Anuncio.Where(anc => anc.Preco == preco)
                                                                .Include(pdt => pdt.IdProdutoNavigation)
                                                                .Include(avl => avl.IdAvaliacaoNavigation)
                                                                .ToListAsync();

            foreach(var anuncio in listaAnuncios){

                anuncio.IdProdutoNavigation.Anuncio = null;
                anuncio.IdAvaliacaoNavigation.Anuncio = null;
            }

            return listaAnuncios;
        }

        public async Task<List<Anuncio>> BuscaPorMemoria(int memoria)
        {
            List<Anuncio> listaAnuncio = await context.Anuncio.Where(anc => anc.IdProdutoNavigation.Memoria == memoria)
                                                              .Include(pdt => pdt.IdProdutoNavigation)
                                                              .Include(avl => avl.IdAvaliacaoNavigation)
                                                              .ToListAsync();

            foreach(var anuncio in listaAnuncio)
            {
                anuncio.IdProdutoNavigation.Anuncio = null;
                anuncio.IdAvaliacaoNavigation.Anuncio = null;
            }  

            return listaAnuncio;
        }

        public async Task<List<Anuncio>> BuscaPorProcessador(string processador){

            List<Anuncio> listaAnuncio = await context.Anuncio.Where(anc => anc.IdProdutoNavigation.Processador == processador)
                                                              .Include(pdt => pdt.IdProdutoNavigation)
                                                              .Include(avl => avl.IdAvaliacaoNavigation)
                                                              .ToListAsync();

            foreach(var anuncio in listaAnuncio){
                
                anuncio.IdProdutoNavigation.Anuncio = null;
                anuncio.IdAvaliacaoNavigation.Anuncio = null;
            }

            return listaAnuncio;
        }

        
    }
}