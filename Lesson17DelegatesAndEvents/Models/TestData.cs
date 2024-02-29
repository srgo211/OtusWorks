using System;

namespace Lesson17DelegatesAndEvents.Models;

public class TestData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Weight { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}; Name: {Name}; Weight:{Weight}";
    }

    public static ICollection<TestData> GetTestDatas()
    {
        List<TestData> datas = new List<TestData>();

        Random rnd = new Random();

        int maxCount = rnd.Next(5,11);
        
        for (int i = 1; i <= maxCount; i++)
        { 
            TestData data = new TestData()
            { 
                Id = i,
                Name = $"Имя - {i}",
                Weight = (float)(rnd.NextDouble() * (100 - 50) + 50)
            };

            datas.Add(data);

        }

        return datas;

    }
}
