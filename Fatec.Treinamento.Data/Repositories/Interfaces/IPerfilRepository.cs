using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    public interface IPerfilRepository: ICrudRepository<Perfil>
    {
        void InserirPermissoes(int idPerfil, IList<Funcionalidade> funcionalidades);

        IEnumerable<Funcionalidade> ObterPermissoes(int idPerfil);

    }
}
