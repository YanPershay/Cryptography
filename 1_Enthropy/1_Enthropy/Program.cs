using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Enthropy
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathEng = $"rus.txt";
            string engAlphabet = "abcdefghijklmnopqrstuvwxyz";

            string pathBin = $"bin.txt";
            string binAlphabet = "10";

            ShannonEnthropyFile(pathEng, engAlphabet);
            Console.WriteLine($"English alphavet enthropy: {ShannonEntropyString(engAlphabet)}");

            Console.WriteLine();

            ShannonEnthropyFile(pathBin, binAlphabet);
            Console.WriteLine($"Binary alphavet enthropy: {ShannonEntropyString(binAlphabet)}");
            Console.WriteLine();

            string name = "pershayyanborisovich";
            Console.WriteLine($"Name:{name}");
            double countOfInfo = ShannonEntropyString(engAlphabet) * name.Length;
            Console.WriteLine($"FIO count of information = {countOfInfo}");

            byte[] nameAscii = Encoding.ASCII.GetBytes(name);
            Console.Write("Name(ASCII):");
            for (int i = 0; i < nameAscii.Length; i++)
            {
                Console.Write(nameAscii[i]);
            }
            Console.WriteLine();
            countOfInfo = ShannonEntropyString(binAlphabet) * nameAscii.Length;
            Console.WriteLine($"FIO(ASCII) count of information = {countOfInfo}");

            Console.WriteLine("--------------");

            Throughput(0.1);
            Throughput(0.5);
            Throughput(1);
        }
        public static void Throughput(double error)
        {
            var d = 1 - ((-error) * Math.Log(error, 2) - (1 - error) * Math.Log(1 - error, 2));
            Console.WriteLine($"Throughput(error={error}) = {1 - ((-error) * Math.Log(error, 2) - (1 - error)*Math.Log(1 - error, 2))}");
        }

        public static double ShannonEntropyString(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] += 1;
            }

            double result = 0.0;
            int len = s.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency, 2));
            }

            return result;
        }

        public static void ShannonEnthropyFile(string path, string alphabet)
        {
            //string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int[] freq = new int[256];
            for (int i = 0; i < 256; i++)
            {
                freq[i] = 0;
            }
            string s;
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                s = Encoding.Default.GetString(array).ToLower();
                Console.WriteLine($"Text from file: {s}");
            }

            foreach (var c in s)
            {
                freq[c]++;
            }

            int totalCount = s.Length;
            double result = 0.0;
            double frequency;
            foreach (var letter in alphabet)
            {
                Console.Write(letter);
                Console.Write(" => " + freq[letter]);
                frequency = (double)freq[letter] / totalCount;
                Console.WriteLine(" => " + frequency);
                if(frequency != 0)
                {
                    result -= frequency * (Math.Log(frequency, 2));
                }
            }

            Console.WriteLine("Enthropy alphv(with msg) = " + result);
            Console.WriteLine("Total letters: " + totalCount);
        }

    }
}
