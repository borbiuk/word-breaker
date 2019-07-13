using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileService.Txt
{
    public class TxtReader
    {
        private readonly FileStream _fileStream;

        /// <summary> Initialization </summary>
        /// <param name="path">Path to .txt file.</param>
        public TxtReader(string path)
        {
            try
            {
                _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException(
                    string.Format("File by path \"{0}\" not found.", path));
            }
        }

        public IEnumerable<string> GetGermanyWords()
        {
            using (var streamReader = new StreamReader(_fileStream, Encoding.UTF8))
            {
                return Regex.Split(streamReader.ReadToEnd(), @"([A-Z][a-zÄÖÜäöüẞß]*)")
                            .Select(w => w.Trim());
            }
        }
    }
}
