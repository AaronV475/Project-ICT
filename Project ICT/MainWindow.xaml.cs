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
using System.Security;
using System.Security.Cryptography;
using System.Windows.Media.Animation;

namespace Project_ICT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SerialPort _serialPort;
        Animations _animation = new Animations();

        public int colorRed;
        public int colorGreen;
        public int colorBlue;
        public int colorCombo = 0;
        public double cubeSize = 3;
        public double cube = 3;
        public double plane = 2;
        public double row = 1;
        
        public MainWindow()
        {
            InitializeComponent();

            _serialPort = new SerialPort();

        }

        private void btnAnimation1_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {

            }
        }

        private async void btnAnimation2_Click(object sender, RoutedEventArgs e)
        {
            int ledAmount = Convert.ToInt16(Math.Pow(cubeSize, cube));
            for (int i = 0; i < ledAmount; i++)
            {
                _animation.RGB_CubeFill(i, ColorButtons());
                lblData.Content = String.Join(" ", _animation.data3);
                await Task.Delay(500);
            }
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());
            if (_serialPort.IsOpen)
            {
            }
        }

        private void btnAnimation3_Click(object sender, RoutedEventArgs e)
        {
            _animation.RGB_Animation(ColorButtons());
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());
            lblData.Content = String.Join(" ", _animation.data3);
            if (_serialPort.IsOpen)
            {
                
            }
        }

        private void btnAnimation4_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
 
            }
        }

        private void cbxSerialSelect_DropDownOpened(object sender, EventArgs e)
        {
            // Refreshed de displayed ports in de combobox.
            cbxSerialSelect.Items.Clear();
            cbxSerialSelect.Items.Add("None");
            foreach (string ports in SerialPort.GetPortNames())
            {
                cbxSerialSelect.Items.Add(ports);
            }
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
                        _serialPort.PortName = cbxSerialSelect.SelectedItem.ToString() ?? "None";
                        _serialPort.Open();
                    }
                }
            }
        }

        public int ColorButtons()
        {
            if (chbRed.IsChecked ?? false)
                colorRed = 1;
            else
                colorRed = 0;

            if (chbGreen.IsChecked ?? false)
                colorGreen = 2;
            else
                colorGreen = 0;

            if (chbBlue.IsChecked ?? false)
                colorBlue = 4;
            else
                colorBlue = 0;

            return colorCombo = colorRed + colorGreen + colorBlue;
            // colorCombo: 1 = red, 2 = green, 3 = yellow, 4 = blue, 5 = magenta, 6 = cyan, 7 = white
        }
    }
}
