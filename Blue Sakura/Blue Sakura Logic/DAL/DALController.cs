using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace Blue_Sakura_Logic.DAL
{
    public static class DALController
    {
        private static string connectionStr = "Server=studmysql01.fhict.local;Username=dbi450046;Database=dbi450046;Password=Mrf3MwW8di;ssl mode= none";
        //private static string connectionStr = "Server=localhost;Username=root;Database=dbi450046;Password=;ssl mode= none";
        private static MySqlConnection connection = new MySqlConnection(connectionStr);

        private static MySqlParameter GetParam(KeyValuePair<string, dynamic> keyValuePair)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = "@" + keyValuePair.Key,
                Value = keyValuePair.Value
            };
            return param;
        }

        //execute sql to get data
        public static DataSet ExecuteSql(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                DataSet dataset = new DataSet();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand mySqlCommand = connection.CreateCommand();

                foreach (KeyValuePair<string, dynamic> keyValuePair in parameters)
                {
                    mySqlCommand.Parameters.Add(GetParam(keyValuePair));
                }

                mySqlCommand.CommandText = sql;
                dataAdapter.SelectCommand = mySqlCommand;
                connection.Open();
                dataAdapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                DataSet result = new DataSet();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        //execute sql to update data in database
        public static bool ExecuteInsert(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                MySqlCommand mySqlCommand = connection.CreateCommand();
                foreach (KeyValuePair<string, dynamic> keyValuePair in parameters)
                {
                    mySqlCommand.Parameters.Add(GetParam(keyValuePair));
                }
                mySqlCommand.CommandText = sql;
                connection.Open();
                mySqlCommand.ExecuteScalar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
