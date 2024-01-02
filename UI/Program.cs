using System;
using CLI.FileService;
using WordBreaker.WordBreakers.Implementations;
using WordBreaker.WordBreakers.Interfaces;

namespace CLI;

internal class Program
{
    private static void Main()
    {
        var reader = new WordReader(path: @"../../../dict");
        IWordBreaker breaker = new GermanBreaker(words: reader.GetGermanyWords());

        while (true)
        {
            var normalizeWord = Console.ReadLine();

            if (string.IsNullOrEmpty(normalizeWord))
                break;

            var result = breaker.GetSubWords(normalizeWord);
            foreach (var item in result)
                Console.WriteLine($"  - {item}");
        }
    }
}
