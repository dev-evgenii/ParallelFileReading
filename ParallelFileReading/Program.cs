using ParallelFileReading;

// Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
TaskFilesRead.ThreePredifinedFilesProcess();

// Параллельное считывание файлов из папки по указанному пути и подсчёт пробелов
Console.Write("\nЗадайте путь к папке для чтения файлы: ");
var path = Console.ReadLine();

TaskFilesRead.ParallelReadFromFolder(path ?? string.Empty);