using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a sample scripture
        Scripture scripture = new Scripture("John 3:16", "For aGod so bloved the cworld, that he dgave his eonly begotten fSon, that whosoever gbelieveth in him should not perish, but have heverlasting ilife");

        do
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to end.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
        } while (!scripture.AllWordsHidden());
    }
}

class Scripture
{
    private readonly Reference reference;
    private readonly List<Word> words;

    public Scripture(string referenceText, string text)
    {
        reference = new Reference(referenceText);
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference.GetText()}: {GetVisibleText()}");
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            int indexToHide = new Random().Next(visibleWords.Count);
            visibleWords[indexToHide].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    private string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "_____" : word.GetText()));
    }
}

class Reference
{
    private readonly string text;

    public Reference(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}

class Word
{
    private readonly string text;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        this.text = text;
        IsHidden = false;
    }

    public string GetText()
    {
        return text;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
