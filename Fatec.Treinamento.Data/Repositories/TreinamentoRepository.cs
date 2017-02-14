using Dapper;
using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Data
{
    public class TreinamentoRepository : RepositoryBase
    {
        public TreinamentoCurso ObterTreinamento(int idUsuario, int idCurso)
        {
            return Connection.Query<TreinamentoCurso>(
               @"SELECT
                    t.Id, 
                    IdUsuario, 
                    IdCurso, 
                    DataInicio, 
                    UltimoAcesso, 
                    DataConclusao,
					u.Id AS IdUsuario,
					u.Nome AS NomeUsuario
                FROM Treinamento t
				INNER JOIN Usuario u ON u.Id = t.IdUsuario
                WHERE IdUsuario = @IdUsuario 
                And IdCurso = @IdCurso; 
               SELECT SCOPE_IDENTITY()",
               param: new {
                   IdUsuario = idUsuario,
                   IdCurso = idCurso
               }
           ).FirstOrDefault();
        }

        public void ComecarTreinamento(int idUsuario, int idCurso)
        {
            Connection.ExecuteScalar(
                @"INSERT INTO Treinamento (IdUsuario, IdCurso, DataInicio, UltimoAcesso) 
                    VALUES (@IdUsuario,@IdCurso,GETDATE(),GETDATE())",
                new
                {
                    IdUsuario = idUsuario,
                    IdCurso = idCurso
                }
            );
        }

        public void AtualizarUltimoAcessoTreinamento(int id)
        {
            Connection.ExecuteScalar(
                @"UPDATE Treinamento SET UltimoAcesso = GETDATE() 
                    Where Id = @Id",
                new
                {
                    Id = id
                }
            );
        }

        public void AtualizarDataConclusaoTreinamento(int id)
        {
            Connection.ExecuteScalar(
                @"UPDATE Treinamento SET DataConclusao = GETDATE() 
                    Where Id = @Id",
                new
                {
                    Id = id
                }
            );
        }

        public int PontosUsuario(int idUsuario)
        {
            return Connection.Query<int>(
                @"SELECT Sum(Pontos) 
                    FROM Treinamento_Capitulo 
                    WHERE IdUsuario = @IdUsuario",
                new { IdUsuario = idUsuario }
                ).FirstOrDefault();
        }

        public IEnumerable<TreinamentoCurso> ListarTodosTreinamentos(int idUsuario)
        {
            return Connection.Query<TreinamentoCurso>(
                    @"SELECT 
                        IdCurso, 
                        DataInicio, 
                        UltimoAcesso, 
                        DataConclusao 
                    FROM Treinamento 
                    WHERE IdUsuario = @IdUsuario",
                    new { IdUsuario = idUsuario }
                    ).ToList();
        }

    }
}
