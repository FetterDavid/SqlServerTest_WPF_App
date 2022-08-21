using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SqlServerTest_WPF_App.Classes
{
    internal class Sensor
    {
        private ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"];

        public void SaveData(string sensorName, string sensorType)
        {
            try
            {
               
                SqlConnection con = new SqlConnection(settings.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("SaveSensor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SensorName", sensorName));
                cmd.Parameters.Add(new SqlParameter("@SensorType", sensorType));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This sensor name is already used.");
                    return;
                }

                MessageBox.Show("Error when inserting data to the database.");
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error.");
            }
        }
        public void RemoveData(string sensorName, string sensorType)
        {
            SqlConnection con = new SqlConnection(settings.ConnectionString);
            con.Open();

            string sqlQuery = " delete from Sensor where SensorName = '"+sensorName+ "' and SensorTypeId = (select SensorTypeId " +
                "from Sensor_Type where SensorType = '"+sensorType+"'); ";

            SqlCommand cmd = new SqlCommand(sqlQuery,con);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
