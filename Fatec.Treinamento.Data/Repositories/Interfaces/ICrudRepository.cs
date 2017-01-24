using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    // Essa interface generica pode ser utilizada para operações basicas de CRUD
    public interface ICrudRepository<T> where T: class, new()
    {

        T Inserir(T entidade);

        IEnumerable<T> Listar();

        T Obter(int id);

        T Atualizar(T entidade);

        void Excluir(T entidade);

    }
}
