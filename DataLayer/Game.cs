using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Game
    {
        #region Methods
        public static DataTable ListGame()
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
                command.CommandText = "ListGame";

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

        public static DataTable ListGame(string filter)
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

                string commandString = $"SELECT * FROM [Game] WHERE [GameName] LIKE @Filter";

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

        public static bool GetGame(long id,ref string gameName, ref string gameImage, ref long genderId, out string error)
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
                command.CommandText = "GetGame";

                SqlParameter parameter = new SqlParameter("Id", SqlDbType.BigInt);
                parameter.Value = id;
                command.Parameters.Add(parameter);

                SqlDataReader sqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        gameImage = sqlDataReader.GetString(1);
                    }
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        gameName = sqlDataReader.GetString(2);
                    }
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        genderId = sqlDataReader.GetInt64(3);
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
