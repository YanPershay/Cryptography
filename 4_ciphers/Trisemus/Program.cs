using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Trisemus
{
    class Program
    {

        static void Main(string[] args)
        {
            Encoding unicode = Encoding.Unicode;
            Console.OutputEncoding = unicode;
            string alphabet = "абвгдеёжзійклмнопрстуўфхцчшыьэюя";

            char[,] belAlpavet =
            {

             {'Я', 'Н', 'А', 'Б', 'В', 'Г', 'Д'},
             {'Е', 'Ё', 'Ж', 'З', 'І', 'Й', 'К'},
             {'Л', 'М', 'О', 'П', 'Р', 'С', 'Т',},
             {'У', 'Ў', 'Ф', 'Х', 'Ц', 'Ч', 'Ш',},
             {'Ы', 'Ь', 'Э', 'Ю', ' ', '0', '1'},
             {'9', '-', ',', '.', '!', '?', ';'},
             {'2','3', '4', '5', '6', '7', '8'}

            };

            StreamReader file = new StreamReader("textfile.txt", Encoding.Default);
            string message = file.ReadToEnd();
            GetStatistics(message, alphabet);

            Console.WriteLine("Encrypt by relation.");
            var date1 = DateTime.Now;
            var c = Relation.Encrupt(alphabet, message);
            var date2 = DateTime.Now;
            GetStatistics(c, alphabet);
            Console.WriteLine($"Encrypt lasted on {date2.Ticks - date1.Ticks} ticks");
            Console.WriteLine("Decrypt by relation");
            date1 = DateTime.Now;
            var r = Relation.Decrupt(alphabet, c);
            date2 = DateTime.Now;
            Console.WriteLine($"Decrypt lasted on {date2.Ticks - date1.Ticks} ticks");


            Console.WriteLine("\n----------Trisemis cipher------------\n");
            
            string encodeMessage = "";

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < belAlpavet.GetLength(0); j++)
                    for (int k = 0; k < belAlpavet.GetLength(1); k++)
                        if (char.ToLower(belAlpavet[j, k]) == message[i] || char.ToUpper(belAlpavet[j, k]) == message[i])
                        {
                            int x = j + 1;
                            int y = k;
                            if (x == 7)
                            {
                                x = 1;
                            }
                            encodeMessage += belAlpavet[x, y];
                            break;
                        }

            }

            Console.WriteLine("Encode message:");
            Console.WriteLine(encodeMessage);

            string decodeMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < belAlpavet.GetLength(0); j++)
                {
                    for (int k = 0; k < belAlpavet.GetLength(1); k++)
                    {
                        if (char.ToLower(belAlpavet[j, k]) == message[i] || char.ToUpper(belAlpavet[j, k]) == message[i])
                        {
                            int x = j + 1;
                            int y = k;
                            if (x == 7)
                            {
                                x = 1;
                            }
                            decodeMessage += belAlpavet[x-1, y];
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("\nDecode message:");
            Console.WriteLine(decodeMessage);
        }

        public static void GetStatistics(string str, string alphabet)
        {

            var countLetter = new int[alphabet.Length];
            var probabilityLetters = new double[alphabet.Length];
            for (var j = 0; j < alphabet.Length; j++)
            {
                countLetter[j] = str.Count(x => x == alphabet[j]);
                var jCount = str.Count(x => x == alphabet[j]);
                Console.WriteLine($"{alphabet[j]}: {countLetter[j]}");

                probabilityLetters[j] = (double)countLetter[j] / str.Length;
                Console.WriteLine($"G({alphabet[j]}): {probabilityLetters[j]}");
                Console.WriteLine();
            }

            Console.WriteLine(probabilityLetters.Sum());
        }
    }
}
