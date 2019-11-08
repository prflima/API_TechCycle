using System.Collections.Generic;
using System.Threading.Tasks;
using API_TechCycle.Models;

namespace API_TechCycle.Interfaces
{
    public interface IUsuarioRepositorio
    {
         Task<List<Usuario>> Get();
         Task<Usuario> Get(int id);
         Task<Usuario> Post(Usuario usuario);
         Task<Usuario> Put(Usuario usuario);
         Task<Usuario> Delete(Usuario usuario);
         Task<Usuario> VerificarEmail(string email);
         Task<Usuario> VerificarLogin(string loginUsuario);
         Task<Usuario> VerificarUsuario(string email, string senha);
         Task<Usuario> RecuperarSenha(Usuario Usuario);
    }
}