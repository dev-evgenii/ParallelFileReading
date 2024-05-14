using System.Diagnostics;

namespace ParallelFileReading;

public static class TaskFilesRead
{   
    public static void ThreePredifinedFilesProcess()
    {        
        var fileDirectory = Directory.GetCurrentDirectory().Split("\\bin");
        if (fileDirectory.Length > 1)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            string filePath1 = $"{fileDirectory[0]}\\Files\\File1.txt";
            string filePath2 = $"{fileDirectory[0]}\\Files\\File2.txt";
            string filePath3 = $"{fileDirectory[0]}\\Files\\File3.txt";

            var task1 = FileTaskExecute(filePath1);
            var task2 = FileTaskExecute(filePath2);
            var task3 = FileTaskExecute(filePath3);

            Task.WaitAll(task1, task2, task3);

            stopwatch.Stop();
            Console.WriteLine($"Файлы обработаны за: {stopwatch.ElapsedMilliseconds} мс");
        }
        else
        {
            Console.WriteLine("Файлы для теста метода ThreePredifinedFilesProcess не найдены !");
        }
    }

    public static void ParallelReadFromFolder(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
        {
            Console.WriteLine("Путь к папке не найден!");
            return;
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var taskList = new List<Task>();
        var filesAll = Directory.GetFiles(path);
        foreach (var file in filesAll)
        {
            taskList.Add(FileTaskExecute(file));
        }

        Task.WaitAll([.. taskList]);

        stopwatch.Stop();
        Console.WriteLine($"Файлы из папки '{path}' обработаны за: {stopwatch.ElapsedMilliseconds} мс");
    }

    private static Task FileTaskExecute(string filePath)
    {     
       return Task.Run(() => FileHelper.GetSpaces(filePath));
    }
}