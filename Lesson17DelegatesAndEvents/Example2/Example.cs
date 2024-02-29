namespace Lesson17DelegatesAndEvents.Example2;

public class Example : ExampleBase
{
    private readonly string directoryPath;

    int stopSearh = 3;
    public Example(string directoryPath)
    {
        this.directoryPath = directoryPath;     
    }
    public override void Run()
    {
        Console.WriteLine("Пример обходящий каталог файлов и выдающий событие при нахождении каждого файла");

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        FileSearcher searcher = new FileSearcher();
        searcher.FileFound += FileSearcher_FileFound;
        searcher.SearchFiles(directoryPath);

        Console.WriteLine("Пример завершен!\n\n");
    }

    void FileSearcher_FileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"Найден файл: {e.FileName}");

        var fileSearcher = sender as FileSearcher;
        if (fileSearcher is null) return;

        if (--stopSearh <= 0)
        {
           fileSearcher.CancelSearch();
        }
    }
}
