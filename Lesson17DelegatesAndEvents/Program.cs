﻿

#region ДЗ - Делегаты и события
/*
Домашнее задание
Делегаты и события

Цель:
В этом задании требуется реализовать механизмы делегатов и событий для получения практического навыка их применения
   
Описание/Пошаговая инструкция выполнения домашнего задания:
1) Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
2) Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
3) Оформить событие и его аргументы с использованием .NET соглашений:
public event EventHandler FileFound;
FileArgs – будет содержать имя файла и наследоваться от EventArgs
4) Добавить возможность отмены дальнейшего поиска из обработчика;
5) Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.
 
 */
#endregion


using Lesson17DelegatesAndEvents;

string[] arr = new string[1];
//arr.GetMax(x => x);