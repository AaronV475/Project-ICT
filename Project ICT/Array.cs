//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Project_ICT
//{
//    internal class Array
//    {
//        byte[,,] cube = new byte[,,] { { { 9, 9, 9 } } };
//        byte[,,] cubes = new byte[,,] 
//        { 
//            { 
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            },
//            {
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//            }
//        };
//        void ClearCube()
//        {
//            memset(cube, 0, 125 * sizeof cube[0][0][0]);
//        }

//        // turns on a specific LED
//        void LedOn(int x, int y, int z)
//        {
//            cube[x, y, z] = 1;
//        }
//        // turns off a specific LED
//        void LedOff(int x, int y, int z)
//        {
//            cube[x, y, z] = 0;
//        }


//        // This code is for 5x5x5 but can be converted to a 9x9x9

//        // ***************************** Begin Pulsing Sphere ******************************************
//        // creates a shpere which grows and shrinks 
//        void PulsingSphere()
//        {
//            float count;
//            for (int k = 0; k < 10; k++)
//            {
//                for ( count = 0.5f; count < 2.8; count += 0.3f)
//                { // expand the radius
//                    Sphere(count);
//                }
//                for (count = 2.7f; count > 0.5; count -= 0.3f)
//                { // contaract the radius
//                    Sphere(count);
//                }
//            }
//        }

//        // this routine creates a sphere in the cube of a specified radius
//        void Sphere(float radius)
//        {
//            float polar, j, k, l;
//            for (int x = 0; x < 9; x++)
//            { // scan thru each led in the cube
//                for (int y = 0; y < 9; y++)
//                {
//                    for (int z = 0; z < 9; z++)
//                    {
//                        j = Convert.ToSingle(x); // convert coordinates to floating point to compute distance from center of cube
//                        k = Convert.ToSingle(y);
//                        l = Convert.ToSingle(z);
//                        polar = (float)Math.Sqrt((j - 2) * (j - 2) + (k - 2) * (k - 2) + (l - 2) * (l - 2)); // Calculate the distance
//                        if (polar < radius)
//                        { // if an LED is inside the radius specified, turn it on.
//                            LedOn(x, y, z);
//                        }
//                        else
//                        { // otherwise turn it off
//                            LedOff(x, y, z);
//                        }
//                    }
//                }
//            }
//            delay(20);  // control speed
//        }
//        // ***************************** End Pulsing Sphere ******************************************
//    }
//}
