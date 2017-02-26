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
					c.Id AS IdCurso,
					c.Nome,
					a.Id AS IdAssunto,
					u.Id AS IdAutor,
					a.Nome as NomeAssunto,
					u.Nome as NomeAutor,
					c.DataCriacao,
					c.Classificacao,
					c.Nivel
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
				   c.Id AS IdCurso,
				   a.Id AS IdAssunto,
				   u.Id AS IdAutor, 
				   u.Nome AS NomeAutor,
				   a.Nome AS NomeAssunto,
				   cd.Descricao,
				   c.DataCriacao,
				   c.Nivel,
				   c.Img
			   FROM Curso c
			   INNER JOIN Usuario u ON c.IdAutor = u.Id
			   INNER JOIN Assunto a ON c.IdAssunto = a.Id
			   INNER JOIN Curso_Descricao cd ON cd.IdCurso = c.Id
			   WHERE c.Id = @Id",
			   param: new { Id = id }
		   ).FirstOrDefault();
		}

		public IEnumerable<AssuntoCursoUsuario> ObterLista(int idCurso)
		{
			return Connection.Query<AssuntoCursoUsuario>(
			   @"SELECT c.Nome,
				   c.Classificacao,
				   c.Id AS IdCurso,
				   a.Id AS IdAssunto,
				   u.Id AS IdAutor, 
				   u.Nome AS NomeAutor,
				   a.Nome AS NomeAssunto,
				   cd.Descricao,
				   c.Nivel
			   FROM Curso c
			   INNER JOIN Usuario u ON c.IdAutor = u.Id
			   INNER JOIN Assunto a ON c.IdAssunto = a.Id
			   INNER JOIN Curso_Descricao cd ON cd.IdCurso = c.Id
			   WHERE c.Id = @Id",
			   new { Id = idCurso }
		   ).ToList();
		}

		public AssuntoCursoUsuario Atualizar(AssuntoCursoUsuario acu)
		{
			Connection.Execute(
			   @"BEGIN TRANSACTION;

				UPDATE Curso SET Curso.Nome = @Nome, Curso.IdAutor = @IdAutor
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
					c.Classificacao,
					c.Nivel
				 FROM curso c
				 inner join assunto a on c.IdAssunto = a.id
				 inner join usuario u on c.IdAutor = u.Id
				 ORDER BY c.Nome"
			).ToList();
		}

		//Lista os detalhes do curso para mostrar na view Detalhe
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
					cd.Descricao AS Descricao,
					c.Nivel
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
					c.Classificacao,
					c.Nivel
				 FROM curso c
				 inner join assunto a on c.IdAssunto = a.id
				 inner join usuario u on c.IdAutor = u.Id
				 ORDER BY c.Nome"
				  ).ToList();
		}

		//Lista curso poulares ordenado por melhor classificação
		public IEnumerable<AssuntoCursoUsuario> ListarPopulares() {
			return Connection.Query<AssuntoCursoUsuario>(
					@"SELECT
					c.Id AS IdCurso,
						c.Nome,
						a.Id AS IdAssunto,
						a.Nome AS NomeAssunto,
						u.Id AS IdAutor,
						u.Nome AS NomeAutor,
						c.DataCriacao,
						cd.Descricao,
						c.Classificacao,
						c.Nivel,
						c.Img
					FROM curso c
					INNER JOIN assunto a ON c.IdAssunto = a.id
					INNER JOIN usuario u ON c.IdAutor = u.Id
					INNER JOIN Curso_Descricao cd ON cd.IdCurso = c.Id
					ORDER BY Classificacao DESC"
				  ).ToList();
		}

		//Inserir curso
		public AssuntoCursoUsuario Inserir(AssuntoCursoUsuario acu)
		{
			var id = Connection.ExecuteScalar<int>(
			   @"INSERT INTO Curso (Nome, IdAutor, IdAssunto, Classificacao, DataCriacao, Nivel, Img) 
				 VALUES (@Nome, @IdAutor, @IdAssunto, null, GETDATE(), @Nivel, @Img); 
			   SELECT SCOPE_IDENTITY()",
			   param: new
			   {
				   Nome = acu.Nome,
				   //IdAutor = acu.UsuarioSelecionado,
				   //IdAssunto = acu.AssuntoSelecionado,
				   Nivel = acu.Nivel,
				   Img = acu.Img
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

		//Atualiza a classificação/nota média do curso
		public void AtualizaClassificacao(int id)
		{
			Connection.Execute(
			   @"UPDATE Curso 
					SET Classificacao = (SELECT (T.Nota/T.QtdUsuarios) AS Media 
											FROM (SELECT COUNT(cc.IdUsuario) As QtdUsuarios, SUM(cc.Nota) AS Nota 
											FROM Curso_Classificacao cc WHERE IdCurso = @IdCurso) T) WHERE Id = @IdCurso",
			   param: new
			   {
				   IdCurso = id
			   }
		   );
		}

		//Inseri a nota do curso depois de concluido o curso
		public void InserirNota(int idCurso, int idUsuario, int nota)
		{
			Connection.Execute(
			   @"INSERT INTO Curso_Classificacao (IdCurso, IdUsuario, Nota) 
					VALUES (@IdCurso, @IdUsuario, @Nota)",
			   param: new
			   {
				   IdCurso = idCurso,
				   IdUsuario = idUsuario,
				   Nota = nota
			   }
		   );
		}

		//Obtem a quantidade de usuarios que votaram em um determinado curso
		public int ObterQtdVotos(int? id)
		{
			return Connection.Query<int>(
			   @"Select COUNT(IdUsuario) AS QtdUsuario 
					FROM Curso_Classificacao 
					WHERE IdCurso = @IdCurso",
			   new { IdCurso = id }
			   ).FirstOrDefault();
		}

		//Obtem a duração máxima de um curso
		public int SomarDuracaoCurso(int? id)
		{
			return Connection.ExecuteScalar<int>(
				@"Select SUM(v.Duracao) AS QtdTotalCurso 
					FROM Video v 
					INNER JOIN Capitulo cap 
					ON cap.Id = v.IdCapitulo 
					WHERE cap.IdCurso = @IdCurso",
				new { IdCurso = id }
				);
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
