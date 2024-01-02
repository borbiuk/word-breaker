using System;
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
        var normalizeWord = Console.ReadLine();

        if (string.IsNullOrEmpty(normalizeWord))
            break;

        var result = breaker.GetSubWords(normalizeWord);
        foreach (var item in result)
            Console.WriteLine($"  - {item}");
    }
});

app.Run();
