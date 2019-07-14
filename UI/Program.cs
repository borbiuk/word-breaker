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
            var spliter = new WordBraker(words: reader.GetGermanyWords());

            while (true)
            {
                var normalizeWord = Console.ReadLine();

                if (string.IsNullOrEmpty(normalizeWord)) break;

                normalizeWord = normalizeWord.Trim().ToLower();

                var result = spliter.GetSubWords(normalizeWord);
                foreach (var item in result)
                {
                    Console.WriteLine(string.Format("\t{0}", item));
                }
            }
        }
    }
}
