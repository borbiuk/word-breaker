using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CLI.FileService
{
	public class WordReader
	{
		private readonly string _path;

		/// <summary> Initialization </summary>
		/// <param name="path">Path to file.</param>
		public WordReader(string path)
		{
			if (!File.Exists(path))
			{
				throw new ArgumentException(
					string.Format("File by path \"{0}\" not found.", path));
			}

			_path = path;
		}

		public IEnumerable<string> GetGermanyWords()
		{
			using (var stream = new FileStream(_path, FileMode.Open, FileAccess.Read))
			{
				using (var reader = new StreamReader(stream, Encoding.UTF8))
				{
					return Regex.Split(reader.ReadToEnd(), @"([A-Z][a-zÄÖÜäöüẞß]*)")
								.Select(w => w.Trim());
				}
			}
		}
	}
}
