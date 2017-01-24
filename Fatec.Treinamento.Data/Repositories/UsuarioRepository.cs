using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Data.Repositories.Interfaces;
using Fatec.Treinamento.Model;
using Dapper;
using Fatec.Treinamento.Model.Extensoes;

namespace Fatec.Treinamento.Data.Repositories
{
    public class UsuarioRepository: RepositoryBase, IUsuarioRepository
    {

        private const string CONSULTA_COM_PERFIL = 
                @"SELECT
	                Usuario.Id,
	                Usuario.Nome,
	                Usuario.Email,
	                Usuario.Ativo,
	                Perfil.Id,
	                Perfil.Nome
                FROM
	                Usuario 
	                INNER JOIN Perfil on Usuario.IdPerfil = Perfil.Id ";




        public Usuario Inserir(Usuario usuario)
        {
            var id = Connection.ExecuteScalar<int>(
               @"INSERT INTO Usuario (Nome, Email, Senha, Ativo, IdPerfil) 
                 VALUES (@Nome, @Email, @Senha, @Ativo, @IdPerfil); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   usuario.Nome,
                   usuario.Email,
                   Senha = usuario.HashSenha,
                   usuario.Ativo,
                   IdPerfil = usuario.Perfil.Id
               }
           );

            usuario.Id = id;
            return usuario;
        }

        public IEnumerable<Usuario> Listar()
        {
              return Connection.Query<Usuario, Perfil, Usuario>(
              CONSULTA_COM_PERFIL,
              (usuario, perfil) =>
              {
                  if (perfil != null)
                      usuario.Perfil = perfil;

                  return usuario;
              }
            ).ToList();
        }
        
        public IEnumerable<Usuario> ListarPorNome(string nome)
        {
            return Connection.Query<Usuario, Perfil, Usuario>(
               CONSULTA_COM_PERFIL + @"WHERE Usuario.Nome like @Nome",
               (usuario, perfil) =>
               {
                   if (perfil != null)
                       usuario.Perfil = perfil;

                   return usuario;
               },
               param: new { Nome = "%" + nome + "%" }
           ).ToList();
        }

        public Usuario Obter(int id)
        {

            return Connection.Query<Usuario, Perfil, Usuario>
            (
               CONSULTA_COM_PERFIL + @"WHERE Usuario.Id = @Id",
               (usuario, perfil) =>
               {
                   if (perfil != null)
                       usuario.Perfil = perfil;

                   return usuario;
               },
	           param: new { Id = id }
           ).FirstOrDefault();
        }


        public Usuario Atualizar(Usuario usuario)
        {
            Connection.Execute(
               @"UPDATE Usuario SET 
                    Nome = @Nome,
                    Email = @Email,
                    Ativo = @Ativo,
                    IdPerfil = @IdPerfil
                WHERE Id = @Id",
               param: new
               {
                   usuario.Nome,
                   usuario.Email,
                   usuario.Ativo,
                   usuario.Id,
                   IdPerfil = usuario.Perfil.Id
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

        public void Excluir(Usuario usuario)
        {
            Connection.Execute(
                "DELETE FROM Usuario WHERE Id = @Id",
                param: new { Id = usuario.Id }
            );
        }

        public Usuario Login(string email, string senha)
        {
            senha = senha.GerarHash();

            return Connection.Query<Usuario>(
               CONSULTA_COM_PERFIL + 
                 @"WHERE Email = @Email AND Senha = @Senha And Ativo = 1",
               param: new
               {
                   Email = email,
                   Senha = senha
               }
           ).FirstOrDefault();
        }
    }
}
