using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TechCycle.Controllers;
using API_TechCycle.Interfaces;
using API_TechCycle.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TechCycle.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TECHCYCLEContext context = new TECHCYCLEContext();
        UploadController upload = new UploadController();
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
        }

        public async Task<Usuario> VerificarLogin(string loginUsuario)
        {
            Usuario usuario = await context.Usuario.Where(us => us.LoginUsuario == loginUsuario).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> VerificarUsuario(string email, string senha)
        {
            Usuario usuario = await context.Usuario.Where(us => us.Email == email && us.Senha == senha).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> RecuperarSenha(Usuario usuario)
        {
            Usuario usuarioAlterar = await context.Usuario.FirstOrDefaultAsync(us => us.Email == usuario.Email);
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            Random random = new Random();
            int tamanhoSenha = random.Next(3,9);

            string senha = "";

            for(int i = 0; i <= tamanhoSenha; i++)
            {
                senha += guid.Substring(random.Next(1, guid.Length), 1);
            }

            usuarioAlterar.Senha = senha;

            return usuarioAlterar;            
        }
    }
}