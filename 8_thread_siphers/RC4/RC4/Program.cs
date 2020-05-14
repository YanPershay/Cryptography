using System;
using System.Text;

namespace RC4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = ASCIIEncoding.ASCII.GetBytes("11121314151");

            RC4 encoder = new RC4(key);
            string testString = "Plaintext";
            byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(testString);
            byte[] result = encoder.Encode(testBytes, testBytes.Length);

            RC4 decoder = new RC4(key);
            byte[] decryptedBytes = decoder.Decode(result, result.Length);
            string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);
            Console.WriteLine(decryptedString);
        }
    }
}