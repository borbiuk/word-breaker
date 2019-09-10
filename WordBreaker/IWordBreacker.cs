using System.Collections.Generic;

namespace WordBreaker
{
	/// <summary>
	/// Provides decomposition of compound words into sub-words.
	/// </summary>
	public interface IWordBreacker
	{
		/// <summary>
		/// Get subwords if exists.
		/// </summary>
		IEnumerable<string> GetSubWords(string word);
	}
}
