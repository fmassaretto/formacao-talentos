using System.Collections.Generic;
using Fatec.Treinamento.Model;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Inserir(Usuario usuario);

        IEnumerable<Usuario> Listar();

        Usuario Obter(int id);

        IEnumerable<Usuario> ListarPorNome(string nome);

        Usuario Atualizar(Usuario usuario);

        Usuario AtualizarSenha(Usuario usuario);

        void Excluir(int id);
    }
}
