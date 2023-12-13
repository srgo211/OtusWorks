var serviceProvider = RegistrateServiceCollection().BuildServiceProvider();

var game = serviceProvider.GetRequiredService<IGameServiсe>();
game.StartGame();




IServiceCollection RegistrateServiceCollection()
{
    var collection = new ServiceCollection()
        .AddSingleton<BusinessLogic>()
        .AddScoped<IGameServiсe, GameService>()
        .AddScoped<INotificationService, NotificationService>()
        .AddScoped<ISettingsServiсe, SettingsService>()
        ;

    return collection;
}