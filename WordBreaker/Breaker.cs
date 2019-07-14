using System.Collections.Generic;

namespace WordBreaker
{
    public class Breaker
    {
        private readonly Dictionary<int, TCI> _indexedWords;
        private readonly int _sml;

        /// <summary>
        /// Create new WordBreaker service by input parameters.
        /// </summary>
        /// <param name="words">Dictionary for comparisons.</param>
        /// <param name="subWordMinLength">Subword minimum length.</param>
        public Breaker(IEnumerable<string> words, int subWordMinLength = 3)
        {
            _indexedWords = new Dictionary<int, TCI>();
            _sml = subWordMinLength;

            SetDictionary(words);
        }

        /// <summary>
        /// Fills the repository with words from the vocabulary.
        /// </summary>
        private void SetDictionary(IEnumerable<string> words)
        {
            foreach (string word in words)
            {
                if (word.Length < _sml) continue;

                if (!_indexedWords.TryGetValue(word.Length, out TCI wordIndex))
                {
                    wordIndex = new TCI();
                    _indexedWords[word.Length] = wordIndex;
                }

                wordIndex.Insert(word.ToLower());
            }
        }

        /// <summary>
        /// Get subwords if exists.
        /// </summary>
        public IEnumerable<string> GetSubWords(string word)
        {
            var result = new List<string>();

            int i = 0;
            while (true)
            {
                var subLength = word.Length - i;
                if (subLength < _sml) break;

                for (var j = subLength; j >= _sml; j--)
                {
                    var subWord = word.Substring(i, j);
                    if (_indexedWords.TryGetValue(j, out TCI wordIndex))
                    {
                        if (wordIndex.Exist(subWord))
                        {
                            result.Add(subWord);
                            i += j - 1;
                            break;
                        }
                    }
                }
                i++;
            }

            return result;
        }
    }
}
