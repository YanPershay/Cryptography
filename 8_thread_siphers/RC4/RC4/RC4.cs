using System.Linq;

namespace RC4
{
    public class RC4
    {
        byte[] S = new byte[256];
        int _x = 0;
        int _y = 0;
        
        public RC4(byte[] key)
        {
            Init(key);
        }
        
        private byte KeyItem()
        {
            _x = (_x + 1) % 256;
            _y = (_y + S[_x]) % 256;

            S.Swap(_x, _y);

            return S[(S[_x] + S[_y]) % 256];
        } 
        
        private void Init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);      
            }
        }
        
        public byte[] Encode(byte[] dataB, int size)
        {   
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {       
                cipher[m] = (byte)(data[m] ^ KeyItem());
            }

            return cipher;
        }
        
        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }

    }
    
    static class SwapExt
    {
        public static void Swap(this byte[] array, int index1, int index2)
        {
            byte temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}