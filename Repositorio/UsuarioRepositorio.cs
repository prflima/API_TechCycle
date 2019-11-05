using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();
        public async Task<List<Usuario>> Get()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> Post(Usuario usuario)
        {
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Put(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> Delete(Usuario usuario)
        {
            context.Usuario.Remove(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> VerificarEmail(string email)
        {
            Usuario usuario = await context.Usuario.Where(us => us.Email == email).FirstOrDefaultAsync();
            return usuario;
;        }
    }
}