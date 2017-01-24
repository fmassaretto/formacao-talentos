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
              "SELECT Id, Nome, Email, Senha, Ativo FROM Usuario"
            ).ToList();
        }
        
        public IEnumerable<Usuario> ListarPorNome(string nome)
        {
            return Connection.Query<Usuario>(
               "SELECT Id, Nome, Email, Senha, Ativo FROM Usuario WHERE Nome like @Nome",
               param: new { Nome = "%" + nome + "%" }
           ).ToList();
        }

        public Usuario Obter(int id)
        {

            return Connection.Query<Usuario, Perfil, Usuario>
            (
               @"SELECT
	                Usuario.Id,
	                Usuario.Nome,
	                Usuario.Email,
	                Usuario.Ativo,
	                Perfil.Id,
	                Perfil.Nome
                FROM
	                Usuario 
	                LEFT JOIN Usuario_Perfil on Usuario.Id = Usuario_Perfil.IdUsuario
	                LEFT JOIN Perfil on Usuario_Perfil.IdPerfil = Perfil.Id
                WHERE 
                    Usuario.Id = @Id",
               (usuario, perfil) =>
               {
                   if(perfil != null)
                       usuario.Perfis.Add(perfil);

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
               @"SELECT Id, Nome, Email, Senha, Ativo 
                 FROM Usuario 
                 WHERE Email = @Email AND Senha = @Senha And Ativo = 1",
               param: new
               {
                   Email = email,
                   Senha = senha
               }
           ).FirstOrDefault();
        }
    }
}
