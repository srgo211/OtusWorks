namespace Solid.Serviсes;

internal class GameService : IGameServiсe
{
    
    private readonly  BusinessLogic logic;
    private readonly ISettingsServiсe settingsServiсe;
    public GameService(BusinessLogic logic)=> this.logic = logic;

    public void GetSettingsGame()
    {
        settingsServiсe.GetSettingsServiсe();
    }

    public void StartGame()
    {
        Status status = Status.wait;
        while (status == Status.wait)
        {
            status = logic
                          .InputNumber()
                          .CheckNumber()
                          .NotifyResult();
        }            
    }




}
