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
    public class PerfilRepository : RepositoryBase, IPerfilRepository
    {
        public Perfil Inserir(Perfil perfil)
        {
            Connection.Execute(
               @"INSERT INTO Perfil (Id, Nome) 
                 VALUES (@Id, @Nome);",
               param: new
               {
                   perfil.Id,
                   perfil.Nome
               }
           );

            return perfil;
        }

        public IEnumerable<Perfil> Listar()
        {
            return Connection.Query<Perfil>(
              "SELECT Id, Nome FROM Perfil"
            ).ToList();
        }
        
        public Perfil Obter(int id)
        {
            return Connection.Query<Perfil>(
               "SELECT Id, Nome FROM Perfil WHERE Id = @Id",
               param: new { Id = id }
           ).FirstOrDefault();
        }

        public Perfil Atualizar(Perfil perfil)
        {
            Connection.Execute(
               @"UPDATE Perfil SET 
                    Nome = @Nome
                WHERE Id = @Id",
               param: new
               {
                   perfil.Nome,
                   perfil.Id
               }
            );

            return perfil;
        }
        
        public void Excluir(Perfil perfil)
        {

            var trans = Connection.BeginTransaction();

            try
            {
                // Exclui todas as permissões associadas a esse perfil antes:
                Connection.Execute(
                    "DELETE FROM Permissao WHERE IdPerfil = @Id",
                    param: new { perfil.Id },
                    transaction: trans
                );

                Connection.Execute(
                     "DELETE FROM Perfil WHERE Id = @Id",
                     param: new { perfil.Id },
                     transaction: trans
                );

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
            }
        }

        public void InserirPermissoes(int idPerfil, IList<Funcionalidade> funcionalidades)
        {

            // Cria uma lista contento IdPerfil,IdFuncionalidade, seguindo o modelo a inserir
            var lista = (from x in funcionalidades
                select new
                {
                    IdPerfil = idPerfil,
                    IdFuncionalidade = x.Id
                }).ToList();

            var trans = Connection.BeginTransaction();

            try
            {
                // Exclui todos os itens para inserir tudo novamente.
                Connection.Execute(
                    "DELETE FROM Permissao WHERE IdPerfil = @Id",
                    param: new { Id = idPerfil },
                    transaction: trans
                );

                Connection.Execute(
                    @"INSERT INTO Permissao (IdPerfil, IdFuncionalidade) 
                      VALUES(@IdPerfil, @IdFuncionalidade)",
                    param: lista,
                    transaction: trans
                );
                
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
            }
        }

        public IEnumerable<Funcionalidade> ObterPermissoes(int idPerfil)
        {
            return Connection.Query<Funcionalidade>(
              @"SELECT f.Id, f.Nome 
                FROM Permissao p
                INNER JOIN funcionalidade f ON p.IdFuncionalidade = f.Id
                WHERE p.IdPerfil = @IdPerfil",
              new { IdPerfil = idPerfil}
            ).ToList();
        }
    }
}
