using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

public class ScriptureReference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int VerseStart { get; set; }
    public int VerseEnd { get; set; }

    public ScriptureReference(string book, int chapter, int verseStart)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseStart;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseStart == VerseEnd)
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
        else
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
    }
}

public class Scripture
{
    private List<Word> words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public ScriptureReference Reference { get; }

    public void Display()
    {
        Console.WriteLine($"Scripture Reference: {Reference}");
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "***** " : $"{word.Text} ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count(w => !w.IsHidden));
        int wordsHidden = 0;
        while (wordsHidden < wordsToHide)
        {
            int index = random.Next(words.Count);
            if (!words[index].IsHidden)
            {
                words[index].IsHidden = true;
                wordsHidden++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
        var reference = new ScriptureReference("John", 3, 16);
        var scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, scriptureText);

        
        scripture.Display();

        
        Console.WriteLine("Press Enter to hide more words or type 'quit' to end.");
        while (!scripture.AllWordsHidden())
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                
                scripture.HideRandomWords();
                scripture.Display();
            }
        }
    }
}
