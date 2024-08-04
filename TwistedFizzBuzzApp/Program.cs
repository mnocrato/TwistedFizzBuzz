using Microsoft.Extensions.DependencyInjection;
using TwistedFizzBuzzLib.Interfaces;
using TwistedFizzBuzzLib.Services;

class Program
{
    static void Main()
    {
        ServiceProvider serviceProvider = InitServices();

        var twistedFizzBuzzService = serviceProvider.GetService<ITwistedFizzBuzzService>()!;

        var divisors = new List<int> { 5, 9, 27 };
        var tokens = new List<string> { "Fizz", "Buzz", "Bar" };

        var results = twistedFizzBuzzService.GenerateCustomFizzBuzzForRange(-20, 127, divisors, tokens);

        results.ForEach(Console.WriteLine);
    }

    private static ServiceProvider InitServices()
        => new ServiceCollection()
        .AddSingleton<ITwistedFizzBuzzService, TwistedFizzBuzzService>()
        .AddSingleton<IApiTokenService, ApiTokenService>()
        .AddSingleton<HttpClient>()
        .BuildServiceProvider();
}