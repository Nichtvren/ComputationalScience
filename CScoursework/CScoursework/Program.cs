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
        static StreamWriter sw;
        static StreamReader sr;
        static Random random;
        static float[] x;
        static float H = 0.1f; // step size.
        static float a = -2;
        static float b = 2;
        static float U = 0; // direction.
        static float Tf = 15; // final time.
        static float T0 = 0; // initial time.
        static float n; 
        static float t = 0; // time to take.
        static int samples = 0;
        static float m = 0.0f; // mean.
        static float SD = 0.001f; // standard deviation.
        double X = 0.0; // xnoise.
        double A = 0.0; //inclusive lower bound.
        double B = 0.0; //inclusive upper bound.
        static string[] fileData;





        static void generate()
        {
            sw = new StreamWriter("Part1.csv");
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
                    sw.WriteLine(t + "," + x[k] + "," + U);
                    sw.Flush();
                    samples = 0;
                }           
            }
        }

        static void randomness()
        {
            sr = new StreamReader("Part2.csv");
            random = new Random();


            

        }

        static void Main(string[] args)
        {

            generate();

            sw.Close();       
            Console.ReadLine();
        }
    }
}
