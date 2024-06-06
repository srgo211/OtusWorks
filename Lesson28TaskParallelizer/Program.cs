#region ДЗ
/*
 Домашнее задание
Многопоточный проект

Цель:
Применение разных способов распараллеливания задач и оценка оптимального способа реализации.


1) Описание/Пошаговая инструкция выполнения домашнего задания:
Напишите вычисление суммы элементов массива интов:
*Обычное
*Параллельное (для реализации использовать Thread, например List)
*Параллельное с помощью LINQ
2) Замерьте время выполнения для 100 000, 1 000 000 и 10 000 000
3)Укажите в таблице результаты замеров, указав:
*Окружение (характеристики компьютера и ОС)
*Время выполнения последовательного вычисления
*Время выполнения параллельного вычисления
*Время выполнения LINQ
Пришлите в чат с преподавателем помимо ссылки на репозиторий номера своих строк в таблице.
 */

#endregion
using Lesson28TaskParallelizer;
using System.Diagnostics;
using System.Threading.Channels;

Stopwatch sw = default;




// Table header
Console.WriteLine("{0,15} | {1,20} | {2,20} | {3,20} | {4,20} | {5,20}", 
    "Размер массива", "Обычной рассчет (ms)", "Linq рассчет (ms)",
    "Parallel LINQ (ms)", "Parallel Threads (ms)", "Parallel Task (ms)");
Console.WriteLine(new string('-', 130));

int[] sizes = { 100000, 1000000, 10000000 };

List<ExecutionResults> results = new();

foreach (var size in sizes)
{
    int[] array = GenerateArray(size);   

    // Обычный рассчет
    Stopwatch stopwatch = Stopwatch.StartNew();
    long sum = SumDefault(array);
    stopwatch.Stop();
    var time = GetTime(stopwatch);

    // Linq рассчет
    stopwatch.Restart();
    long linqSum = SumWithLINQ(array);
    stopwatch.Stop();
    var linqTime = GetTime(stopwatch);

    // Параллельное с помощью LINQ
    stopwatch.Restart();
    long parallelLinqSum = ParallelSumWithLINQ(array);
    stopwatch.Stop();
    var parallelLinqTime = GetTime(stopwatch);

    // Параллельное с помощью Threads
    stopwatch.Restart();
    long parallelThreadSum = ParallelSumWithThreads(array);
    stopwatch.Stop();
    var parallelThreadTime = GetTime(stopwatch);

    // Параллельное с помощью Task
    stopwatch.Restart();
    long parallelTaskSum = ParallelSumWithTasks(array);
    stopwatch.Stop();
    var parallelTaskTime = GetTime(stopwatch);
    
    Console.WriteLine("{0,15} | {1,20:F2} | {2,20:F2} | {3,20:F2} | {4,20:F2} | {5,20:F2}", 
        size, time, linqTime, parallelLinqTime, parallelThreadTime, parallelTaskTime);


    Dictionary<string, double> dicTimes = new()
    {
        {"Обычный рассчет (foreach)", time },
        {"Linq рассчет (Sum)", linqTime },
        {"Parallel LINQ (.AsParallel().Sum)", parallelLinqTime },
        {"Parallel Threads", parallelThreadTime },
        {"Parallel Task", parallelTaskTime },
    };
    // Сортировка словаря по значению (времени)
    var sortedTimes = dicTimes.OrderBy(pair => pair.Value).Select((pair, index) =>
        new ExecutionResults { SizeArray = size, Place = index + 1,NameOperation =  pair.Key, Time = pair.Value }).ToArray();
    results.AddRange(sortedTimes); 


}


Console.WriteLine();
PrintResult(results);
PrintInfoSystem();
Console.ReadKey();

int[] GenerateArray(int max)
{
    Random rnd = new Random();
    System.Threading.Thread.Sleep(300);

    int[] arr = new int[max];
    int count = arr.Length;
    for (int i = 0; i < count; i++)
    {
        arr[i] = rnd.Next(1, 101);
    }

    return arr;
}


long SumDefault(int[] arr)
{    
    long sum = default;
    foreach (var el in arr)
    {
        sum += el;
    }  
    return sum;
}
long SumWithLINQ(int[] arr)
{   
    long sum = arr.Sum();   
    return sum;
}
long ParallelSumWithLINQ(int[] arr)
{    
    var sum = arr.AsParallel().Sum();
    return sum;
}
long ParallelSumWithThreads(int[] array)
{
    int threadCount = Environment.ProcessorCount;
    int partSize = array.Length / threadCount;
    List<Thread> threads = new List<Thread>();
    long sum = 0;
    object lockObject = new object();
    for (int i = 0; i < threadCount; i++)
    {
        int start = i * partSize;
        int end = (i == threadCount - 1) ? array.Length : start + partSize;

        Thread thread = new Thread(() =>
        {
            long localSum = 0;
            for (int j = start; j < end; j++)
            {
                localSum += array[j];
            }
            lock (lockObject)
            {
                sum += localSum;
            }
        });

        threads.Add(thread);
        thread.Start();
    }
    foreach (var thread in threads)
    {
        thread.Join();
    }
    return sum;
}
long ParallelSumWithTasks(int[] array)
{
    int processorCount = Environment.ProcessorCount;
    int partSize = array.Length / processorCount;
    Task<long>[] tasks = new Task<long>[processorCount];

    for (int i = 0; i < processorCount; i++)
    {
        int start = i * partSize;
        int end = (i == processorCount - 1) ? array.Length : start + partSize;

        tasks[i] = Task<long>.Factory.StartNew(() =>
        {
            long localSum = 0;
            for (int j = start; j < end; j++)
            {
                localSum += array[j];
            }
            return localSum;
        });
    }

    Task.WaitAll(tasks);

    long sum = 0;
    for (int i = 0; i < tasks.Length; i++)
    {
        sum += tasks[i].Result;
    }

    return sum;
}


double GetTime(Stopwatch stopwatch)
{
    double time = stopwatch.Elapsed.TotalMilliseconds;
    return time;
}

void PrintResult(List<ExecutionResults> results)
{
    // Группируем результаты по размеру массива
    var grResults = results.GroupBy(x => x.SizeArray);
       
    foreach (var group in grResults)
    {
        string formattedSize = string.Format("{0:#,0}", group.Key); 
        Console.WriteLine($"Размер массива: {formattedSize}");

        // Перебираем результаты в текущей группе
        foreach (var result in group)
        {
            string log = $"{result.Place}. {result.NameOperation}: {result.Time} ms";
            Console.WriteLine(log);
        }

        Console.WriteLine();
    }
}
void PrintInfoSystem()
{
    Console.WriteLine("\nEnvironment Details:");
    Console.WriteLine("OS: {0}", InfoSystem.GetOSVersion());
    Console.WriteLine("Processor Name: {0}", InfoSystem.GetProcessorName());
    Console.WriteLine("Processor Frequency: {0} MHz", InfoSystem.GetProcessorFrequency());
    Console.WriteLine("Processor Count: {0}", InfoSystem.GetProcessorCount());
    Console.WriteLine("Total Memory: {0} MB", InfoSystem.GetTotalMemoryInMB());
}