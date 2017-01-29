using Fatec.Treinamento.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model.DTO;
using Fatec.Treinamento.Data.Repositories.Base;
using Dapper;
using Fatec.Treinamento.Model;

namespace Fatec.Treinamento.Data.Repositories
{
    public class CursoRepository : RepositoryBase, ICursoRepository
    {
        public IEnumerable<DetalhesCurso> ListarCursosPorNome(string nome)
        {
            return Connection.Query<DetalhesCurso>(
              @"SELECT
	                c.Id,
	                c.Nome,
	                a.Nome as Assunto,
	                u.Nome as Autor,
	                c.DataCriacao,
	                c.Classificacao
                 FROM curso c
                 inner join assunto a on c.IdAssunto = a.id
                 inner join usuario u on c.IdAutor = u.Id
                 WHERE c.nome like @Nome
                 ORDER BY c.Nome",
              param: new { Nome = "%" + nome + "%" }
            ).ToList();
        }

        public IEnumerable<DetalhesCurso> ListarTodosCursos()
        {
            return Connection.Query<DetalhesCurso>(
              @"SELECT
	                c.Id,
	                c.Nome,
	                a.Nome as Assunto,
	                u.Nome as Autor,
	                c.DataCriacao,
	                c.Classificacao
                 FROM curso c
                 inner join assunto a on c.IdAssunto = a.id
                 inner join usuario u on c.IdAutor = u.Id
                 ORDER BY c.Nome"
            ).ToList();
        }

        public IEnumerable<Detalhe> DetalheCurso(int id)
        {
            return Connection.Query<Detalhe>(
              @"SELECT
	                c.Id,
	                c.Nome,
	                a.Nome as Assunto,
	                u.Nome as Autor,
	                c.DataCriacao,
	                c.Classificacao,
                    cd.Descricao
                 FROM curso c
                 inner join assunto a on c.IdAssunto = a.id
                 inner join usuario u on c.IdAutor = u.Id
                 inner join curso_descricao cd on cd.IdCurso = c.Id
                 WHERE c.Id = @Id",
              param: new { Id = id }
            ).ToList();
        }
    }
}
