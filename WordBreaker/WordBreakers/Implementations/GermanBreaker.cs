using System.Collections.Generic;

using WordBreaker.Services;
using WordBreaker.WordBreakers.Interfaces;

namespace WordBreaker.WordBreakers.Implementations
{
	/// <summary>
	/// Provides decomposition of german compound words into sub-words.
	/// </summary>
	public class GermanBreaker : IWordBreaker
	{
		private readonly Dictionary<int, Index> _indexedWords;
		private readonly int _sml;

		/// <param name="words">Dictionary for comparisons.</param>
		/// <param name="subWordMinLength">Sub-word minimum length.</param>
		public GermanBreaker(IEnumerable<string> words, int subWordMinLength = 3)
		{
			_indexedWords = new Dictionary<int, Index>();
			_sml = subWordMinLength;

			SetDictionary(words);
		}

		/// <summary>
		/// Fills the repository with words from the vocabulary.
		/// </summary>
		private void SetDictionary(IEnumerable<string> words)
		{
			foreach (var word in words)
			{
				if (word.Length < _sml)
					continue;

				if (!_indexedWords.TryGetValue(word.Length, out var wordIndex))
				{
					wordIndex = new Index();
					_indexedWords[word.Length] = wordIndex;
				}

				wordIndex.Insert(word.Simplify());
			}
		}

		/// <summary>
		/// Get sub-words if exists.
		/// </summary>
		public IEnumerable<string> GetSubWords(string word)
		{
			word.Simplify();
			var result = new List<string>();

			var i = 0;
			while (true)
			{
				var subLength = word.Length - i;
				if (subLength < _sml) break;

				for (var j = subLength; j >= _sml; j--)
				{
					var subWord = word.Substring(i, j);
					if (_indexedWords.TryGetValue(j, out var wordIndex) && wordIndex.Exist(subWord))
					{
						result.Add(subWord.ToUmlaut());
						i += j - 1;
						break;
					}
				}
				i++;
			}

			return result;
		}
	}
}
