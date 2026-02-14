using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperService
{
    public class Dapper
    {
        private readonly string? _connection;

        public Dapper(string connection)
        {
            this._connection = connection;
        }

        public List<T>? Query<T>(string query,params List<DapperQueryParameter> parameters)
        {
            using (IDbConnection db = new SqlConnection(this._connection))
            {
                var result =  db.Query<T>(query,parameters).ToList();
                return result;
            }
        }
    }

    public class DapperQueryParameter
    {
        public string? Name { get; set; }

        public object? Value { get; set; }
    }
}
