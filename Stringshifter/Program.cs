using System;

namespace Stringshifter;

class Program
{
    static void Main(string[] args)
    {
        _ = args; // unused

        Console.Title = "Stringshifter";
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wilkommen bei Stringshifter!");

        while (true)
        {
            Console.WriteLine("Gib einen String ein, der verändert werden soll.");
            Console.Write("Eingabe: ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine().Trim();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Eingabe \"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\" wurde eingelesen.\r\n");

            Write("Lowercase:  \"", Lower(input), "\"");
            Write("Uppercase:  \"", Upper(input), "\"");
            Write("Camelcase:  \"", Camel(input), "\"");
            Write("Filename:   \"", Filename(input), "\"");
            Write("Zigzag:     \"", Zigzag(input), "\"");
            Write("Upsidedown: \"", UpsideDown(input), "\"");
            Write("Flipped:    \"", Flip(input), "\"");
            Write("Reversed:   \"", Reverse(input), "\"");
            Write("Discord:    \"", Discord(input), "\"");

            Console.WriteLine("\r\n");
        }
    }

    private static void Write(string start, string content, string end)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(start);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(content);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(end);
    }

    private static string Reverse(string input)
    {
        string output = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            output += input[i];
        }
        return output;
    }

    private static string Filename(string input)
    {
        return Camel(input).Replace(' ', '-');
    }

    private static string Zigzag(string input)
    {
        string output = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                output += input[i].ToString().ToUpper();
            }
            else
            {
                output += input[i].ToString().ToLower();
            }
        }
        return output;
    }

    private static string Lower(string input)
    {
        return input.ToLower();
    }

    private static string Upper(string input)
    {
        return input.ToUpper();
    }

    private static string Camel(string input)
    {
        string output = "";
        bool upper = true;
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (upper)
            {
                output += currentChar.ToString().ToUpper();
                upper = false;
            }
            else
            {
                output += currentChar.ToString().ToLower();
            }

            if (currentChar == ' ' || currentChar == '.' || currentChar == '_' || currentChar == '-')
            {
                upper = true;
            }
        }
        return output;
    }

    private static string UpsideDown(string input)
    {
        string output = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            output += FlipChar(input[i]);
        }
        return output;

        static char FlipChar(char x)
        {
            char[] regularChars = [ '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '_', '(', '[', '{', '<', ',', '?', '!', '&' ];
            char[] flippedChars = [ 'Ɩ', '2', 'Ɛ', 'ㄣ', '5', '9', 'ㄥ', '8', '6', '0',
                'ɐ', 'q', 'ɔ', 'p', 'ǝ', 'ɟ', 'ƃ', 'ɥ', 'ᴉ', 'ɾ', 'ʞ', 'l', 'ɯ', 'u', 'o', 'd', 'b', 'ɹ', 's', 'ʇ', 'n', 'ʌ', 'ʍ', 'x', 'ʎ', 'z',
                '∀', 'q', 'Ɔ', 'p', 'Ǝ', 'Ⅎ', 'פ', 'H', 'I', 'ſ', 'ʞ', '˥', 'W', 'V', 'O', 'Ԁ', 'Q', 'ɹ', 'S', '┴', '∩', 'Λ', 'M', 'X', '⅄', 'Z',
                '‾', ')', ']', '}', '>', '\'', '¿', '¡', '⅋' ];

            for (int i = 0; i < regularChars.Length; i++)
            {
                if (x == regularChars[i])
                {
                    return flippedChars[i];
                }
                if (x == flippedChars[i])
                {
                    return regularChars[i];
                }
            }
            return x;
        }
    }

    private static string Flip(string input)
    {
        return Reverse(UpsideDown(input));
    }

    private static string Discord(string input)
    {
        string output = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            output += GetDiscordChar(input[i].ToString());
        }
        return output;

        static string GetDiscordChar(string x)
        {
            string[] normalStrings = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "#", "*", "?", "!"];
            string[] discordEmojis = [":one:", ":two:", ":three:", ":four:", ":five:", ":six:", ":seven:", ":eight:", ":nine:", ":zero:", ":hash:", ":asterisk:", ":question:", ":exclamation:"];
            string[] regIndicators = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];

            for (int i = 0; i < normalStrings.Length; i++)
            {
                if (x == normalStrings[i])
                {
                    return discordEmojis[i] + " ";
                }
            }

            string xLower = x.ToLower();
            for (int i = 0; i < regIndicators.Length; i++)
            {
                if (xLower == regIndicators[i])
                {
                    return $":regional_indicator_{regIndicators[i]}: ";
                }
            }

            return x + " ";
        }
    }
}
