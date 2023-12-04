using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarbonKeyOverhaul
{
    public class tenantPicker
    {
    //    private void PopulateDatabaseComboBox()
    //    {
    //        string connectionString = "Server=YourServerName;Integrated Security=true;"; // Modify connection string with your server details

    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            try
    //            {
    //                connection.Open();

    //                // Query to retrieve database names
    //                string query = "SELECT name FROM sys.databases WHERE database_id > 4"; // Exclude system databases

    //                SqlCommand command = new SqlCommand(query, connection);
    //                SqlDataReader reader = command.ExecuteReader();

    //                while (reader.Read())
    //                {
    //                    string dbName = reader["name"].ToString();
    //                    comboBox1.; // Add database names to ComboBox
    //                }

    //                reader.Close();
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show("Error: " + ex.Message);
    //            }
    //            finally
    //            {
    //                connection.Close();
    //            }
    //        }

    //    }
    }
}
