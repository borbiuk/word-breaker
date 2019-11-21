using System;
using System.Collections.Generic;

namespace WordBreaker
{
	/// <summary>
	/// Two Char Index - selected words by first two letter.
	/// </summary>
	internal class Tci : Dictionary<string, List<string>>
	{
		private const string WordLengthExceptionMessage =
			"Word index length must must contain more than two characters.";

		/// <summary>
		/// Add <paramref name="word"/> to current TCI(<see cref="KeyValuePair"/>).
		/// </summary>
		/// <param name="word"></param>
		public void Insert(string word)
		{
			if (word.Length < 2) throw new ArgumentOutOfRangeException(
				WordLengthExceptionMessage);

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
				WordLengthExceptionMessage);

			return TryGetValue(word.Substring(0, 2), out var words)
				   && words.Contains(word);
		}
	}
}
