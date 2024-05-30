using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class clsDataConnection
{
    private SqlConnection connectionToDB;
    private SqlDataAdapter dataChannel;
    private SqlCommandBuilder commandBuilder;
    private List<SqlParameter> SQLParams;
    private DataTable dataTable;
    private string connectionString;

    public clsDataConnection()
    {

        // Initialize the connection string from web.config
        connectionString = GetConnectionString();
        SQLParams = new List<SqlParameter>();
        dataTable = new DataTable();
      
    }


    private string GetConnectionString()
    {
        System.Net.WebClient client = new System.Net.WebClient();
        string downloadString = client.DownloadString("http://localhost:5000/");
        return downloadString;
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
        catch (Exception ex)
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
