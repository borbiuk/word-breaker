using WordBreaker;
using System;
using CLI.FileService;

namespace CLI
{
    class Program
    {
        static void Main()
        {
            var reader = new WordReader(path: @"..\..\..\dict");
            var breaker = new Breaker(words: reader.GetGermanyWords());

            while (true)
            {
                var normalizeWord = Console.ReadLine();

                if (string.IsNullOrEmpty(normalizeWord)) break;

                var result = breaker.GetSubWords(normalizeWord);
                foreach (var item in result)
                {
                    Console.WriteLine(string.Format("\t{0}", item));
                }
            }
        }
    }
}
