namespace Lesson17DelegatesAndEvents.Example2;

public class FileSearcher
{
    public event EventHandler<FileArgs> FileFound;

    private CancellationTokenSource _cancellationTokenSource;

    public void SearchFiles(string directoryPath)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = _cancellationTokenSource.Token;


        if (!Directory.Exists(directoryPath))
        {
            return;
        }

        string[] files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Поиск отменен.");
                return;
            }

            OnFileFound(new FileArgs(file));

            if (Directory.Exists(file))
            {
                SearchFiles(file);
            }
        }

    }

    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }

    public void CancelSearch()
    {
        _cancellationTokenSource?.Cancel();
    }
}
