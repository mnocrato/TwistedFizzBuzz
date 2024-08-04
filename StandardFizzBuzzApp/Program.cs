
using Microsoft.Extensions.DependencyInjection;
using TwistedFizzBuzzLib.Interfaces;
using TwistedFizzBuzzLib.Services;

class Program
{
    static void Main()
    {
        ServiceProvider serviceProvider = InitServices();

        var twistedFizzBuzzService = serviceProvider.GetService<ITwistedFizzBuzzService>()!;

        var results = twistedFizzBuzzService.GenerateFizzBuzzForRange(1, 100);

        results.ForEach(Console.WriteLine);
    }

    private static ServiceProvider InitServices()
        => new ServiceCollection()
        .AddSingleton<ITwistedFizzBuzzService, TwistedFizzBuzzService>()
        .AddSingleton<IApiTokenService, ApiTokenService>()
        .AddSingleton<HttpClient>()
        .BuildServiceProvider();
}