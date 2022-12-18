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
        public SerialPort _serialPort = new SerialPort();
        Animations _animation = new Animations();
        Random _random = new Random();

        List<int> listRandom = new List<int>(); // Creates a list for random values
        int randomNumber;   // Used for random number storage.

        public int colorRed;
        public int colorGreen;
        public int colorBlue;
        public int colorCombo = 0;

        static double CUBE_SIDES_MULTIPLIER = 3;
        static double PLANE_SIDES_MULTIPLIER = 2;       // Modifiers for the calculation of the amount of leds.
        static double ROW_SIDES_MULTIPLIER = 1;

        static double LEDS_PER_ROW = 3;                 // Amount of leds per row, also for calculations. If the cube has a different amount of leds, change this.
        static int BYTES_PER_LED = 3;                   // Amount of bytes a led needs to work. This value should nor really change for the most part.

        static int amountOfLeds = Convert.ToInt16(Math.Pow(LEDS_PER_ROW, CUBE_SIDES_MULTIPLIER)); // Calculation for the total amount of leds.
        static int amountOfBytes = amountOfLeds * BYTES_PER_LED;

        static int WAIT_TIME = 200;                     // The amount of time between data outputs (in ms). Changes speed of leds changing.

        public MainWindow()
        {
            InitializeComponent();

        }

        async private void btnAnimation1_Click(object sender, RoutedEventArgs e)    // Random fill animation
        {
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());

            if (_serialPort.IsOpen)
            {
                int randomLed = 0;
                listRandom.Clear();
                for (int i = 0; i < amountOfLeds; i++)
                {
                    if (randomLed < amountOfLeds)   // Makes it so that no duplicates get send to the ledcube.
                    {
                        do
                        {
                            randomNumber = _random.Next(amountOfLeds);
                        } 
                        while (listRandom.Contains(randomNumber));
                        listRandom.Add(randomNumber);
                        randomLed++;
                    }

                    _animation.RGB_CubeFill(randomNumber, ColorButtons());
                    _serialPort.Write(_animation.Data, 0, amountOfBytes);
                    await Task.Delay(WAIT_TIME);
                }
            }
        }

        private async void btnAnimation2_Click(object sender, RoutedEventArgs e)    // Sequential fill animation
        {
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());
            
            if (_serialPort.IsOpen)
            {
                for (int i = 0; i < amountOfLeds; i++)
                {
                    _animation.RGB_CubeFill(i, ColorButtons());
                    _serialPort.Write(_animation.Data, 0, amountOfBytes);
                    await Task.Delay(WAIT_TIME);
                }
            }
        }

        private void btnAnimation3_Click(object sender, RoutedEventArgs e)  // RGB color change animation
        {
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());

            if (_serialPort.IsOpen)
            {
                _animation.RGB_Animation(ColorButtons());
                _serialPort.Write(_animation.Data, 0, amountOfBytes);
            }
        }

        private async void btnAnimation4_Click(object sender, RoutedEventArgs e) // Fill and empty the cube.
        {
            if (_serialPort.IsOpen)
            {
                lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());

                if (_serialPort.IsOpen)
                {
                    for (int i = 0; i < amountOfLeds; i++)
                    {
                        _animation.RGB_CubeFill(i, ColorButtons());
                        _serialPort.Write(_animation.Data, 0, amountOfBytes);
                        await Task.Delay(WAIT_TIME / 2);
                    }
                    for (int i = 0; i < amountOfLeds; i++)
                    {
                        _animation.RGB_CubeFill(i, 0);
                        _serialPort.Write(_animation.Data, 0, amountOfBytes);
                        await Task.Delay(WAIT_TIME / 2);
                    }
                }
            }
        }

        private async void btnAnimation5_Click(object sender, RoutedEventArgs e)    // Makes a runnen led. This does not take a color.
        {
            lblColor.Content = _animation.RGB_ColorCombo(ColorButtons());

            if (_serialPort.IsOpen)
            {
                for (int i = 0; i < amountOfLeds; i++)
                {
                    _animation.Running_LED(i);
                    _serialPort.Write(_animation.Data, 0, amountOfBytes);

                    await Task.Delay(WAIT_TIME);
                }
            }
        }

        private void cbxSerialSelect_DropDownOpened(object sender, EventArgs e) // Refreshes the list of COM-ports every time the combobox is opened.
        {
            cbxSerialSelect.Items.Clear();
            cbxSerialSelect.Items.Add("None");

            foreach (string ports in SerialPort.GetPortNames())
                cbxSerialSelect.Items.Add(ports);
        }

        private void cbxSerialSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)   // Opens the selected COM-port when selected
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                if (cbxSerialSelect.SelectedItem != null)
                {
                    if (cbxSerialSelect.SelectedItem.ToString() != "None")  // Confiquration to send to the specific led-cube we use.
                    {
                        _serialPort.PortName = cbxSerialSelect.SelectedItem.ToString() ?? "None";
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.BaudRate = 250000;
                        _serialPort.Parity = Parity.None;
                        _serialPort.Open();
                    }
                }
            }
        }

        public int ColorButtons()   // Changes the value of colorCombo so colorcombinations can be made.
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
