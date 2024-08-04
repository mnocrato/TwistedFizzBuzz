using TwistedFizzBuzzLib;
using Microsoft.Extensions.DependencyInjection;
using TwistedFizzBuzzLib.Interfaces;
using TwistedFizzBuzzLib.Services;
using Moq;

namespace TwistedFizzBuzzTests
{
    public class TwistedFizzBuzzTests
    {
        private TwistedFizzBuzz _twistedFizzBuzz;
        private ServiceProvider _serviceProvider;
        private Mock<IApiTokenService> _apiTokenServiceMock;

        [SetUp]
        public void Setup()
        {
            _apiTokenServiceMock = new Mock<IApiTokenService>();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ITwistedFizzBuzzService, TwistedFizzBuzzService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            _twistedFizzBuzz = new TwistedFizzBuzz(_serviceProvider.GetService<ITwistedFizzBuzzService>()!, _apiTokenServiceMock.Object);
        }

        [TearDown]
        public void TearDown() => _serviceProvider.Dispose();

        [Test]
        public void TestGenerateFizzBuzzForRange()
        {
            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz" };

            var result = _twistedFizzBuzz.GenerateFizzBuzzForRange(1, 5);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestGenerateFizzBuzzForNonSequentialNumbers()
        {
            var inputNumbers = new List<int> { -5, 6, 300, 12, 15 };
            var expected = new List<string> { "Buzz", "Fizz", "FizzBuzz", "Fizz", "FizzBuzz" };

            var result = _twistedFizzBuzz.GenerateFizzBuzzForList(inputNumbers);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestGenerateCustomFizzBuzzForRange()
        {
            var divisors = new List<int> { 7, 15, 3 };
            var tokens = new List<string> { "Poem", "Writer", "College" };
            var expected = new List<string> { "1", "2", "College", "4", "5", "College", "Poem", "8", "College", "10", "11", "College", "13", "Poem", "WriterCollege" };

            var result = _twistedFizzBuzz.GenerateCustomFizzBuzzForRange(1, 15, divisors, tokens);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task TestGenerateFizzBuzzWithApiTokens()
        {

            var apiTokens = new
            {
                Divisors = new List<int> { 3, 5 },
                Tokens = new List<string> { "Fizz", "Buzz" }
            };

            _apiTokenServiceMock.Setup(s => s.FetchApiTokens(It.IsAny<string>())).ReturnsAsync((apiTokens.Divisors, apiTokens.Tokens));

            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };

            var result = await _twistedFizzBuzz.GenerateFizzBuzzWithApiTokens(1, 15, "https://fake-url.com");
            Assert.AreEqual(expected, result);
        }
    }
}
