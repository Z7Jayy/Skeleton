using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class clsDataConnection
{
    // Connection object used to connect to the database
    private SqlConnection connectionToDB;
    // Data adapter used to transfer data to and from the database
    private SqlDataAdapter dataChannel;
    // Command builder for building SQL commands
    private SqlCommandBuilder commandBuilder;
    // Stores a list of all the SQL parameters
    private List<SqlParameter> SQLParams;
    // Data table used to store the results of the stored procedure
    private DataTable dataTable;
    // String variable used to store the connection string
    private string connectionString;
    public clsDataConnection()
    {
        // Initialize the connection string from web.config
        connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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
        // Create a new instance of the SQL parameter object
        SqlParameter param = new SqlParameter(paramName, paramValue);
        // Add the parameter to the list
        SQLParams.Add(param);
    }
    public int Execute(string sProcName)
    {
        // Initialize the connection to the database
        connectionToDB = new SqlConnection(connectionString);
        // Open the database
        connectionToDB.Open();
        // Initialize the command for this connection
        SqlCommand dataCommand = new SqlCommand(sProcName, connectionToDB);
        // Add the parameters to the command builder
        foreach (var param in SQLParams)
        {
            dataCommand.Parameters.Add(param);
        }
        // Create an instance of the SqlParameter class for the return value
        SqlParameter returnValue = new SqlParameter
        {
            Direction = ParameterDirection.ReturnValue
        };
        dataCommand.Parameters.Add(returnValue);
        // Set the command type as stored procedure
        dataCommand.CommandType = CommandType.StoredProcedure;
        // Initialize the data adapter
        dataChannel = new SqlDataAdapter(dataCommand);
        // Use the command builder to generate SQL insert, delete, etc.
        commandBuilder = new SqlCommandBuilder(dataChannel);
        // Fill the data table
        dataChannel.Fill(dataTable);
        // Close the connection
        connectionToDB.Close();
        // Return the result of the stored procedure
        return Convert.ToInt32(returnValue.Value);
    }
    public int Count
    {
        get
        {
            // Return the count of records in the query results
            return dataTable.Rows.Count;
        }
    }
    public DataTable DataTable
    {
        get
        {
            // Return the query results
            return dataTable;
        }
        set
        {
            // Set the query results
            dataTable = value;
        }
    }
}