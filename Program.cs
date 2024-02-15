// C# Implementation of the above graph

using Hypergaph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

class GFG
{
    static private BigInteger C(BigInteger n, BigInteger k) // C_n^k = n!/(k!(n-k)!)
    {
        BigInteger res = 1;
       /* res *= Fact(n);
        res /= Fact(k);
        res *= Fact(n-k);*/
        for (int i = 1; i < n; i++)
            res *= (i+1);
        for (int i = 1; i < k; i++)
            res /= (i + 1);
        for (int i = 1; i < (n-k); i++)
            res /= (i + 1);
        return res;
    }

    static BigInteger Fact(BigInteger value)
    {
        BigInteger result = new BigInteger(1);

        for (int i = 1; i < value; i++)
        {
            result *= i;
        }

        return result;
    }

    static void printList(List<BigInteger> list)
    {
        for (int i = 0; i < list.Count; i++)
            Console.WriteLine(list[i]);
    }

    static public List<BigInteger> Cgen(BigInteger i, BigInteger n, BigInteger k)
    {
        List<BigInteger> c = new List<BigInteger>();
        BigInteger r = i + 0;
        BigInteger j = 0;
        for (BigInteger s = 1; s < (k + 1); s++)
        {
            BigInteger cs = j + 1;
            while (r - C(n-cs, k-s) > 0)
            {
                r -= C(n-cs, k-s);
                cs += 1;
            }
            c.Add(cs);
            j = cs;
        }
        printList(c);
        return c;
    }

    static double MySumPow(int n)
    {
        double res = 0;
        for (int i = 0; i < n; i++)
        {
            res += Math.Pow(2, (i-1));
        }
        return res; 
    }
    


    public static void Main()
    {
        Console.WriteLine("Factorial 1000: " + Fact(1000));
        Console.WriteLine("C(10, 3) = " + C(10, 3));
       // Console.WriteLine("Factorial 10: " + Fact(10));
        // Console.WriteLine(cgen(173103094564, 100, 10));
        List<BigInteger>  list = Cgen(173103094564, 100, 10);
       // List<long> list = Cgen(17, 100, 10);
        Console.WriteLine("Answer: \n" );
        printList(list);

        List<BigInteger> list2 = Cgen(101, 10, 3);
        // List<long> list = Cgen(17, 100, 10);
        Console.WriteLine("Answer2: \n");
        printList(list2);

        // TheSternBrokawTree(2);

        TheSternRrokawTree tree = new TheSternRrokawTree();
        Results results;

        results = tree.Approximate(3.14159265359, 6);
        results.Display(6);

        tree.Reset();

        results = tree.Approximate(0.56, 6);
        results.Display(6);

        tree.Reset();
        results = tree.Approximate(0.0, 6);
        results.Display(6);
        tree.Reset();
        results = tree.Approximate(-5.67, 6);
        results.Display(6);
    }
}
