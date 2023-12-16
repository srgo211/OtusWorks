﻿
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

#region Решение ДЗ
/*
1) Принцип единственной ответственности:
Класс должен быть ответственен только за один аспект функциональности

В моем примере, например класс GameService - отвечает только за игровое поведение.
класс NotificationService - отвечает только за уведомления.

2) Принцип открытости/закрытости;
Все программные сущности в коде (классы, функции и т. д.) открыты для расширения, но закрыты для модификации.

3)Принцип подстановки Барбары Лисков
Объект базового класса должен быть заменен объектом его производного класса без изменения корректности программы.
Производный класс должен дополнять, а не изменять поведение базового класса.

У меня есть базовый класс "BaseBusinessLogicGame" и производный от него "BusinessLogic"
при вызове дочернего класса "BusinessLogic" логика программы не нарушается.

4) Принцип разделения интерфейса;
Не следует заставлять клиентов зависеть от интерфейсов, которые они не используют.
Множество маленьких, специфичных интерфейсов лучше, чем один общий.

В коде каждый интерфейс отвечает за свою задачу, лишние методы туда не запиханы. Каждый интерфейс полностью реализован.

5) Принцип инверсии зависимостей;
Модули верхнего уровня не должны зависеть от модулей нижнего уровня. Оба типа модулей должны зависеть от абстракций.
Абстракции не должны зависеть от деталей. Детали должны зависеть от абстракций.

В коде данный подход так же реализован. Все данные зависят от абсиракций. 
*/
#endregion

var serviceProvider = RegistrateServiceCollection().BuildServiceProvider();

var game = serviceProvider.GetRequiredService<IGameServiсe>();
game.StartGame();

IServiceCollection RegistrateServiceCollection()
{
    var collection = new ServiceCollection()
        .AddSingleton<BaseBusinessLogicGame, BusinessLogic>()
        .AddScoped<IGameServiсe, GameService>()
        .AddScoped<INotificationService, NotificationService>()
        .AddScoped<ISettingsServiсe, SettingsServiceFromFile>() //взятие настроек из файла
        //.AddScoped<ISettingsServiсe, SettingsServiceRandom>() //взятие настроек рандомно
        ;

    return collection;
}