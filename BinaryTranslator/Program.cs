using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string defaultOutputFileLocation = @"C:\Users\sock\Desktop\Translated.txt";
        string defaultInputFileLocation = @"C:\Users\sock\Desktop\The King James Bible.txt";

        Stopwatch stopwatch = new();
        stopwatch.Start();

        string genesis = DataAccess.TrimStringForTranslation(System.IO.File.ReadAllText(defaultInputFileLocation)).ToUpper().Trim();
        _ = DataAccess.WriteSingleStringToText(defaultOutputFileLocation, TranslateCharacterToBinaryDict(genesis));

        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        Console.WriteLine("Runtime " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        ts.Hours, ts.Minutes, ts.Seconds,
                                                        ts.Milliseconds / 10));
    }

    public static string TranslateCharacterEnglishToBinary(string toTranslate)
    {
        char[] toTranslateCharArray = toTranslate.ToCharArray();
        int alphabetIndex;
        string translated = "";

        foreach (char c in toTranslateCharArray)
        {
            alphabetIndex = Data.alphabet.IndexOf(Char.ToUpper(c));
            translated += Data.binaryValues[alphabetIndex] + " ";
        }
        return translated;
    }

    public static string TranslateCharacterToBinaryDict(string toTranslate)
    {
        string translation = "";
        int counter = 0;

        foreach (char c in toTranslate)
        {
            translation += Data.binaryAlphabet[c];
            counter++;
            if (counter % 10000 == 0)
            {
                Console.WriteLine("Processed " + counter + " characters");
            }
        }
        return translation;
    }

    //public static string TranslateEnglishToBinary(string toTranslate)
    //{
    //    string translation = "";

    //    for (int i = 0; i <= toTranslate.Length; i++)
    //    {

    //    }
    //}
}