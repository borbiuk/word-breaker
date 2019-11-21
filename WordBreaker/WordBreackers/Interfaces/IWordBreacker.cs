using System.Collections.Generic;

namespace WordBreaker.WordBreackers.Interfaces
{
	/// <summary>
	/// Provides decomposition of compound words into sub-words.
	/// </summary>
	public interface IWordBreacker
	{
		/// <summary>
		/// Get sub-words if exists.
		/// </summary>
		IEnumerable<string> GetSubWords(string word);
	}
}
