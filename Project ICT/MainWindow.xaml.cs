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
using System.IO.Ports;

namespace Project_ICT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort _serialPort;
        public MainWindow()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
        }

        private void btnAnimation1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAnimation2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnimation3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnimation4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sldRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void sldGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void sldBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void cbxSerialSelect_DropDownOpened(object sender, EventArgs e)
        {
            cbxSerialSelect.Items.Clear();
            cbxSerialSelect.Items.Add("None");
            foreach (string s in SerialPort.GetPortNames())
            {
                cbxSerialSelect.Items.Add(s);
            }

            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                if (cbxSerialSelect.SelectedItem != null)
                {
                    if (cbxSerialSelect.SelectedItem.ToString() != "None")
                    {
                        _serialPort.PortName = cbxSerialSelect.SelectedItem.ToString();
                        _serialPort.Open();
                    }
                }
            }
        }
    }
}
