using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Publisher
    {
        #region Methods
        public static DataTable GetPublisher()
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListPublisher";

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                connection.Close();
            }
            catch (Exception e)
            {
            }
            return dataTable;

        }

        public static DataTable GetList(string filter)
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                string comando = $"SELECT * FROM [Publisher] WHERE [PublisherName] LIKE @Filter";

                cmd.CommandText = comando;
                SqlParameter param = new SqlParameter("Filter", SqlDbType.NVarChar, -1);
                param.Value = "%" + filter + "%";
                cmd.Parameters.Add(param);

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                connection.Close();
            }
            catch (Exception e)
            {
            }
            return dataTable;

        }

        public static bool GetPublisher(long id, ref string publisherName, out string error)
        {
            bool ok = true;
            error = "";
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPublisher";

                SqlParameter param = new SqlParameter("Id", SqlDbType.BigInt);
                param.Value = id;
                cmd.Parameters.Add(param);

                SqlDataReader sqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        publisherName = sqlDataReader.GetString(1);
                    }

                    ok = true;
                }

                connection.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
                ok = false;
            }
            return ok;
        }
        #endregion
    }
}
