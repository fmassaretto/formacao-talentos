using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    public interface IAssuntoRepository : ICrudRepository<AssuntoCursoUsuario>
    {
        IEnumerable<CursosPorAssunto> ListarTotalCursosPorAssunto();
    }
}
