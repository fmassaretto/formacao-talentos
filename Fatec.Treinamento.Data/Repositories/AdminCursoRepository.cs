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
    public class AdminCursoRepository : RepositoryBase
    {

        public AssuntoCursoUsuario Atualizar(AssuntoCursoUsuario acu)
        {
            Connection.Execute(
               @"BEGIN TRANSACTION;

				UPDATE Curso SET Curso.Nome = @Nome, 
                                 Curso.IdAutor = @IdAutor,
                                 Curso.IdAssunto = @IdAssunto,
                                 Curso.DataCriacao = @DataCriacao,
                                 Curso.Nivel = @Nivel,
                                 Curso.Img = @Img
					WHERE Curso.Id = @IdCurso;

				UPDATE Curso_Descricao SET Descricao = @Descricao
					WHERE Curso_Descricao.IdCurso = @IdCursoDescricao

				COMMIT;",
               param: new
               {
                   Nome = acu.Nome,
                   IdAutor = acu.UsuarioSelecionado,
                   IdAssunto = acu.AssuntoSelecionado,
                   DataCriacao = acu.DataCriacao,
                   Nivel = acu.Nivel,
                   Img = acu.Img,
                   Descricao = acu.Descricao,
                   IdCurso = acu.IdCurso,
                   IdCursoDescricao = acu.IdCurso
               }

            );
               return acu;
        }

        public AssuntoCursoUsuario Inserir(AssuntoCursoUsuario acu)
        {
            var id = Connection.ExecuteScalar<int>(
                    @"INSERT INTO Curso (Nome, IdAutor, IdAssunto, DataCriacao, Nivel, Img)
                                VALUES (@Nome, @IdAutor, @IdAssunto, GETDATE(), @Nivel, @Img);
                        SELECT SCOPE_IDENTITY()",
                    param: new
                    {
                        Nome = acu.Nome,
                        IdAutor = acu.UsuarioSelecionado,
                        IdAssunto = acu.AssuntoSelecionado,
                        Nivel = acu.Nivel,
                        Img = acu.Img
                    }
                );

            acu.IdCurso = id;

            Connection.Execute(
                    @"INSERT INTO Curso_Descricao (Descricao, IdCurso)
                                VALUES (@Descricao, @IdCurso)",
                    param: new
                    {
                        Descricao = acu.Descricao,
                        IdCurso = id
                    }
                );
            return acu;
        }

        public void Excluir(AssuntoCursoUsuario acu)
        {
            Connection.Execute(
               @"BEGIN TRANSACTION;

				DELETE FROM Curso_Descricao WHERE IdCurso = @IdCurso

				DELETE FROM Curso WHERE Id = @Id

				COMMIT;",
               param: new
               {
                   IdCurso = acu.IdCurso,
                   Id = acu.IdCurso
               }
            );
        }

        public IEnumerable<Usuario> ListaUsuario()
        {
            return Connection.Query<Usuario>(
                @"SELECT Id, Nome FROM Usuario"
                ).ToList();
        }

        public IEnumerable<Assunto> ListaAssunto()
        {
            return Connection.Query<Assunto>(
                @"SELECT Id, Nome FROM Assunto"
                ).ToList();
        }



    }
}
