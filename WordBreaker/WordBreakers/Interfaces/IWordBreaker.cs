using System.Collections.Generic;

namespace WordBreaker.WordBreakers.Interfaces;

/// <summary>
/// Provides decomposition of compound words into sub-words.
/// </summary>
public interface IWordBreaker
{
    /// <summary>
    /// Get sub-words if exists.
    /// </summary>
    IEnumerable<string> GetSubWords(string word);
}
