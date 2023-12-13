var serviceProvider = RegistrateServiceCollection().BuildServiceProvider();

var game = serviceProvider.GetRequiredService<IGameServiсe>();
game.StartGame();




IServiceCollection RegistrateServiceCollection()
{
    var collection = new ServiceCollection()
        .AddSingleton<BusinessLogic>()
        .AddScoped<IGameServiсe, GameService>()
        .AddScoped<INotificationService, NotificationService>()
        .AddScoped<ISettingsServiсe, SettingsServiceFromFile>() //взятие настроек из файла
        //.AddScoped<ISettingsServiсe, SettingsServiceRandom>() //взятие настроек рандомно
        ;

    return collection;
}