using Solid.Interfaces;

namespace Solid.Serviсes;

internal class GameService : IGameServiсe
{
    
    private readonly  BusinessLogic logic;
    private readonly INotificationService notificationService;
    public GameService(BusinessLogic logic, INotificationService notificationService)
    {
        this.logic = logic;
        this.notificationService = notificationService;
    }

    public void GetSettingsGame()
    {
        //settingsServiсe.GetSettingsServiсe();
    }

    public void StartGame()
    {
        notificationService.InfoToLog("Старт игры - \"Угадай число\"\n");
        Status status = Status.wait;
        while (status == Status.wait)
        {
            status = logic
                          .InputNumber()
                          .CheckNumber()
                          .NotifyResult();
        }

        notificationService.InfoToLog("Конец Игры - \"Угадай число\"");

    }




}
