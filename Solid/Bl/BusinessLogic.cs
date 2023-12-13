using Solid.Serviсes;

namespace Solid.Bl;

public enum Status
{ 
    ok,
    wait,
    stop,
}

internal class BusinessLogic
{
    private readonly ISettingsModel settingsModel;
    private readonly INotificationService notificationService;

    public BusinessLogic(ISettingsModel settingsModel, INotificationService notificationService)
    {
        this.settingsModel = settingsModel;
        this.notificationService = notificationService;
    }

    private int attemptsCurrent = 0;
    private int inputNumber = 0;
    private bool checkNumber;
    
   
    /// <summary>Ввод номера</summary>
    public BusinessLogic InputNumber()
    {
        notificationService.InfoToLog($"Введите номер от {settingsModel.MinNumber} до {settingsModel.MaxNumber}:");
        string text = Console.ReadLine();

        bool chek = int.TryParse(text, out int res);
        attemptsCurrent++;
        inputNumber = res;
        return this;
    }

    /// <summary>Проверка номера</summary>
    public BusinessLogic CheckNumber()
    {

        checkNumber = inputNumber == settingsModel.AproveNumber;
        return this;
    }

    /// <summary>Уведомление о результате</summary>
    public Status NotifyResult()
    {
        if (attemptsCurrent >= settingsModel.AttemptsCount)
        {
            notificationService.InfoToLog($"Вы не угадали число с {attemptsCurrent} попытки");
            return Status.stop;
        }
        if (checkNumber)
        {
            notificationService.InfoToLog($"Поздравляю, вы угадали число: {settingsModel.AproveNumber} с {attemptsCurrent} попытки");
            return Status.ok;
        }       
        return Status.wait;
    }

}
