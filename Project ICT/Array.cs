using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ICT
{
    internal class Array
    {
        public int[,,,] data = new int[,,,]    // In theorie kan je hiermee zowel de volledige cube, een plane, een row of een enkele LED aansturen
        {                                      // 3 planes to form the cube
            {                                  // 3 rows to form a plane
                { {0,0,0}, {0,0,0}, {0,0,0} }, // 3 LEDS to form a row
                { {0,0,0}, {0,0,0}, {0,0,0} },
                { {0,0,0}, {0,0,0}, {0,0,0} }
            },
            {
                { {0,0,0}, {0,0,0}, {0,0,0} },
                { {0,0,0}, {0,0,0}, {0,0,0} },
                { {0,0,0}, {0,0,0}, {0,0,0} }
            },
            {
                { {0,0,0}, {0,0,0}, {0,0,0} },
                { {0,0,0}, {0,0,0}, {0,0,0} },
                { {0,0,0}, {0,0,0}, {0,0,0} }
            }
        };
        // OR

        public int[,] data2 = new int[,] { // Hiermee specifiek de led aansturen en de 3 waardes van de led.
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
            { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        // turns verything off
        void clearCube()
        {
            
        }

        // turns on a specific LED
        void ledOn(int x, int y, int z)
        {
            //data = [1,1,1,1];
        }
        // turns off a specific LED
        void ledOff(int x, int y, int z)
        {
            //cube[x][y][z] = 0;
        }

        // show cube for a multiples of 10 ms before clearing it.
        void showCube(int mytime)
        {
            //delay(10 * mytime);
            clearCube();
        }

        // clear the cube and wait 1/2 second
        void pause()
        {  // pause between animations
            clearCube();
            //delay(500);
        }
        void panels()
        {
            for (int k = 0; k < 3; k++)
            {
                for (int z = 4; z > -1; z--)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
                for (int z = 0; z < 5; z++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
                for (int x = 0; x < 5; x++)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
                for (int x = 4; x > -1; x--)
                {
                    for (int z = 0; z < 5; z++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
                for (int y = 4; y > -1; y--)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            ledOn(x, y, z);
                        }
                    }
                    showCube(4);
                }
            }
            pause();
        }
    }
}
