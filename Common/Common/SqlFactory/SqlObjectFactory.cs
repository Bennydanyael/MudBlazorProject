using Common.Abstract.SqlFactory;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common.SqlFactory
{
    public class SqlObjectFactory : ISqlObjectFactory
    {
        private string _connString = "Server=HALELUYAH\\SQLEXPRESS;Database=BaseProject;Trusted_Connection=False;User ID=sa;Password=Sabeso76;MultipleActiveResultSets=true;TrustServerCertificate=true";
        //private DbConnection DbConnection;

        //public async Task<IDbConnection> CreateConnectionAsync()
        //{
        //    var _sqlConnection = new SqlConnection(_connString);
        //    if (string.IsNullOrWhiteSpace(_connString)) throw new Exception("No Database connection string found...");
        //    if (_sqlConnection.State == ConnectionState.Closed) await _sqlConnection.OpenAsync();
        //    return _sqlConnection;
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public DbCommand GetCommand(string _sql)
        {
            return new SqlCommand(_sql);
        }

        public DbCommand GetCommand(string _sql, DbConnection _conn)
        {
            return new SqlCommand(_sql, (SqlConnection)_conn);
        }

        public DbConnection GetConnection()
        {
            var _sqlConnection = new SqlConnection(_connString);
            if (string.IsNullOrWhiteSpace(_connString)) throw new Exception("No Database connection string found...");
            return _sqlConnection;
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            return new SqlConnection(_connString).ConnectionString;
        }

        public DbParameter GetParameter(string _paramName, object _value)
        {
            return new SqlParameter(_paramName, _value);
        }
    }
}
