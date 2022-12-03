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
        Brush? RGBBrush;
        public MainWindow()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
        }

        private void btnAnimation1_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write("1");
            }
        }

        private void btnAnimation2_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write("0");
            }
        }

        private void btnAnimation3_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.WriteLine("A30");
            }
        }

        private void btnAnimation4_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.WriteLine("A40");
            }
        }

        private void sldRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RGBBrush = new SolidColorBrush(RGBcolor());
            cnvsColorPreview.Background = RGBBrush;
            if (_serialPort.IsOpen)
            {
                _serialPort.WriteLine("A45");
            }
        }

        private void sldGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RGBBrush = new SolidColorBrush(RGBcolor());
            cnvsColorPreview.Background = RGBBrush;
        }

        private void sldBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RGBBrush = new SolidColorBrush(RGBcolor());
            cnvsColorPreview.Background = RGBBrush;
        }

        private void cbxSerialSelect_DropDownOpened(object sender, EventArgs e)
        {
            cbxSerialSelect.Items.Clear();
            cbxSerialSelect.Items.Add("None");
            foreach (string ports in SerialPort.GetPortNames())
            {
                cbxSerialSelect.Items.Add(ports);
            }

            
        }

        private Color RGBcolor()
        {
            Color RGBcolor = new Color();
            RGBcolor = Color.FromRgb(Convert.ToByte(sldRed.Value), Convert.ToByte(sldGreen.Value), Convert.ToByte(sldBlue.Value));
            return RGBcolor;
        }

        private void cbxSerialSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
