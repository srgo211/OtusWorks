using Lesson17DelegatesAndEvents.Models;

namespace Lesson17DelegatesAndEvents.Example1;

public class Example : ExampleBase
{
    public override void Run()
    {
        Console.WriteLine("Пример обобщённой функции расширения, находящую и возвращающую максимальный элемент коллекции");
        var datas = TestData.GetTestDatas();

        foreach (var data in datas) Console.WriteLine(data);

        var res = datas.GetMax(s => s.Weight);
        Console.WriteLine("***********");
        Console.WriteLine($"Максимальный вес:\n{res}");
        Console.WriteLine("Пример завершен!\n\n");
    }
}
