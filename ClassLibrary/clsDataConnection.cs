using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class clsDataConnection
    {
        private SqlConnection connectionToDB;
        private SqlDataAdapter dataChannel;
        private SqlCommandBuilder commandBuilder;
        private List<SqlParameter> SQLParams;
        private DataTable dataTable;
        private static string connectionString;

        public clsDataConnection()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set. Please ensure it is configured correctly.");
            }
            SQLParams = new List<SqlParameter>();
            dataTable = new DataTable();
        }

        public static void SetConnectionString(string connString)
        {
            connectionString = connString;
        }

        public void AddParameter(string paramName, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue);
            SQLParams.Add(param);
        }

        public void AddParameter(SqlParameter param)
        {
            SQLParams.Add(param);
        }

        public int Execute(string sProcName)
        {
            try
            {
                connectionToDB = new SqlConnection(connectionString);
                connectionToDB.Open();
                SqlCommand dataCommand = new SqlCommand(sProcName, connectionToDB);
                foreach (var param in SQLParams)
                {
                    dataCommand.Parameters.Add(param);
                }

                SqlParameter returnValue = new SqlParameter
                {
                    Direction = ParameterDirection.ReturnValue
                };
                dataCommand.Parameters.Add(returnValue);
                dataCommand.CommandType = CommandType.StoredProcedure;
                dataChannel = new SqlDataAdapter(dataCommand);
                commandBuilder = new SqlCommandBuilder(dataChannel);
                dataChannel.Fill(dataTable);
                connectionToDB.Close();
                return Convert.ToInt32(returnValue.Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error executing stored procedure {sProcName}: {ex.Message}");
                throw;
            }
        }

        public int Count
        {
            get
            {
                return dataTable.Rows.Count;
            }
        }

        public DataTable DataTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public List<SqlParameter> Parameters
        {
            get
            {
                return SQLParams;
            }
        }
    }
}
