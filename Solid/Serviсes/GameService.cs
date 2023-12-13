namespace Solid.Serviсesж
{
    internal class GameService : IGameServiсe
    {
        private readonly ISettingsServise settingsServise;
        private readonly INotificationService notificationService;
        private readonly INumberGeneratorServiсe numberGeneratorServiсe;
        private readonly ISettingsModel settingsModel;
        BusinessLogic logic;
        public GameService(ISettingsServise settingsServise, INotificationService notificationService, INumberGeneratorServiсe numberGeneratorServiсe)
        {

            this.settingsServise        = settingsServise;
            this.notificationService    = notificationService;
            this.numberGeneratorServiсe = numberGeneratorServiсe;

        }


        public void GetSettingsGame()
        {
            
        }

        public void StartGame()
        {
            Status status = Status.wait;
            while (status == Status.ok || status == Status.stop)
            {
                status = logic
                              .InputNumber()
                              .CheckNumber()
                              .NotifyResult();
            }            
        }




    }
}
