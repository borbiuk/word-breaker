namespace WordBreaker.Services
{
	internal static class StringExtensions
	{
		public static string Simplify(this string word)
		{
			word = word.Trim()
				.ToLower()
				.Replace('ä', '0')
				.Replace('ö', '1')
				.Replace('ü', '2')
				.Replace('ß', '3');

			return word;
		}

		public static string ToUmlaut(this string word)
		{
			word = word.Replace('0', 'ä')
				.Replace('1', 'ö')
				.Replace('2', 'ü')
				.Replace('3', 'ß');

			return word;
		}
	}
}
