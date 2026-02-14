using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetService
{
    public class AdoService
    {
        private readonly string? _connectionStr;

        public AdoService(string  connection)
        {
            this._connectionStr = connection;
        }

        public DataTable? Query(string query,params List<SqlQueryParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(this._connectionStr);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            if(parameters.Count >= 1)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public bool Excute(string query, params List<SqlQueryParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(this._connectionStr);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);

            if(parameters.Count >= 1)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Name,parameter.Value);
                }
            }

            var result = cmd.ExecuteNonQuery();
            connection.Close();

            return result >= 1;
        }
    }

    public class SqlQueryParameter
    {
        public string? Name { get; set; } 

        public object? Value { get; set; }   
    }
}
