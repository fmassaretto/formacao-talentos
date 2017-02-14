using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Data.Repositories
{
    public class AdminUsuarioRepository : RepositoryBase
    {

        public Usuario Atualizar(Usuario usuario)
        {
            Connection.Execute(
               @"UPDATE Usuario SET Usuario.Nome = @Nome, 
                                 Usuario.Email = @Email,
                                 Usuario.IdPerfil = @Perfil,
                                 Usuario.Ativo = @Ativo
					WHERE Usuario.Id = @Id",
               param: new
               {
                   Nome = usuario.Nome,
                   Email = usuario.Email,
                   Perfil = usuario.PerfilSelecionado,
                   Ativo = usuario.Ativo,
                   Id = usuario.Id
               }

            );
               return usuario;
        }

        public Usuario Inserir(Usuario usuario)
        {
            var id = Connection.ExecuteScalar<int>(
                    @"INSERT INTO Usuario (Nome, Email, Senha, Ativo, IdPerfil)
                                VALUES (@Nome, @Email, @Senha, @Ativo, @Perfil);
                        SELECT SCOPE_IDENTITY()",
                    param: new
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Senha = usuario.HashSenha,
                        Ativo = usuario.Ativo,
                        Perfil = usuario.PerfilSelecionado
                    }
                );

            usuario.Id = id;

            return usuario;
        }

        public void Excluir(Usuario usuario)
        {
            Connection.Execute(
               @"DELETE FROM Usuario WHERE Id = @Id",
               param: new
               {
                   Id = usuario.Id
               }
            );
        }

        public IEnumerable<Usuario> ListaUsuario()
        {
            return Connection.Query<Usuario>(
                @"SELECT Id, Nome FROM Usuario"
                ).ToList();
        }

    }
}
