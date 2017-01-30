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
        public Assunto Inserir(Assunto assunto)
        {
            var id = Connection.ExecuteScalar<int>(
               @"INSERT INTO Assunto (Nome) 
                 VALUES (@Nome); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   assunto.Nome
               }
           );

            assunto.Id = id;
            return assunto;
        }

        public IEnumerable<Assunto> Listar()
        {
            return Connection.Query<Assunto>(
              @"SELECT Id, Nome FROM Assunto
                ORDER BY Nome ASC"
            ).ToList();
        }

        public IEnumerable<CursosPorAssunto> ListarTotalCursosPorAssunto()
        {
            return Connection.Query<CursosPorAssunto>(
              @"Select a.Id, a.Nome, Count(c.Id) as TotalCursos
                FROM Assunto a INNER JOIN curso c on a.Id = c.IdAssunto
                GROUP BY a.id, a.nome
                ORDER BY a.Nome"
            ).ToList();
        }

        public Assunto Obter(int id)
        {
            return Connection.Query<Assunto>(
               "SELECT Id, Nome FROM Assunto WHERE Id = @Id",
               param: new { Id = id }
           ).FirstOrDefault();
        }


        public Assunto Atualizar(Assunto assunto)
        {
            Connection.Execute(
               @"UPDATE Assunto SET 
                    Nome = @Nome
                WHERE Id = @Id",
               param: new
               {
                   assunto.Nome,
                   assunto.Id
               }
            );

            return assunto;
        }
        
        public void Excluir(Assunto assunto)
        {
            Connection.Execute(
                "DELETE FROM Assunto WHERE Id = @Id",
                param: new { Id = assunto.Id }
            );
        }

        public IEnumerable<Assunto> ListarCursosPorAssuntos(int? id)
        {
            return Connection.Query<Assunto>(
                @"SELECT c.Id AS IdCurso, 
                    c.Nome AS NomeCurso, 
                    u.Nome AS Autor,
                    a.Nome AS Assunto, 
                    c.DataCriacao FROM Curso c
	                INNER JOIN Usuario u ON c.IdAutor = u.Id
	                INNER JOIN Assunto a ON c.IdAssunto = a.Id
	                WHERE a.Id = @Id
                    ORDER BY a.Nome", 
                param: new { Id = id }
                ).ToList();
        }
    }
}
