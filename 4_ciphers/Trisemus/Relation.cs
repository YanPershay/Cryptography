using System;
using System.Collections.Generic;
using System.Text;

namespace Trisemus
{
    public static class Relation
    {
        private static string alphabet;

        private static string Alphabet
        {
            get => alphabet;
            set
            {
                alphabet = value.ToLower();
            }
        }

        private static int FormulaEncrupt(int x, int k = 28, int N = 32) => (x + k) % N;

        private static int FormulaDecrupt(int y, int k = 28, int N = 32) => Math.Abs(y - k % N);
        
        public static string Encrupt(string alphabet, string message)
        {
            Alphabet = alphabet;
            var result = new StringBuilder(message.Length);
            message += message.ToLower();
            foreach (var t in message)
            {
                var v = alphabet.IndexOf(t.ToString(), StringComparison.Ordinal);
                var c = FormulaEncrupt(v);
                result.Append(alphabet[c]);
            }
            return result.ToString();
        }

        public static string Decrupt(string alphabet, string cipherMessage)
        {
            Alphabet = alphabet;
            var result = new StringBuilder(cipherMessage.Length);
            cipherMessage += cipherMessage.ToLower();

            foreach (var t in cipherMessage)
            {
                var ind = alphabet.IndexOf(t);
                result.Append(alphabet[FormulaDecrupt(ind)]);
            }
            return result.ToString();

        }
    }
}
