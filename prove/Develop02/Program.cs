using System;
using System.Collections.Generic;
using System.IO;


class Journalinput
{    public string Prompt { get; set; }
            public string Response { get; set; }
                public string Date { get; set; }}

class Journal
{        private List<Journalinput> entries = new List<Journalinput>();

    public void WriteNewEntry()
    {        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Journalinput entry = new Journalinput
        { Prompt = randomPrompt,
        Response = response,
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")};
        entries.Add(entry);
        Console.WriteLine("Input saved successfully.");}
    public void DisplayJournal()
    {
        foreach (var entry in entries)
  {Console.WriteLine($"Date: {entry.Date}");
    Console.WriteLine($"Prompt: {entry.Prompt}");
    Console.WriteLine($"Response: {entry.Response}\n");
        }}

    public void SaveToFile()
    {        Console.Write("Enter the filename of journal: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        { foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal was saved .");
    }
    public void LoadFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {entries.Clear(); 
        using (StreamReader reader = new StreamReader(filename))
            {  while (!reader.EndOfStream)
                {   string[] parts = reader.ReadLine().Split(',');
                    Journalinput entry = new Journalinput
                    {   Date = parts[0],
                        Prompt = parts[1],
                        Response = parts[2]
                    };
                    entries.Add(entry);
                }
            }

            Console.WriteLine("Journal loaded  successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    private string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person you met today?",
               "What was the best part of my day?",
               "How did the Lord bless me today?",
               "How do I deal with frustration?",
               "What will be better tomorrow than I didn't like today?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}
class Program
{
    static void Main(string[] args)
    { Console.Write("Hello welcome back to the RufusJournay What is your name? : ");
        string userName = Console.ReadLine();
        Journal myJournal = new Journal();
        while (true)
        {
            Console.WriteLine($"\nWelcome back, {userName}! remember that you always can say who was your day ");
            Console.WriteLine("1. Write a new input");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save  a file");
            Console.WriteLine("4. Load  a file");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice (1-5): ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            { switch (choice)
                {
                    case 1:
                        myJournal.WriteNewEntry();
                        break;
                    case 2:
                        myJournal.DisplayJournal();
                        break;
                    case 3:
                        myJournal.SaveToFile();
                        break;
                    case 4:
                        myJournal.LoadFromFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
