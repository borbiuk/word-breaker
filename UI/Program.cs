using FileService.Txt;
using WordBreaker;
using System;

namespace UI
{
    class Program
    {
        static void Main()
        {
            var fileReader = new TxtReader(path: @"..\..\..\dict");
            var spliter = new WordBraker(words: fileReader.GetGermanyWords());

            var result = spliter.GetSubWords("krankenhaus");


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
