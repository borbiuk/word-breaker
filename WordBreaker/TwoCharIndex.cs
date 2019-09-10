using System;
using System.Collections.Generic;

namespace WordBreaker
{
	/// <summary>
	/// Two Char Index - selected words by first two letter.
	/// </summary>
	internal class TCI : Dictionary<string, List<string>>
	{
		/// <summary>
		/// Add <paramref name="word"/> to current TCI(<see cref="KeyValuePair"/>).
		/// </summary>
		/// <param name="word"></param>
		public void Insert(string word)
		{
			if (word.Length < 2) throw new ArgumentOutOfRangeException(
				"Word index length must must contain more than two characters.");

			if (!TryGetValue(word.Substring(0, 2), out List<string> words))
			{
				words = new List<string>();
				this[word.Substring(0, 2)] = words;
			}

			words.Add(word);
		}

		/// <summary>
		/// Check that <paramref name="word"/> exist in current TCI(<see cref="KeyValuePair"/>).
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public bool Exist(string word)
		{
			if (word.Length < 2) throw new ArgumentOutOfRangeException(
				"Word index length must must contain more than two characters.");

			if (TryGetValue(word.Substring(0, 2), out List<string> words))
				return words.Contains(word);

			return false;
		}
	}
}
