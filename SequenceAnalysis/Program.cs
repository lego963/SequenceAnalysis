using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAnalysis
{
    class Program
    {
        private static Dictionary<char, int> messageLetterFrequency = new Dictionary<char, int>();
        private static List<char> letterFrequency = new List<char> { 'о', 'е', 'а', 'и', 'н', 'т', 'с', 'р', 'в', 'л', 'к', 'м', 'д', 'п', 'у', 'я', 'ы', 'ь', 'г', 'з', 'б', 'ч', 'й', 'х', 'ж', 'ш', 'ю', 'ц', 'щ', 'э', 'ф', 'ъ', 'ё' };
        static void Main(string[] args)
        {
            try
            {
                var objReader = new StreamReader(@"C:\Users\rgyrbu\source\repos\SequenceAnalysis\message.txt");
                var message = objReader.ReadLine();
                message = message.ToLower();
                Console.Write($"message: {message}");
                for (var i = 0; i < message.Length; i++)
                {
                    if (char.IsLetter(message[i]))
                        if (messageLetterFrequency.ContainsKey(message[i]))
                        {
                            messageLetterFrequency[message[i]]++;
                        }
                        else
                        {
                            messageLetterFrequency.Add(message[i], 1);
                        }


                }
                var index = 0;
                var sortedLetters = messageLetterFrequency.OrderBy(item => item.Value).Reverse();
                foreach (var item in sortedLetters)
                {
                    message = message.Replace(item.Key, letterFrequency[index++]);
                }
                Console.ReadKey();

            }
            catch (Exception)
            {
                Console.WriteLine("Чёт не то");
                throw;
            }
        }
    }
}
