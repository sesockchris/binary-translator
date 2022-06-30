using System.Text.RegularExpressions;
public class DataAccess
{
    public static void CreateFile(string directory, string filename)
    {
        File.Create(directory + "\\" + filename);
    }

    public static async Task WriteSingleStringToText(string toWrite)
    {
        await File.WriteAllTextAsync(@"C:\Users\sock\Desktop\Translated.txt", toWrite);
    }

    public static int LengthOfString(string str)
    {
        return str.Length;
    }

    public static void SplitStringForTranslation(string toTranslate)
    {
        string[] split = toTranslate.Split(" ");
        foreach (string s in split)
        {
            Program.TranslateCharacterEnglishToBinary(s);
        }
    }

    public static string TrimStringForTranslation(string toTrim)
    {
        return Regex.Replace(toTrim, $"[^a-zA-Z]", String.Empty);
    }
}