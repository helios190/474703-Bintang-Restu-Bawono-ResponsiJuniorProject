using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responsi
{
    internal interface Interface1
    {
        DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters);
        void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters);
    }
}
