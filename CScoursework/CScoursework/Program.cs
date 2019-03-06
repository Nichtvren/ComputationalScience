using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace computational_science
{
    class Program
    {
        static StreamWriter file = new StreamWriter("Part1.csv");
        static Random random = new Random();
        static float[] x;
        static float H = 0.1f;
        static float a = -2;
        static float b = 2;
        static float U = 0;
        static float Tf = 15;
        static float T0 = 0;
        static float n;
        static float t = 0;
        static int samples = 0;
        static float m = 0.0f;
        static float SD = 0.001f;
        

        


        static void generate()
        {
            n = (Tf - T0) / H;
            x = new float[(int)n + 2];
            x[0] = 1;
            for (int k = 0; k < n; ++k)
            {
                if (t < 5)
                {
                    U = 2;
                }
                if (5 < t && t <= 10)
                {
                    U = 1;
                }
                if (10 < t && t <= 15)
                {
                    U = 3;
                }
                x[k + 1] = x[k] + H * (a * x[k] + b * U);
                t = t + H;

                ++samples;

                if (samples == 10)
                {
                    Console.WriteLine(t + " : " + x[k] + " : " + U);
                    file.WriteLine(t + "," + x[k] + "," + U);
                    file.Flush();
                    samples = 0;
                }           
            }
        }

        static void randomness()
        {
            double x = 0.0;
            double a = 0.0; //inclusive lower bound.
            double b = 0.0; //inclusive upper bound.

            b = 2 * Math.PI;

            x = random.Next((int)a, (int)b);

           // b = SD - 2

        }

        static void Main(string[] args)
        {

            generate();

            file.Close();       
            Console.ReadLine();
        }
    }
}
