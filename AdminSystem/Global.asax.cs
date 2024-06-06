using System;
using System.Web;
using System.Configuration;
using ClassLibrary;

namespace AdminSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            var connStr = ConfigurationManager.ConnectionStrings["ConnectionString"];
            string connectionString = connStr == null ? null : connStr.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not loaded.");
            }

            clsDataConnection.SetConnectionString(connectionString);
        }

        // Other event handlers...
    }
}
