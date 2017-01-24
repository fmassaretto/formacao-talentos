using Fatec.Treinamento.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Data.Repositories.Base;
using Dapper;

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
              "SELECT Id, Nome FROM Assunto"
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
    }
}
