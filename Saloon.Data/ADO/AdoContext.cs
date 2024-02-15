using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Saloon.Common;

namespace Saloon.Data.ADO
{
    public static class AdoContext
    {
        public static ConnectionDefinition defaultConnection { get; set; } = new ConnectionDefinition { ConnectionString = CommonAppConfig.GetConnectionString("DefaultConnection") };
        

        public static async Task<List<T>> GetList<T>(this ConnectionDefinition connectionDefinition, string query, List<SqlParameter> sqlParams)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionDefinition.ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());

                var sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                await sqlConnection.OpenAsync();

                var data = new DataTable();
                sqlDataAdapter.Fill(data);

                await sqlConnection.CloseAsync();

                return data.ConvertDataTable<T>();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static async Task<T> Get<T>(this ConnectionDefinition connectionDefinition, string query, List<SqlParameter> sqlParams)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionDefinition.ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());

                var sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                await sqlConnection.OpenAsync();

                var data = new DataTable();
                sqlDataAdapter.Fill(data);

                await sqlConnection.CloseAsync();

                return data.ConvertDataTable<T>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public static async Task<T> GetCell<T>(this ConnectionDefinition connectionDefinition, string query, List<SqlParameter> sqlParams)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionDefinition.ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());

                var sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                await sqlConnection.OpenAsync();

                T data = (T)sqlCommand.ExecuteScalar();

                await sqlConnection.CloseAsync();

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<double[][]> GetTrend(this ConnectionDefinition connectionDefinition, string query, List<SqlParameter> sqlParams)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionDefinition.ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());

                var sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                await sqlConnection.OpenAsync();

                var data = new DataTable();
                sqlDataAdapter.Fill(data);

                await sqlConnection.CloseAsync();

                return data.AsEnumerable().Select(row => new[] { Convert.ToDouble(row["x"]), Convert.ToDouble(row["y"]) }).ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static T GetItem<T>(DataRow dr)
        {
            try
            {
                var genericProperties = typeof(T).GetProperties();
                T obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in dr.Table.Columns)
                {
                    var pro = genericProperties.FirstOrDefault(x => x.Name.ToLower().Equals(column.ColumnName.ToLower()));
                    if (pro != null)
                    {
                        var value = dr[column.ColumnName] != DBNull.Value && dr[column.ColumnName] != null ? dr[column.ColumnName] : null;
                        pro.SetValue(obj, value, null);
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
