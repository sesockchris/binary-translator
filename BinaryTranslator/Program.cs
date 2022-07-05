using System.Diagnostics;

public class Program
{

    public static List<string> binaryValues = new List<string> { "01000001", "01000010", "01000011", "01000100", "01000101", "01000110", "01000111", "01001000",
    "01001001", "01001010", "01001011", "01001100", "01001101", "01001110", "01001111", "01010000", "01010001", "01010010", "01010011", "01010100", "01010101",
    "01010110", "01010111", "01011000", "01011001", "01011010"};

    public static List<char> alphabet = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
    'U', 'V', 'W', 'X', 'Y', 'Z'};

    public static Dictionary<char, string> binaryAlphabet = new Dictionary<char, string> { { 'A', "01000001" }, { 'B', "01000010" }, { 'C', "01000011" }, { 'D', "01000100" }, { 'E', "01000101" },
        { 'F', "01000110" }, { 'G', "01000111" }, { 'H', "01001000" }, { 'I', "01001001" }, { 'J', "01001010" }, { 'K', "01001011" }, { 'L', "01001100" }, { 'M', "01001101" },
        { 'N', "01001110" }, { 'O', "01001111" }, { 'P', "01010000" }, { 'Q', "01010001" }, { 'R', "01010010" }, { 'S', "01010011" }, { 'T', "01010100" }, { 'U', "01010101" },
        { 'V', "01010110" }, { 'W', "01010111" }, { 'X', "01011000" }, { 'Y', "01011001" }, { 'Z', "01011010" } };

    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        string genesis = DataAccess.TrimStringForTranslation(System.IO.File.ReadAllText(@"C:\Users\sock\Desktop\The King James Bible.txt")).ToUpper().Trim();
        //Console.WriteLine(genesis); //debug
        //_ = DataAccess.WriteSingleStringToText(TranslateCharacterEnglishToBinary(genesis));
        _ = DataAccess.WriteSingleStringToText(TranslateCharacterToBinaryDict(genesis));

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
            alphabetIndex = alphabet.IndexOf(Char.ToUpper(c));
            translated += binaryValues[alphabetIndex] + " ";
        }
        return translated;
    }

    //possible improvement in efficiency?
    public static string TranslateCharacterToBinaryDict(string toTranslate)
    {
        //char[] toTranslateCharArray = toTranslate.ToCharArray();
        string translation = "";
        int counter = 0;

        foreach (char c in toTranslate)
        {
            translation += binaryAlphabet[c];
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