using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Ciphers
{
    class TrisemusTable
    {
        
        private int line = 5;
        private int column = 5;
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private char[] allsymbol = new char[100];
        private char[] tr = new char[40];
        private char[,] table = new char[6,9];

        public TrisemusTable()
        {
        }

        public char[,] GetTable(String key)
        {
            allsymbol = (key + alphabet).ToCharArray();
            tr = RemoveDuplicates(allsymbol);
            for (int n = 0, i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if ((i < tr.Length) || (j < tr.Length))
                    {
                        table[i,j] = tr[n];
                        n++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return table;
        }

        public char[] RemoveDuplicates(char[] values)
        {
            bool[] mask = new bool[values.Length];
            int removeCount = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if (!mask[i])
                {
                    char tmp = values[i];

                    for (int j = i + 1; j < values.Length; j++)
                    {
                        if (tmp == values[j])
                        {
                            mask[j] = true;
                            removeCount++;
                        }
                    }
                }
            }

            char[] result = new char[values.Length - removeCount];

            for (int i = 0, j = 0; i < values.Length; i++)
            {
                if (!mask[i])
                {
                    result[j++] = values[i];
                }
            }
            return result;
        }
    }
}
