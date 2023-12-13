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

    public BusinessLogic(ISettingsServiсe settingsService, INotificationService notificationService)
    {
        this.settingsModel = settingsService.GetSettingsServiсe();
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
        notificationService.WarringToLog($"Не верное число, попробуйте ввести другое число, осталось {count} попытки");
        return Status.wait;
    }

}
