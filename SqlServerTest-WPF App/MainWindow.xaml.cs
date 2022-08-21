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
using SqlServerTest_WPF_App.Classes;

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
            FillSensorTypeComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        void SaveData()
        {
            string sensorName = SensorNameTB.Text;
            string sensorType = ComboSensorType.Text;

            if (sensorName == "")
            {
                MessageBox.Show("Sensor name is invalid.");
            }
            else if (sensorType == "")
            { 
                MessageBox.Show("You have to choose a sensor type.");
            }
            else
            {
                Sensor sensor = new Sensor();
                sensor.SaveData(sensorName, sensorType);
                SensorNameTB.Text = "";
            }
        }

        void FillSensorTypeComboBox()
        {
            SensorType sensorType = new SensorType();

            List<SensorType> sensorTypeList = sensorType.GetSensorTypes();

            foreach (SensorType sensorTypeItem in sensorTypeList)
            {
                ComboSensorType.Items.Add(sensorTypeItem.sensorTypeName);
            }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            RemoveData();
        }

        private void RemoveData()
        {
            string sensorName = SensorNameTB.Text;
            string sensorType = ComboSensorType.Text;

            Sensor sensor =new Sensor();
            sensor.RemoveData(sensorName, sensorType);
        }
    }
}
