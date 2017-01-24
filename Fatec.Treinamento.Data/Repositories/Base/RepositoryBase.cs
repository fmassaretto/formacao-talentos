using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fatec.Treinamento.Data.Repositories.Base
{
    /// <summary>
    /// Repositório base para as classes de repositório.
    /// Já possui os objetos de conexão.
    /// </summary>
    public abstract class RepositoryBase: IDisposable
    {
        private bool _disposed;

        protected IDbConnection Connection { get; private set; }

        protected RepositoryBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TreinamentoConnectionString"].ConnectionString;
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }
        
        #region Implementaçao do Pattern IDisposable

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~RepositoryBase()
        {
            dispose(false);
        }

        #endregion
    }
}
