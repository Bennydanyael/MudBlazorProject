using Common.Abstract.SqlFactory;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common.SqlFactory
{
    public static class SqlExtensions
    {
        public static DbCommand Command(this DbConnection connection, ISqlObjectFactory sqlObjectFactory, string sql)
        {
            var command = sqlObjectFactory.GetCommand(sql, connection);
            return command;
        }

        public static DbCommand AddParameter(this DbCommand command, ISqlObjectFactory sqlObjectFactory, string parameterName, object value)
        {
            var parameter = sqlObjectFactory.GetParameter(parameterName, value);
            command.Parameters.Add(parameter);
            return command;
        }

        public static object ExecuteAndReturnIdentity(this DbCommand command)
        {
            if (command.Connection == null)
                throw new Exception("SqlCommand has no connection.");
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            command.CommandText = "SELECT @@IDENTITY";
            var result = command.ExecuteScalar();
            return result;
        }

        public static DbDataReader ReadOne(this DbDataReader reader, Action<DbDataReader> action)
        {
            if (reader.Read())
                action(reader);
            reader.Dispose();
            return reader;
        }

        public static DbDataReader ReadAll(this DbDataReader reader, Action<DbDataReader> action)
        {
            while (reader.Read())
                action(reader);
            reader.Dispose();
            return reader;
        }

        public static void Using(this DbConnection connection, Action<DbConnection> action)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    action(connection);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static QueryFactory DatabaseQueryFactory(this DbConnection connection)
        {
            var database = new QueryFactory(connection, new SqlServerCompiler());
            return database;
        }

        public static object GetObjectOrDbNull(this object value)
        {
            return value ?? DBNull.Value;
        }
        public static int? NullIntDbHelper(this DbDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return null;
            return reader.GetInt32(index);
        }

        public static double? NullDoubleDbHelper(this DbDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return null;
            return reader.GetDouble(index);
        }

        public static DateTime? NullDateTimeDbHelper(this DbDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return null;
            return reader.GetDateTime(index);
        }

        public static string NullStringDbHelper(this DbDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return null;
            return reader.GetString(index);
        }

        public static Guid? NullGuidDbHelper(this DbDataReader reader, int index)
        {
            if (reader.IsDBNull(index)) return null;
            return reader.GetGuid(index);
        }
        public static string NullToEmpty(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;
            return text;
        }
    }
}
