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
		public IEnumerable<AssuntoCursoUsuario> ListarCursosPorNome(string nome)
		{
			return Connection.Query<AssuntoCursoUsuario>(
			  @"SELECT
					c.Id,
					c.Nome,
					a.Id AS IdAssunto,
					u.Id AS IdAutor,
					a.Nome as NomeAssunto,
					u.Nome as NomeAutor,
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

		public AssuntoCursoUsuario Obter(int id)
		{
			return Connection.Query<AssuntoCursoUsuario>(
			   @"SELECT c.Nome,
			   c.Classificacao,
			   a.Id AS IdAssunto,
			   u.Id AS IdAutor, 
			   u.Nome AS NomeAutor,
			   a.Nome AS NomeAssunto,
			   cd.Descricao
			   FROM Curso c
			   INNER JOIN Usuario u ON c.IdAutor = u.Id
			   INNER JOIN Assunto a ON c.IdAssunto = a.Id
			   INNER JOIN Curso_Descricao cd ON cd.IdCurso = c.Id
			   WHERE c.Id = @Id",
			   param: new { Id = id }
		   ).FirstOrDefault();
		}

		public AssuntoCursoUsuario Atualizar(AssuntoCursoUsuario acu)
		{
			Connection.Execute(
			   @"BEGIN TRANSACTION;

				UPDATE Curso SET Curso.Nome = @Nome, Curso.IdAutor = @IdAutor, Curso.Classificacao = @Classificacao
					WHERE Curso.Id = @IdCurso;

				UPDATE Assunto SET Nome = @NomeAssunto
					FROM Assunto a INNER JOIN Curso c
					ON c.IdAssunto = a.Id
					AND a.Id = @IdAssunto;

				UPDATE Curso_Descricao SET Descricao = @Descricao
					WHERE Curso_Descricao.Id = @IdCursoDescricao

				COMMIT;",
			   param: new
			   {
				   acu.Nome,
				   acu.Classificacao,
				   acu.IdAutor,
				   acu.IdCurso,
				   acu.NomeAssunto,
				   acu.IdAssunto,
				   acu.IdCursoDescricao,
				   acu.Descricao
			   }
			);

			return acu;
		}

		public IEnumerable<AssuntoCursoUsuario> ListarTodosCursos()
		{
			return Connection.Query<AssuntoCursoUsuario>(
			  @"SELECT
					c.Id AS IdCurso,
					c.Nome,
					a.Id AS IdAssunto,
					a.Nome AS NomeAssunto,
					u.Id AS IdAutor,
					u.Nome AS NomeAutor,
					c.DataCriacao,
					c.Classificacao
				 FROM curso c
				 inner join assunto a on c.IdAssunto = a.id
				 inner join usuario u on c.IdAutor = u.Id
				 ORDER BY c.Nome"
			).ToList();
		}

		public AssuntoCursoUsuario DetalheCurso(int? id)
		{
			var curso = Connection.Query<AssuntoCursoUsuario>(
			  @"SELECT
					c.Id AS IdCurso,
					c.Nome,
					a.Id AS IdAssunto,
					a.Nome as NomeAssunto,
					u.Id AS IdAutor,
					u.Nome as NomeAutor,
					c.DataCriacao,
					c.Classificacao,
					cd.Descricao AS Descricao
				 FROM curso c
				 inner join Assunto a on c.IdAssunto = a.id
				 inner join Usuario u on c.IdAutor = u.Id
				 inner join Curso_Descricao cd on cd.IdCurso = c.Id
				 WHERE c.Id = @Id",
			  new { Id = id }
			).FirstOrDefault();

            if (curso == null)
            {
                return curso;
            }

            var capitulos = Connection.Query<Capitulo>(
                    @"SELECT Id, Nome, Pontos 
                    FROM Capitulo WHERE IdCurso = @IdCurso",
                    new {IdCurso = id}
            ).ToList();

            foreach (var capitulo in capitulos)
            {
                var videos = Connection.Query<Video>(
                    @"SELECT Id, Nome, Duracao, CodigoVideo
                    FROM Video WHERE IdCapitulo = @IdCapitulo",
                    new { IdCapitulo = capitulo.Id}   
                ).ToList();

                capitulo.Videos = videos;
            }

            curso.TotalDuracaoCurso = capitulos;
            curso.Pontos = capitulos;
            curso.Capitulos = capitulos;

            return curso;
		}

		public IEnumerable<DetalhesCurso> ListarCursosDetalhes()
		{
			return Connection.Query<DetalhesCurso>(
			  @"SELECT
					c.Id AS IdCurso,
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
        
		public AssuntoCursoUsuario Inserir(AssuntoCursoUsuario acu)
		{
            var id = Connection.ExecuteScalar<int>(
               @"INSERT INTO Curso (Nome, IdAutor, IdAssunto, Classificacao, DataCriacao, Nivel) 
                 VALUES (@Nome, @IdAutor, @IdAssunto, null, GETDATE(), @Nivel); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   Nome = acu.Nome,
                   IdAutor = acu.UsuarioSelecionado,
                   IdAssunto = acu.AssuntoSelecionado,
                   Nivel = acu.Nivel
               }
           );

            acu.IdCurso = id;

            Connection.Execute(
               @"INSERT INTO Curso_Descricao (Descricao, IdCurso) 
                 VALUES (@Descricao, @IdCurso); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   Descricao = acu.Descricao,
                   IdCurso = id
               }
           );

            return acu;
        }

		public IEnumerable<AssuntoCursoUsuario> Listar()
		{
			throw new NotImplementedException();
		}

		public void Excluir(AssuntoCursoUsuario entidade)
		{
			throw new NotImplementedException();
		}
	}
}
