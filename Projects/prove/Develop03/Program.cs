using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
       List<string> texts = new List<string> {
    "In the beginning God created the heavens and the earth. (Genesis 1:1)",
    "Blessed are the peacemakers, for they will be called children of God. (Matthew 5:9)",
    "Ask and it will be given to you; seek and you will find; knock and the door will be opened to you. (Matthew 7:7)",
    "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life. (John 3:16)",
    "The Lord is my shepherd, I lack nothing. (Psalm 23:1)",
    "For I know the plans I have for you,” declares the Lord, “plans to prosper you and not to harm you, plans to give you hope and a future. (Jeremiah 29:11)",
    "But behold, I, Nephi, will show you that the tender mercies of the Lord extend to all those whom he has chosen for their faith, to strengthen them, yea, until they have power to deliver themselves. (1Nephi 1:20)",
    "Yes, and how is it that you have forgotten that the Lord has power to do all things according to his will, for the children of men, if they exercise faith in him? Therefore, let us be faithful. (1Nephi 7:12)",
    "Notwithstanding, they fasted and prayed frequently, and became stronger and stronger in their humility, and more and more firm in the faith of Christ, until their souls were filled with joy and consolation; yes, until the purification and sanctification that comes from surrendering the heart of God. (Helaman 3:35)",
    "Be prudent in the days of your probation, strip yourselves of all impurity; Do not ask to satisfy your lusts, but ask with an unwavering resolution, so that you will not give in to any temptation, but will serve the true living God. (Mormon 9:21)"
};

        Random rand = new Random();

        string text = texts[rand.Next(texts.Count)];

        List<Word> words = text.Split(' ')
                               .Select(word => new Word(word, true))
                               .ToList();

        Console.Write(GetRenderedText(words));
        Console.WriteLine("\n\nPress Enter to hide a word or type 'quit' to exit:");

        while (words.Any(word => word.IsVisible()))
        {
            string input = Console.ReadLine();

            if (input == "")
            {
                HideRandomWord(words);
                Console.Write($"\r{GetRenderedText(words)}");
            }
            else if (input == "quit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide a word or type 'quit' to exit:");
            }
        }

        Console.WriteLine("\n\nAll words are hidden. Press any key to exit.");
        Console.ReadKey();
    }

    static void HideRandomWord(List<Word> words)
    {
        Random rand = new Random();
        int index;
        do
        {
            index = rand.Next(words.Count);
        } while (!words[index].IsVisible());
        words[index].Hide();
    }

    static string GetRenderedText(List<Word> words)
    {
        string renderedText = "";
        foreach (Word word in words)
        {
            if (word.IsVisible())
            {
                renderedText += word.GetWord() + " ";
            }
            else
            {
                renderedText += new string('_', word.GetWord().Length) + " ";
            }
        }
        return renderedText.TrimEnd();
    }
}

public class Word
{
    private string _word;
    private bool _visibility;

    public Word(string word, bool visibility)
    {
        _word = word;
        _visibility = visibility;
    }

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public string Underscore()
    {
        return new string('_', _word.Length);
    }

    public void Hide()
    {
        _visibility = false;
    }

    public void Show()
    {
        _visibility = true;
    }

    public bool IsVisible()
    {
        return _visibility;
    }
}
