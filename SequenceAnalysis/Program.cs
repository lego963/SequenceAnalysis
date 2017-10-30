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
        private static Dictionary<char, int> _messageLetterFrequency = new Dictionary<char, int>();
        private static readonly List<char> LetterFrequency = new List<char> { 'о', 'е', 'а', 'и', 'н', 'т', 'с', 'р', 'в', 'л', 'к', 'м', 'д', 'п', 'у', 'я', 'ы', 'ь', 'г', 'з', 'б', 'ч', 'й', 'х', 'ж', 'ш', 'ю', 'ц', 'щ', 'э', 'ф', 'ъ', 'ё' };

        static void Main(string[] args)
        {
            try
            {
                var objReader = new StreamReader(@"C:\Users\rgyrbu\source\repos\SequenceAnalysis\message.txt");
                var message = objReader.ReadLine();
                message = message.ToLower();
                Console.Write($"message: {message}");
                objReader.Close();
                var decyphered = new char[message.Length];
                Dictionary<char, bool> txt = new Dictionary<char, bool>();
                for (var i = 0; i < message.Length; i++)
                {
                    if (char.IsLetter(message[i]))
                        if (_messageLetterFrequency.ContainsKey(message[i]))
                        {
                            _messageLetterFrequency[message[i]]++;
                        }
                        else
                        {
                            _messageLetterFrequency.Add(message[i], 1);
                        }
                }

                var index = 0;
                var sortedLetters = _messageLetterFrequency.OrderBy(item => item.Value).Reverse();
                Console.WriteLine();
                foreach (var item in sortedLetters)
                {
                    Console.WriteLine($"Example: {item.Key}: {item.Value}/Wikipedia: {LetterFrequency[index]}");
                    //message = message.Replace(item.Key, LetterFrequency[index++]);
                    for (var i = 0; i < message.Length; i++)
                    {
                        if (char.IsLetter(message[i]))
                        {
                            if (message[i] == item.Key)
                            {
                                decyphered[i] = LetterFrequency[index];
                            }
                        }
                        else
                        {
                            decyphered[i] = message[i];
                        }
                    }
                    index++;
                }
                message = string.Empty;
                foreach (var item in decyphered)
                {
                    message += item;
                }
                var objWriter = new StreamWriter(@"C:\Users\rgyrbu\source\repos\SequenceAnalysis\Decyphered.txt", false);
                objWriter.WriteLine(message);
                objWriter.Close();
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
