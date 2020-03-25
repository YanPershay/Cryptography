using _4_Ciphers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trisemus_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding unicode = Encoding.Unicode;
            Console.OutputEncoding = unicode;

            Console.Write("Enter key ");
            string key = Console.ReadLine();
            Console.WriteLine("Word to encode ");
            string word = Console.ReadLine();

            EnCode incode = new EnCode();
            string incodeword = incode.GetWord(key, word);

            DeCode decode = new DeCode();
            string decodeword = decode.GetWord(key, incodeword);

            Console.WriteLine("Encoding word " + word);
            Console.WriteLine("Result: " + incodeword);

            Console.WriteLine(decodeword);
        }
    }
}