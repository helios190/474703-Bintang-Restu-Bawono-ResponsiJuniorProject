using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responsi
{
    public class ReferensiHelper : DatabaseHelper
    {
        public DataTable LoadDepartemen()
        {
            string query = "SELECT * FROM get_departemen()";
            return ExecuteQuery(query);
        }

        public DataTable LoadJabatan()
        {
            string query = "SELECT * FROM get_jabatan()";
            return ExecuteQuery(query);
        }
    }
}
