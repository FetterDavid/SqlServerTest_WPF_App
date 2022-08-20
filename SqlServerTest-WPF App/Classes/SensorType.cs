using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SqlServerTest_WPF_App.Classes
{
    internal class SensorType
    {
        private ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"];

        public int sensorTypeId { get; set; }
        public string sensorTypeName { get; set; }

        public List<SensorType> GetSensorTypes()
        {
            List<SensorType> sensorTypes = new List<SensorType>();

            SqlConnection con = new SqlConnection(settings.ConnectionString);
            con.Open();

            string sqlQuerry = "select SensorTypeId, SensorType from Sensor_Type order by SensorType";

            SqlCommand cmd = new SqlCommand(sqlQuerry, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    SensorType sensorType = new SensorType();

                    sensorType.sensorTypeId = Convert.ToInt32(dr["SensorTypeId"]);
                    sensorType.sensorTypeName = dr["SensorType"].ToString();

                    sensorTypes.Add(sensorType);
                }
            }

            con.Close();
            return sensorTypes;
        }

    }
}
