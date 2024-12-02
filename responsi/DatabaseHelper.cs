using System;
using System.Data;
using Npgsql;
using responsi;

// Base Class: DatabaseHelper
// Base Class: DatabaseHelper
public class DatabaseHelper : Interface1
{
    protected string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=responsi";

    // Implementasi dari metode di interface IDatabaseHelper
    public DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters)
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

    public void ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
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


