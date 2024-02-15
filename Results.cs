using System;
using System.Collections.Generic;
using System.Linq;
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
            }
        }// Display
    }// Results (class)
}// SBTlib (namespace)
