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
        static StreamWriter file = new StreamWriter(@"\\adir.hull.ac.uk\home\512\512910\Desktop\ComputationalScience.txt");
        static float[] x = new float[1];
        static float H = 0.01f;
        static float a = -2;
        static float b = 2;
        static float U = 0;
        static float Tf = 100;
        static float T0 = 0;
        static float n;
        static float t = 0;


        static void Main(string[] args)
        {
            n = Tf - T0 / H;
            x = new float[(int)n + 1];
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
                t = t + H;

                x[k + 1] = x[k] + H * (a * x[k] + b * U);

                Console.WriteLine(t + " : " + x[k] + " : " + U);
                file.WriteLine(t + " : " + x[k] + " : " + U);
                file.Flush();
            }

            file.Close();       

            Console.ReadLine();
        }
    }
}
