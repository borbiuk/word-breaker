using System.Collections.Generic;
using WordBreaker.Models;

namespace WordBreaker
{
    public class WordBraker
    {
        /// <summary> Storage of words in 'length -> key -> word' order. </summary>
        private readonly Dictionary<int, WordIndex> _wordIndexes;

        /// <summary> Subword minimum length. </summary>
        private readonly int _sml;

        /// <summary>
        /// Create new WordBraker service by input parameters.
        /// </summary>
        /// <param name="words">Dictionary for comparisons.</param>
        /// <param name="subWordMinLength">Subword minimum length.</param>
        public WordBraker(IEnumerable<string> words, int subWordMinLength = 3)
        {
            _wordIndexes = new Dictionary<int, WordIndex>();
            _sml = subWordMinLength;

            SetDictionary(words);
        }

        /// <summary> Get subwords if exists. </summary>
        public IEnumerable<string> GetSubWords(string word)
        {
            var k = 0;
            var result = new List<string>();

            var i = 0;

            while (true)
            {
                var subLength = word.Length - i;
                if (subLength < _sml) break;

                for (var j = subLength; j >= _sml; j--)
                {
                    k++;
                    var subWord = word.Substring(i, j);
                    if (_wordIndexes.TryGetValue(j, out WordIndex wordIndex))
                    {
                        if (wordIndex.Exist(subWord)) result.Add(subWord);
                    }
                }
                i++;
            }
            return result;
        }

        private void SetDictionary(IEnumerable<string> words)
        {
            foreach (string word in words)
            {
                if (word.Length < _sml) continue;

                if (!_wordIndexes.TryGetValue(word.Length, out WordIndex wordIndex))
                {
                    wordIndex = new WordIndex();
                    _wordIndexes[word.Length] = wordIndex;
                }

                wordIndex.Insert(word.ToLower());
            }
        }
    }
}
