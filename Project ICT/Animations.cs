﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ICT
{
    internal class Animations
    {
        public string colorString = "Off";

        public byte[] data = new byte[] { // Hiermee specifiek de led aansturen en de 3 waardes van de led.
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public void RGB_Animation(int colorCombo)
        {
            switch (colorCombo)
            {
                case 0: // Dark
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = 0;
                    }
                    break;
                case 1: // Red
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 255;
                        data[i + 1] = 0;
                        data[i + 2] = 0;
                    }
                    break;
                case 2: // Green
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 0;
                        data[i + 1] = 255;
                        data[i + 2] = 0;
                    }
                    break;
                case 3: // Yellow
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 255;
                        data[i + 1] = 255;
                        data[i + 2] = 0;
                    }
                    break;
                case 4: // Blue
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 0;
                        data[i + 1] = 0;
                        data[i + 2] = 255;
                    }
                    break;
                case 5: // Magenta
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 255;
                        data[i + 1] = 0;
                        data[i + 2] = 255;
                    }
                    break;
                case 6: // Cyan
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        data[i] = 0;
                        data[i + 1] = 255;
                        data[i + 2] = 255;
                    }
                    break;
                case 7: // White
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = 255;
                    }
                    break;
                default: // Any other values will make the cube dark
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = 0;
                    }
                    break;
            }
        }

        public string RGB_ColorCombo(int colorInt)
        {
            switch (colorInt)
            {
                case 0: // Dark
                    return colorString = "Off";
                case 1: // Red
                    return colorString = "Red";
                case 2: // Green
                    return colorString = "Green";
                case 3: // Yellow
                    return colorString = "Yellow";
                case 4: // Blue
                    return colorString = "BLue";
                case 5: // Magenta
                    return colorString = "Magenta";
                case 6: // Cyan
                    return colorString = "Cyan";
                case 7: // White
                    return colorString = "White";
                default: // Any other values will make the cube dark
                    return colorString = "Off";
            }
        }

        public void RGB_CubeFill(int ledNmbr, int colorCombo)
        {
            switch (colorCombo)
            {
                case 0: // Dark
                    data[ledNmbr * 3] = 0;
                    data[ledNmbr * 3 + 1] = 0;
                    data[ledNmbr * 3 + 2] = 0;
                    break;
                case 1: // Red
                        data[ledNmbr * 3] = 255;
                        data[ledNmbr * 3 + 1] = 0;
                        data[ledNmbr * 3 + 2] = 0;
                    break;
                case 2: // Green
                        data[ledNmbr * 3] = 0;
                        data[ledNmbr * 3 + 1] = 255;
                        data[ledNmbr * 3 + 2] = 0;
                    break;
                case 3: // Yellow
                        data[ledNmbr * 3] = 255;
                        data[ledNmbr * 3 + 1] = 255;
                        data[ledNmbr * 3 + 2] = 0;
                    break;
                case 4: // Blue
                        data[ledNmbr * 3] = 0;
                        data[ledNmbr * 3 + 1] = 0;
                        data[ledNmbr * 3 + 2] = 255;
                    break;
                case 5: // Magenta
                        data[ledNmbr * 3] = 255;
                        data[ledNmbr * 3 + 1] = 0;
                        data[ledNmbr * 3 + 2] = 255;
                    break;
                case 6: // Cyan
                        data[ledNmbr * 3] = 0;
                        data[ledNmbr * 3 + 1] = 255;
                        data[ledNmbr * 3 + 2] = 255;
                    break;
                case 7: // White
                        data[ledNmbr * 3] = 255;
                        data[ledNmbr * 3 + 1] = 255;
                        data[ledNmbr * 3 + 2] = 255;
                    break;
                default: // Any other values will make the cube dark
                        data[ledNmbr * 3] = 0;
                        data[ledNmbr * 3 + 1] = 0;
                        data[ledNmbr * 3 + 2] = 0;
                    break;
            }
        }
    }
}
