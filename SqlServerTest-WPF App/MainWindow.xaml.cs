using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SqlServerTest_WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"];
            SqlConnection con = new SqlConnection(settings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SaveSensor ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            string sensorName = SensorNameTB.Text;
            string sensorType = SensorTypeTB.Text;

            cmd.Parameters.Add(new SqlParameter("@SensorName",sensorName));
            cmd.Parameters.Add(new SqlParameter("@SensorType",sensorType));

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
