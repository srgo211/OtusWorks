﻿using System.Reflection;

namespace Solid.Bl;

public enum Status
{ 
    ok,
    wait,
    stop,
}

internal class BusinessLogic : BaseBusinessLogicGame
{
    private readonly ISettingsModel settingsModel;
    private readonly INotificationService notificationService;

    public BusinessLogic(ISettingsServiсe settingsService, INotificationService notificationService)
    {
        this.settingsModel = settingsService.GetSettingsServiсe();
        this.notificationService = notificationService;
    }

    private int attemptsCurrent = 0;
    private int inputNumber = 0;
    private bool checkNumber;



    public override BaseBusinessLogicGame InputNumber()
    {
        notificationService.InfoToLog($"Введите номер от {settingsModel.MinNumber} до {settingsModel.MaxNumber}:");
        string text = Console.ReadLine();

        bool chek = int.TryParse(text, out int res);
        attemptsCurrent++;
        inputNumber = res;
        return this;
    }


    public override BaseBusinessLogicGame CheckNumber()
    {

        checkNumber = inputNumber == settingsModel.AproveNumber;
        return this;
    }

    
    public override Status NotifyResult()
    {
        int attemptsCount =  settingsModel.AttemptsCount;
        if (attemptsCurrent >= attemptsCount)
        {
            notificationService.ErrorToLog($"Вы не угадали число {settingsModel.AproveNumber} с {attemptsCurrent} попытки");
            return Status.stop;
        }
        if (checkNumber)
        {
            notificationService.InfoToLog($"Поздравляю, вы угадали число: {settingsModel.AproveNumber} с {attemptsCurrent} попытки");
            return Status.ok;
        }

        int count = attemptsCount - attemptsCurrent;
        bool isBigger =  inputNumber > settingsModel.AproveNumber;
        string info = isBigger ? "Введенное число БОЛЬШЕ" : "Введенное число МЕНЬШЕ";

        notificationService.WarringToLog($"{info}, попробуйте ввести другое число, осталось {count} попытки");
        return Status.wait;
    }

}
