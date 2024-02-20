using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hypergaph
{
    /// <summary> Класс для инкапсуляции результатов рациональной аппроксимации.
    /// </summary>
    public class Results
    {
        int numerator, denominator;

        double number, approx, error;

        List<Tuple<int, int, double>> sequence;

        public Results(int p, int q, double x, double _approx,
                        List<Tuple<int, int, double>> _sequence)
        {
            numerator = p;
            denominator = q;
            number = x;
            approx = _approx;
            error = x - _approx;
            sequence = _sequence;
        }// Results (constructor)

        public int Numerator { get { return numerator; } }
        public int Denominator { get { return denominator; } }

        public void RationalFraction(List<int> V)
        {
         /*   for (int i = 0; i < V.Count; i++)
            {
                Console.WriteLine("V[i] : " + V[i]);
            }*/
            int size = V.Count;
            Console.WriteLine("Length: " + size);
            V[size - 2] = V[size-1] * V[size-2] + 1;
            Console.WriteLine("V[" + (size - 2) + "] : " + V[size - 2]);
            for (int i = size-3; i > -1; i--)
            {
                V[i] = V[i + 1] * V[i] + V[i+2];
                //Console.WriteLine("V[i] : " + V[i]);
            }
            Console.WriteLine("Rational fraction: " + V[0] + " " + V[1]);

        }

        public void GetChainShot(int k, int z)
        {
           /* int n = 50;  // так плохо делать надо что-то придумать
            int[] H = new int[n];
            int[] Z = new int[n];*/
            List<int> V = new List<int>();
            List<int> Z = new List<int>();
            List<int> H = new List<int>();
            //int[] V = new int[n];



            H.Add(k);
            
            Z.Add(z);
            Console.WriteLine("числитель: " + H[0] + "\n");
            Console.WriteLine("знаменатель:" + Z[0] + "\n");
            Console.WriteLine(" [ ");
            int i = 0;
            while (Z[i] != 0)
            {
                V.Add(H[i] / Z[i]);

                Console.WriteLine(V[i]);
                Z.Add(H[i] - Z[i] * V[i]);
                H.Add(Z[i]);
                i++;
            }
            Console.WriteLine("] \n");

            /*
            for (int i = 0; i < n; i++)
            {
                if (Z[i] == 0)
                {
                    Console.WriteLine("] \n");
                    break;
                }
                else
                {
                    V[i] = H[i] / Z[i];

                    Console.WriteLine( V[i]);
                    Z[i + 1] = H[i] - Z[i] * V[i];
                    H[i + 1] = Z[i];
                }
            }*/
            Console.WriteLine("Rational fraction function start: ");
            RationalFraction(V);
        }
        public void Display(int decPlaces)
        {
            if (sequence.Count > 0)
            {
                Console.WriteLine("\nРациональное приближение к {0}\n с {1} десятичными знаками:\n",
                                   number, decPlaces);

                string formatStr
                   = "{0,4}/{1,4} == {2,"
                     + (decPlaces + 5).ToString() + ":F" + decPlaces.ToString() + "}";

                foreach (Tuple<int, int, double> tuple in sequence)
                {
                    Console.WriteLine(formatStr, tuple.Item1, tuple.Item2, tuple.Item3);
                }

                Console.WriteLine("\nFinal result:\n");
                Console.WriteLine(formatStr, numerator, denominator, approx);
                Console.WriteLine();
                Console.WriteLine("test examples: ");
                GetChainShot(5, 3);
                GetChainShot(5, 2);
                GetChainShot(71, 41);
                Console.WriteLine("Current Shot:");
                // Представление дроби в виде цепной
                GetChainShot(numerator, denominator);

            }
        }// Display


        }// Results (class)
}// SBTlib (namespace)
