namespace ParallelFileReading;

public static class FileHelper
{
    public static void GetSpaces(string filePath)
    {
        string text = File.ReadAllText(filePath);       
        int spaceCount = text.Count(char.IsWhiteSpace);

        Console.WriteLine($"В файле '{filePath}' количество пробелов: {spaceCount}");
    }
}
