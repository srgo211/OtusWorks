﻿#region ДЗ
/*
 Домашнее задание
Рефлексия и её применение

Цель:
Написать свой класс-сериализатор данных любого типа в формат CSV, сравнение его быстродействия с типовыми механизмами серализации.
Полезно для изучения возможностей Reflection, а может и для применения данного класса в будущем.


Описание/Пошаговая инструкция выполнения домашнего задания:
Основное задание:

1)  Написать сериализацию свойств или полей класса в строку
2)  Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
3)  Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
4)  Вывести в консоль полученную строку и разницу времен
5)  Отправить в чат полученное время с указанием среды разработки и количества итераций
6)  Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль
7)  Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
8)  И тоже посчитать время и прислать результат сравнения
9)  Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
10) Замерить время на десериализацию
11) Общий результат прислать в чат с преподавателем в системе в таком виде:
Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}
код сериализации-десериализации: ...
количество замеров: 1000 итераций
мой рефлекшен:
Время на сериализацию = 100 мс
Время на десериализацию = 100 мс
стандартный механизм (NewtonsoftJson):
Время на сериализацию = 100 мс
Время на десериализацию = 100 мс
 */
#endregion

using Lesson13Reflection.Serializes;
using System.Diagnostics;

F testDatas = new F().Get();

ISerializationManager serializerCustom     = new CustomSerializer();
ISerializationManager serializerSystemJson = new SystemJsonSerializer();
ISerializationManager serializerSystemXml  = new SystemXmlSerializer();

Dictionary<string, ISerializationManager> dicSerializers = new Dictionary<string, ISerializationManager>()
{
    {"Custom",     serializerCustom},
    {"SystemJson", serializerSystemJson},
    {"SystemXml",  serializerSystemXml},
};

int countIterations = 100_000;

SerializationToString(countIterations);
Console.WriteLine("**************\n");
DeserializationToObject(countIterations);


void SerializationToString(int countIterations)
{
    foreach (var dic in dicSerializers)
    {
        string key = dic.Key;
        var val = dic.Value;

        Console.WriteLine($"Сериализация данных методом: {key}");
        Stopwatch sw = new Stopwatch();
        sw.Start();

        string res = default;
        for (int i = 1; i <= countIterations; i++)
        {
            res = val.SerializeToString(testDatas);
        }

        sw.Stop();
        Console.WriteLine($"Сериализация данных методом завершена {key} : {sw.Elapsed}\nРезультат: {res}\n");
    }

}

void DeserializationToObject(int countIterations)
{
    foreach (var dic in dicSerializers)
    {
        string key = dic.Key;
        var val = dic.Value;

        string data = val.SerializeToString(testDatas);


        Console.WriteLine($"Десериализация данных методом: {key}");
        Stopwatch sw = new Stopwatch();
        sw.Start();

        string res = default;
        for (int i = 1; i <= countIterations; i++)
        {
            var obj = val.DeserializeToObject<F>(data);

            if(i== countIterations) res = obj.ToString();
        }

        sw.Stop();
        Console.WriteLine($"Десериализация данных методом завершена {key} : {sw.Elapsed}\nРезультат: {res}\n");
    }

}








