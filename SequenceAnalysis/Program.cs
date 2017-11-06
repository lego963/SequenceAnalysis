using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SequenceAnalysis
{
    internal static class Program
    {
        private static readonly Dictionary<char, int> MessageLetterFrequency = new Dictionary<char, int>();
        //private static readonly List<char> LetterFrequency = new List<char> { 'о', 'а', 'т', 'е', 'и', 'н', 'с', 'р', 'к', 'в', 'д', 'л', 'м', 'у', 'п', 'ы', 'я', 'ь', 'х', 'з', 'б', 'ж', 'й', 'ш', 'г', 'ч', 'ю', 'э', 'щ', 'ц', 'ф', 'ё', 'ъ' };
        //Даниил

        private static readonly List<char> LetterFrequency = new List<char> { 'о', 'т', 'е', 'и', 'н', 'а', 'с', 'р', 'в', 'л', 'п', 'к', 'д', 'м', 'ы', 'у', 'ь', 'я', 'г', 'б', 'з', 'й', 'ч', 'ж', 'х', 'ц', 'ю', 'э', 'щ', 'ш', 'ф', 'ё', 'ъ' };
        //Кс_Наташк
        private static void Main()
        {
            try
            {
                var objReader = new StreamReader(@"C:\Users\rgyrbu\source\repos\SequenceAnalysis\message.txt");
                var message = objReader.ReadLine();
                // ReSharper disable once PossibleNullReferenceException
                message = message.ToLower();
                objReader.Close();
                var decyphered = new char[message.Length];
                foreach (var symbol in message)
                {
                    if (!char.IsLetter(symbol)) continue;
                    if (MessageLetterFrequency.ContainsKey(symbol))
                    {
                        MessageLetterFrequency[symbol]++;
                    }
                    else
                    {
                        MessageLetterFrequency.Add(symbol, 1);
                    }
                }
                var index = 0;
                var sortedLetters = MessageLetterFrequency.OrderBy(item => item.Value).Reverse();
                foreach (var item in sortedLetters)
                {
                    Console.WriteLine($"Text: {item.Key} | Wikipedia: {LetterFrequency[index]}");
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
                message = decyphered.Aggregate(string.Empty, (current, item) => current + item);
                var objWriter = new StreamWriter(@"C:\Users\rgyrbu\source\repos\SequenceAnalysis\Decyphered.txt", false);
                objWriter.WriteLine(message);
                objWriter.Close();
                Console.WriteLine("Check Decyphered.txt");
                Console.ReadKey();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Текста нет");
                throw;
            }
        }
    }
}
