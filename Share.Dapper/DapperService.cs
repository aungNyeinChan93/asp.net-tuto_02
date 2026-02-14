using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Share.Dapper
{
    public class DapperService
    {
        private readonly string? _connection;

        public DapperService(string connection)
        {
            this._connection = connection;
        }

        public List<T>? Query<T>(string query,object? parameters = null)
        {
            using (IDbConnection db = new SqlConnection(this._connection))
            {
                var result = db.Query<T>(query, parameters).ToList();
                return result;
            }
        }

        public bool Excute(string query , object? parameters = null)
        {
            using (IDbConnection db = new SqlConnection(this._connection))
            {
               var result =  db.Execute(query,parameters);

                return result >= 1;
            }
        }

    }
}
