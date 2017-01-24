using System.Collections.Generic;
using Fatec.Treinamento.Model;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        
        IEnumerable<Usuario> ListarPorNome(string nome);
        
        Usuario AtualizarSenha(Usuario usuario);

        Usuario Login(string email, string senha);


    }
}
