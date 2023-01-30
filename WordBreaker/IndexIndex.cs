﻿using System;using System.Collections.Generic;namespace WordBreaker{	/// <summary>	/// Char Index - selected words by first characters.	/// </summary>	internal class Index : Dictionary<string, List<string>>	{		private const string WordLengthExceptionMessage =			"Word index length must must contain more than two characters.";		private readonly int _length;		/// <param name="length">Index length</param>		public Index(int length = 2)		{			_length = length;		}		/// <summary>		/// Add <paramref name="word"/> to current TCI(<see cref="KeyValuePair"/>).		/// </summary>		public void Insert(string word)		{			if (word.Length < _length)				throw new ArgumentOutOfRangeException(nameof(word), WordLengthExceptionMessage);			if (!TryGetValue(word[.._length], out var words))			{				words = new List<string>();				this[word.Substring(0, 2)] = words;			}			words.Add(word);		}		/// <summary>		/// Check that <paramref name="word"/> exist in current TCI(<see cref="KeyValuePair"/>).		/// </summary>		public bool Exist(string word)		{			if (word.Length < _length)				throw new ArgumentOutOfRangeException(nameof(word), WordLengthExceptionMessage);			return TryGetValue(word[.._length], out var words)				&& words.Contains(word);		}	}}