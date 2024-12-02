using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responsi
{
    // Inheritance concept untuk class turunan: KaryawanHelper
    public class KaryawanHelper : DatabaseHelper
    {
        // Polymorphism: Overloading metode untuk fleksibilitas parameter
        public void InsertKaryawan(string name, int depId, int jabatanId)
        {
            string query = "SELECT insert_karyawan(@name, @depId, @jabatanId)";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@name", name),
                new NpgsqlParameter("@depId", depId),
                new NpgsqlParameter("@jabatanId", jabatanId));
        }

        public void InsertKaryawan(string name, int depId)
        {
            InsertKaryawan(name, depId, jabatanId: 0);
        }

        public void EditKaryawan(int id, string name, int depId, int jabatanId)
        {
            string query = "SELECT edit_karyawan(@id, @name, @depId, @jabatanId)";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@id", id),
                new NpgsqlParameter("@name", name),
                new NpgsqlParameter("@depId", depId),
                new NpgsqlParameter("@jabatanId", jabatanId));
        }

        public void DeleteKaryawan(int id)
        {
            string query = "SELECT delete_karyawan(@id)";
            ExecuteNonQuery(query, new NpgsqlParameter("@id", id));
        }

        public DataTable LoadKaryawan()
        {
            string query = "SELECT * FROM get_karyawan()";
            return ExecuteQuery(query);
        }
    }

}
