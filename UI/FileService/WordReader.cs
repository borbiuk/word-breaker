using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CLI.FileService;

public partial class WordReader
{
    private readonly string _path;

    /// <summary> Initialization </summary>
    /// <param name="path">Path to file.</param>
    public WordReader(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException($"File by path \"{path}\" not found.", nameof(path));
        }

        _path = path;
    }

    public IEnumerable<string> GetGermanyWords()
    {
        using var stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(stream, Encoding.UTF8);
        return MyRegex()
            .Split(reader.ReadToEnd())
            .Select(w => w.Trim());
    }

    [GeneratedRegex("([A-Z][a-zÄÖÜäöüẞß]*)")]
    private static partial Regex MyRegex();
}
