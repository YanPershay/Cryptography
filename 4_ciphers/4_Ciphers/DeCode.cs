using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Ciphers
{
    class DeCode
    {
        private int line = 5;
        private int column = 5;
        private char[] word = new char[255];
        private char[] decodeword = new char[255];
        private char[,] table = new char[6,9];


        public string GetWord(string key, string word)
        {
            this.word = word.ToCharArray();
            TrisemusTable newtable = new TrisemusTable();
            table = newtable.GetTable(key);
            int l = 0;
            for (int x = 0; x < this.word.Length; x++)
            {
                for (int k = 0; k < line; k++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (table[k,j] == this.word[x])
                        {
                            if (k == 0)
                            {
                                decodeword[l] = table[0,j];
                                l++;
                            }
                            else
                            {
                                decodeword[l] = table[k - 1,j];
                                l++;
                            }
                        }
                    }
                }
            }
            var builder = new StringBuilder();
            foreach (var c in decodeword)
            {
                builder.Append(c);
            }
            string result = builder.ToString();

            return result;
        }
    }
}
