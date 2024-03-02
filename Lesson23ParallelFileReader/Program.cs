#region ДЗ
/*
Домашнее задание
Task: Параллельное считывание файлов
   
Цель:
Студент сделает запуск тасок в параллель, тем самым обретя базовые навыки работы с тасками, что необходимо в повседневной работе C#-программиста
   
Описание/Пошаговая инструкция выполнения домашнего задания:
1) Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
2) Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
3) Замерьте время выполнения кода (класс Stopwatch).
*/

#endregion





using Lesson23ParallelFileReader;
using System.Diagnostics;

string directoryPath = System.IO.Directory.GetCurrentDirectory();
string[] files = Directory.GetFiles(directoryPath);

//для ДЗ
long test1 = await Test1Async(files);

#region другие экспереминты
long test2 = Test2(files);
long test3 = await Test3Async(files);
long test4 = Test4(files);
#endregion


Dictionary<string, long> times = new Dictionary<string, long>()
{
    {"Тест1 - создания списка с результатом Task<int> и ожиданием их выполнения с Task.WhenAll", test1}, 
    {"Тест2 - параллейное считывание файлов с помощью AsParallel", test2},
    {"Тест3 - создание списка с Task<string>, перебор их в цикле и вывод результата на экран", test3},
    {"Тест4 - синхронное выполнение", test4}
};

log.Info($"Результат времени выполнения:", ConsoleColor.Green);
foreach (var test in times.OrderBy(t => t.Value))
{
    log.Info($"{test.Key} время выполнения {test.Value}");
}



Console.ReadLine();
async Task<long> Test1Async(string[] files)
{

    await log.InfoAsync("Тест1 - создания списка с результатом Task<int> и ожиданием их выполнения с Task.WhenAll", ConsoleColor.Green);
    Stopwatch sw = new Stopwatch();
    sw.Start();

    var tasks = new List<Task<int>>();

    foreach (var filePath in files)
    {
        tasks.Add(CountSpacesFromFileAsync(filePath));
    }

    // Ожидаем завершения всех задач
    int[] results = await Task.WhenAll(tasks);
    int allSpase = results.Sum();   

    sw.Stop();
        
    await log.InfoAsync($"Всего пробелов: {allSpase}", ConsoleColor.Blue);

    return sw.ElapsedTicks;

}
async Task<int> CountSpacesFromFileAsync(string filePath)
{
    string nameFile = Path.GetFileName(filePath);
    string content = await File.ReadAllTextAsync(filePath);
    int count = content.Count(c => c == ' ');
    await Console.Out.WriteLineAsync($"{nameFile} : {count} пробелов в файле");
    return count;
}


long Test2(string[] files)
{
    log.Info("Тест2 - параллейное считывание файлов с помощью AsParallel", ConsoleColor.Green);
    Stopwatch sw = new Stopwatch();
    sw.Start();

    files.AsParallel().ForAll(x =>
    {
        var text = File.ReadAllText(x);
        int count = text.Count(c => c == ' ');
        Console.WriteLine(count);
    });

    sw.Stop();
    return sw.ElapsedTicks;

}
async Task<long> Test3Async(string[] files)
{
    await log.InfoAsync("Тест3 - создание списка с Task<string>, перебор их в цикле и вывод результата на экран", ConsoleColor.Green);
    Stopwatch sw = new Stopwatch();
    sw.Start();
    List<Task<string>> tasks = new();
    foreach (var file in files)
    {
        var task = File.ReadAllTextAsync(file);
        tasks.Add(task);
    }


    foreach (var task in tasks)
    {
        string text = await task;
        int countSpase = text.Count(c => c == ' ');
        await log.InfoAsync($"Кол-во пробелов: {countSpase}");
    }

    sw.Stop();

    return sw.ElapsedTicks;

}

long Test4(string[] files)
{
    log.Info("Тест4 - синхронное выполнение", ConsoleColor.Green);
    Stopwatch sw = new Stopwatch();
    sw.Start();
  
    foreach (var file in files)
    {
        var text = File.ReadAllText(file);
        int countSpase = text.Count(c => c == ' ');
        log.Info($"Кол-во пробелов: {countSpase}");
    }
    sw.Stop();
    return sw.ElapsedTicks;

}