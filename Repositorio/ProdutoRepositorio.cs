using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();

        public async Task<List<Produto>> Get()
        {
            List<Produto> listaProdutos = await context.Produto.Include(mr => mr.IdMarcaNavigation)
                                                               .Include(ct => ct.IdCategoriaNavigation)
                                                               .ToListAsync();
            
            foreach(var produto in listaProdutos)
            {
                produto.IdMarcaNavigation.Produto = null;
                produto.IdCategoriaNavigation.Produto = null;
            }

            return listaProdutos;
        }

        public async Task<Produto> Get(int id)
        {
            Produto produto = await context.Produto.Include(mr => mr.IdMarcaNavigation)
                                                   .Include(ct => ct.IdCategoriaNavigation)
                                                   .FirstOrDefaultAsync(pr => pr.IdProduto == id);
            
            return produto;
        }

        public async Task<Produto> Post(Produto produto)
        {
            await context.Produto.AddAsync(produto);
            await context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Put(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Delete(Produto produto)
        {
            context.Produto.Remove(produto);
            await context.SaveChangesAsync();

            return produto;
        }
        public async Task<List<Produto>> BuscaPorMemoria(int memoria)
        {
            List<Produto> listaProdutos = await context.Produto.Where(pr => pr.Memoria == memoria)
                                                               .Include(mr => mr.IdMarcaNavigation)
                                                               .Include(ct => ct.IdCategoriaNavigation)
                                                               .ToListAsync();

            foreach(var produto in listaProdutos)
            {
                produto.IdMarcaNavigation.Produto = null;
                produto.IdCategoriaNavigation.Produto = null;
            }

            return listaProdutos;
        }

        public async Task<List<Produto>> BuscaPorProcessador(string processador)
        {
            List<Produto> listaProdutos = await context.Produto.Where(pr => pr.Processador == processador)
                                                               .Include(mr => mr.IdMarcaNavigation)
                                                               .Include(ct => ct.IdCategoriaNavigation)
                                                               .ToListAsync();

            foreach(var produto in listaProdutos)
            {
                produto.IdMarcaNavigation.Produto = null;
                produto.IdCategoriaNavigation.Produto = null;
            }

            return listaProdutos;
        }
    }
}