using System.Linq;
using CLI.FileService;
using NUnit.Framework;
using WordBreaker.WordBreakers.Implementations;

namespace UnitTests
{
	[TestFixture]
	public class Tests
	{
		private readonly GermanBreaker _service;

		public Tests()
		{
			var reader = new WordReader(path: @"../../../dict");
			_service = new GermanBreaker(words: reader.GetGermanyWords());
		}

		[Test]
		public void Krankenhaus()
		{
			//Arrange
			const string word = "krankenhaus";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 2);
			Assert.IsTrue(subWords.Contains("kranken"));
			Assert.IsTrue(subWords.Contains("haus"));
		}

		[Test]
		public void KrankenhausWithWhitespaces()
		{
			//Arrange
			const string word = "\n krankenhaus\t";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 2);
			Assert.IsTrue(subWords.Contains("kranken"));
			Assert.IsTrue(subWords.Contains("haus"));
		}

		[Test]
		public void KrankenhausWithWhitespacesBetween()
		{
			//Arrange
			const string word = "kranken\t\nhaus";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 2);
			Assert.IsTrue(subWords.Contains("kranken"));
			Assert.IsTrue(subWords.Contains("haus"));
		}

		[Test]
		public void Kranken()
		{
			//Arrange
			const string word = "kranken";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 1);
			Assert.IsTrue(subWords.Contains("kranken"));
		}

		[Test]
		public void WordWithUpperCaseLetterReturnsEmptyList()
		{
			//Arrange
			const string word = "haUs";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 0);
		}

		[Test]
		public void WordWithoutSubWordsReturnsCurrentWord()
		{
			//Arrange
			const string word = "haus";

			// Action
			var subWords = _service.GetSubWords(word).ToArray();

			//Assert
			Assert.IsTrue(subWords.Length == 1);
			Assert.AreEqual(word, subWords.FirstOrDefault());
		}
	}
}
