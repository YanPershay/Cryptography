using System;
using System.Collections.Generic;

namespace Congruent
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in GenerateArray(x0)) Console.Write(i + " ");
            Console.WriteLine();
        }
        
        static int a = 430;
        static int c = 2531;
        static int n = 11979;
        static int x0 = 5;
        
        static int Generator(int xn)
        {
            return (a * xn + c) % n;
        }

        static int[] GenerateArray(int x_0)
        {
            List<int> intArray = new List<int>();
            intArray.Add(x_0);
            int xn = Generator(x_0);
            while (xn != x_0)
            {
                intArray.Add(xn);
                xn = Generator(xn);
            }
            return intArray.ToArray();
        }
    }
}