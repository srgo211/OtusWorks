namespace Lesson17DelegatesAndEvents.Example2;

public class FileArgs : EventArgs
{
    public string FileName { get; set; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}
