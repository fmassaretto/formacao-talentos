using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Data.Repositories.Interfaces;
using Fatec.Treinamento.Model;
using Dapper;

namespace Fatec.Treinamento.Data.Repositories
{
    public class UsuarioRepository: RepositoryBase, IUsuarioRepository
    {
        public Usuario Inserir(Usuario usuario)
        {
            var id = Connection.ExecuteScalar<int>(
               @"INSERT INTO Usuario (Nome, Email, Senha, Ativo) 
                 VALUES (@Nome, @Email, @Senha, @Ativo); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   usuario.Nome,
                   usuario.Email,
                   Senha = usuario.HashSenha,
                   usuario.Ativo
               }
           );

            usuario.Id = id;
            return usuario;
        }

        public IEnumerable<Usuario> Listar()
        {
            return Connection.Query<Usuario>(
              "SELECT Nome, Email, Senha, Ativo FROM Usuario"
            ).ToList();
        }
        
        public IEnumerable<Usuario> ListarPorNome(string nome)
        {
            return Connection.Query<Usuario>(
               "SELECT Nome, Email, Senha, Ativo FROM Usuario WHERE Nome like @Nome",
               param: new { Nome = "%" + nome + "%" }
           ).ToList();
        }

        public Usuario Obter(int id)
        {
            return Connection.Query<Usuario>(
               "SELECT Id, Nome, Email, Senha, Ativo FROM Usuario WHERE Id = @Id",
               param: new { Id = id }
           ).FirstOrDefault();
        }


        public Usuario Atualizar(Usuario usuario)
        {
            Connection.Execute(
               @"UPDATE Usuario SET 
                    Nome = @Nome,
                    Email = @Email,
                    Ativo = @Ativo
                WHERE Id = @Id",
               param: new
               {
                   usuario.Nome,
                   usuario.Email,
                   usuario.Ativo,
                   usuario.Id
               }
            );

            return usuario;
        }

        public Usuario AtualizarSenha(Usuario usuario)
        {
            Connection.Execute(
               @"UPDATE Usuario SET 
                    Senha = @Senha,
                WHERE Id = @Id",
               param: new
               {
                   Senha = usuario.HashSenha,
                   usuario.Id
               }
            );

            return usuario;
        }

        public void Excluir(int id)
        {
            Connection.Execute(
                "DELETE FROM Usuario WHERE Id = @Id",
                param: new { Id = id }
            );
        }
    }
}
