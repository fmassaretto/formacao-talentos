using Fatec.Treinamento.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Data.Repositories.Base;
using Dapper;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Data.Repositories
{
    public class AssuntoRepository : RepositoryBase, IAssuntoRepository
    {
        public AssuntoCursoUsuario Inserir(AssuntoCursoUsuario assunto)
        {
            var id = Connection.ExecuteScalar<int>(
               @"INSERT INTO Assunto (Nome) 
                 VALUES (@Nome); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   assunto.NomeAssunto
               }
           );

            assunto.IdAssunto = id;
            return assunto;
        }

        public IEnumerable<AssuntoCursoUsuario> Listar()
        {
            return Connection.Query<AssuntoCursoUsuario>(
              @"SELECT Id AS IdAssunto, Nome AS NomeAssunto FROM Assunto
                ORDER BY Nome ASC"
            ).ToList();
        }

        //public IEnumerable<AssuntoCursoUsuario> ListarTotalCursosPorAssunto()
        //{
        //    return Connection.Query<AssuntoCursoUsuario>(
        //      @"Select a.Id, a.Nome, Count(c.Id) as TotalCursos
        //        FROM Assunto a INNER JOIN curso c on a.Id = c.IdAssunto
        //        GROUP BY a.id, a.nome
        //        ORDER BY a.Nome"
        //    ).ToList();
        //}

        public AssuntoCursoUsuario Obter(int id)
        {
            return Connection.Query<AssuntoCursoUsuario>(
               "SELECT Id AS IdAssunto, Nome AS NomeAssunto FROM Assunto WHERE Id = @Id",
               param: new { Id = id }
           ).FirstOrDefault();
        }


        public AssuntoCursoUsuario Atualizar(AssuntoCursoUsuario assunto)
        {
            Connection.Execute(
               @"UPDATE Assunto SET 
                    Nome = @Nome
                WHERE Id = @Id",
               param: new
               {
                   assunto.NomeAssunto,
                   assunto.IdAssunto
               }
            );

            return assunto;
        }
        
        public void Excluir(AssuntoCursoUsuario assunto)
        {
            Connection.Execute(
                "DELETE FROM Assunto WHERE Id = @Id",
                param: new { Id = assunto.IdAssunto }
            );
        }

        public IEnumerable<AssuntoCursoUsuario> ListarCursosPorAssuntos(int? id)
        {
            return Connection.Query<AssuntoCursoUsuario>(
                @"SELECT c.Id, 
                    c.Nome,
                    a.Id AS IdAssunto,
                    u.Id AS IdAutor, 
                    u.Nome AS NomeAutor,
                    a.Nome AS NomeAssunto, 
                    c.DataCriacao FROM Curso c
	                INNER JOIN Usuario u ON c.IdAutor = u.Id
	                INNER JOIN Assunto a ON c.IdAssunto = a.Id
	                WHERE a.Id = @Id
                    ORDER BY a.Nome", 
                param: new { Id = id }
                ).ToList();
        }

        public IEnumerable<CursosPorAssunto> ListarTotalCursosPorAssunto()
        {
            return Connection.Query<CursosPorAssunto>(
              @"Select a.Id, 
                a.Nome AS NomeAssunto, 
                Count(c.Id) as TotalCursos
                FROM Assunto a INNER JOIN curso c on a.Id = c.IdAssunto
                GROUP BY a.id, a.nome
                ORDER BY a.Nome"
            ).ToList();
        }
    }
}
