using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
        // Initializes connection string from web.config if not already set
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        SQLParams = new List<SqlParameter>();
        dataTable = new DataTable();
    }

    private string GetConnectionString()
    {
        // Downloads connection string from local server
        System.Net.WebClient client = new System.Net.WebClient();
        string downloadString = client.DownloadString("http://localhost:5000/");
        return downloadString;
    }

    public static void SetConnectionString(string connString)
    {
        connectionString = connString;
    }

    public void AddParameter(string paramName, object paramValue)
    {
        // Ensures DateTime values are within the SQL Server valid range
        if (paramValue is DateTime dateValue)
        {
            if (dateValue == DateTime.MinValue)
            {
                paramValue = SqlDateTime.MinValue.Value; // Set to SQL Server minimum date if DateTime.MinValue
            }
            else if (dateValue < SqlDateTime.MinValue.Value || dateValue > SqlDateTime.MaxValue.Value)
            {
                throw new ArgumentOutOfRangeException($"DateTime value {dateValue} is out of range for SQL Server.");
            }
        }

        SqlParameter param = new SqlParameter(paramName, paramValue);
        SQLParams.Add(param);
    }

    public int Execute(string sProcName)
    {
        // Initializes and open the database connection
        connectionToDB = new SqlConnection(connectionString);
        connectionToDB.Open();
        // Initializes the command for the connection
        SqlCommand dataCommand = new SqlCommand(sProcName, connectionToDB);
        foreach (var param in SQLParams)
        {
            dataCommand.Parameters.Add(param);
        }
        dataCommand.CommandType = CommandType.StoredProcedure;
        // Initializes data adapter and command builder
        dataChannel = new SqlDataAdapter(dataCommand);
        commandBuilder = new SqlCommandBuilder(dataChannel);
        dataChannel.Fill(dataTable);
        connectionToDB.Close();
        return 0;
    }

    public int ExecuteWithOutput(string sProcName, SqlParameter outputParam)
    {
        // Initializes and open the database connection
        connectionToDB = new SqlConnection(connectionString);
        connectionToDB.Open();
        // Initializes the command for the connection
        SqlCommand dataCommand = new SqlCommand(sProcName, connectionToDB);
        foreach (var param in SQLParams)
        {
            dataCommand.Parameters.Add(param);
        }
        dataCommand.Parameters.Add(outputParam);
        dataCommand.CommandType = CommandType.StoredProcedure;
        // Initializes data adapter and command builder
        dataChannel = new SqlDataAdapter(dataCommand);
        commandBuilder = new SqlCommandBuilder(dataChannel);
        dataChannel.Fill(dataTable);
        connectionToDB.Close();
        // Returns the value of the output parameter
        return Convert.ToInt32(outputParam.Value);
    }

    public int Count
    {
        get { return dataTable.Rows.Count; }
    }

    public DataTable DataTable
    {
        get { return dataTable; }
        set { dataTable = value; }
    }
}
