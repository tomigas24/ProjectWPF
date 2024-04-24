using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Launch
    {
        #region Methods
        public static DataTable ListLaunch()
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ListLaunch";

                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                connection.Close();
            }
            catch (Exception e)
            {
            }
            return dataTable;

        }

        public static DataTable ListLaunch(string filter)
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                string commandString = $"SELECT * FROM [Launch] WHERE [GameId] LIKE @Filter";

                command.CommandText = commandString;
                SqlParameter parameter = new SqlParameter("Filter", SqlDbType.NVarChar, -1);
                parameter.Value = "%" + filter + "%";
                command.Parameters.Add(parameter);

                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                connection.Close();
            }
            catch (Exception e)
            {
            }
            return dataTable;

        }

        public static bool GetLaunch(long id, ref long gameId, ref DateTime releaseDate, ref float rating, ref float price, ref long salesNumber, ref long platformId, ref long publisherId, out string error)
        {
            bool ok = true;
            error = "";
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetLaunch";

                SqlParameter parameter = new SqlParameter("Id", SqlDbType.BigInt);
                parameter.Value = id;
                command.Parameters.Add(parameter);

                SqlDataReader sqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        gameId = sqlDataReader.GetInt64(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        releaseDate = sqlDataReader.GetDateTime(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        rating = sqlDataReader.GetFloat(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        price = sqlDataReader.GetFloat(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        salesNumber = sqlDataReader.GetInt64(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        platformId = sqlDataReader.GetInt64(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        publisherId = sqlDataReader.GetInt64(7);
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
