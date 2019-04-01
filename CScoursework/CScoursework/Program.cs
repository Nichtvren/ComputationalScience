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
        static float H = 0.01f; // step size.
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
        static double A = 0.0; //inclusive lower bound.
        static double B = 0.0; //inclusive upper bound.
        static string line;
        static List<string> generatedData;
        static List<string> normalized;




        static void generate()
        {
            using (sw = new StreamWriter("Part1.csv"))
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
                        Console.WriteLine($"{t} : {x[k]} : {U}");
                        sw.WriteLine($"{t},{x[k]},{U}");
                        sw.Flush();
                        samples = 0;
                    }
                }
            }
            
        }

        static void randomness()
        {
            sr = new StreamReader("Part1.csv");
           
            random = new Random();
            generatedData = new List<string>();
            int iteration = 0; // iteration.
            double Xn;
            double z1;
            double z2 = 0;

            while ((line = sr.ReadLine()) != null)
            {
                generatedData.Add(line);
            }
            using (sw = new StreamWriter("Part2.csv"))
            {
                for (int i = 0; i < generatedData.Count; ++i)
                {
                    string[] line = generatedData[i].Split(new char[] { ',' });
                    Double.TryParse(line[0], out double t);
                    Double.TryParse(line[1], out double x);
                    Double.TryParse(line[2], out double u);

                    A = random.NextDouble() * (2 * Math.PI);
                    B = SD * Math.Sqrt(-2 * Math.Log(random.NextDouble()));

                    if (iteration == 0)
                    {
                        z1 = B * Math.Sin(A) + m;
                        z2 = B * Math.Cos(A) + m;
                        Xn = x + z1;
                        Console.WriteLine($"{t},{x},{Xn},{u}");


                        sw.WriteLine($"{t},{x},{Xn},{u}");


                        sw.Flush();
                        iteration = 1;
                    }
                    else if (iteration == 1)
                    {
                        Xn = x + z2;
                        Console.WriteLine($"{t},{x},{Xn},{u}");
                        sw.WriteLine($"{t},{x},{Xn},{u}");
                        sw.Flush();
                        iteration = 0;
                    }
                }
            }
        }

        static void perceptron()
        {
            sr = new StreamReader("Part2.csv");
            sw = new StreamWriter("Part3.csv");

            double currentMin = 1.0;
            double currentMax = 0.0;

            normalized = new List<string>();

            generatedData = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                generatedData.Add(line);
            }

            for(int i = 0; i < generatedData.Count; ++i)
            {
                string[] line = generatedData[i].Split(new char[] { ',' });
                Double.TryParse(line[2], out double xnoise);
               
                if(xnoise < currentMin)
                {
                    currentMin = xnoise;
                    
                }
                else if(xnoise > currentMax)
                {
                    currentMax = xnoise;

                }    
            }
            Console.WriteLine($"current min: {currentMin}\ncurrent max: {currentMax}");




        }


        static void Main(string[] args)
        {

            generate();
            randomness();
            perceptron();

            sw.Close();       
            Console.ReadLine();
        }
    }
}
