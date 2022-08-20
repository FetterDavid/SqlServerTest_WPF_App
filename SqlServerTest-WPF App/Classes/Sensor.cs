using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SqlServerTest_WPF_App.Classes
{
    internal class Sensor
    {
        public void SaveData(string sensorName, string sensorType)
        {
            try
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"];
                SqlConnection con = new SqlConnection(settings.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("SaveSensor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SensorName", sensorName));
                cmd.Parameters.Add(new SqlParameter("@SensorType", sensorType));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Error when inserting data to the database.");
            }
        }
    }
}
