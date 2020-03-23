using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_SmallestCommonFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers for NOD:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"NOD({x},{y}) = {SmallestCommonFactor(x, y)}");
            Console.WriteLine();

            Console.WriteLine("Enter number for check on simple:");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine($"Is the number {s} simple? It is {IsSimple(s)}.");
            Console.WriteLine();

            Console.WriteLine("Enter start of interval:");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter end of interval:");
            int n = int.Parse(Console.ReadLine());

            SimplesInInterval(m, n);

            Console.WriteLine("Enter number for reverse:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter module");
            int module = int.Parse(Console.ReadLine());

            if (IsSimple(SmallestCommonFactor(number, module)))
            {
                Evklid(number, module);
            }
            else
            {
                Console.WriteLine("NOD != 1");
            }
        }

        private static void Evklid(int a, int m)
        {
            a = a % m;

            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                   Console.WriteLine($"Reverse element for {a} by mod {m} is {x}"); 
                }  
            }    
        }
        
        static int SmallestCommonFactor(int x, int y)
        {
            while(x !=0 && y != 0)
            {
                if (x > y)
                    x -= y;

                else
                    y -= x;
            }

            return Math.Max(x, y);
        }

        static bool IsSimple(int x)
        {
            if (x == 1)
                return true;

            else
            {
                for (int i = 2; i * i <= x; i++) 
                {
                    if (x % i == 0)
                        return false;
                }
            }

            return true;
        }

        static void SimplesInInterval(int m, int n)
        {
            if(n < m)
            {
                Console.WriteLine("Incorrect values.");
            }

            Console.Write($"Simple numbers on interval [{m},{n}]: ");

            for (int i = m; i <= n; i++)
            {
                if (IsSimple(i))
                {
                    Console.Write(i.ToString() + " ");
                }
            }
        }
    }
}

