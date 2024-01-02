using System;
using System.Linq;
using CLI.FileService;
using Cocona;
using Microsoft.Extensions.DependencyInjection;
using WordBreaker.WordBreakers.Implementations;
using WordBreaker.WordBreakers.Interfaces;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<WordReader>(x => new WordReader(@"../../../dict"));
builder.Services.AddSingleton<IWordBreaker, GermanBreaker>(x => new GermanBreaker(x.GetService<WordReader>().GetGermanyWords()));

var app = builder.Build();

app.AddCommand((IWordBreaker breaker) =>
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Input word to break: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        var normalizeWord = Console.ReadLine();

        if (string.IsNullOrEmpty(normalizeWord))
            break;

        var result = breaker.GetSubWords(normalizeWord);

        if (!result.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No words found.");
            Console.ForegroundColor = ConsoleColor.Gray;
            
            continue;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Found words:");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var item in result)
        {
            Console.WriteLine("  - {0}", item);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
});

app.Run();
