using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract.SqlFactory
{
    public interface ISqlObjectFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbCommand GetCommand(string _sql);
        DbCommand GetCommand(string _sql, DbConnection _conn);
        DbParameter GetParameter(string _paramName, object _value);
        string GetConnectionString();
    }
}
