using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CarbonKeyOverhaul
{
    public class DbConnector
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public DbConnector(string connectionStringName) // Constructor to initialize connection string
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query) // Pass query result in view for datagridview
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw it as needed
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }
        public DataTable InvoiceDataQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log, or throw it as needed
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return dataTable;
        }
    }
}
