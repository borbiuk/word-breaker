# Word Breaker

Module for get meaningful parts of compound words.

![searching...](https://media.giphy.com/media/3h2AeAOj83j7slRkyW/giphy.gif)

## Exapmle

* "krankenhaus" => {"kranken", "haus"}
* "haus" => {"haus"}

## Algorithm

The algorithm is based on the comparison of words with the dictionary. A dictionary is a large set of words, it used for comparison. The minimum possible length for a subword is equal 3, to exclude extra iterations and non-valued subwords.

**Simple:**

```csharp
for each compound {
    for each possible_word {
        if (compound.Contains(possible_word)) {
            results.Add(possible_word)
        }
    }
}
```

**Advanced:**

```csharp
for each compound {
    for each character except the first one {
        get possible_words starting with this character
        for each possible_word {
            if (compound contains the word at the character’s position) {
                results.Add(possible_word)
            }
        }
    }
}
```

## Data structure

The resulting data structure consists of word lists indexed by two properties:

* Length of the words
* Two characters of the words

```csharp
Dictionary<int, Dictionary<string, List<string>>>
```

where the int is the word length, the string is the first two characters and the lists contain the suitable words.

Search by length and first two letters in HashTable minimize word list for Contains() method. This significantly speeds up the program.

## Notes

* The algorithm can be modified to get all subwords
* Yhe algorithm can also be modified so as to receive first shorter or longer subword
* Be careful to work with umlaut
* If you have any remarks, let me know [emial](borbiuk.n@gmail.com)
