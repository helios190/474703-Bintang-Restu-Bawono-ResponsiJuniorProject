using System;
using System.Data;
using Npgsql;

// Base Class: DatabaseHelper
public class DatabaseHelper
{
    protected string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=responsi";

    // Encapsulation: Membatasi akses ke properti dan metode dengan akses modifier protected.
    protected DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during query execution: " + ex.Message);
            throw;
        }
    }

    protected void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during non-query execution: " + ex.Message);
            throw;
        }
    }
}

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

// Derived Class: ReferensiHelper
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