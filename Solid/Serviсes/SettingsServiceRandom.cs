using System;

namespace Solid.Serviсes;

#region Описание ДЗ
/*
Домашнее задание
Демонстрация SOLID принципов
Цель:
Практическое применение SOLID принципов.

Описание/Пошаговая инструкция выполнения домашнего задания:
На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
Программа рандомно генерирует число, пользователь должен угадать это число.При каждом вводе числа программа пишет больше или меньше отгадываемого. Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
В отчёте написать, что именно сделано по каждому принципу.
Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.

Критерии оценки:
2 балла: Принцип единственной ответственности;
1 балла: Принцип инверсии зависимостей;
2 балла: Принцип разделения интерфейса;
2 балла: Принцип открытости/закрытости;
2 балла: Принцип подстановки Барбары Лисков;
1 балл: CodeStyle, грамотная архитектура, всё замечания проверяющего исправлены.
Минимально необходимый балл: 6.
*/
#endregion


internal class SettingsServiceRandom : ISettingsServiсe
{
    public ISettingsModel GetSettingsServiсe()
    {
        const int minNum = 1;
        Random rnd = new Random();
        int attemptsCount = rnd.Next(minNum, 6); 
        int maxNumber     = rnd.Next(minNum+1, 11);
        var settings      = new SettingsModel(attemptsCount, minNum, maxNumber);

        settings.AproveNumber = NumberGeneratorService.GenerateRandomNumber(minNum, maxNumber);

        return settings;
    }
}
