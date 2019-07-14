using CLI.FileService;
using NUnit.Framework;
using System;
using System.Linq;
using WordBreaker;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly Breaker _service;

        public Tests()
        {
            var reader = new WordReader(path: @"..\..\..\dict");
            _service = new Breaker(words: reader.GetGermanyWords());
        }

        [Test]
        public void Krankenhaus()
        {
            //Arrange
            var word = "krankenhaus";

            // Action
            var subWords = _service.GetSubWords(word);

            //Assert
            Assert.IsTrue(subWords.Count() == 2);
            Assert.IsTrue(subWords.Contains("kranken"));
            Assert.IsTrue(subWords.Contains("haus"));
        }

        [Test]
        public void KrankenhausWithWhitespaces()
        {
            //Arrange
            var word = "\n krankenhaus\t";

            // Action
            var subWords = _service.GetSubWords(word);

            //Assert
            Assert.IsTrue(subWords.Count() == 2);
            Assert.IsTrue(subWords.Contains("kranken"));
            Assert.IsTrue(subWords.Contains("haus"));
        }

        [Test]
        public void KrankenhausWithWhitespacesBetween()
        {
            //Arrange
            var word = "kranken\t\nhaus";

            // Action
            var subWords = _service.GetSubWords(word);

            //Assert
            Assert.IsTrue(subWords.Count() == 2);
            Assert.IsTrue(subWords.Contains("kranken"));
            Assert.IsTrue(subWords.Contains("haus"));
        }

        [Test]
        public void Kranken()
        {
            //Arrange
            var word = "kranken";

            // Action
            var subWords = _service.GetSubWords(word);

            //Assert
            Assert.IsTrue(subWords.Count() == 1);
            Assert.IsTrue(subWords.Contains("kranken"));
        }

        [Test]
        public void WordWithUpperCaseLetterReturnsEmptyList()
        {
            //Arrange
            var word = "haUs";

            // Action
            var subWords = _service.GetSubWords(word);
            
            //Assert
            Assert.IsTrue(subWords.Count() == 0);
        }

        [Test]
        public void WordWithoutSubWordsReturnsCurrentWord()
        {
            //Arrange
            var word = "haus";

            // Action
            var subWords = _service.GetSubWords(word);

            //Assert
            Assert.IsTrue(subWords.Count() == 1);
            Assert.AreEqual(word, subWords.FirstOrDefault());
        }
    }
}